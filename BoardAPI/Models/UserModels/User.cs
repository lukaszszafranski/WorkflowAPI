using BoardAPI.Models.OrganizationsModels;
using BoardAPI.Models.ProjectsModels;

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

        ////Foreign Key
        //public Organization Organization { get; set; }
        //public int OrganizationID { get; set; }

        // Project
        //public Project Project { get; set; }
        //public int ProjectID { get; set; }
    }
}
