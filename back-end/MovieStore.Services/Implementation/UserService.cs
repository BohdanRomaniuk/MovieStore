using AutoMapper;
using MovieStore.DataAccess;
using MovieStore.DataTransfer.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MovieStore.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public UserIdentityDTO CreateUser(UserRegistrationDTO user)
        {
            if (Repository.Get(u => u.UserName == user.UserName).Any())
            {
                return null;
            }

            string passwordHash = CalculateMD5Hash(user.Password);

            Repository.Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = "user",
                UserName = user.UserName,
                HashedPassword = passwordHash
            });

            _unitOfWork.SaveChanges();

            User savedUser = Repository.Get(u => u.UserName == user.UserName).FirstOrDefault();
            if (savedUser == null)
            {
                return null;
            }

            UserIdentityDTO identityDTO = new UserIdentityDTO();
            GetUserToUserIdentityDTOMapper().Map(savedUser, identityDTO);
            return identityDTO;
        }

        public override IEnumerable<User> Get()
        {
            return Repository.Get()
                .ToList();
        }

        public override User Get(int id)
        {
            return Repository.Get(m => m.Id == id)
                .FirstOrDefault();
        }

        public UserIdentityDTO GetUserIdentity(string username)
        {
            User user = Repository.Get(u => u.UserName == username)
                .FirstOrDefault();
            if (user == null)
            {
                return null;
            }

            UserIdentityDTO identityDTO = new UserIdentityDTO();
            GetUserToUserIdentityDTOMapper().Map(user, identityDTO);
            return identityDTO;
        }

        public override void Remove(int id)
        {
            Repository.Remove(Get(id));
        }

        public bool ValidateUserPassword(UserLoginDTO user)
        {
            User dbUser = Repository.Get(u => u.UserName == user.Username).FirstOrDefault();
            if (dbUser == null)
            {
                return false;
            }

            return CalculateMD5Hash(user.Password).Equals(dbUser.HashedPassword, StringComparison.InvariantCultureIgnoreCase);
        }

        private IMapper GetUserToUserIdentityDTOMapper()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<User, UserIdentityDTO>())
                .CreateMapper();
        }

        private string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
