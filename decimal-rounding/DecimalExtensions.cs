[HtmlTargetElement("input", Attributes = "asp-for")]
public class DecimalFormatTagHelper : TagHelper
{
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }
    public string TotalDecimals = "0.########";

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var model = For?.Model;

        if (model is decimal decimalValue)
        {
            output.Attributes.SetAttribute("value", decimalValue.ToString(TotalDecimals, CultureInfo.InvariantCulture));
        }
        else if (model is decimal? nullableDecimalValue && nullableDecimalValue.HasValue)
        {
            output.Attributes.SetAttribute("value", nullableDecimalValue.Value.ToString(TotalDecimals, CultureInfo.InvariantCulture));
        }
    }
}

