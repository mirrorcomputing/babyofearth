%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe KingServer.exe
Net Start ServiceTest
sc config ServiceTest start= auto