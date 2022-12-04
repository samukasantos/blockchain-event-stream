
using Blockchain.Processor.Core.Enumerators;
using Blockchain.Processor.Core.Messages;

namespace Blockchain.Processor.EventStream.Service.Commands
{
    public class ResetCommand : Command, ICommand
    {
        #region Properties

        public CommandType CommandType => CommandType.None;

        #endregion

        #region Methods

        public override void Validate() { }
        
        #endregion
    }
}
