using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiInterviewDevTest.Models
{
    public class BoardGame
    {
        public int Id { get; set; }
        public string NameGame { get; set; }
        public string Brand { get; set; }
        public int FromAge { get; set; }
        public string ImageAddress { get; set; }
    }
}