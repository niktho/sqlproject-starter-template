#r "nuget: Microsoft.SqlServer.DACFx, 150.4897.1"

using Microsoft.SqlServer.Dac;

var buildDirectory = "";
foreach (var arg in Args)
{
    if (arg.StartsWith("bd:"))
    {
        buildDirectory = arg.Substring(3, arg.Length - 3);
    }
}

Console.WriteLine(buildDirectory);
Console.WriteLine("Publishing database");

if (string.IsNullOrEmpty(buildDirectory))
{
    throw new ArgumentNullException("bd");
}

var dacPackage = DacPackage.Load(buildDirectory + "tests.dacpac");
var dacService = new DacServices(@"Server=localhost;User Id=SA;Password=TestTest.2021!;");
var publishOptions = new PublishOptions();

publishOptions.DeployOptions = new DacDeployOptions()
{
    CreateNewDatabase = true,
    IncludeCompositeObjects = true
};


dacService.Publish(dacPackage, "tests", publishOptions);