using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DWAApi.Models
{
    public class UserInfo : BaseModel
    {

        public int Age { get; set; } // Возраст

        public string SkinColour { get; set; }// Цвет кожи 
        
        public int EUSizeS { get; set; } // Размер EU обуви
        
        public int EUSizeT { get; set; } // Размер EU верха
        
        public int EUSizeL { get; set; } // Размер EU низа(штаны)
        
        public int CircleHip { get; set; } // Обхват бедра
        
        public int CircleChest { get; set; } // Обхват груди
        
        public int CircleCalf { get; set; } // Обхват голени
        [JsonIgnore]
        public User? User { get; set; }
    }
}
