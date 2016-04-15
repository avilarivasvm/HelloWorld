using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterviewDevTest.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InterviewDevTest.Repository
{
    public class Repository : IRepository<BoardGame>
    {
        private HttpClient client;
        private const string url = "http://localhost:12081/api/boardGame/";

        public Repository()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }

        public async Task<BoardGame> getBoardGame(int id)
        {
            string controllerAction = "getBoardGame/" + id.ToString();
            client.BaseAddress = new Uri(url + controllerAction);
            HttpResponseMessage responseMessage = await client.GetAsync(url + controllerAction);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var boardGame = JsonConvert.DeserializeObject<BoardGame>(responseData);

                return boardGame;
            }
            return new BoardGame();
        }

        public async Task<IEnumerable<BoardGame>> getAllBoardGames()
        {
            string controllerAction = "getAllBoardGames";
            client.BaseAddress = new Uri(url + controllerAction);
            HttpResponseMessage responseMessage = await client.GetAsync(url + controllerAction);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var boardGame = JsonConvert.DeserializeObject<List<BoardGame>>(responseData);

                return boardGame;
            }
            return new List<BoardGame>() ;
        }

        public bool add(BoardGame entity)
        {
            return true;
        }

        public bool remove(int i)
        {
            return true;
        }

        public bool saveChanges()
        {
            return true;
        }
    }
}