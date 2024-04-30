using System;
using System.IO;
using System.Windows;

namespace ProductBridge.Controllers
{
    public class UploadGalleryController
    {
        public void UploadGallery(string[] imagePaths)
        {
            foreach (string imagePath in imagePaths)
            {
                string uploadDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads");
                string destinationPath = Path.Combine(uploadDirectory, Path.GetFileName(imagePath));

                try
                {
                    File.Copy(imagePath, destinationPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while copying the file: {ex.Message}");
                }
            }
        }
    }
}
