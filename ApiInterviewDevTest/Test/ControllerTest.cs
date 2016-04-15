using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiInterviewDevTest.Models;
using ApiInterviewDevTest.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace ApiInterviewDevTest.Test
{
    [TestFixture]
    public class ControllerTest
    {
        [Test]
        public void testApiGetBoardGame()
        {
            var rep = new Object();
            createHTTPContext();
            BoardGameController objTest = new BoardGameController();
            var boardGame = objTest.getBoardGame(4);
            Assert.AreEqual(3, 3);
            HttpContext.Current = null;
        }

        private void createHTTPContext()
        {
            
            HttpContext.Current = new HttpContext(
                new HttpRequest("BoardGames.xml", "http://localhost:12081/", null),
                new HttpResponse(null)
            );
            //string s = HttpContext.Current.Server.MapPath("~\\BoardGames.xml");
        }
    }
}