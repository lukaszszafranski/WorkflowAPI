namespace BoardAPI.Models.ProjectsModels
{
    public class UpdateProject
    {
        public string Title { get; set; }
        public string VisibilityState { get; set; } //Private/Public
        public string Status { get; set; } //Archived, Closed, Done, etc.
    }
}
