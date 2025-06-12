using System.ClientModel;
using System.Text;
using OpenAI;
using OpenAI.Assistants;
using OpenAI.Audio;


namespace VideoTranscript.Service
{
    public class OpenAIService
    {
        private ApiKeyCredential apiKeyCredential;


        public OpenAIService(string apiKey) { apiKeyCredential = new ApiKeyCredential(apiKey); }


        public StringBuilder TranscribeAudio(string fullFilePath)
        {


            OpenAIClientOptions openAIClientOptions = new OpenAIClientOptions();
            openAIClientOptions.NetworkTimeout = new TimeSpan(0, 10, 0);

            AudioClient client = new("whisper-1", apiKeyCredential, openAIClientOptions);

            string audioFilePath = Path.Combine("Assets", fullFilePath).GetShortPath();

            AudioTranscriptionOptions options = new()
            {
                ResponseFormat = AudioTranscriptionFormat.Verbose,
                TimestampGranularities = AudioTimestampGranularities.Word | AudioTimestampGranularities.Segment,
            };

            AudioTranscription transcription = client.TranscribeAudio(audioFilePath, options);
            return new StringBuilder(transcription.Text);
        }

   


    }
}



