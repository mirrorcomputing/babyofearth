%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\installutil.exe DynamicIPServer.exe
Net Start DynamicIPServer
sc config DynamicIPServer start= auto