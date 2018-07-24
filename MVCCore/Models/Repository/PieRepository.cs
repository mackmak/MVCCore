using CoreMVCApp.Models;
using CoreMVCApp.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCApp.Models.Repository
{
    public class PieRepository:IPieRepository
    {
        public readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Pie> GetAllPies()
        {
            return _appDbContext.Pies;
        }

        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.Find(pieId);
        }
    }
}
