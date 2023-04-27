using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class DataBase
    {
        static Random randClient;
        internal static List<string> dbClients;

        static DataBase()
        {
            randClient = new Random();
            dbClients = new List<string>();
        }

        internal static string path = @"Clients.csv";

        /// <summary>
        /// Наборы для базы клиентов
        /// </summary>
        string[] surNames = {"Иванов", "Петров", "Сидоров",
                            "Бичан", "Бондарев", "Лещук"};

        string[] names = {"Алексей", "Игорь", "Сергей",
                          "Виктор", "Вячеслав", "Константин"};

        string[] patronymics = {"Сергеевич", "Иванович", "Александрович",
                                "Петрович", "Николаевич", "Антонович"};

        string[] passports = {"КН0541625", "МР5896345", "АВ4512635",
                              "РВ3658945", "АС1452556", "КС7851211",
                              "НВ4586923", "КТ2564879", "КР1891155"};
        internal string SurName { get; set; }
        internal string Name { get; set; }
        internal string Patrinymic { get; set; }
        internal string PhoneNumber { get; set; }
        internal string Passport { get; set; }
        internal string Date { get; set; }
        internal string DataChanged { get; set; }
        internal string TypeOfChanges { get; set; }
        internal string UserName { get; set; }

        internal DataBase(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport,
                          string Date, string DataChanged, string TypeOfChanges, string UserName)
        {
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
            {

                int i = randClient.Next(surNames.Length);
                SurName = surNames[i];
                int a = randClient.Next(names.Length);
                Name = names[a];
                int j = randClient.Next(patronymics.Length);
                Patronymic = patronymics[j];
                PhoneNumber = $"{randClient.Next(1000000, 9999999)}";
                int d = randClient.Next(passports.Length);
                Passport = passports[d];
                Date = Convert.ToString(DateTime.Now);
                DataChanged = "добавлен клиент";
                TypeOfChanges = "автопополнение базы";
                UserName = string.Empty;

                this.SurName = SurName;
                this.Name = Name;
                this.Patrinymic = Patronymic;
                this.PhoneNumber = PhoneNumber;
                this.Passport = Passport;
                this.Date = Date;
                this.DataChanged = DataChanged;
                this.TypeOfChanges = TypeOfChanges;
                this.UserName = UserName;


                dbClients.Add(SurName);
                dbClients.Add(Name);
                dbClients.Add(Patronymic);
                dbClients.Add(PhoneNumber);
                dbClients.Add(Passport);
                dbClients.Add(Date);
                dbClients.Add(DataChanged);
                dbClients.Add(TypeOfChanges);
                dbClients.Add(UserName);

                sw.WriteLine(string.Join('\t', SurName, Name, Patronymic, PhoneNumber, Passport,
                                               Date, DataChanged, TypeOfChanges, UserName));

            }
        }
        /// <summary>
        /// Печать заглавной строки в списке сотрудников
        /// </summary>
        public static string TitlePrint()
        {
            return $"| {"Фамилия",15} | {"Имя",15} | {"Отчество",15} | {"Номер телефона",20} | {"Номер паспорта",15} " +
                   $"| {"Дата и время изменения записи",30} | {"Изменены данные",25} | {"Тип изменений",20} " +
                   $"| {"Изменения произвел",20} |";
        }

        /// <summary>
        /// Вывод списка клиентов
        /// </summary>
        /// <returns></returns>
        internal string Print()
        {
            return $"| {this.SurName,15} | {this.Name,15} | {this.Patrinymic,15} | {this.PhoneNumber,20} | {this.Passport,15} " +
                   $"| {this.Date,30} | {this.DataChanged,25} | {this.TypeOfChanges,20} | {UserName,20} |";
        }
    }
}
