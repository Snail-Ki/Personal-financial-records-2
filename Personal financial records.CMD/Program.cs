using Personal_financial_records_BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_financial_records.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуй путник");

            Console.WriteLine("Как мне к вам обращаться?\nВведите ваше имя: ");
            var name = Console.ReadLine();
            #region
            //Console.WriteLine("Кто вы есть?\nВведите пол: ");
            //var gender = Console.ReadLine();

            //Console.WriteLine("С какого момента вы вошли в этот мир?\nВведите вашу дату рождения: ");
            //var birthdate = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Чем вы занимаетесь в этом мире?\nВведите вашу профессию: ");
            //var profession = Console.ReadLine();
            #endregion
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {                              
                DateTime birthDate;
                while (true)
                {
                    Console.WriteLine("С какого момента вы вошли в этот мир?\nВведите вашу дату рождения (dd.MM.yyyy): ");
                    if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Формат неверный рождения даты.");
                    }
                }
                Console.WriteLine("Чем вы занимаетесь в этом мире?\nВведите вашу профессию: ");
                var profession = Console.ReadLine();

                userController.SetNewUserData(birthDate, profession);                
            }

            Console.WriteLine($"Что ж, я тебя запомнил, {name}, за тобой уже выехали.");
            Console.ReadLine();
        }
    }
}
