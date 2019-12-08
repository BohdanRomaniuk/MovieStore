using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore.DataTransfer.Objects
{
    public class UserIdentityDTO
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
