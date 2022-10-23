using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using FontStyle = System.Drawing.FontStyle;

namespace WPF_TextEditor
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
         
            InitializeComponent();

            cBoxFontStyle.SelectionChanged += (s, e) =>
            rtb.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, e.AddedItems[0]);

            cBoxFontSize.SelectionChanged += (s, e) =>
            rtb.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, e.AddedItems[0]);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int fsize = 7; fsize < 73; fsize++)
                cBoxFontSize.Items.Add(fsize.ToString());
        }

        private void MenuItemNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This method will be fixed soon!");
            //var fileDialog = new OpenFileDialog()
            //{
            //    Filter = "Text|*.txt"
            //};

            //if (fileDialog.ShowDialog() is true)
            //{
            //    using StreamReader streamReader = new(fileDialog.FileName);
            //    TextRange textRange = new TextRange(rtb.Document.ContentStart,rtb.Document.ContentEnd);
            //    textRange.Text = streamReader.ReadToEnd();
            //}
        }

        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Text Files|*.txt";
            if (saveFile.ShowDialog() is true)
            {
                using StreamWriter streamWriter = new(saveFile.FileName);
                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                
                streamWriter.Write(textRange.Text);
            }
        }

        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
         
            var fileDialog = new OpenFileDialog()
            {
                Filter = "Text|*.txt"
            };
            fileDialog.Filter = "All files|*.*|Text Files|*.txt";

            if (fileDialog.ShowDialog() is true)
            {
                using StreamReader streamReader = new(fileDialog.FileName);
                TextRange textRange = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
                textRange.Text = streamReader.ReadToEnd();
            }
        }
    }
}
