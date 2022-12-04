using CommandLine;

namespace Blockchain.Processor.EventStream.Service.Application.Dto.Request
{
    public class CommandRequest
    {
        [Option(longName: "read-inline", Required = false, HelpText = "Read Inline")]
        public string ReadInline { get; set; }

        [Option(longName: "read-file", Required = false, HelpText = "Read File")]
        public string ReadFile { get; set; }

        [Option(longName: "nft", Required = false, HelpText = "NFT Ownership")]
        public string NFT { get; set; }

        [Option(longName: "wallet", Required = false, HelpText = "Wallet Ownership")]
        public string Wallet { get; set; }

        [Option(longName: "reset", Required = false, Default = true, HelpText = "Reset")]
        public bool Reset { get; set; }

    }
}
