using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiInterviewDevTest.Models;
using System.Web.Http.Cors;
using NUnit.Framework;

namespace ApiInterviewDevTest.Controllers
{
    [EnableCors(origins: "http://localhost:10482", headers: "*", methods: "*")]
    public class BoardGameController : ApiController
    {
        private Repo.Repository repository;

        public BoardGameController()
        {
            repository = new Repo.Repository();
        }

        public BoardGame getBoardGame(int id)
        {
            return repository.getBoardGame(id);
        }

        public IEnumerable<BoardGame> getAllBoardGames()
        {
            return repository.getAllBoardGames();
        }

        [HttpPost]
        public bool addBoardGame(BoardGame boardGame)
        {
            repository.add(boardGame);
            repository.saveChanges();
            return true;
        }

        [HttpPost]
        public bool editBoardGame(BoardGame boardGame)
        {
            var answer = getBoardGame(boardGame.Id);
            if(answer != null)
            {
                answer.NameGame = boardGame.NameGame;
                answer.Brand = boardGame.Brand;
                answer.FromAge = boardGame.FromAge;
                answer.ImageAddress = boardGame.ImageAddress;
            }
            repository.saveChanges();
            return true;
        }

        [HttpPost]
        public bool removeBoardGame(int Id)
        {
            var answer = repository.remove(Id);
            repository.saveChanges();
            return answer;
        }

        [HttpPost]
        public bool saveChanges()
        {
            return repository.saveChanges();
        }
    }
}
