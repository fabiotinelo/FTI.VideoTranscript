using NAudio.Wave;
using NAudio.Lame;
using System.Text;

namespace VideoTranscript.Service
{
    public class ExtractService
    {
        private string openAIKey;

        public ExtractService(string openAIKey) 
        { 
            this.openAIKey= openAIKey;
        }

        #region Private Methods
     

        private string GenerateCompactAudio(string videoOrAudioFile)
        {
            if (string.IsNullOrEmpty(videoOrAudioFile))
                throw new ArgumentException(message: "Wav File Path cannot be null or empty.", paramName: nameof(videoOrAudioFile));

            if (!File.Exists(videoOrAudioFile))
                throw new ArgumentException(message: "Wav file does not exist.", paramName: nameof(videoOrAudioFile));

            string fullPathMp3 = videoOrAudioFile.NewFileName($"audio-{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}", Extensions.Mnemonic.MP3.ToString());
            using var reader = new AudioFileReader(videoOrAudioFile);
            using var writer = new LameMP3FileWriter(fullPathMp3, reader.WaveFormat, LAMEPreset.ABR_16);
            reader.CopyTo(writer);
            reader.Dispose();
            return fullPathMp3;
        }

        private StringBuilder TranscribeAudio(string mp3FilePath)
        {
            OpenAIService openAIService = new OpenAIService(openAIKey);
            return openAIService.TranscribeAudio(mp3FilePath);
        }
        #endregion

        public StringBuilder Transcribe(string videoOrAudioPath)
        {
            string mp3FullPath = videoOrAudioPath;

            if (!Path.GetExtension(videoOrAudioPath).Equals(".mp3", StringComparison.InvariantCultureIgnoreCase))
                mp3FullPath = GenerateCompactAudio(videoOrAudioPath);
            
            StringBuilder strBuilder = TranscribeAudio(mp3FullPath);
            if (File.Exists(mp3FullPath)) File.Delete(mp3FullPath);
            return strBuilder;
        }
    }


}
