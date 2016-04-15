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
        private List<BoardGame> lsBoardGames;
        //string imagesDirectory = HttpRuntime.AppDomainAppPath;
        private string filePath = HttpContext.Current.Server.MapPath("~\\DATA\\BoardGames.xml");


        public Repository()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BoardGame>), new XmlRootAttribute("BoardGames"));
            if (File.Exists(filePath))
            {
                using (StreamReader sr= new StreamReader(filePath ))
                {
                    lsBoardGames = (List<BoardGame>)serializer.Deserialize(sr);
                    sr.Close();
                }
            }
            else
            {
                DirectoryInfo di = Directory.CreateDirectory(filePath);
                di = null;
                lsBoardGames = new List<BoardGame>();
                saveChanges();
            }
        }

        public BoardGame getBoardGame(int id)
        {
            return lsBoardGames.Find(zx => zx.Id.Equals(id));
        }

        public IEnumerable<BoardGame> getAllBoardGames()
        {
            lsBoardGames = (List<BoardGame>)lsBoardGames.OrderBy(bg => bg.NameGame).ToList();
            return lsBoardGames;
        }

        public bool add(BoardGame boardGame)
        {
            if (lsBoardGames.Count > 0)
            {
                lsBoardGames = (List<BoardGame>)lsBoardGames.OrderByDescending(bg => bg.Id).ToList();
                BoardGame tempBoardGame = lsBoardGames[0];
                boardGame.Id = tempBoardGame.Id + 1;
            }
            else
            {
                boardGame.Id = 1;
            }
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