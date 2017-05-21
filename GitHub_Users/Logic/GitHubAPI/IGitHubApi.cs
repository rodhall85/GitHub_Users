using GitHub_Users.Models;

namespace GitHub_Users.Logic.GitHubAPI
{
    public interface IGitHubApi
    {
        SearchResults GetUserDetails(string username);
    }
}
