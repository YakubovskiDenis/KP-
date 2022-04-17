using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {

        public string v;
        public Edit()
        {
            InitializeComponent();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string dataSource = "accounting.db";
            using (SQLiteConnection connection = new SQLiteConnection())
            {
                connection.ConnectionString = "Data Source=" + dataSource;
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText =
                        @"update Students 
set Имя=:Name,Группа=:Group,Специальность=:Spec,Возвраст=:Age,Курс=:Course,Диагноз=:Diagnosis where Фамилия="+v+";";
                    command.Parameters.Add("Name", DbType.String).Value = Name.Text;
                    command.Parameters.Add("Group", DbType.Int32).Value = Convert.ToInt32(Group.Text);
                    command.Parameters.Add("Spec", DbType.String).Value = Spec.Text;
                    command.Parameters.Add("Age", DbType.Int32).Value = Convert.ToInt32(Age.Text);
                    command.Parameters.Add("Course", DbType.Int32).Value = Convert.ToInt32(Course.Text);
                    command.Parameters.Add("Diagnosis", DbType.String).Value = Diagnosis.Text;
                    command.Parameters.Add("fam", DbType.String).Value = Name.Text;
                    command.ExecuteNonQuery();
                    if (command.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Информация обновлена");
                    }
                }
                StudentsList obj = new StudentsList();
                obj.Show();
                this.Close();
            }
        }
    }
}
