using System.Text.Json.Serialization;


namespace VideoTranscript.UI
{
    public class Config
    {
        [JsonPropertyName("open_ai_key")]
        public required string OpenAiKey { get; set; }
    }
}
