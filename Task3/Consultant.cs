using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Consultant : DataBase, IWorker
    {

        internal Consultant(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport,
                            string Date, string DataChanged, string TypeOfChanges, string UserName) :
                            base(SurName, Name, Patronymic, PhoneNumber, Passport, Date, DataChanged, TypeOfChanges, UserName)
        {
        }

        string IWorker.SurName { get; set; }
        string IWorker.Name { get; set; }
        string IWorker.Patronymic { get; set; }
        string IWorker.PhoneNumber { get; set; }
        string IWorker.Passport { get; set; }
        string IWorker.Date { get; set; }
        string IWorker.DataChanged { get; set; }
        string IWorker.TypeOfChanges { get; set; }
        string IWorker.UserName { get; set; }

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

                        Console.WriteLine($"| {SurName,15} | {Name,15} | {Patronymic,15} | {PhoneNumber,20} | {"*********",15} |" +
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
        /// Изменение номера телефона
        /// </summary>
        public static void ReverseNumber()
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
                            dbClients.Insert(index + 5, "консультант");

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

            }
        }
        /// <summary>
        /// Изменение фамилии клиента
        /// </summary>
        public static void ReverseSurName()
        {
            Console.WriteLine("Вы не обладаете правом изменения фамилии клиента. Обратитесь к менеджеру.");
        }
        /// <summary>
        /// Изменение серии и номера паспорта клиента
        /// </summary>
        public static void ReversePassport()
        {
            Console.WriteLine("Вы не обладаете правом изменения паспорта клиента. Обратитесь к менеджеру.");
        }
    }
}
