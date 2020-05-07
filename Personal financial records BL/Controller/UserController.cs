using Personal_financial_records_BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Personal_financial_records_BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser != null)
            {
                Console.WriteLine($"Вы не представляете, но вы: {CurrentUser.Name} и вы {CurrentUser.BirthDate.Year} года рождения.");
            }
            else
            {
                Console.WriteLine("О_о так вы новый пользователь...");
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using(var fs=new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length!=0)
                {   
                    return formatter.Deserialize(fs) as List<User>; ;
                }
                else
                {
                    return new List<User>();
                }                
            }
        }

        /// <summary>
        /// Внести данные нового пользователя.
        /// </summary>
        /// <param name="genderName"></param>
        /// <param name="birthDate"></param>
        /// <param name="profession"></param>
        public void SetNewUserData(             
            DateTime birthDate, 
            string profession = "Рядовой диванных войск")
        {           
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }
                       
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Profession = profession;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>  
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if( formatter.Deserialize(fs) is User users)
                {
                    return users;
                }
                else
                {
                    throw new FileLoadException("Не удалось получить данные пользователя", "users.dat");
                }
            }
        }
    }
}
