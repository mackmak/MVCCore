using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCApp.Models.Repository
{
    public interface IFeedbackRepository
    {
        void AddFeedback(Feedback feedback);
    }
}
