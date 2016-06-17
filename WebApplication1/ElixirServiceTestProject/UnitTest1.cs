using ElixirService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ElixirServiceTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var elixir = new ElixirService.ElixirService();
            var banks = elixir.GetBanks().Result;

            Assert.IsNotNull(banks);
        }

        [TestMethod]
        public void TestMethod2()
        {

            TransferModel model = new TransferModel { SenderBank = "249", TargetBank = "106", SendTime = new DateTime(2016, 06, 17, 13, 0, 0) };
            var elixir = new ElixirService.ElixirService();
            var banks = elixir.GetElixirTime(model).Result;

            Assert.IsNotNull(banks);
        }
    }
}
