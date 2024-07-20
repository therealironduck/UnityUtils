#if ODIN_VALIDATOR
using System.Collections;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector.Editor.Validation;
using TheRealIronDuck.Editor.Types.Validators;
using TheRealIronDuck.Runtime.Types.Attributes;

[assembly: RegisterValidator(typeof(NotEmptyAttributeValidator))]

namespace TheRealIronDuck.Editor.Types.Validators
{
    /// <summary>
    /// This validator extends the Odin Validator logic to validate the NotEmptyAttribute.
    ///
    /// If returns an error if the list/array is empty.
    /// </summary>
    public class NotEmptyAttributeValidator : AttributeValidator<NotEmptyAttribute>
    {
        protected override void Validate(ValidationResult result)
        {
            var list = Property.ValueEntry.WeakValues[0] as IList;

            if (list?.Count == 0)
            {
                result.AddError("Cannot be empty!");
            }
        }

        public override bool CanValidateProperty(InspectorProperty property)
        {
            return property.ChildResolver is ICollectionResolver
                && property.ValueEntry != null
                && typeof(IList).IsAssignableFrom(property.Info.TypeOfValue);
        }
    }
}
#endif