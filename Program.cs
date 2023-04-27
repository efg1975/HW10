using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace Task1
{
    class Program
    {
        static void Main(string[] args)
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
                    Consultant.GetAllClientsConsultant();
                    break;
                case 3:
                    Consultant.GetAllClientsConsultant();
                    Consultant.ReversNumber();
                    break;
            }
        }
    }
}