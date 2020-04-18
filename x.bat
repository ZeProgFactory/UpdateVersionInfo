
for /f %%a in ('dir ..\..\UpdateVersionInfo.exe /s /b') do ( copy UpdateVersionInfo\bin\Debug\UpdateVersionInfo.exe %%a /y )
