
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreMVCApp.Models.Repository
{
    public interface IPieRepository
    {
        IEnumerable<Pie> GetAllPies();
        Pie GetPieById(int pieId);
    }
}
