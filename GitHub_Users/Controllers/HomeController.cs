using System.Web.Mvc;
using GitHub_Users.Logic.GitHubAPI;

namespace GitHub_Users.Controllers
{
    public class HomeController : Controller
    {
        private IGitHubApi gitHubApi;
        
        public HomeController(IGitHubApi gitHubApi)
        {
            this.gitHubApi = gitHubApi;
        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Searches username returning SearchResults Model to the view
        /// </summary>
        /// <returns></returns>
        public ActionResult SearchUsername(string username)
        {
            this.gitHubApi.GetUserDetails(username);
            return View();
        }

        public ActionResult SearchResults()
        {
            ViewBag.Message = "Search Results JSON";

            return View();
        }
    }
}