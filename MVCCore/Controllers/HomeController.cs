using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CoreMVCApp.Models.Repository;

namespace CoreMVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        /// <summary>
        /// constructor injection
        /// </summary>
        /// <param name="pieRepository"></param>
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                Title = "Pie Shop",
                Pies = _pieRepository.GetAllPies().OrderBy(x => x.Name).ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if(pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }
    }
}