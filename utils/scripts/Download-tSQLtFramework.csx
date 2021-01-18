#!/usr/bin/env dotnet-script

#r "System.Net.Http"
#r "System.IO.Compression"
using System.Net.Http;
using System.IO.Compression;

Console.WriteLine("Downloading tSQLt framework..");

// TODO: Refactor this code..
var client = new HttpClient();
var response = await client.GetAsync(@"http://tsqlt.org/download/tsqlt/");

using (var stream = await response.Content.ReadAsStreamAsync())
{
    using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
    {
        foreach (var entry in zip.Entries)
        {
            var file = new FileInfo(".external-dependencies/tSQLt/" + entry.Name);
            Console.WriteLine("Extracting file " + entry.Name + " to " + file.Directory);


            if (!file.Directory.Exists)
                file.Directory.Create();

            using (var fileStream = file.OpenWrite())
            {
                await entry.Open().CopyToAsync(fileStream);
            }
        }
    }
}

Console.WriteLine("tSQLt framework downloaded sucessfully.");
