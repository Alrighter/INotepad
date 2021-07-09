using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace notepad.Model
{
    class ApplicationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Text { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Path { get; set; }

        public void SaveFile(bool SaveAs = false)
        {
            SaveFileDialog saveFileDialog = new() { Filter = "txt|*.txt", FileName = FileName };
            if (SaveAs || FileName == "New_File")
            {
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, Text);
                    Path = saveFileDialog.FileName;
                }
            }
            else if (SaveAs == false)
            {
                try
                {
                    File.WriteAllText(Path, Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Save or open file firstly.");
                }

            }
        }

        public void NewFile(bool NewFile = false)
        {
            SaveFileDialog saveFileDialog = new() { Filter = "txt|*.txt", FileName = FileName };
            if (NewFile)
            {
                saveFileDialog.ShowDialog();
                File.Create(saveFileDialog.FileName);
                Path = saveFileDialog.FileName;
            }

        }

        public void OpenFile(bool OpenFile = false)
        {
            OpenFileDialog openFileDialog = new() { Filter = "txt|*.txt" };
            if (OpenFile)
            {
                openFileDialog.ShowDialog();
                Path = openFileDialog.FileName;
                Text = File.OpenText(Path).ReadLine();
            }
        }

    }
}
