using System.Collections.Generic;

namespace GitHub_Users.Models
{
    public class SearchResults
    {
        public string Login { get; set; }
        
        public string Location { get; set; }

        public string Avatar_Url { get; set; }

        public IList<string> StarredRepos { get; set; }
    }
}