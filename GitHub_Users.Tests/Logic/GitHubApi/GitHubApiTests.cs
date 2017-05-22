using System.Web;
using GitHub_Users.Logic;
using GitHub_Users.Logic.Config;
using GitHub_Users.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GitHub_Users.Tests.Logic.GitHubApi
{
	[TestClass]
	public class GitHubApiTests
	{

		private GitHub_Users.Logic.GitHubAPI.GitHubApi sut;

		[TestInitialize]
		public void Init()
		{
			//setup mock for the interface
			sut = new GitHub_Users.Logic.GitHubAPI.GitHubApi(
				new JsonConvertor(), 
				new ConfigRepository());
			
		}

		[TestMethod]
		public void GetUserDetails_ValidUserDetails_CallsJsonConvertor()
		{
			////arrange
			//var username = "Barry";
			//var mockJsonConvertor = new Mock<IJsonConvertor>();
			//mockJsonConvertor.Verify(m => m.ConvertToModel(It.IsAny<string>()));

			////act
			//sut.GetUserDetails(username);

			////assert
			//Assert.
		}
	}
}
