//MAIN 

using System.Text.Json;
using martin.gobert.FaceDetection;
if (args.Length != 0)
{
    try
    {
        var imagesBytes = new List<byte[]>();
        foreach (var arg in args)
        {
            imagesBytes.Add(await File.ReadAllBytesAsync(arg));
        }
        var detectFaceInScenesResults = new FaceDetection().DetectInScenes(imagesBytes);
            
        foreach (var detectionResult in detectFaceInScenesResults)
        {
            System.Console.WriteLine($"Points:{JsonSerializer.Serialize(detectionResult.Points)}");
        } 
    }
    catch (Exception e)
    {
        //error file not found
        Console.WriteLine(e.Message);
        Console.WriteLine(e);
        throw;
    }
}
else
{
    Console.WriteLine("No arguments");
}