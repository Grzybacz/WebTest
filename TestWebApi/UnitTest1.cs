using Xunit;

using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebTestApplication.Controllers;
using WebTestApplication.Repository;
using WebTestApplication.Repository.IRepository;

namespace TestWebApi
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(2, 2);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(2, 3);
        }
    }
}