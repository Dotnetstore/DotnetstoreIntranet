namespace Dotnetstore.Intranet.WebAPI.SDK;

public static class ApiEndpoints
{
    private const string Base = "/api";
    
    public static class Organization
    {
        private const string OrganizationBase = $"{Base}/organizations";
        
        public static class Users
        {
            private const string UserBase = $"{OrganizationBase}/users";
            
            public const string GetAll = UserBase;
            public const string GetByUsername = $"{UserBase}/Username";
            public const string Create = UserBase;
        }
    }
}