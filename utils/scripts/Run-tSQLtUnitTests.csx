#r "nuget: Microsoft.Data.SqlClient, 2.1.1"

using Microsoft.Data.SqlClient;
using System.Xml;

var destinationDirectory = "";
foreach (var arg in Args)
{
    if (arg.StartsWith("fp:"))
    {
        destinationDirectory = arg.Substring(3, arg.Length - 3);
    }
}

if (string.IsNullOrEmpty(destinationDirectory))
{
    throw new ArgumentNullException("fp");
}


var sql = "BEGIN TRY EXEC tSQLt.RunAll END TRY BEGIN CATCH END CATCH; EXEC tSQLt.XmlResultFormatter";
var testResult = string.Empty;

using (SqlConnection sqlConnection = new SqlConnection(@"Server=localhost;Database=tests;User Id=SA;Password=TestTest.2021!;"))
{
    sqlConnection.Open();

    SqlCommand command = new SqlCommand(sql, sqlConnection);

    var queryResult = command.ExecuteReader();

    while (queryResult.Read())
    {
        testResult += queryResult.GetString(0);
        queryResult.NextResult();
    }
}

if (testResult != string.Empty)
{
    var file = new FileInfo(destinationDirectory);
    if (!file.Directory.Exists)
        file.Directory.Create();

    using (var sw = file.CreateText())
    {
        sw.WriteLine(testResult);
    }
}