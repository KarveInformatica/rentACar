using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTraining04Dialogs
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to greet the world with a \"Hello, world\"?",
                                                      "My App",
                                                      MessageBoxButton.YesNoCancel,
                                                      MessageBoxImage.Question,
                                                      MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Hello to you too!", "My App",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Exclamation);
                    break;
            }
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Abrir archivo...";
            openFileDialog.InitialDirectory = @"c:\Users\karve\Downloads";
            //openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|Text files (*.txt)|*.txt|C# file (*.cs)|*.cs|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                txtEditor.Text = openFileDialog.FileName;// File.ReadAllText(openFileDialog.FileName);
                Process.Start(openFileDialog.FileName);
            }
        }
        private void btnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Abrir archivo...";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|C# file (*.cs)|*.cs|Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                    lbFiles.Items.Add(System.IO.Path.GetFileName(filename));
            }
        }
        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // saveFileDialog.Title = "Guardar como...";
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs|Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);
        }
        private void btnEnterName_Click(object sender, RoutedEventArgs e)
        {
            InputDialogSample inputDialog = new InputDialogSample("Please enter your name:", "");
            if (inputDialog.ShowDialog() == true)
                lblName.Text = inputDialog.Answer;
        }
    }
}
