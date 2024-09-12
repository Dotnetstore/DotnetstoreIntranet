using Dotnetstore.Intranet.WebAPI.Utility.Services;

namespace Dotnetstore.Intranet.WebAPI.Organization.Enums;

internal sealed class EmailType(Guid id, string name) : Enumeration(id, name)
{
    public static EmailType RegistrationEmail = new(new Guid("A5E49C54-D751-4F87-99C8-5069AD5434EA"), "Registration e-mail");
}