

/*Разработка направлена на ПП “BeforeBuy“ , основные элементы, которые должны входить в БД:

Имя пользователя(логин)

Пароль

Возраст

Пол (м/ж)

Цвет кожи

Размер одежды в формате EU(пример таблицы приложен тут )

Обхват бедра, голени, груди*/
using DWA_test_app.Models.Base;

namespace DWA_test_app.Models.Users
{
    public class User : BaseModel
    {
        public string Login { get; set; } // Логин
        public string Password { get; set; } // Пароль
        public int Age { get; set; } // Возраст
        //public string SkinColour { get; set;} // Цвет кожи 
        public int EUSizeS { get; set; } // Размер EU обуви
        public int EUSizeT { get; set; } // Размер EU верха
        public int EUSizeL { get; set; } // Размер EU низа(штаны)
        public int CircleHip { get; set; } // Обхват бедра
        public int CircleChest { get; set; } // Обхват груди
        public int CircleCalf { get; set; } // Обхват голени
    }
}
