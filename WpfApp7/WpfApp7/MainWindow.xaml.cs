using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace WpfApp7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string directory = TextBoxDirectory.Text;
            string search = TextBoxSearch.Text;
            RichTextBoxOutput.Document.Blocks.Clear();

            if (string.IsNullOrEmpty(directory) && string.IsNullOrEmpty(search))
            {
                RichTextBoxOutput.Document.Blocks.Clear();
                RichTextBoxOutput.Document.Blocks.Add(new Paragraph(new Run("Заполните все поля\n")));
            }
            else
            {
                if (Directory.Exists(directory))
                {
                    // Путь к PHP интерпретатору и скрипту
                    string phpPath = @"C:\xampp\php\php.exe";
                    string scriptPath = @"C:\xampp\htdocs\php\hw\search.php";

                    // Аргументы командной строки
                    string arguments = $"\"{scriptPath}\" \"{directory}\" \"{search}\"";

                    // Запуск процесса
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = phpPath,
                        Arguments = arguments,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    try
                    {
                        using (Process process = Process.Start(startInfo))
                        {
                            using (StreamReader reader = process.StandardOutput)
                            {
                                string result = reader.ReadToEnd();
                                RichTextBoxOutput.AppendText(result);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        RichTextBoxOutput.AppendText($"Ошибка: {ex.Message}\n");
                    }
                }
                else
                {
                    RichTextBoxOutput.Document.Blocks.Clear();
                    RichTextBoxOutput.Document.Blocks.Add(new Paragraph(new Run("Указанная директория не существует.")));
                }
            }
        }
        private void OpenWebsite_Click(object sender, RoutedEventArgs e)
        {
            string url = "http://localhost/php/hw/"; // Замените URL на нужный вам
            System.Diagnostics.Process.Start(url);
        }

    }
}

