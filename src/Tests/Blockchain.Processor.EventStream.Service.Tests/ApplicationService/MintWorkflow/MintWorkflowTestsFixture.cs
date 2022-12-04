
using Blockchain.Processor.EventStream.Service.Application.Dto.Request;
using Blockchain.Processor.EventStream.Service.Commands;
using Moq.AutoMock;
using Newtonsoft.Json;
using System.Security.Policy;
using Xunit;

namespace Blockchain.Processor.EventStream.Service.Tests.ApplicationService.MintWorkflow
{

    [CollectionDefinition(nameof(MintWorflowCollection))]
    public class MintWorflowCollection : ICollectionFixture<MintWorkflowTestsFixture> { }

    public class MintWorkflowTestsFixture : IDisposable
    {
        #region Properties

        public AutoMocker Mocker { get; private set; }

        #endregion

        #region Constructor

        public MintWorkflowTestsFixture()
        {
            Mocker = new AutoMocker();
        }

        #endregion

        #region Methods

        public List<MintCommand> GetMintCommands() 
        {
            return new List<MintCommand>() 
            {
                new MintCommand("0xA000000000000000000000000000000000000000","0x1000000000000000000000000000000000000000"),
                new MintCommand("0xB000000000000000000000000000000000000000","0x2000000000000000000000000000000000000000"),
                new MintCommand("0xC000000000000000000000000000000000000000","0x3000000000000000000000000000000000000000")
            };
        }

        public string GetJsonActions() 
        {
            return "[{\"Type\": \"Mint\", \"TokenId\": \"0xA000000000000000000000000000000000000000\",\r\n\"Address\": \"0x1000000000000000000000000000000000000000\"},{\"Type\": \"Mint\", \"TokenId\": \"0xB000000000000000000000000000000000000000\",\r\n\"Address\": \"0x2000000000000000000000000000000000000000\"}]";
        }

        public List<ActionRequest> GetActions(string json)
        {
            return JsonConvert.DeserializeObject<List<ActionRequest>>(json);
        }

        public void Dispose() { }

        #endregion
    }
}
