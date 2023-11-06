using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using DWAApi.Models;

namespace DWAApi.Models
{
    public class User : BaseModel
    {
        [Required] 
        public required string Login { get; set; }

        [Required] 
        public required string Password { get; set; }

        [JsonIgnore]
        public UserInfo? UserInfo { get; set; }

    }
}
