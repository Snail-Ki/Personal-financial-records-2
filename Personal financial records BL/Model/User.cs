using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_financial_records_BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства.
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }               
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Профессия.
        /// </summary>
        public string Profession { get; set; }       
        #endregion
        /// <summary>
        /// Создвть нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="profession"> Профессия. </param>
        public User(
            string name, 
            DateTime birthDate, 
            string profession)
        {
            #region Проверка условий.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }            
            if (birthDate<DateTime.Parse( "01.01.1900") || birthDate>= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }
            if (string.IsNullOrWhiteSpace(profession))
            {
                throw new ArgumentNullException("Профессия не может быть пустой.", nameof(profession));
            }
            #endregion
            Name = name;
            BirthDate = birthDate;
            Profession = profession;
        }

        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
