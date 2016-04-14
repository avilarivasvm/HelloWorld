using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiInterviewDevTest.Models;

namespace ApiInterviewDevTest.Controllers
{
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
