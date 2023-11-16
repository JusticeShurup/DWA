using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DWAApi.Models
{
    public class User : BaseModel
    {
        [Required] 
        public required string Login { get; set; }
        [Required] 
        public required string Password { get; set; }
        [ForeignKey("UserInfoId")]
        public Guid? UserInfoId { get; set; }
        [JsonIgnore]
        public string? RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefreshTokenExpiryTime { get; set; }
        [JsonIgnore]
        public UserInfo? UserInfo { get; set; }

    }
}
