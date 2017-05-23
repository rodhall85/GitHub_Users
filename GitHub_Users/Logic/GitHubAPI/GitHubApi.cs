using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using GitHub_Users.Entities;
using GitHub_Users.Logic.Config;
using GitHub_Users.Models;

namespace GitHub_Users.Logic.GitHubAPI
{
    public class GitHubApi : IGitHubApi
    {
        private readonly IJsonConvertor jsonConvertor;
        private readonly IConfigRepository configRepository;
        private readonly ICallGitHubApi callGitHubApi;

        public GitHubApi(
            IJsonConvertor jsonConvetor, 
            IConfigRepository configRepository, 
            ICallGitHubApi callGitHubApi)
        {
            this.jsonConvertor = jsonConvetor;
            this.configRepository = configRepository;
            this.callGitHubApi = callGitHubApi;
        }

		/// <summary>
		/// Gets the user details from the GitHubApi
		/// </summary>
		/// <param name="username">The username.</param>
		/// <returns></returns>
		public SearchResults GetUserDetails(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("username has not been provided");
            }

            var url = this.configRepository.GetConfig<string>("GitHubApiUsersUrl");
            var json = this.callGitHubApi.FetchJson($"{url}{username.ToLowerInvariant()}");
            
			var searchResults = this.jsonConvertor.ConvertToModel<SearchResults>(json);

            var usersReposJson = this.callGitHubApi.FetchJson($"{searchResults.Repos_Url}");
            searchResults.StarredRepos = this.jsonConvertor.ConvertToModel<List<Repo>>(usersReposJson)
                                                            .OrderByDescending(x => x.Stargazers_Count)
                                                            .Take(5);

            return searchResults;
        }
    }
}