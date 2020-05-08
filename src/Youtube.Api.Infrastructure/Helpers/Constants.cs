using System;
using System.Collections.Generic;
using System.Text;

namespace Youtube.Api.Infrastructure.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }

            public static class Sections
            {
                public const string Liked = "Liked";
                public const string History = "History";
                public const string Disliked = "Disliked";
                public const string PendingVideos = "Pending";
            }
        }
    }
}
