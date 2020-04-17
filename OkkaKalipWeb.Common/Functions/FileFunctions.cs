using System;
using System.IO;

namespace OkkaKalipWeb.Common.Functions
{
    public static class FileFunctions
    {
        /// <summary>
        /// The image entered as a parameter permanently deletes the image in the file path.
        /// </summary>
        /// <param name="path">Image path to be deleted</param>
        public static void DeletePreviousImage(string path)
        {
            try
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}