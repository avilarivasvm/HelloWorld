using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiInterviewDevTest.Models;

namespace ApiInterviewDevTest.Repo
{
    interface IRepository<T> where T: class
    {
        T getBoardGame(int i);

        IEnumerable<T> getAllBoardGames();

        bool add(T entity);

        bool remove(int i);

        bool saveChanges();
    }
}
