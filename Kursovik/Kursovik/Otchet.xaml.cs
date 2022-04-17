using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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
using System.Windows.Shapes;

namespace Kursovik
{
    public partial class Otchet : Window
    {
        public Otchet()
        {
            InitializeComponent();
        }
        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            
            SourseGrid.SelectAllCells();
            SourseGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, SourseGrid);
            SourseGrid.UnselectAllCells();
            var result = (string)Clipboard.GetData(DataFormats.Text);
            dynamic wordApp = null;
            try
            {
                var sw = new StreamWriter("export.doc");
                sw.WriteLine(result);
                sw.Close();
                //var proc = Process.Start("export.doc");
                Type wordType = Type.GetTypeFromProgID("Word.Application");
                wordApp = Activator.CreateInstance(wordType);
                wordApp.Documents.Add(System.AppDomain.CurrentDomain.BaseDirectory + "export.doc");
                wordApp.ActiveDocument.Range.ConvertToTable(1, SourseGrid.Items.Count, SourseGrid.Columns.Count);
                wordApp.ActiveDocument.SaveAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (wordApp != null)
                {
                    wordApp.Quit();
                }
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SourseGrid.Visibility = Visibility.Hidden;
        }
        private void ChoiseTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiseTable.SelectedIndex == 0)
            {
                RefreshTable(sender, e, "Дата","Students");
            }
            else
            {
                RefreshTable(sender, e, "Выписан","Archieve");
            }
        }
        private void RefreshTable(object sender, RoutedEventArgs e,string param,string dataTable)
        {
            string baseName = "accounting.db";
            DataSet dataSet = new DataSet();
            string sql = $"SELECT Фамилия,Имя,Отчество,{param},Диагноз FROM {dataTable}";
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, connection))
                {
                    dataAdapter.Fill(dataSet);
                    SourseGrid.ItemsSource = dataSet.Tables[0].DefaultView;
                }
                connection.Close();
            }
        }
    }
}
