using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MR.AspNet.Identity.EntityFramework6;
using NuGet.Packaging;

namespace FaceMaze.Web.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }
        public string GoogleId { get; set; }
        public virtual ICollection<User> Friends { get; set; } = new HashSet<User>();
        public virtual ICollection<UserScore> Scores { get; set; } = new HashSet<UserScore>();

        public void UpdateFriendship(ICollection<User> friends, string socialNetwork)
        {
            switch (socialNetwork)
            {
                case "Facebook":
                    var userFriends = Friends.ToList();
                    foreach (var userFriend in userFriends)
                        if (!friends.Contains(userFriend))
                            Friends.Remove(userFriend);
                    userFriends = Friends.ToList();
                    var newFriends = friends.Except(userFriends);
                    Friends.AddRange(newFriends);
                    break;
            }
        }
        public IEnumerable<UserScore> GetScore() => Scores.ToList();
        public async Task<IEnumerable<UserScore>> GetScoreAsync() => await Task.Run(() => GetScore());
    }
}