using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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
    /// <summary>
    /// Логика взаимодействия для Studentsrchieve.xaml
    /// </summary>
    public partial class StudentsArchieve : Window
    {
        AppContext db;
        public StudentsArchieve()
        {
            InitializeComponent();
            db = new AppContext();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string baseName = "accounting.db";
            DataSet dataSet = new DataSet();
            string sql = @"SELECT Фамилия,Имя,Отчество,Пол,Группа,Специальность,Возвраст,Курс,Выписан,Диагноз,Примечания FROM archieve";
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, connection))
                {
                    dataAdapter.Fill(dataSet);
                    ArchieveGrid.ItemsSource = dataSet.Tables[0].DefaultView;
                }
                connection.Close();
            }
        }
        private void GoBackStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentsList obj = new StudentsList();
            obj.Show();
            this.Close();
        }
        private void DropButton_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=accounting.db");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql_delete = "DELETE FROM archieve;";
            cmd.CommandText = sql_delete;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Window_Loaded(null, null);
        }
        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            Transport(sender,e);
        }
        public void Transport(object sender, RoutedEventArgs e)
        {
                DataRowView dataRow = (DataRowView)ArchieveGrid.SelectedItem;
                string sur = Convert.ToString(dataRow.Row.ItemArray[0]);
                string name = Convert.ToString(dataRow.Row.ItemArray[1]);
                string fath = Convert.ToString(dataRow.Row.ItemArray[2]);
                string Gender = Convert.ToString(dataRow.Row.ItemArray[3]);
                int Group = Convert.ToInt32(dataRow.Row.ItemArray[4]);
                string spec = Convert.ToString(dataRow.Row.ItemArray[5]);
                int age = Convert.ToInt32(dataRow.Row.ItemArray[6]);
                int course = Convert.ToInt32(dataRow.Row.ItemArray[7]);
                string diagnosis = Convert.ToString(dataRow.Row.ItemArray[8]);
                string notes = Convert.ToString(dataRow.Row.ItemArray[9]);
                SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=accounting.db;Version=3;New=False;Compress=True;");
                sqlite_conn.Open();
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                DateTime obj = DateTime.Now;
                DateTime dateOnly = obj.Date;
                string date = dateOnly.ToShortDateString();
                sqlite_cmd.CommandText =
@"INSERT INTO students
(
    Имя,
    Фамилия,
    Отчество,
    Группа,
    Пол,
    Возвраст,
    Специальность,
    Курс,
    Диагноз,
    Примечания,
    Дата
)
VALUES
(
    @name,
    @sur,
    @fath,
    @group,
    @gender,
    @age,
    @spec,
    @course,
    @diagn,
    @note,
    @date
)";
                sqlite_cmd.Parameters.AddWithValue("name", name);
                sqlite_cmd.Parameters.AddWithValue("sur", sur);
                sqlite_cmd.Parameters.AddWithValue("fath", fath);
                sqlite_cmd.Parameters.AddWithValue("group", Group);
                sqlite_cmd.Parameters.AddWithValue("gender", Gender);
                sqlite_cmd.Parameters.AddWithValue("age", age);
                sqlite_cmd.Parameters.AddWithValue("spec", spec);
                sqlite_cmd.Parameters.AddWithValue("course", course);
                sqlite_cmd.Parameters.AddWithValue("diagn", diagnosis);
                sqlite_cmd.Parameters.AddWithValue("note", notes);
                sqlite_cmd.Parameters.AddWithValue("date", date);
                sqlite_cmd.ExecuteNonQuery();
                sqlite_conn.Close();
                Delete();
        }
        public void Delete()
        {
            DataRowView dataRow = (DataRowView)ArchieveGrid.SelectedItem;
            string i = Convert.ToString(dataRow.Row.ItemArray[0]);
            DataRowView row = (DataRowView)ArchieveGrid.SelectedItem;
            row.Row.Delete();
            SQLiteConnection conn = new SQLiteConnection("Data Source=accounting.db");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql_delete = "DELETE FROM archieve WHERE Фамилия = " + i + ";";
            cmd.CommandText = sql_delete;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            conn.Close();
            Window_Loaded(null, null);
        }
    }
}
