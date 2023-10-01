using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Admin.Template.Component.Basic.Inputs;

public partial class TextArea : InputBase<string>
{
    private bool isValid = true;
    
    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public int Rows { get; set; } = 1;

     [Parameter]
    public string TextMuted { get; set; }

    [Parameter]
    public Expression<Func<string>> ValidationFor { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (this.EditContext != null)
        {
            this.EditContext.OnFieldChanged += this.FieldValueChanged;
            this.EditContext.OnValidationRequested += this.ValidationRequested;
        }
    }

    protected override bool TryParseValueFromString(
        string? value,
        [MaybeNullWhen(false)] out string result,
        [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = string.IsNullOrEmpty(value) ? string.Empty : value?.Trim();
        validationErrorMessage = null;
        return true;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (this.EditContext != null)
        {
            this.EditContext.OnFieldChanged -= this.FieldValueChanged;
            this.EditContext.OnValidationRequested -= this.ValidationRequested;
        }
    }

    private void FieldValueChanged(object sender, FieldChangedEventArgs args)
    {
        if (args.FieldIdentifier.FieldName == this.FieldIdentifier.FieldName)
        {
            if(EditContext != null)
            {
                this.isValid = !this.EditContext.GetValidationMessages(this.FieldIdentifier).Any();
            }
        }
    }

    private void ValidationRequested(object sender, ValidationRequestedEventArgs args)
    {
        if(EditContext != null)
        {
            this.isValid = !this.EditContext.GetValidationMessages(this.FieldIdentifier).Any();
        }
    }
}
