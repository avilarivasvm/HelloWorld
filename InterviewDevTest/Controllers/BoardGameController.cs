using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using InterviewDevTest.Models;
using InterviewDevTest.Repository;
using System.Net;

namespace InterviewDevTest.Controllers
{
    public class BoardGameController : Controller
    {
        Repository.Repository repository;

        public BoardGameController()
        {
            repository = new Repository.Repository();
        }

        // GET: BoardGame
        public async Task<ActionResult> Index()
        {
            IEnumerable<BoardGame> boardGames = await repository.getAllBoardGames();
            if(boardGames.Count() > 0)
            {
                return View(boardGames);
            }
            return View("Error");
        }

        // GET: BoardGame/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if(id == 0)
            {
                return View("Index");
            }
            BoardGame boardGame = await repository.getBoardGame(id);
            if (boardGame.Id > 0)
            {
                return View(boardGame);
            }
            return View("Error");
        }

        // GET: BoardGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoardGame/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BoardGame/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if(id == 0)
            {
                return View("Edit");
            }
            BoardGame boardGame = await repository.getBoardGame(id);
            if (boardGame.Id > 0)
            {
                return View(boardGame);
            }
            return View("Error");
        }

        // POST: BoardGame/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BoardGame/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            BoardGame boardGame = await repository.getBoardGame(id);
            if (boardGame.Id > 0)
            {
                return View(boardGame);
            }
            return View("Error");
        }

        // POST: BoardGame/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
