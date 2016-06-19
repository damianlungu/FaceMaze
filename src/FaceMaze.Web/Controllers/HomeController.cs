using System.Linq;
using System.Threading.Tasks;
using FaceMaze.Web.Data;
using FaceMaze.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FaceMaze.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
       public HomeController(ApplicationDbContext dbContext)
       {
           _dbContext = dbContext;
       }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> GetHighScoreAsync(User user)
        {
            var score = await user.GetScoreAsync();
            return ViewComponent("UserHighScore", score);
        }

        public ViewComponentResult GetHighScore(User user)
        {
            var score = user.GetScore();
            return ViewComponent("UserHighScore", score);
        }

        public ViewComponentResult GetHighScores(User user)
        {
            var score = _dbContext.Scores.OrderBy(x => x.Score).ToList();
            return ViewComponent("HighScores", score);
        }
    }
}
