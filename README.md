# HashChecker

[![Build status](https://ci.appveyor.com/api/projects/status/github/topuzs/hashchecker?branch=master&svg=true)](https://ci.appveyor.com/project/topuzs/hashchecker) [![CodeFactor](https://www.codefactor.io/repository/github/topuzs/hashchecker/badge)](https://www.codefactor.io/repository/github/topuzs/hashchecker)

HashChecker is a Windows Shell Extension that shows MD5 and SHA256 hashes of files.


#### Screenshots

![Screenshot](./docs/HashChecker.png)

#### Installation Requeriments

- .NET Framework 4.6

#### Installation

Simply download HashChecker.zip from latest release, extract the zip file and run the following command to register:

```
c:\Windows\Microsoft.NET\Framework64\v4.0.30319\RegAsm.exe /codebase .\hashchecker.dll
```

#### Third-party Libraries

- [SharpShell](https://github.com/dwmkerr/sharpshell)
