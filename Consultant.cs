using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Consultant
    {
        public Consultant(string SurName, string Name, string Patronymic, string PhoneNumber, string Passport)
        {

        }
        internal string SurName { get; }
        internal string Name { get; }
        internal string Patronymic { get; }
        internal string PhoneNumber { get; set; }
        internal string Passport { get; }

        /// <summary>
        /// Получение списка клиентов из файла
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllClientsConsultant()
        {
            DataBase.dbClients = new List<string>();
            if (File.Exists(DataBase.path))
            {
                Console.WriteLine("Список клиентов:\n");
                Console.WriteLine(DataBase.TitlePrint());
                using (StreamReader line = new StreamReader(DataBase.path, Encoding.Unicode))
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

                        DataBase.dbClients.Add(SurName);
                        DataBase.dbClients.Add(Name);
                        DataBase.dbClients.Add(Patronymic);
                        DataBase.dbClients.Add(PhoneNumber);
                        DataBase.dbClients.Add(Passport);

                        Console.WriteLine($"| {SurName,15} | {Name,15} | {Patronymic,15} | {PhoneNumber,15} | {"*********",15} |");
                    }
                }
            }
            else
            {
                Console.WriteLine("Отсутствует база клиентов! Создайте её.");
            }
            return DataBase.dbClients;
        }
        /// <summary>
        /// Изменение номера телефона клиента консультантом
        /// </summary>
        public static void ReversNumber()
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

                            Consultant.GetAllClientsConsultant();

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
    }
}
