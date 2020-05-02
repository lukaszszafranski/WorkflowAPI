﻿using BoardAPI.Models.UserModels;

namespace BoardAPI.Services.Communication
{
    public class UserResponse : BaseResponse
    {
        public User User { get; private set; }

        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            User = user;
        }

        /// <summary>
        /// Creates success response.
        /// </summary>
        /// <param name="stockData">Saved category.</param>
        /// <returns>Response.</returns>
        public UserResponse(User user) : this(true, string.Empty, user)
        {

        }

        /// <summary>
        /// Creates error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : this(false, message, null)
        {

        }
    }
}
