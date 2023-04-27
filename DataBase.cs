using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DataBase
    {
        static Random randClient;
        public static List<String> dbClients;

        static DataBase()
        {
            randClient = new Random();
            dbClients = new List<String>();
        }

        public static string path = @"Clients.csv";

        /// <summary>
        /// Наборы для базы клиентов
        /// </summary>
        string[] surNames = {"Иванов", "Петров", "Сидоров",
                            "Бичан", "Бондарев", "Лещук"};

        string[] names = {"Алексей", "Игорь", "Сергей",
                          "Виктор", "Вячеслав", "Константин"};

        string[] patronymics = {"Сергеевич", "Иванович", "Александрович",
                                "Петрович", "Николаевич", "Антонович"};

        string[] passports = {"КН0541625", "МР5896345", "AB4512635",
                              "PB3658945", "AC1452556", "KC7851211",
                              "HB4586923", "KT2564879", "KP1891155"};

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
        public DataBase(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport)
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {
                if (SurName == String.Empty)
                {
                    int i = randClient.Next(surNames.Length);
                    SurName = surNames[i];
                    int j = randClient.Next(names.Length);
                    Name = names[j];
                    int g = randClient.Next(patronymics.Length);
                    Patronymic = patronymics[g];
                    PhoneNumber = Convert.ToString(randClient.Next(1000000, 9999999));
                    int d = randClient.Next(passports.Length);
                    Passport = passports[d];
                }

                this.SurName = SurName;
                this.Name = Name;
                this.Patronymic = Patronymic;
                this.PhoneNumber = PhoneNumber;
                this.Passport = Passport;

                DataBase.dbClients.Add(SurName);
                DataBase.dbClients.Add(Name);
                DataBase.dbClients.Add(Patronymic);
                DataBase.dbClients.Add(PhoneNumber);
                DataBase.dbClients.Add(Passport);

                sw.WriteLine(string.Join('\t', SurName, Name, Patronymic, PhoneNumber, Passport));
            }
        }

        /// <summary>
        /// Печать заглавной строки в списке сотрудников
        /// </summary>
        public static string TitlePrint()
        {
            return $"| {"Фамилия",15} | {"Имя",15} | {"Отчество",15} | " +
                   $"{"Номер телефона",15} | {"Номер паспорта",15} |";
        }

        /// <summary>
        /// Вывод списка клиентов
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"| {this.SurName,15} | {this.Name,15} | {this.Patronymic,15} | {this.PhoneNumber,15} | {this.Passport,15} |";
        }
    }
}
