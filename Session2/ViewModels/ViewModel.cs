using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session2.Models;

namespace Session2.ViewModels
{
    class ViewModel
    {
        public static List<Mail> MailList = new List<Mail>();

        public ViewModel()
        {
            if(MailList.Count == 0)
            {
                //Mails = new List<Mail>();
                Mails.Add(new Mail("philong@gmail.com", "ALo alo", "123"));
                Mails.Add(new Mail("philong123@gmail.com", "ALo123 alo", "123123"));
            }
          
        }
        public List<Mail> Mails
        {
            get => MailList;
         
        }
    }
}
