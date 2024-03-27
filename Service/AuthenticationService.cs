using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _confuguration;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, UserManager<User> userManager,
            IConfiguration confuguration
            )
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _confuguration = confuguration;
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
