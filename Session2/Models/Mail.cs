using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Models
{
    class Mail
    {
     
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }

        public Mail(string email, string subject, string description)
        {
            Email = email;
            Subject = subject;
            Description = description;
        }
    }
}
