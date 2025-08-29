
for /f %%a in ('dir ..\..\..\UpdateVersionInfoMaui.exe /s /b') do ( copy "D:\GitWare\Apps\UpdateVersionInfo\UpdateVersionInfoMaui\bin\Release\net9.0\win-x64\publish\UpdateVersionInfoMaui.exe" %%a /y )
