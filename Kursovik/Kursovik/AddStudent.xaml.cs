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
using System.Windows.Shapes;

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public string s;
        AppContext db;
        public AddStudent()
        {
            InitializeComponent();
            db = new AppContext();
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            StudentsList studentsList = new StudentsList();
            studentsList.Show();
            this.Close();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(Check()==false)
            {
                MessageBox.Show("Нужно заполнить все поля");
            }
            else
            {
                string g = s;
                string studentName = Name.Text;
                string surname = Sur.Text;
                string fatherhood = Fath.Text;
                int group = Convert.ToInt32(GroupNum.Text); 
                int age = Convert.ToInt32(Age.Text);
                string gender = g;
                string diagnosis = Diagnosis.Text;
                int CourseNum= Convert.ToInt32(Num.Text);
                string speciality = Spec.Text;
                string notes = Notes.Text;
                Student student = new Student(studentName, surname, fatherhood, group, gender, age, speciality, CourseNum, diagnosis, notes);
                db.students.Add(student);
                db.SaveChanges();
                Clear();
                MessageBox.Show("Студент был успешно добавлен");
            }
        }
        private void GenderList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            s = (selectedItem.Content.ToString());
        }
        public bool Check()
        {
            if(Name.Text == String.Empty || Spec.Text == String.Empty || Sur.Text == String.Empty || Fath.Text == String.Empty || Age.Text == String.Empty || GroupNum.Text == String.Empty || Diagnosis.Text == String.Empty || Notes.Text == String.Empty || Num.Text == String.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Clear()
        {
            Name.Clear();
            Sur.Clear();
            Fath.Clear();
            GroupNum.Clear();
            Age.Clear();
            Diagnosis.Clear();
            Num.Clear();
            Spec.Clear();
            Notes.Clear();
        }
    }
}
