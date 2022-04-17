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

namespace Kursovik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            StudentsList studentsList = new StudentsList();
            studentsList.Show();
            this.Close();
        }
        private void TestsButton_Click(object sender, RoutedEventArgs e)
        {
            Tests tests = new Tests();
            tests.Show();
            this.Close();
        }
        private void OtchetButton_Click(object sender, RoutedEventArgs e)
        {
            Otchet otchet = new Otchet();
            otchet.Show();
            this.Close();
        }
    }
}
