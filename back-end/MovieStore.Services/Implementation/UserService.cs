using AutoMapper;
using MovieStore.DataAccess;
using MovieStore.DataTransfer.Objects;
using System.Collections.Generic;
using System.Linq;

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

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

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

            return BCrypt.Net.BCrypt.Verify(user.Password, dbUser.HashedPassword);
        }

        private IMapper GetUserToUserIdentityDTOMapper()
        {
            return new MapperConfiguration(cfg => cfg.CreateMap<User, UserIdentityDTO>())
                .CreateMapper();
        }
    }
}
