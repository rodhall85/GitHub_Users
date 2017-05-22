using GitHub_Users.Models;

namespace GitHub_Users.Logic.GitHubAPI
{
    public interface IGitHubApi
    {
		/// <summary>
		/// Gets the user details from the GitHubApi
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		SearchResults GetUserDetails(string username);
    }
}
