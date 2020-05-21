using BoardAPI.Models.ProjectsModels;

namespace BoardAPI.Services.Communication
{
    public class TaskResponse : BaseResponse
    {
        public Task _task { get; private set; }

        private TaskResponse(bool success, string message, Task task) : base(success, message)
        {
            task = _task;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="stockData">Saved category.</param>
        /// <returns>Response.</returns>
        public TaskResponse(Task task) : this(true, string.Empty, task)
        {

        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TaskResponse(string message) : this(false, message, null)
        {

        }
    }
}
