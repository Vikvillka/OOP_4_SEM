using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_test
{
    public class User
    {
        public int Id { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }  
        public List<Comment> Comments { get; set; }
    }
}
