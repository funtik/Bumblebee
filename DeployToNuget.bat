@ECHO OFF

REM Update Nuget
REM ============
nuget.exe update -self

REM Delete Any Artifacts
REM ====================
if exist build (
	rd /s/q build
)

mkdir build

REM Requests the API Key
REM ====================
SET /p NuGetApiKey= Please enter the project's NuGet API Key: 
nuget.exe setApiKey %NuGetApiKey%

SET package="src\Wasp\Wasp.csproj"

REM Create the Package
REM ==================
ECHO "Packing/Pushing project found here:  %package%."
"c:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /t:pack /p:PackageVersion=1.1  %package%

REM Push to Nuget 
REM =============
REM cd build
REM nuget.exe push *.nupkg
REM cd ..