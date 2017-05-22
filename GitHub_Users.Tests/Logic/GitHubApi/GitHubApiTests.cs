using System;
using System.Web;
using GitHub_Users.Logic;
using GitHub_Users.Logic.Config;
using GitHub_Users.Logic.GitHubAPI;
using GitHub_Users.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GitHub_Users.Tests.Logic.GitHubApi
{
	[TestClass]
	public class GitHubApiTests
	{
        private GitHub_Users.Logic.GitHubAPI.GitHubApi sut;
        private Mock<IJsonConvertor> jsonConvertorMock;
        private Mock<IConfigRepository> configRepositoryMock;
        private Mock<ICallGitHubApi> callGitHubApiMock;

		[TestInitialize]
		public void Init()
		{
            jsonConvertorMock = new Mock<IJsonConvertor>();
            configRepositoryMock = new Mock<IConfigRepository>();
            callGitHubApiMock = new Mock<ICallGitHubApi>();

            sut = new GitHub_Users.Logic.GitHubAPI.GitHubApi(
                jsonConvertorMock.Object,
                configRepositoryMock.Object,
                callGitHubApiMock.Object);

            jsonConvertorMock.Setup(m => m.ConvertToModel<SearchResults>(It.IsAny<string>())).Returns(new SearchResults()
            {
                Login = "Barry"
            });
            configRepositoryMock.Setup(m => m.GetConfig<string>(It.IsAny<string>())).Returns("url");
            callGitHubApiMock.Setup(m => m.FetchJson(It.IsAny<string>())).Returns("json");
		}
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetUserDetails_NoUsername_ReturnsNull()
        {
            //act & assert
            var result = sut.GetUserDetails(null);
        }

        [TestMethod]
        public void GetUserDetails_ReturnsSearchResults()
        {
            //arrange
            var username = "Barry";
            
            //act
            var result = sut.GetUserDetails(username);

            //assert
            Assert.IsInstanceOfType(result, typeof(SearchResults));
        }

		[TestMethod]
		public void GetUserDetails_ValidUserDetails_CallsJsonConvertor()
		{
            //arrange
            var username = "Barry";
            
            //act
            sut.GetUserDetails(username);

            //assert
            jsonConvertorMock.Verify(m => m.ConvertToModel<SearchResults>(It.IsAny<string>()));
        }
    }
}
