using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Task2
{
    internal class Client
    {
        internal string SurName { get; set; }
        internal string Name { get; set; }
        internal string Patronymic { get; set; }
        internal string PhoneNumber { get; set; }
        internal string Passport { get; set; }

        /// <summary>
        /// Автосоздание (пополнение) базы клиентов
        /// </summary>
        /// <param name="SurName"></param>
        /// <param name="Name"></param>
        /// <param name="Patronymic"></param>
        /// <param name="PhoneNumber"></param>
        /// <param name="Passport"></param>
        internal Client(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport)
        {
            this.SurName = SurName;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.PhoneNumber = PhoneNumber;
            this.Passport = Passport;
        }

        /// <summary>
        /// Вывод списка клиентов
        /// </summary>
        /// <returns></returns>
        internal string Print()
        {
            return $"| {this.SurName,15} | {this.Name,15} | {this.Patronymic,15} | {this.PhoneNumber,15} | {this.Passport,15} |";
        }
    }
}

