#r "nuget: Microsoft.SqlServer.DACFx, 150.4897.1"

using Microsoft.SqlServer.Dac;

Console.WriteLine("Publishing database");

var dacPackage = DacPackage.Load("./bin/tests/tests.dacpac");
var dacService = new DacServices(@"Server=localhost;User Id=SA;Password=TestTest.2021!;");
var publishOptions = new PublishOptions();

publishOptions.DeployOptions = new DacDeployOptions()
{
    CreateNewDatabase = true,
    IncludeCompositeObjects = true
};


dacService.Publish(dacPackage, "tests", publishOptions);