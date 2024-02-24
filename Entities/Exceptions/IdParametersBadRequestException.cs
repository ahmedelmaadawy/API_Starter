﻿namespace Entities.Exceptions
{
    public sealed class IdParametersBadRequestException : BadRequestException
    {
        public IdParametersBadRequestException() : base("parameter ids is null")
        {

        }
    }
}
