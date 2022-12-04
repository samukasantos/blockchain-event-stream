# Blockchain Event Stream Processor

This is a bash application that manages transactions on a blockchain allowing identification over NFT ownership.

## Usage rules:

- This application has been tested on operating systems:

- Windows
- Linux (Ubuntu)

## Commands:
- The commands below describe the allowed operations and Powershell (Windows) and Terminal (Linux) were used.

The **program** reference below refers to the application executable for example: **Blockchain.Processor.EventStream.Service.exe**

Read Inline (**--read-inline** <json>)
- Reads either a single json element, or an array of json elements representing transactions from the file in the specified location.

```
$ program --read-file transactions.json
```
  
Read File (**--read-file** <file-path>)
- Reads either a single json element, or an array of json elements representing transactions as an argument.
  
```
$ program --read-file transactions.json
```
