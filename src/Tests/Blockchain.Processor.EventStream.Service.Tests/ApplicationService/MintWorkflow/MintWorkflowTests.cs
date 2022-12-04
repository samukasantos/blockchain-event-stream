

using Blockchain.Processor.Core.Messages;
using Blockchain.Processor.EventStream.Service.Adapters;
using Blockchain.Processor.EventStream.Service.Application.Dto.Request;
using Blockchain.Processor.EventStream.Service.Application.Services.Interfaces;
using Blockchain.Processor.EventStream.Service.Commands;
using FluentAssertions;
using Moq;
using Xunit;

namespace Blockchain.Processor.EventStream.Service.Tests.ApplicationService.MintWorkflow
{
    [Collection(nameof(MintWorflowCollection))]
    public class MintWorkflowTests
    {
        #region Fields

        private readonly MintWorkflowTestsFixture mintWorkflowTestsFixture;

        #endregion

        #region Constructor

        public MintWorkflowTests(MintWorkflowTestsFixture mintWorkflowTestsFixture)
        {
            this.mintWorkflowTestsFixture = mintWorkflowTestsFixture;
        }

        #endregion

        #region Methods

        [Theory(DisplayName = "Mint transaction - [Command]")]
        [InlineData("", "0x2000000000000000000000000000000000000000")]
        [Trait("Transaction", "Mint")]
        public void Given_MintTransactionIsExecuted_When_TokenIdInputIsEmpty_ShouldThrowException(string tokenId, string address)
        {
            //Arrange
            var command = new MintCommand(tokenId, address);

            //Act
            Action act = () => command.Validate();

            //Assert
            act.Should().Throw<Exception>().WithMessage("TokenId is required.");
        }

        [Theory(DisplayName = "Mint transaction - [Command]")]
        [InlineData("0xB000000000000000000000000000000000000000", "")]
        [Trait("Transaction", "Mint")]
        public void Given_MintTransactionIsExecuted_When_AddressdInputIsEmpty_ShouldThrowException(string tokenId, string address)
        {
            //Arrange
            var command = new MintCommand(tokenId, address);

            //Act
            Action act = () => command.Validate();

            //Assert
            act.Should().Throw<Exception>().WithMessage("Address is required.");
        }

        [Fact(DisplayName = "Mint transaction - [ActionRequest/Commands]")]
        [Trait("Transaction", "Mint")]
        public void Given_ReadInline_When_MapActionRequestToCommands_ShouldBothHaveSameQuantity()
        {
            //Arrange
            var json = mintWorkflowTestsFixture.GetJsonActions();
            var actions = mintWorkflowTestsFixture.GetActions(json);
            var commandRequest = mintWorkflowTestsFixture.Mocker.GetMock<CommandRequest>();
            var applicationService = mintWorkflowTestsFixture.Mocker.GetMock<IWalletApplicationService>();
            int totalCommands = 0;

            commandRequest.Object.ReadInline = json;

            applicationService.Setup(c => c.ProcessCommand(commandRequest.Object))
                               .Callback<CommandRequest>((c) =>
                               {
                                   totalCommands = CommandAdapter.ConvertJsonToCommands(c.ReadInline).Count;
                               });
            
            //Act
            applicationService.Object.ProcessCommand(commandRequest.Object);

            //Assert
            actions.Count.Should().Be(totalCommands);
            applicationService.Verify(c => c.ProcessCommand(commandRequest.Object), Times.Once);

        }


        #endregion
    }
}
