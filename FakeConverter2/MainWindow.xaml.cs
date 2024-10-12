
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FakeConverter2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Pick_Click(object sender, RoutedEventArgs e)
        {

            var instanceType = Type.GetTypeFromProgID("Shell.Application");
            dynamic shell = Activator.CreateInstance(instanceType);
            var folder = shell.Namespace("shell:Downloads");
            string DownloadPath = folder.Self.Path;


            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.jpeg;*.webp"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                MessageBox.Show("ファイルを選択しました！" + filename);
                Convert_button.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Boke Kasu");
            }

        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            Convert_button.Content = "変換中";
            System.Diagnostics.Process pros = new System.Diagnostics.Process();
            pros.StartInfo.FileName = "cmd";
            pros.StartInfo.WorkingDirectory = ".\\assets";
            pros.StartInfo.Arguments = "/k convert.bat";
            pros.Start();

            Thread.Sleep(2000);
            pros.Kill();//プロセスを強制的に終了させる


            while (true)
            {
                if (MessageBox.Show("変換が完了しました！変換済みファイルを開きますか？", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                {
                    MessageBox.Show("Open it BOKE");
                    continue;
                }
                else
                {

                    bottomText.Text = "ご利用ありがとうございました！";

                    var psi = new System.Diagnostics.ProcessStartInfo("assets\\hage.png");
                    pros.StartInfo.WorkingDirectory = "assets";
                    psi.UseShellExecute = true;
                    System.Diagnostics.Process.Start(psi);


                    break;
                }
            }




        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {


            var instanceType = Type.GetTypeFromProgID("Shell.Application");
            dynamic shell = Activator.CreateInstance(instanceType);
            var folder = shell.Namespace("shell:Downloads");
            string DownloadPath = folder.Self.Path;


            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.jpeg;*.webp"; // Filter files by extension
            dialog.Multiselect = true;

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                foreach (string filename in dialog.FileNames)
                    ListBox1.Items.Add(filename);

                Convert_button.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Boke Kasu");
            }





        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            // 項目を削除します
            // 選択項目がない場合は処理をしない
            if (ListBox1.SelectedItems.Count == 0)
            {
                return;

            }



            // 選択された項目を削除
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex);
            if (ListBox1.Items.Count == 0)
            {
                Convert_button.IsEnabled = false;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ListBox1.Items.Clear();

            if (ListBox1.Items.Count == 0)
                Convert_button.IsEnabled= false;
        }



        private void Resize_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Resize_combobox.IsEnabled = true;
            Resize_combobox.Text = "x2";
        }


        private void Rotation_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Rotation_combobox.IsEnabled = true;
            Rotation_combobox.Text = "90°";
        }


        private void Format_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            Format_combobox.IsEnabled = true;
            Format_combobox.Text = "png";
        }

        private void Resize_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Resize_combobox.IsEnabled = false;
            Resize_combobox.Text = "";
        }

        private void Rotation_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Rotation_combobox.IsEnabled = false;
            Rotation_combobox.Text = "";
        }

        private void Format_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            Format_combobox.IsEnabled = false;
            Format_combobox.Text = "";
        }


    }
}