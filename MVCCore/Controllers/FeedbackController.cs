using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCApp.Models;
using CoreMVCApp.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCApp.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);
                return RedirectToAction("FeedbackComplete");
            }

            //return same data to the user, with the form already filled
            return View(feedback);

        }

        public IActionResult FeedbackComplete()
        {
            return View();
        }
    }
}