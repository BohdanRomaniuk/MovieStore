using MovieStore.DataAccess;

namespace MovieStore.Services.DataTransfer.Objects
{
    public class CommentDTO : Comment
    {
        public string UserName => User!=null ? $"{User.FirstName} {User.LastName}" : "";
    }
}
