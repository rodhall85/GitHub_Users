using System.Collections.Generic;
using GitHub_Users.Entities;

namespace GitHub_Users.Models
{
    public class SearchResults
    {
        public string Login { get; set; }
        
        public string Location { get; set; }

        public string Avatar_Url { get; set; }

        public string Repos_Url { get; set; }

        public IEnumerable<Repo> StarredRepos { get; set; }
    }
}