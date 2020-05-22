namespace BoardAPI.Models.OrganizationsModels
{
    public class Organization
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        //public IEnumerable<Project> ProjectsList { get; set; }

        //// Foreign Keys
        //public IEnumerable<User> Members { get; set; }
    }
}
