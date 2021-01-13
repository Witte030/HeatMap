using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace HeatMap.Extensions
{
    public class FileExtension
    {
        /// <summary>
        /// Get file path with extension
        /// </summary>
        /// <param name="fileType">File type</param>
        /// <param name="fileExtension">File extension</param>
        /// <returns>Complete file path with name and extension</returns>
        public static string GetFilePathWithExtension(string fileType, string fileExtension)
        {
            string output = null;
            OpenFileDialog openFileDialog = new OpenFileDialog
                { Filter = $"{fileType}(*.{fileExtension}) | *.{fileExtension}" };
            if (openFileDialog.ShowDialog() == true)
            {
                output = openFileDialog.FileName;
            }

            return output;
        }

        /// <summary>
        /// Get folder path
        /// </summary>
        /// <returns>Full folder path</returns>
        public static string GetFolderPath()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            return dialog.SelectedPath;
        }
    }
}
