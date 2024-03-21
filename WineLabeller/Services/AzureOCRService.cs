using System;
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using WineLabeller.Models;

namespace WineLabeller.Services
{
    internal class AzureOCRService : IOCRService
    {
        string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
        string key = Environment.GetEnvironmentVariable("VISION_KEY");
        ImageAnalysisClient client;

        public AzureOCRService()
        {
            client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
        }

        public void Analyse(FileStream stream)
        {
            VisualFeatures features = VisualFeatures.None;
            features |= VisualFeatures.Read;

            ////features |= VisualFeatures.Tags; // For detected wine or alchol bottles.
            //ImageAnalysisResult result = client.Analyze(BinaryData.FromStream(stream), features);

            //string json = JsonSerializer.Serialize(result.Read);
            string json = File.ReadAllText("ImageAnalysisResult.json"); 
            LabelReadResult read = JsonSerializer.Deserialize<LabelReadResult>(json);
            foreach (var block in read.Blocks)
                foreach (var line in block.Lines)
                {
                    System.Diagnostics.Trace.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
                    foreach (var word in line.Words)
                    {

                        System.Diagnostics.Trace.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
                    }
                }
            //File.WriteAllText("ImageAnalysisResult.json", json);
        }
    }
}
