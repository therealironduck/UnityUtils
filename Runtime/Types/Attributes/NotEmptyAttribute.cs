using System;

namespace TheRealIronDuck.Runtime.Types.Attributes
{
    /// <summary>
    /// This validator extends the Odin Validator logic to validate the NotEmptyAttribute.
    ///
    /// If returns an error if the list/array is empty.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class NotEmptyAttribute : Attribute
    {

    }
}