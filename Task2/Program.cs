using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите сотрудника для входа:\n" +
                              "1 - менеджер\n" +
                              "2 - консультант\n");
            int entry = int.Parse(Console.ReadLine());
            switch (entry)
            {
                case 1:
                    Manager();
                    break;
                case 2:
                    Consultant();
                    break;
            }
        }

        /// <summary>
        /// Меню консультанта
        /// </summary>
        private static void Consultant()
        {
            Console.WriteLine("Выберите операцию:\n" +
                "1 - создание(пополнение) базы клиентов\n" +
                "2 - просмотр списка клиентов\n" +
                "3 - изменение номера телефона у клиента\n" +
                "0 - для выхода из программы");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: break;
                case 1:
                    Console.WriteLine("В клиентскую базу были добавлены следующие клиенты:\n");
                    Console.WriteLine(DataBase.TitlePrint());
                    for (int i = 0; i < 5; i++)
                    {
                        DataBase Client1 = new DataBase("", "", "", "", "");
                        Console.WriteLine(Client1.Print());
                    }
                    break;
                case 2:
                    Task2.Consultant.GetAllClientsConsultant();
                    break;
                case 3:
                    Task2.Consultant.GetAllClientsConsultant();
                    Task2.Consultant.ReversNumber();
                    break;

            }
        }

        /// <summary>
        /// Меню менеджера
        /// </summary>
        private static void Manager()
        {
            Console.WriteLine("Выберите операцию:\n" +
                "1 - создание(пополнение) базы клиентов\n" +
                "2 - просмотр списка клиентов\n" +
                "3 - изменение номера телефона у клиента\n" +
                "4 - добавление нового клиента\n" +
                "0 - для выхода из программы");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: break;
                case 1:
                    Console.WriteLine("В клиентскую базу были добавлены следующие клиенты:\n");
                    Console.WriteLine(DataBase.TitlePrint());
                    for (int i = 0; i < 5; i++)
                    {
                        DataBase Client1 = new DataBase("", "", "", "", "");
                        Console.WriteLine(Client1.Print());
                    }
                    break;
                case 2:
                    Task2.Manager.GetAllClientsInManager();
                    break;
                case 3:
                    Task2.Manager.GetAllClientsInManager();
                    Task2.Manager.ReversNumberInManager();
                    break;
                case 4:
                    Task2.Manager.ClientAdd();
                    Task2.Manager.GetAllClientsInManager();
                    break;
            }
        }
    }
}