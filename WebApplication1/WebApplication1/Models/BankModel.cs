using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class BankModel : BankBaseModel
    {
        public BankModel()
        {
        }

        public List<DateTime> IncomeSessions { get; set; }
        public List<DateTime> OutcomeSessions { get; set; }
    }
}