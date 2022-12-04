# Blockchain Event Stream Processor

This is a bash application that manages transactions on a blockchain allowing identification over NFT ownership.

## Usage rules:

- This application has been tested on operating systems:

- Windows
- Linux (Ubuntu)

## Commands:
- The commands below describe the allowed operations and Powershell (Windows) and Terminal (Linux) were used.

The **program** reference below refers to the application executable for example: **Blockchain.Processor.EventStream.Service.exe**

The paylod (file/input) follow the format below:

```JSON
[
   {
      "Type":"Mint",
      "TokenId":"0xA000000000000000000000000000000000000000",
      "Address":"0x1000000000000000000000000000000000000000"
   },
   {
      "Type":"Mint",
      "TokenId":"0xB000000000000000000000000000000000000000",
      "Address":"0x2000000000000000000000000000000000000000"
   },
   {
      "Type":"Mint",
      "TokenId":"0xC000000000000000000000000000000000000000",
      "Address":"0x3000000000000000000000000000000000000000"
   },
   {
      "Type":"Burn",
      "TokenId":"0xA000000000000000000000000000000000000000"
   },
   {
      "Type":"Transfer",
      "TokenId":"0xB000000000000000000000000000000000000000",
      "From":"0x2000000000000000000000000000000000000000",
      "To":"0x3000000000000000000000000000000000000000"
   }
]
```

Read Inline (**--read-inline** <json>)
- Reads either a single json element, or an array of json elements representing transactions as an argument.

```
$ ./program --read-inline '{"Type": "Burn", "TokenId": “0x..."}'
```

```
$ ./program --read-file '[{"Type": "Mint", "TokenId": "0x...", "Address": "0x..."}, {"Type": "Burn", "TokenId": "0x..."}]'
```
  
Read File (**--read-file** <file-path>)
- Reads either a single json element, or an array of json elements representing transactions from the file in the specified location.
  
```
$ ./program --read-file transactions.json
```

NFT Ownership (**--nft** <id>)
- Returns ownership information for the nft with the given id

```
$ ./program --nft '0xC000000000000000000000000000000000000000'
```
  
Wallet Ownership (**--wallet** <address> )
- Lists all NFTs currently owned by the wallet of the given address
  
```
$ ./program --wallet '0x3000000000000000000000000000000000000000'
```
  
Reset (**--reset**)
- Deletes all data previously processed by the program
    
```
$ ./program --reset
```
