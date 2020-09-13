using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session2.Models
{
    class Customer
    {
        //de public
        //public string FullName { get; set; }
        //public string Phone { get; set; }     
        //public string typeContact { get; set; }
        //public char icon { get; set; }

        //public Customer(string fullName, string phone, string typeContact, char icon)
        //{
        //    FullName = fullName;
        //    Phone = phone;
        //    this.typeContact = typeContact;
        //    this.icon = icon;
        //}

        private string FullName;
        private string Telephone;
        private string typeContact;
        private char icon;
        public string Name
        {
            get { return FullName; }
            set { FullName = value; }
        }
        public char Icon
        {
            get { return icon; }
            set { icon = value; }
        }
        public string Phone
        {
            get { return Telephone; }
            set { Telephone = value; }
        }
        public string TypeContact
        {
            get { return typeContact; }
            set { typeContact = value; }
        }

        public Customer(string name, char icon, string phone, string typeContact)//đây này ông ơi ^^em tuong goi ntn cung dc ai biet phai theo trinh tu dau haha

        {
            Name = name;
            Icon = icon;
            Phone = phone;
            TypeContact = typeContact;
        }
    }
}
