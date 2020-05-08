using BoardAPI.Models.ProjectsModels;

namespace BoardAPI.Services.Communication
{
    public class ProjectResponse : BaseResponse
    {
        public Project _project { get; private set; }

        private ProjectResponse(bool success, string message, Project project) : base(success, message)
        {
            project = _project;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="stockData">Saved category.</param>
        /// <returns>Response.</returns>
        public ProjectResponse(Project project) : this(true, string.Empty, project)
        {

        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProjectResponse(string message) : this(false, message, null)
        {

        }
    }
}
