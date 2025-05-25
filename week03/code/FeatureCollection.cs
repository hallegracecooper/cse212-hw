using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("features")]
    public Feature[] Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }

    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }
}

public class Properties
{
    [JsonPropertyName("mag")]
    public double Magnitude { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }
}

public class Geometry
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; set; }
}