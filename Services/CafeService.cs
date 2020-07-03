using System;
using System.Collections.Generic;
using System.Linq;
using CafeFinderWebApi.Data;
using CafeFinderWebApi.Model;

namespace CafeFinderWebApi.Services
{
    public class CafeService : ICafeService
    {
        CafeDbContext _cafeDbContext;
        public CafeService(CafeDbContext cafeDbContext)
        {
            _cafeDbContext =cafeDbContext;
        }

        public Cafe CreateCafe(Cafe cafe)
        {
            _cafeDbContext.Cafes.Add(cafe);
            _cafeDbContext.SaveChanges();
            return cafe;
        }

        public void DeleteCafe(int id)
        {
           var deleteCafe = GetCafeById(id);
           _cafeDbContext.Cafes.Remove(deleteCafe);
        }

        public IEnumerable<Cafe> GetAllCafes()
        {
            return _cafeDbContext.Cafes.ToList();
        }

        public Cafe GetCafeById(int id)
        {
            return _cafeDbContext.Cafes.Find(id);
        }

        public Cafe UpdateCafe(Cafe cafe)
        {
           var updateCafe =GetCafeById(cafe.Id);
             updateCafe.Name=cafe.Name;
             updateCafe.City=cafe.City;
            _cafeDbContext.Update(cafe);
            _cafeDbContext.SaveChanges();
            return cafe;

            
        }
    }
}
