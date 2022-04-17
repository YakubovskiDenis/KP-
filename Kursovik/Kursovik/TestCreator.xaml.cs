using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для TestCreator.xaml
    /// </summary>
    public partial class TestCreator
    {
        Microsoft.Office.Interop.Word._Application oWord = new Microsoft.Office.Interop.Word.Application();
        public TestCreator()
        {
            InitializeComponent();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Tests obj = new Tests();
            var dateAndTime = DateTime.Now;
            var date1 = dateAndTime.ToShortDateString();
            string date = date1.ToString();
            _Document oDoc = GetDoc("C:\\Users\\Hello\\Desktop\\Kursovik\\Kursovik\\DockTemplates\\test12.doc");
            oDoc.SaveAs(FileName: "C:\\Users\\" + Environment.UserName + "\\Desktop\\123.docx");
            oDoc.Close();
        }
        private _Document GetDoc(string path) //Вот этот ГетДок
        {
            _Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }
        private void SetTemplate(Microsoft.Office.Interop.Word._Document oDoc)
        {
            Tests obj1 = new Tests();
            string s = obj1.NameOfTest.Text;
            oDoc.Bookmarks["A1"].Range.Text = Convert.ToString(A1.Text);
            oDoc.Bookmarks["A10"].Range.Text = Convert.ToString(A10.Text);
            oDoc.Bookmarks["A11"].Range.Text = Convert.ToString(A11.Text);
            oDoc.Bookmarks["A12"].Range.Text = Convert.ToString(A12.Text);
            oDoc.Bookmarks["A2"].Range.Text = Convert.ToString(A2.Text);
            oDoc.Bookmarks["A3"].Range.Text = Convert.ToString(A3.Text);
            oDoc.Bookmarks["A4"].Range.Text = Convert.ToString(A4.Text);
            oDoc.Bookmarks["A5"].Range.Text = Convert.ToString(A5.Text);
            oDoc.Bookmarks["A6"].Range.Text = Convert.ToString(A6.Text);
            oDoc.Bookmarks["A7"].Range.Text = Convert.ToString(A7.Text);
            oDoc.Bookmarks["A8"].Range.Text = Convert.ToString(A8.Text);
            oDoc.Bookmarks["A9"].Range.Text = Convert.ToString(A9.Text);
            oDoc.Bookmarks["Name"].Range.Text = Convert.ToString(s);
            oDoc.Bookmarks["Q1"].Range.Text = Convert.ToString(Q1.Text);
            oDoc.Bookmarks["Q10"].Range.Text = Convert.ToString(Q10.Text);
            oDoc.Bookmarks["Q11"].Range.Text = Convert.ToString(Q11.Text);
            oDoc.Bookmarks["Q12"].Range.Text = Convert.ToString(Q12.Text);
            oDoc.Bookmarks["Q2"].Range.Text = Convert.ToString(Q2.Text);
            oDoc.Bookmarks["Q3"].Range.Text = Convert.ToString(Q3.Text);
            oDoc.Bookmarks["Q4"].Range.Text = Convert.ToString(Q4.Text);
            oDoc.Bookmarks["Q5"].Range.Text = Convert.ToString(Q5.Text);
            oDoc.Bookmarks["Q6"].Range.Text = Convert.ToString(Q6.Text);
            oDoc.Bookmarks["Q7"].Range.Text = Convert.ToString(Q7.Text);
            oDoc.Bookmarks["Q8"].Range.Text = Convert.ToString(Q8.Text);
            oDoc.Bookmarks["Q9"].Range.Text = Convert.ToString(Q9.Text);
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Tests obj = new Tests();
            obj.Show();
            this.Close();
        }
    }
}
