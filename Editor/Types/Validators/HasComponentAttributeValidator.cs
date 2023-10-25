#if ODIN_VALIDATOR
using Sirenix.OdinInspector.Editor.Validation;
using TheRealIronDuck.Editor.Types.Validators;
using TheRealIronDuck.Runtime.Types.Attributes;
using UnityEngine;

[assembly: RegisterValidator(typeof(HasComponentAttributeValidator))]
namespace TheRealIronDuck.Editor.Types.Validators
{
    public class HasComponentAttributeValidator : AttributeValidator<HasComponentAttribute, GameObject>
    {
        protected override void Validate(ValidationResult result)
        {
            if (Value == null)
            {
                return;
            }

            if (Value.GetComponent(this.Attribute.Type) == null)
            {
                result.AddError($"GameObject does not have the required component: {this.Attribute.Type}");
            }
        }
    }
}
#endif
