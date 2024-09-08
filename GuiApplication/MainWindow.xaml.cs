using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using GuiApplication.Models;

namespace GuiApplication
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Document Files (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                FilePathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FilePathTextBox.Text))
            {
                // Mock file upload - in real applications, you would save to a database or storage service
                string destinationPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", Path.GetFileName(FilePathTextBox.Text));
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                File.Copy(FilePathTextBox.Text, destinationPath, true);
                MessageBox.Show("File uploaded successfully to " + destinationPath);
            }
            else
            {
                MessageBox.Show("Please select a file to upload.");
            }
        }

        private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(LecturerNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(ClaimDescriptionTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            // Explicitly use the fully qualified name to avoid ambiguity
            var claim = new GuiApplication.Models.Claim
            {
                LecturerName = LecturerNameTextBox.Text,
                Notes = ClaimDescriptionTextBox.Text,
                DocumentPath = FilePathTextBox.Text,
                Status = "Pending"
            };

            // Handle the saving process (this could be saving to a database, a list, etc.)
            // For now, it's just a mock process
            MessageBox.Show("Claim submitted successfully!");

            // Clear form fields after submission
            LecturerNameTextBox.Clear();
            ClaimDescriptionTextBox.Clear();
            FilePathTextBox.Clear();
        }

        private void TrackClaimButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement tracking logic here
            MessageBox.Show("Tracking claim...");
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement approval logic here
            MessageBox.Show("Claim approved!");
        }
    }
}
