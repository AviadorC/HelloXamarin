using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class BanksLogic
    {
        public static IEnumerable<BankBaseModel> GetBankList()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/BankData.json");
            var json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<IEnumerable<BankBaseModel>>(json);
        }

        public static IEnumerable<BankModel> GetBankFullList()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/BankData.json");
            var json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<IEnumerable<BankModel>>(json);
        }

        public static DateTime? CalculateEliksirTime(TransferModel incommingModel)
        {
            DateTime? result = null;
            var banks = GetBankFullList();

            var sender = banks.FirstOrDefault(b => b.Identifier == incommingModel.SenderBank);
            var target = banks.FirstOrDefault(b => b.Identifier == incommingModel.TargetBank);

            var validOutcomes = sender.OutcomeSessions.Where(os => os - os.Date > incommingModel.SendTime - incommingModel.SendTime.Date);
            DateTime firstOutcomeSession = validOutcomes.Any()
                ? validOutcomes.First()
                : sender.OutcomeSessions.First();

            var validIncomes = target.IncomeSessions.Where(@is => @is - @is.Date > firstOutcomeSession - firstOutcomeSession.Date);

            DateTime closestIncome = validIncomes.Any()
                ? validIncomes.First()
                : target.IncomeSessions.First();

            result = incommingModel.SendTime.Date.Add(closestIncome - closestIncome.Date);
            if (!validOutcomes.Any() || !validIncomes.Any())
            {
                result.Value.AddDays(1);
            }

            return result;
        }
    }
}