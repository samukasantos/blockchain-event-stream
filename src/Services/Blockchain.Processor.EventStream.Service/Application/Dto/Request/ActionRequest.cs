
using Blockchain.Processor.Core.Enumerators;

namespace Blockchain.Processor.EventStream.Service.Application.Dto.Request
{
    public class ActionRequest
    {
        #region Properties

        public CommandType Type { get; set; }
        public string TokenId { get; set; }
        public string Address { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        #endregion
    }
}
