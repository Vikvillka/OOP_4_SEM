using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_test
{
    public class Comment
    {
        public int Id { get; set; } 
        public string Text {  get; set; }   
        public DateTime DateTime {  get; set; }
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}
