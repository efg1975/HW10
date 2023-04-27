using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Client
    {
        internal string SurName { get; set; }
        internal string Name { get; set; }
        internal string Patrinymic { get; set; }
        internal string PhoneNumber { get; set; }
        internal string Passport { get; set; }
        internal DateTime Date { get; set; }
        internal string DataChanged { get; set; }
        internal string TypeOfChanges { get; set; }
        internal string UserName { get; set; }

        internal Client(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport, DateTime Date,
                        string DataChanged, string TypeOfChanges, string UserName)
        {
            this.SurName = SurName;
            this.Name = Name;
            this.Patrinymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.Passport = Passport;
            this.Date = Date;
            this.DataChanged = DataChanged;
            this.TypeOfChanges = TypeOfChanges;
            this.UserName = UserName;
        }
        internal string Print()
        {
            return $"| {this.SurName,15} | {this.Name,15} | {this.Patrinymic,15} | {this.PhoneNumber,20} | {this.Passport,15} " +
                   $"| {this.Date,30} | {this.DataChanged,25} | {this.TypeOfChanges,20} | {this.UserName,20} |";
        }
    }
}
