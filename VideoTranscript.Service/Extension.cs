using System.Runtime.InteropServices;
using System.Text;


namespace VideoTranscript.Service
{
    public static class Extensions
    {
        public enum Mnemonic
        {
            MP3,
            WAV
        }

        public static string NewFileName(this string fullPath, string newFileName, string newExtension)
        {
            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentException(message: "Full Path cannot be null or empty.", paramName: nameof(fullPath));

            if (string.IsNullOrEmpty(newFileName))
                throw new ArgumentException(message: "New Name File cannot be null or empty.", paramName: nameof(newFileName));

            if (string.IsNullOrEmpty(newExtension))
                throw new ArgumentException(message: "New Extension cannot be null or empty.", paramName: nameof(newExtension));

            return Path.Combine(Path.GetDirectoryName(fullPath)!, $"{newFileName}.{newExtension}");
        }

        public static string AddMnemonicFileName(this string fullPath, Mnemonic mnemonic)
        {
            if (string.IsNullOrEmpty(fullPath))
                throw new ArgumentException(message: "Full Path cannot be null or empty.", paramName: nameof(fullPath));

            string newFileName = $"{Path.GetFileNameWithoutExtension(fullPath)}-{mnemonic.ToString()}";
            string newExtension = mnemonic.ToString().ToLower();
            return fullPath.NewFileName(newFileName, newExtension);
        }


        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetShortPathName(string path, StringBuilder shortPath, int shortPathLength);
        public static string GetShortPath(this string path)
        {
            StringBuilder shortPath = new StringBuilder(255);
            GetShortPathName(path, shortPath, shortPath.Capacity);
            string shortCombinedPath = shortPath.ToString();
            return shortCombinedPath;
        }
    }
}
