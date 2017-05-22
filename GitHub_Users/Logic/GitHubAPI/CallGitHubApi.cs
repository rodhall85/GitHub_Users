using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace GitHub_Users.Logic.GitHubAPI
{
    public class CallGitHubApi : ICallGitHubApi
    {
        public string FetchJson(string url)
        {
            var json = string.Empty;

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    json = webClient.DownloadString(url);
                }
                catch (WebException)
                {

                    throw;
                }
            }

            return json;
        }
    }
}