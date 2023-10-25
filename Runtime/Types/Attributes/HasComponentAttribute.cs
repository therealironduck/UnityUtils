using System;

namespace TheRealIronDuck.Runtime.Types.Attributes
{
    public class HasComponentAttribute : Attribute
    {
        public readonly Type Type;
        
        public HasComponentAttribute(Type type)
        {
            Type = type;
        }
    }
}