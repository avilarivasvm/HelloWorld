using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiInterviewDevTest.Models;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Web.Http;
using System.Runtime.Serialization;
using System.Net.Http;
using System.Web.Mvc;

namespace ApiInterviewDevTest.Repo
{
    public class Repository : IRepository<BoardGame>
    {
        private readonly List<BoardGame> lsBoardGames;
        private string filePath = HttpContext.Current.Server.MapPath("~\\DATA\\BoardGames.xml");

        public Repository()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BoardGame>), new XmlRootAttribute("BoardGames"));
            if (File.Exists(filePath ))
            {
                using (StreamReader myWriter = new StreamReader(filePath))
                {
                    lsBoardGames = (List<BoardGame>)serializer.Deserialize(myWriter);
                    myWriter.Close();
                }
            }
            else
            {
                lsBoardGames = new List<BoardGame>();
            }
        }

        public BoardGame getBoardGame(int id)
        {
            return lsBoardGames.Find(zx => zx.Id.Equals(id));
        }

        public IEnumerable<BoardGame> getAllBoardGames()
        {
            return lsBoardGames.ToList();
        }

        public bool add(BoardGame boardGame)
        {
            lsBoardGames.Add(boardGame);
            return true;
        }

        public bool remove(int id)
        {
            var tempBoard = lsBoardGames.Find(m => m.Id.Equals(id));
            lsBoardGames.Remove(tempBoard);
            return true;
        }

        public bool saveChanges()
        {
            XmlSerializer serializer = new XmlSerializer(lsBoardGames.GetType() , new XmlRootAttribute("BoardGames"));
            using (StreamWriter myWriter = new StreamWriter(filePath))
            {
                serializer.Serialize(myWriter, lsBoardGames);
                myWriter.Close();
            }
            return true;
        }
    }
}