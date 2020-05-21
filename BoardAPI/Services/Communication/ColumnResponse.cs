using BoardAPI.Models.ProjectsModels;

namespace BoardAPI.Services.Communication
{
    public class ColumnResponse : BaseResponse
    {
        public Column _column { get; private set; }

        private ColumnResponse(bool success, string message, Column column) : base(success, message)
        {
            column = _column;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="stockData">Saved category.</param>
        /// <returns>Response.</returns>
        public ColumnResponse(Column column) : this(true, string.Empty, column)
        {

        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ColumnResponse(string message) : this(false, message, null)
        {

        }
    }
}
