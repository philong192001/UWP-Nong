using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Models
{
    class Ass1
    { 
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Ass1(string email, string title, string description)
        {
            Email = email;
            Title = title;
            Description = description;
        }
    }
}
