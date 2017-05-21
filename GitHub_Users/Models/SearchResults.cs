using System.Collections.Generic;

namespace GitHub_Users.Models
{
    public class SearchResults
    {
        public string Username { get; set; }
        
        public string Location { get; set; }

        public string Avatar { get; set; }

        public IList<string> Repos { get; set; }
    }
}