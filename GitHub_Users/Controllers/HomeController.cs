using System.Web.Mvc;
using GitHub_Users.Logic.GitHubAPI;
using GitHub_Users.Models;

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
        [HandleError()]
        public ActionResult SearchUsername(UserSearch userSearch)
        {
			return RedirectToAction("SearchResults", userSearch);
		}

        [HandleError()]
        public ActionResult SearchResults(UserSearch userSearch)
        {
			var searchResult =  this.gitHubApi.GetUserDetails(userSearch.Username);

			return View(searchResult);
        }
    }
}