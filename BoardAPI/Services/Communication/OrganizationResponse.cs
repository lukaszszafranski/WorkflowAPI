using BoardAPI.Models.OrganizationsModels;

namespace BoardAPI.Services.Communication
{
    public class OrganizationResponse : BaseResponse
    {
        public Organization _organization { get; private set; }

        private OrganizationResponse(bool success, string message, Organization organization) : base(success, message)
        {
            organization = _organization;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="stockData">Saved category.</param>
        /// <returns>Response.</returns>
        public OrganizationResponse(Organization organization) : this(true, string.Empty, organization)
        {

        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public OrganizationResponse(string message) : this(false, message, null)
        {

        }
    }
}
