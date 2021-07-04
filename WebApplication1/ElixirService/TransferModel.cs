using System;

namespace ElixirService
{
    public class TransferModel
    {
        public string SenderBank { get; set; }

        public string TargetBank { get; set; }

        public DateTime SendTime { get; set; }
    }
}