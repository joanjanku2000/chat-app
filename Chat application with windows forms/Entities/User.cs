using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_application_with_windows_forms.Entities
{
    public class User
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }

        public string hashedPassword;
        public  User (Int64 id, string name, string lastName,string phoneNumber)
        {
            this.id = id;
            this.name = name;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
        }

        public User( string name, string lastName, string phoneNumber, string hashedPasswod)
        {
            
            this.name = name;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.hashedPassword = hashedPasswod;
        }

        public User() { }
      
        public override string ToString()
        {
            return $"{{{nameof(id)}={id}, {nameof(name)}={name}, {nameof(lastName)}={lastName}, {nameof(phoneNumber)}={phoneNumber}}}";
        }
    }
}
