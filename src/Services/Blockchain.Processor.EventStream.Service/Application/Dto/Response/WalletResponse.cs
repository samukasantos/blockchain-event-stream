
using System.Collections.Generic;

namespace Blockchain.Processor.EventStream.Service.Application.Dto.Response
{
    public class WalletResponse
    {
        #region Properties

        public string Address { get; set; }
        public List<string> Tokens { get; set; }

        #endregion
    }
}
