using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _confuguration;
        private User? _user;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager,
            IConfiguration confuguration
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _confuguration = confuguration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCreadentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _confuguration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    signingCredentials: signingCredentials
                );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
          {
              new Claim(ClaimTypes.Name,_user.UserName)
          };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private SigningCredentials GetSigningCreadentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthentication)
        {
            _user = await _userManager.FindByNameAsync(userForAuthentication.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
                userForAuthentication.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}:Authentication failed. wrong user name or password ");
            return result;

        }

        async Task<IdentityResult> IAuthenticationService.RegisterUser(UserForRegistrationDto userForRegisteration)
        {
            var user = _mapper.Map<User>(userForRegisteration);
            var result = await _userManager.CreateAsync(user, userForRegisteration.Password);
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, userForRegisteration.Roles);
            return result;
        }
    }
}
