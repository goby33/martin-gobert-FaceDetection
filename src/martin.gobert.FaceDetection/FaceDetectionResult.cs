namespace martin.gobert.FaceDetection;


public record FaceDetectionResult
{
    public byte[] ImageData { get; set; }
    public IList<FaceDetectionPoint> Points { get; set; }
}

public record FaceDetectionPoint
{
    public double X { get; set; }
    public double Y { get; set; }
}