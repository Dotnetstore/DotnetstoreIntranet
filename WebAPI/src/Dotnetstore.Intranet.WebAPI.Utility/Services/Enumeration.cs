using System.Reflection;

namespace Dotnetstore.Intranet.WebAPI.Utility.Services;

public abstract class Enumeration(Guid id, string name) : IComparable
{
    public string Name { get; } = name;

    public Guid Id { get; } = id;

    public override string ToString() => Name;
    
    public int CompareTo(object? obj)
    {
        return obj is not Enumeration otherValue ? 1 : Id.CompareTo(otherValue.Id);
    }

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                    .Select(f => f.GetValue(null))
                    .Cast<T>();
        
    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static T FromValue<T>(Guid value) where T : Enumeration
    {
        var matchingItem = Parse<T, Guid>(value, "value", item => item.Id == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
        return matchingItem;
    }

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchingItem == null)
            throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

        return matchingItem;
    }
}