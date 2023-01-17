using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace martin.gobert.FaceDetection.Tests;

public class FaceDetectionUnitTest
{
    [Fact]
    public async Task ObjectShouldBeDetectedCorrectly()
    {
        var executingPath = GetExecutingPath();
        var imageScenesData = new List<byte[]>();
        foreach (var imagePath in
                 Directory.EnumerateFiles(Path.Combine(executingPath, "Scenes")))
        {
            var imageBytes = await File.ReadAllBytesAsync(imagePath);
            imageScenesData.Add(imageBytes);
        }

        var detectObjectInScenesResults = new
            FaceDetection().DetectInScenes(imageScenesData);

        var points = detectObjectInScenesResults[0].Points.OrderBy(p => p.X);

        Assert.Equal("[{\"X\":139,\"Y\":195},{\"X\":165,\"Y\":410},{\"X\":744,\"Y\":165}]",JsonSerializer.Serialize(points));
        Assert.Equal("[{\"X\":499,\"Y\":59}]",
            JsonSerializer.Serialize(detectObjectInScenesResults[1].Points));
    }
    private static string GetExecutingPath()
    {
        var executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
        var executingPath = Path.GetDirectoryName(executingAssemblyPath);
        return executingPath;
    }
} 