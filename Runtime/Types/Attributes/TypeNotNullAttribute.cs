using System;

namespace TheRealIronDuck.Runtime.Types.Attributes
{
    /// <summary>
    /// This validator extends the Odin Validator logic to validate that the type from
    /// our InspectableType is not null.
    ///
    /// If returns an error if the type is null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class TypeNotNullAttribute : Attribute
    {}
}
