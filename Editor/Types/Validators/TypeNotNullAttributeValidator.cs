#if ODIN_VALIDATOR
using Sirenix.OdinInspector.Editor.Validation;
using TheRealIronDuck.Editor.Types.Validators;
using TheRealIronDuck.Runtime.Types.Attributes;

[assembly: RegisterValidator(typeof(TypeNotNullAttributeValidator))]

namespace TheRealIronDuck.Editor.Types.Validators
{
    /// <summary>
    /// This validator extends the Odin Validator logic to validate that the type from
    /// our InspectableType is not null.
    ///
    /// If returns an error if the type is null.
    /// </summary>
    public class TypeNotNullAttributeValidator : AttributeValidator<TypeNotNullAttribute>
    {
        protected override void Validate(ValidationResult result)
        {
            var list = Property.ValueEntry.WeakValues[0].ToString();
            if (list != "")
            {
                return;
            }

            result.AddError("Type must be set");
        }
    }
}
#endif
