using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IWorker
    {
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Passport { get; set; }
        public string Date { get; set; }
        public string DataChanged { get; set; }
        public string TypeOfChanges { get; set; }
        public string UserName { get; set; }

        public static List<string> GetAllClients()
        {
            var clients = new List<string>();
            return clients;
        }

        public static void ReverseNumber()
        {

        }
        public static void ReverseSurName()
        {

        }
        public static void ReversePassport()
        {

        }
        public static List<string> ClientAdd()
        {
            return new List<string>();
        }
    }
}
