using Microsoft.AspNetCore.Razor.TagHelpers;

namespace KaianLanches.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Conteudo { get; set; }
        public string Endereco { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
