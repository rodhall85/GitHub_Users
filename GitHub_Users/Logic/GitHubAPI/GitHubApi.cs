using System.Net;
using GitHub_Users.Logic.Config;
using GitHub_Users.Models;

namespace GitHub_Users.Logic.GitHubAPI
{
    public class GitHubApi : IGitHubApi
    {
        private IJsonConvertor JsonConvertor;
        private IConfigRepository ConfigRepository;
        
        public GitHubApi(IJsonConvertor jsonConvetor, IConfigRepository configRepository)
        {
            JsonConvertor = jsonConvetor;
            ConfigRepository = configRepository;
        }

        public SearchResults GetUserDetails(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            var url = ConfigRepository.GetConfig<string>("GitHubApiUsersUrl");
            var json = CallGitHubWebApi($"{url}{username.ToLowerInvariant()}");
            
            return JsonConvertor.ConvertToModel<SearchResults>(json);
        }

        private string CallGitHubWebApi(string url)
        {
            var json = string.Empty;

            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                json = webClient.DownloadString(url);
            }

            return json;
        }
    }
}