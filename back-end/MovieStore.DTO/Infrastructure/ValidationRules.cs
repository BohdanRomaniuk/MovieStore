using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.DTO.Infrastructure
{
    class ValidationRules
    {
        public const int USERNAME_MAX_LENGTH = 20;
        public const string ONLY_LETTERS_AND_NUMBERS = @"^[a-zA-z0-9]*$";
    }
}
