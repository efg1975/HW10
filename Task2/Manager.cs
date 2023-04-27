using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Manager : Consultant
    {
        public Manager(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport) :
            base(SurName, Name, Patronymic, PhoneNumber, Passport)
        {
        }
        internal string SurName { get; set; }
        internal string Name { get; set; }
        internal string Patronymic { get; set; }
        internal string PhoneNumber { get; set; }
        internal string Passport { get; set; }
        /// <summary>
        /// Добавление нового клиента
        /// </summary>
        /// <returns></returns>
        internal static List<string> ClientAdd()
        {
            GetAllClientsInManager();
            DataBase.dbClients = new List<string>();
            using (StreamWriter sw = new StreamWriter(DataBase.path, true, Encoding.Unicode))
            {
                Console.WriteLine("Добавление нового клиента\n");
                Console.Write("Введите фамилию клиента:\n");
                string SurName = Console.ReadLine();
                Console.Write("Введите имя клиента:\n");
                string Name = Console.ReadLine();
                Console.Write("Введите отчество клиента:\n");
                string Patronymic = Console.ReadLine();
                Console.Write("Введите номер телефона клиента:\n");
                string PhoneNumber = Console.ReadLine();
                Console.Write("Введите серию и номер паспорта:\n");
                string Passport = Console.ReadLine();

                DataBase.dbClients.Add(SurName);
                DataBase.dbClients.Add(Name);
                DataBase.dbClients.Add(Patronymic);
                DataBase.dbClients.Add(PhoneNumber);
                DataBase.dbClients.Add(Passport);

                sw.WriteLine(string.Join("\t", DataBase.dbClients.ToArray()));
                Console.WriteLine($"\nНовый клиент {SurName} {Name} {Patronymic} успешно добавлен в список клиентов\n");
            }
            return DataBase.dbClients;
        }
        /// <summary>
        /// Просмотр списка клиентов
        /// </summary>
        /// <returns></returns>
        internal static List<string> GetAllClientsInManager()
        {
            DataBase.dbClients = new List<string>();
            if (File.Exists(DataBase.path))
            {
                Console.WriteLine("Список клиентов:\n");
                Console.WriteLine(DataBase.TitlePrint());
                using (StreamReader sr = new StreamReader(DataBase.path))
                {
                    string str = string.Empty;
                    while ((str = sr.ReadLine()) != null)
                    {
                        string[] data = str.Split('\t');
                        string SurName = data[0];
                        string Name = data[1];
                        string Patronymic = data[2];
                        string PhoneNumber = data[3];
                        string Passport = data[4];

                        DataBase.dbClients.Add(SurName);
                        DataBase.dbClients.Add(Name);
                        DataBase.dbClients.Add(Patronymic);
                        DataBase.dbClients.Add(PhoneNumber);
                        DataBase.dbClients.Add(Passport);

                        Console.WriteLine($"| {SurName,15} | {Name,15} | {Patronymic,15} | {PhoneNumber,15} | {Passport,15} |");
                    }
                }
            }
            return DataBase.dbClients;
        }
        /// <summary>
        /// Изменение номера телефона у клиента
        /// </summary>
        public new static void ReversNumberInManager()
        {
            if (File.Exists(DataBase.path))
            {
                Console.WriteLine("\nВведите номер телефона, который необходимо изменить:\n");
                string PhoneNumber1 = Console.ReadLine();

                if (DataBase.dbClients.Contains(PhoneNumber1))
                {
                    int index = DataBase.dbClients.IndexOf(PhoneNumber1);
                    Console.WriteLine("\nВведите новый номер телефона:\n");
                    string PhoneNumber2 = Console.ReadLine();

                    int n;
                    bool isNumeric = int.TryParse(PhoneNumber2, out n);
                    if (isNumeric)
                    {
                        if (Convert.ToInt64(PhoneNumber2) != 0 && Convert.ToInt64(PhoneNumber2) >= 1000000
                            && Convert.ToInt64(PhoneNumber2) <= 9999999)
                        {
                            DataBase.dbClients.RemoveAt(index);
                            DataBase.dbClients.Insert(index, PhoneNumber2);
                            File.Delete(DataBase.path);
                            StreamWriter sw = new StreamWriter(DataBase.path, false, Encoding.Unicode);

                            List<string> list = new List<string>();
                            for (int i = 0; i < DataBase.dbClients.Count - 4; i = i + 5)
                            {
                                string SurName = DataBase.dbClients[i];
                                string Name = DataBase.dbClients[i + 1];
                                string Patronymic = DataBase.dbClients[i + 2];
                                string PhoneNumber = DataBase.dbClients[i + 3];
                                string Passport = DataBase.dbClients[i + 4];

                                list.Add(SurName);
                                list.Add(Name);
                                list.Add(Patronymic);
                                list.Add(PhoneNumber);
                                list.Add(Passport);

                                sw.WriteLine(string.Join('\t', SurName, Name, Patronymic, PhoneNumber, Passport));
                            }
                            sw.Close();
                            Console.WriteLine($"Номер телефона {PhoneNumber1} успешно изменен на номер {PhoneNumber2}");

                            GetAllClientsInManager();

                        }
                        else if (Convert.ToInt64(PhoneNumber2) > 9999999 && Convert.ToInt64(PhoneNumber2) < 0)
                        {
                            Console.WriteLine("Вы ввели неверное значение. Номер телефона не может " +
                                              "быть меньше нуля или больше 9999999.");
                        }

                        else
                        {
                            Console.WriteLine("Вы ввели неверное значение. Номер телефона не должен быть равен нулю\n" +
                                "и его значение должно быть в пределах 1000000-9999999\n" +
                                "Повторите попытку ввода.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели недопустимое значение. Номер телефона не может содержать буквы. " +
                                          "Повторите попытку вводаю");
                    }
                }
                else
                {
                    Console.WriteLine($"Введенный номер телефона {PhoneNumber1} отсутствует в списке. Введите верный номер телефона.");

                }
            }
            else
            {

            }
        }
    }
}
