using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Admin.Template.Component.Basic.Inputs;

public partial class TextArea : InputBase<string>
{
    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public int Rows { get; set; } = 1;

    [Parameter]
    public Expression<Func<string>> ValidationFor { get; set; }

    protected override bool TryParseValueFromString(
        string? value,
        [MaybeNullWhen(false)] out string result,
        [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = string.IsNullOrEmpty(value) ? string.Empty : value?.Trim();
        validationErrorMessage = null;
        return true;
    }
}
