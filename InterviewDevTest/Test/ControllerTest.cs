using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewDevTest.Models;
using InterviewDevTest.Controllers;
using NUnit.Framework;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace InterviewDevTest.Test
{
    [TestFixture]
    public class ControllerTest
    {
        [Test]
        public async Task testGetBoardGame()
        {
            BoardGameController objTest = new BoardGameController();
            var actResult = await objTest.Details(0) as ViewResult;
            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task testEdit()
        {
            BoardGameController objTest = new BoardGameController();
            var actResult = await objTest.Edit(0) as ViewResult;
            Assert.That(actResult.ViewName, Is.EqualTo("Edit"));
        }
    }
}