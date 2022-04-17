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
    /// Логика взаимодействия для Tests.xaml
    /// </summary>
    public partial class Tests : Window
    {
        public Tests()
        {
            InitializeComponent();
        }
        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Check()==false)
            {
                MessageBox.Show("Не выбрано колличество вопросов или не введенно название теста");
            }
            else
            {
                TestCreator obj = new TestCreator();
                obj.Show();
                QuestionChange(obj);
                this.Close();
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Menu obj = new Menu();
            obj.Show();
            this.Close();
        }
        public void QuestionChange(TestCreator obj)
        {
            switch (CountOFQuestions.SelectedIndex)
            {
                case 0:
                    {
                        obj.A9.Visibility = Visibility.Hidden;
                        obj.Q9.Visibility = Visibility.Hidden;
                        obj.A10.Visibility = Visibility.Hidden;
                        obj.Q10.Visibility = Visibility.Hidden;
                        obj.A11.Visibility = Visibility.Hidden;
                        obj.Q11.Visibility = Visibility.Hidden;
                        obj.A12.Visibility = Visibility.Hidden;
                        obj.Q12.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        obj.A11.Visibility = Visibility.Hidden;
                        obj.Q11.Visibility = Visibility.Hidden;
                        obj.A12.Visibility = Visibility.Hidden;
                        obj.Q12.Visibility = Visibility.Hidden;
                        break;
                    }
                case 3:
                    {
                        break;
                    }
            }
        }
        public bool Check()
        {
            if(CountOFQuestions.Text != String.Empty && NameOfTest.Text != String.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
