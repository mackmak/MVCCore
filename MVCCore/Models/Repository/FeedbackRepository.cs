using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCApp.Models.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public readonly AppDbContext _appDbContext;

        public FeedbackRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
