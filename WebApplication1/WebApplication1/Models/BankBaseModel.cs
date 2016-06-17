using System;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class BankBaseModel
    {
        public BankBaseModel ()
        {
        }

        public string BankName { get; set; }
        public string Identifier { get; set; }
    }
}