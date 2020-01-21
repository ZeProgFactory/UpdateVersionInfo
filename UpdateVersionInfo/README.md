# UpdateVersionInfo

Based on https://github.com/soltechinc/soltechxf/   
// http://stackoverflow.com/questions/27058172/xamarin-mobile-app-version-number-scheme-across-3-platforms

## commandline switches
```
UpdateVersionInfo - V1.0.0

  -?                         Shows help/usage information.
  -s                         silent/verbus
  -i                         Displays current version info
  -v, --major=VALUE          auto | A numeric major version number greater
                               than zero.
  -m, --minor=VALUE          A numeric minor number greater than zero.
  -b, --build=VALUE          A numeric build number greater than zero.
  -r, --revision=VALUE       A numeric revision number greater than zero.
  -p, --path=VALUE           scan | The path to a C# file to update with
                               version information.
  -a, --androidManifest=VALUE
                             The path to an android manifest file to update
                               with version information.
  -t, --touchPlist=VALUE     The path to an iOS plist file to update with
                               version information.
  -n, --nuspec=VALUE         The path to an nuspec file to update with
                               version information.
```

## version info
```
UpdateVersionInfo.exe -i -p=scan
```

```
UpdateVersionInfo - V1.0.0

UWP   1.0.0.11
Droid 1.0.0.11
iOS   1.0
```

## version update

```
UpdateVersionInfo.exe -v=auto -p=scan
```

```
UpdateVersionInfo - V1.0.0

UWP   1.0.0.15 --> 1.0.0.16
Droid 1.0.0.15 --> 1.0.0.16
iOS   1.0.0.15 --> 1.0.0.16
```



N:\UpdateVersionInfo -v=auto 
    -p "D:\Software\Projects\audixis.Expertises\Expertises\Expertises\Expertises.UWP\Properties\AssemblyInfo.cs" 
    -a "D:\Software\Projects\audixis.Expertises\Expertises\Expertises\Expertises.Android\Properties\AndroidManifest.xml"

N:\UpdateVersionInfo -v=auto 
    -p "D:\Software\Projects\audixis.Expertises\Expertises\Expertises\Expertises.UWP\Properties\AssemblyInfo.cs" 
    -a "D:\Software\Projects\audixis.Expertises\Expertises\Expertises\Expertises.Droid\Properties\AndroidManifest.xml"

N:\UpdateVersionInfo -v=2.0.0.1 
    -p "D:\Software\Apps\ZeScanner\ZeScanner\ZeScanner\ZeScanner.UWP\Properties\AssemblyInfo.cs" 
    -t "D:\Software\Apps\ZeScanner\ZeScanner\ZeScanner\ZeScanner.iOS\Info.plist" 
    -a "D:\Software\Apps\ZeScanner\ZeScanner\ZeScanner\ZeScanner.Droid\Properties\AndroidManifest.xml"


<PreBuildEvent>$(SolutionDir)UpdateVersionInfo -v=auto -p "$(SolutionDir)StockAPPro.UWP\Properties\AssemblyInfo.cs" -a"$(ProjectDir)Properties\AndroidManifest.xml"</PreBuildEvent>


set UWP_Path="D:\Software\Apps\ZeScanner\ZeScanner\ZeScanner\ZeScanner.UWP\Properties\AssemblyInfo.cs"
set DroidPath="D:\Software\Apps\ZeScanner\ZeScanner\ZeScanner\ZeScanner.Droid\Properties\AndroidManifest.xml"

N:\UpdateVersionInfo -v=auto -p %UWP_Path% -a %DroidPath%



[assembly: AssemblyVersion("1.0.0.0")]
[assembly: System.Reflection.AssemblyVersion("[assembly: AssemblyVersion("1.0.0.1")]
