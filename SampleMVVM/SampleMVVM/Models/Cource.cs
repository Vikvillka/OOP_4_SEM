using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleMVVM.Models
{
    public class Cource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountHour { get; set; }
        public string NameTeacher { get; set; }
        public int CountStudent { get; set; }

        public Cource(string name, int countHour, string nameTeacher, int countStudent)
        {
            this.Name = name;
            this.CountHour = countHour;
            this.NameTeacher = nameTeacher; ;
            this.CountStudent = countStudent;

        }
    }
}
