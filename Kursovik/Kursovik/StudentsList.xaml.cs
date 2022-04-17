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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для StudentsList.xaml
    /// </summary>
    public partial class StudentsList : Window
    {
        public string i;
        AppContext DB = new AppContext();
        public StudentsList()
        {
            InitializeComponent();
        }
        private void GoBackLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent student = new AddStudent();
            student.Show();
            this.Close();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string baseName = "accounting.db";
            DataSet dataSet = new DataSet();
            string sql = @"SELECT Фамилия,Имя,Отчество,Пол,Группа,Специальность,Возвраст,Курс,Дата,Диагноз,Примечания FROM Students";
            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();
                using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, connection))
                {
                    dataAdapter.Fill(dataSet);
                    StudentssGrid.ItemsSource = dataSet.Tables[0].DefaultView;
                }
                connection.Close();
            }
        }
        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            if(Check()==false)
            {
                MessageBox.Show("Не выбрана запись!");
            }
            else
            {
                Transport(sender, e);
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }
        private void ArchieveButton_Click(object sender, RoutedEventArgs e)
        {
            StudentsArchieve archieve = new StudentsArchieve();
            archieve.Show();
            this.Close();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string param = TextBoxName.Text;
            string value = "Фамилия";
            SearchFunc(value, param);
        }
        public void Clear()
        {
            TextBoxName.Clear();
            TextBoxGroup.Clear();
        }
        public void Transport(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Переместить запись в архив?", " ", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DataRowView dataRow = (DataRowView)StudentssGrid.SelectedItem;
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
@"INSERT INTO archieve
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
    Выписан
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
            else if (result == MessageBoxResult.No)
            {
                Delete();
            }
        }
        public void Delete()
        {
            DataRowView dataRow = (DataRowView)StudentssGrid.SelectedItem;
            string i = Convert.ToString(dataRow.Row.ItemArray[0]);
            DataRowView row = (DataRowView)StudentssGrid.SelectedItem;
            row.Row.Delete();
            SQLiteConnection conn = new SQLiteConnection("Data Source=accounting.db");
            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();
            string sql_delete = "DELETE FROM Students WHERE Фамилия = " + i + ";";
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
        private void SearchByGroupBtn_Click(object sender, RoutedEventArgs e)
        {
            string param = TextBoxGroup.Text;
            string value = "Группа";
            SearchFunc(value, param);
        }
        private void SearchByCourseBtn_Click(object sender, RoutedEventArgs e)
        {
            string param = TextBoxCourse.Text;
            string value = "Курс";
            SearchFunc(value, param);
        } 
        public void SearchFunc(string Value,string param)
        {
            if(SeasrchCheck(param)==false)
            {
                MessageBox.Show("Нужно заполнить поле");
            }
            else
            {
                try
                {
                    string baseName = "accounting.db";
                    DataSet dataSet = new DataSet();
                    string sql = $@"SELECT Фамилия,Имя,Отчество,Пол,Группа,Специальность,Возвраст,Курс,Дата,Диагноз,Примечания FROM Students WHERE {Value}={param}";
                    SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
                    using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
                    {
                        connection.ConnectionString = "Data Source = " + baseName;
                        connection.Open();
                        using (SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sql, connection))
                        {
                            dataAdapter.Fill(dataSet);
                            DataTable at = new DataTable("Students");
                            dataAdapter.Fill(at);
                            if(at.Rows.Count < 1)
                            {
                                MessageBox.Show("Ничего не найденно");
                            }
                            StudentssGrid.ItemsSource = at.DefaultView;
                        }
                        connection.Close();
                    }
                    Clear();
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    Clear();
                }
                
            }
        }
        public bool Check()
        {
            if (StudentssGrid.SelectedItems.Count < 1)
            {
                return false;
            }
            else { return true; }
        }
        public bool SeasrchCheck(string param)
        {
            if(param.Length == 0)
            {
                return false;
            }
            else { return true; }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (Check() == false)
            {
                MessageBox.Show("Не выбрана запись!");
            }
            else
            {
                DataRowView dataRow = (DataRowView)StudentssGrid.SelectedItem;
                i = Convert.ToString(dataRow.Row.ItemArray[0]);
                DataRowView row = (DataRowView)StudentssGrid.SelectedItem;
                Edit obj = new Edit();
                obj.Spec.Text = Convert.ToString(dataRow.Row.ItemArray[5]);
                obj.Name.Text = Convert.ToString(dataRow.Row.ItemArray[1]);
                obj.Group.Text = Convert.ToString(dataRow.Row.ItemArray[4]);
                obj.Diagnosis.Text = Convert.ToString(dataRow.Row.ItemArray[9]);
                obj.Course.Text = Convert.ToString(dataRow.Row.ItemArray[7]);
                obj.Age.Text = Convert.ToString(dataRow.Row.ItemArray[6]);
                obj.Show();
                obj.v = i; 
                this.Close();
            }
        }
    }
}
