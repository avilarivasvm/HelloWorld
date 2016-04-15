using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InterviewDevTest.Repository
{
    interface IRepository<T> where T: class 
    {
        Task<T> getBoardGame(int id);

        Task<IEnumerable<T>> getAllBoardGames();

        bool add(T entity);

        bool remove(int i);

        bool saveChanges();
    }
}
