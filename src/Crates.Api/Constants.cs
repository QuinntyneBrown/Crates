namespace Crates.Api
{
    public static class Constants
    {
        public static class ClaimTypes
        {
            public static readonly string UserId = nameof(UserId);
            public static readonly string ProfileId = nameof(ProfileId);
            public static readonly string AccountId = nameof(AccountId);
            public static readonly string Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        }
    }
}
