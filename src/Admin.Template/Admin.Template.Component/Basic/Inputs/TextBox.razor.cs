using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Linq.Expressions;

namespace Admin.Template.Component.Basic.Inputs;

public partial class TextBox<TValue> : InputBase<TValue>
{
    private bool isValid = true;

    [Parameter]
    public string Id { get; set; } = Guid.NewGuid().ToString().Replace("-", string.Empty);

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public string TextMuted { get; set; }

    [Parameter]
    public Expression<Func<TValue>> ValidationFor { get; set; }

    [Parameter]
    public int Cols { get; set; } = 12;

    [Parameter]
    public EventCallback OnValueChanged { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public EventCallback OnFocus { get; set; }

    [Parameter]
    public string Placeholder { get; set; }

    public string ColCss => this.Cols == 12 ? string.Empty : $"col-md-{this.Cols}";

    protected virtual string InputType => "text";

    [Inject]
    private IJSRuntime JSInterop { get; set; }

    private ValidationMessageStore validationMessageStore;

    public async Task Focus()
    {
        await this.JSInterop.InvokeVoidAsync("jsfunction.focusElement", this.Id);
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (this.EditContext != null)
        {
            validationMessageStore = new ValidationMessageStore(this.EditContext);
            this.EditContext.OnFieldChanged += this.FieldValueChanged;
            this.EditContext.OnValidationRequested += this.ValidationRequested;
        }
    }

    protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
    {
        var success = BindConverter.TryConvertTo<TValue>(
            value,
            System.Globalization.CultureInfo.CurrentCulture,
            out var parsedValue);

        if (success)
        {
            result = parsedValue;
            validationErrorMessage = null;
            this.validationMessageStore.Clear(this.FieldIdentifier);
            this.EditContext.NotifyValidationStateChanged();
            return true;
        }
        else
        {
            result = default;
            validationErrorMessage = this.FieldIdentifier.FieldName + " value is not valid";
            this.validationMessageStore.Add(this.FieldIdentifier, validationErrorMessage);
            this.EditContext.NotifyValidationStateChanged();
            return false;
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (disposing)
        {
            if (this.EditContext != null)
            {
                this.EditContext.OnFieldChanged -= this.FieldValueChanged;
                this.EditContext.OnValidationRequested -= this.ValidationRequested;
            }
        }
    }

    private void FieldValueChanged(object sender, FieldChangedEventArgs args)
    {
        if (args.FieldIdentifier.FieldName == this.FieldIdentifier.FieldName)
        {
            if (this.OnValueChanged.HasDelegate)
            {
                this.OnValueChanged.InvokeAsync(sender);
            }

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

    private void Focused(FocusEventArgs args)
    {
        if (this.OnFocus.HasDelegate)
        {
            this.OnFocus.InvokeAsync(null);
        }
    }
}
