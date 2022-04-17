using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovik
{
    internal class Student
    {
        public int id { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public int Группа { get; set; }
        public string Пол { get; set; }
        public int Возвраст { get; set; }
        public string Специальность { get; set; }
        public int Курс { get; set; }
        public string Диагноз { get; set; }
        public string Примечания { get; set; }
        public string Дата { get; set; }
        public Student() { }
        public Student(string nName, string nSurname, string nFatherhood,int nGroup,string nGender,int nAge,string nSpec,int nCourse,string nDiagnosis,string nNotes)
        {
            Имя = nName;
            Фамилия = nSurname;
            Отчество = nFatherhood;
            Группа = nGroup;
            Пол = nGender;
            Возвраст = nAge;
            Специальность = nSpec;
            Курс = nCourse;
            Диагноз = nDiagnosis;
            Примечания = nNotes;
            DateTime obj = DateTime.Now;
            DateTime dateOnly = obj.Date;
            Дата = dateOnly.ToShortDateString();
        }
    }
}
