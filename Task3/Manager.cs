using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Manager : Consultant, IWorker
    {
        internal Manager(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport,
                         string Date, string DataChanged, string TypeOfChanges, string UserName) :
                         base(SurName, Name, Patronymic, PhoneNumber, Passport, Date, DataChanged, TypeOfChanges, UserName)
        {
        }

        /// <summary>
        /// Просмотр списка клиентов
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllClients()
        {
            dbClients = new List<string>();
            if (File.Exists(path))
            {
                Console.WriteLine("Список клиентов:\n");
                Console.WriteLine(DataBase.TitlePrint());
                using (StreamReader line = new StreamReader(path, Encoding.Unicode))
                {
                    string str;
                    while ((str = line.ReadLine()) != null)
                    {
                        string[] data = str.Split('\t');
                        string SurName = data[0];
                        string Name = data[1];
                        string Patronymic = data[2];
                        string PhoneNumber = data[3];
                        string Passport = data[4];
                        string Date = data[5];
                        string DataChanged = data[6];
                        string TypeOfChanges = data[7];
                        string UserName = data[8];

                        dbClients.Add(SurName);
                        dbClients.Add(Name);
                        dbClients.Add(Patronymic);
                        dbClients.Add(PhoneNumber);
                        dbClients.Add(Passport);
                        dbClients.Add(Date);
                        dbClients.Add(DataChanged);
                        dbClients.Add(TypeOfChanges);
                        dbClients.Add(UserName);

                        Console.WriteLine($"| {SurName,15} | {Name,15} | {Patronymic,15} | {PhoneNumber,20} | {Passport,15} |" +
                                          $" {Date,30} | {DataChanged,25} | {TypeOfChanges,20} | {UserName,20} |");
                    }
                }
            }
            else
            {
                Console.WriteLine("Отсутствует база клиентов! Создайте её.");
            }
            return dbClients;
        }
        /// <summary>
        /// Изменение номера телефона клиента
        /// </summary>
        public new static void ReverseNumber()
        {
            if (File.Exists(path))
            {
                GetAllClients();
                Console.WriteLine("\nВведите номер телефона, который необходимо изменить:\n");
                string PhoneNumber1 = Console.ReadLine();

                if (dbClients.Contains(PhoneNumber1))
                {
                    int index = dbClients.IndexOf(PhoneNumber1);
                    Console.WriteLine("\nВведите новый номер телефона:\n");
                    string PhoneNumber2 = Console.ReadLine();

                    int n;
                    bool isNumeric = int.TryParse(PhoneNumber2, out n);
                    if (isNumeric)
                    {
                        if (Convert.ToInt64(PhoneNumber2) != 0 && Convert.ToInt64(PhoneNumber2) >= 1000000
                            && Convert.ToInt64(PhoneNumber2) <= 9999999)
                        {
                            dbClients.RemoveAt(index);
                            dbClients.Insert(index, PhoneNumber2);
                            dbClients.RemoveAt(index + 2);
                            dbClients.Insert(index + 2, Convert.ToString(DateTime.Now));
                            dbClients.RemoveAt(index + 3);
                            dbClients.Insert(index + 3, "номер телефона");
                            dbClients.RemoveAt(index + 4);
                            dbClients.Insert(index + 4, "изменение");
                            dbClients.RemoveAt(index + 5);
                            dbClients.Insert(index + 5, "менеджер");

                            File.Delete(path);
                            StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);

                            List<string> list = new List<string>();
                            for (int i = 0; i < dbClients.Count - 8; i = i + 9)
                            {
                                string SurName = dbClients[i];
                                string Name = dbClients[i + 1];
                                string Patronymic = dbClients[i + 2];
                                string PhoneNumber = dbClients[i + 3];
                                string Passport = dbClients[i + 4];
                                string Date = dbClients[i + 5];
                                string DataChanged = dbClients[i + 6];
                                string TypeOfChanges = dbClients[i + 7];
                                string UserName = dbClients[i + 8];
                                list.Add(SurName);
                                list.Add(Name);
                                list.Add(Patronymic);
                                list.Add(PhoneNumber);
                                list.Add(Passport);
                                list.Add(Date);
                                list.Add(DataChanged);
                                list.Add(TypeOfChanges);
                                list.Add(UserName);
                                sw.WriteLine(string.Join('\t', SurName, Name, Patronymic, PhoneNumber, Passport, Date,
                                                           DataChanged, TypeOfChanges, UserName));
                            }
                            sw.Close();
                            Console.WriteLine($"Номер телефона {PhoneNumber1} успешно изменен на номер {PhoneNumber2}");

                            GetAllClients();

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
                                          "Повторите попытку ввода.");
                    }
                }
                else
                {
                    Console.WriteLine($"Введенный номер телефона {PhoneNumber1} отсутствует в списке. Введите верный номер телефона.");

                }
            }
            else
            {
                Console.WriteLine("Отсутствует база клиентов! Создайте её.");
            }
        }
        /// <summary>
        /// Изменение фамилии клиента
        /// </summary>
        public static void ReverseSurName()
        {
            if (File.Exists(path))
            {
                Console.WriteLine("\nВведите фамилию клиента, которую необходимо изменить:\n");
                string SurName1 = Console.ReadLine();

                if (dbClients.Contains(SurName1))
                {
                    int index = dbClients.IndexOf(SurName1);
                    Console.WriteLine("\nВведите новую фамилию клиента:\n");
                    string SurName2 = Console.ReadLine();

                    int n;
                    bool isNumeric = int.TryParse(SurName2, out n);
                    if (isNumeric)
                    {
                        Console.WriteLine("Вы ввели неверное значение. Фамилия не может содержать цифры.");
                    }
                    else
                    {
                        dbClients.RemoveAt(index);
                        dbClients.Insert(index, SurName2);
                        dbClients.RemoveAt(index + 5);
                        dbClients.Insert(index + 5, Convert.ToString(DateTime.Now));
                        dbClients.RemoveAt(index + 6);
                        dbClients.Insert(index + 6, "фамилия клиента");
                        dbClients.RemoveAt(index + 7);
                        dbClients.Insert(index + 7, "изменение");
                        dbClients.RemoveAt(index + 8);
                        dbClients.Insert(index + 8, "менеджер");

                        File.Delete(path);
                        StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);

                        List<string> list = new List<string>();
                        for (int i = 0; i < dbClients.Count - 8; i = i + 9)
                        {
                            string SurName = dbClients[i];
                            string Name = dbClients[i + 1];
                            string Patronymic = dbClients[i + 2];
                            string PhoneNumber = dbClients[i + 3];
                            string Passport = dbClients[i + 4];
                            string Date = dbClients[i + 5];
                            string DataChanged = dbClients[i + 6];
                            string TypeOfChanges = dbClients[i + 7];
                            string UserName = dbClients[i + 8];
                            list.Add(SurName);
                            list.Add(Name);
                            list.Add(Patronymic);
                            list.Add(PhoneNumber);
                            list.Add(Passport);
                            list.Add(Date);
                            list.Add(DataChanged);
                            list.Add(TypeOfChanges);
                            list.Add(UserName);
                            sw.WriteLine(string.Join('\t', SurName, Name, Patronymic, PhoneNumber, Passport, Date,
                                                       DataChanged, TypeOfChanges, UserName));
                        }
                        sw.Close();
                        Console.WriteLine($"Фамилия клиента {SurName1} успешно изменена на {SurName2}");

                        GetAllClients();
                    }
                }
                else
                {
                    Console.WriteLine($"Клиент с фамилией {SurName1} отсутствует в списке.");
                }
            }
            else
            {
                
            }
        }
        /// <summary>
        /// Изменение серии и номера паспорта клиента
        /// </summary>
        public static void ReversePassport()
        {
            if (File.Exists(path))
            {
                GetAllClients();
                Console.WriteLine("\nВведите серию и номер паспорта, которые необходимо изменить (буквы латинские):\n");
                string Passport1 = Console.ReadLine();

                if (dbClients.Contains(Passport1))
                {
                    int index = dbClients.IndexOf(Passport1);
                    Console.WriteLine("\nВведите серию и номер нового паспорта клиента:\n");
                    string Passport2 = Console.ReadLine();

                    dbClients.RemoveAt(index);
                    dbClients.Insert(index, Passport2);
                    dbClients.RemoveAt(index + 1);
                    dbClients.Insert(index + 1, Convert.ToString(DateTime.Now));
                    dbClients.RemoveAt(index + 2);
                    dbClients.Insert(index + 2, "серия и номер паспорта");
                    dbClients.RemoveAt(index + 3);
                    dbClients.Insert(index + 3, "изменение");
                    dbClients.RemoveAt(index + 4);
                    dbClients.Insert(index + 4, "менеджер");

                    File.Delete(path);
                    StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode);

                    List<string> list = new List<string>();
                    for (int i = 0; i < dbClients.Count - 8; i = i + 9)
                    {
                        string SurName = dbClients[i];
                        string Name = dbClients[i + 1];
                        string Patronymic = dbClients[i + 2];
                        string PhoneNumber = dbClients[i + 3];
                        string Passport = dbClients[i + 4];
                        string Date = dbClients[i + 5];
                        string DataChanged = dbClients[i + 6];
                        string TypeOfChanges = dbClients[i + 7];
                        string UserName = dbClients[i + 8];
                        list.Add(SurName);
                        list.Add(Name);
                        list.Add(Patronymic);
                        list.Add(PhoneNumber);
                        list.Add(Passport);
                        list.Add(Date);
                        list.Add(DataChanged);
                        list.Add(TypeOfChanges);
                        list.Add(UserName);
                        sw.WriteLine(string.Join('\t', SurName, Name, Patronymic, PhoneNumber, Passport, Date,
                                                   DataChanged, TypeOfChanges, UserName));
                    }
                    sw.Close();
                    Console.WriteLine($"Паспорт клиента {Passport1} успешно изменена на {Passport2}");

                    GetAllClients();
                }
                else
                {
                    Console.WriteLine($"Клиент с паспортом {Passport1} отсутствует в списке.");
                }
            }
            else
            {
                Console.WriteLine("Отсутствует база клиентов! Создайте её.");
            }
        }
        /// <summary>
        /// Добавление нового клиента в базу
        /// </summary>
        /// <returns></returns>
        internal static List<string> ClientAdd()
        {
            GetAllClients();
            dbClients = new List<string>();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Unicode))
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
                string Date = Convert.ToString(DateTime.Now);
                string DataChanged = "новый клиент";
                string TypeOfChanges = "добавление";
                string UserName = "менеджер";


                dbClients.Add(SurName);
                dbClients.Add(Name);
                dbClients.Add(Patronymic);
                dbClients.Add(PhoneNumber);
                dbClients.Add(Passport);
                dbClients.Add(Date);
                dbClients.Add(DataChanged);
                dbClients.Add(TypeOfChanges);
                dbClients.Add(UserName);

                sw.WriteLine(string.Join("\t", dbClients.ToArray()));
                Console.WriteLine($"\nНовый клиент {SurName} {Name} {Patronymic} успешно добавлен в список клиентов\n");
            }
            return dbClients;
        }
    }
}
