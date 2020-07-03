using System;
using System.Text;
using System.Collections.Generic;
using CafeFinderWebApi.Model;

namespace CafeFinderWebApi.Services
{
    public interface ICafeService
    {
        IEnumerable<Cafe> GetAllCafes();
        Cafe GetCafeById(int id);
        Cafe CreateCafe(Cafe cafe);
        Cafe UpdateCafe(Cafe cafe);
        void DeleteCafe(int id);
    }
}
