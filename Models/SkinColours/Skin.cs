using DWA_test_app.Models.Base;
using DWA_test_app.Models.Users;

namespace DWA_test_app.Models.SkinColour
{
    public class Skin : BaseModel
    {
        //public int Id { get; set; }
        public string Colour { get; set; }
        public ICollection<User> SkinId { get; set; }
    }
}
