using System;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
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
                "4 - изменение фамилии клиента\n" +
                "5 - изменение серии и номера паспорта\n" +
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
                        DataBase Client1 = new DataBase("", "", "", "", "", "", "", "", "");
                        Console.WriteLine(Client1.Print());
                    }
                    break;
                case 2:
                    Task3.Consultant.GetAllClients();
                    break;
                case 3:
                    Task3.Consultant.ReverseNumber();
                    break;
                case 4:
                    Task3.Consultant.ReverseSurName();
                    break;
                case 5:
                    Task3.Consultant.ReversePassport();
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
                "4 - изменение фамилии клиента\n" +
                "5 - изменение серии и номера паспорта клиента\n" +
                "6 - добавление нового клиента\n" +
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
                        DataBase Client1 = new DataBase("", "", "", "", "", "", "", "", "");
                        Console.WriteLine(Client1.Print());
                    }
                    break;
                case 2:
                    Task3.Manager.GetAllClients();
                    break;
                case 3:
                    Task3.Manager.ReverseNumber();
                    break;
                case 4:
                    Task3.Manager.ReverseSurName();
                    break;
                case 5:
                    Task3.Manager.ReversePassport();
                    break;
                case 6:
                    Task3.Manager.ClientAdd();
                    Task3.Manager.GetAllClients();
                    break;
            }
        }
    }
}