using BoardAPI.Models.OrganizationsModels;

namespace BoardAPI.Models.UserModels
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        //Foreign Key
        public Organization Organization { get; set; }
        public int OrganizationID { get; set; }
    }
}
