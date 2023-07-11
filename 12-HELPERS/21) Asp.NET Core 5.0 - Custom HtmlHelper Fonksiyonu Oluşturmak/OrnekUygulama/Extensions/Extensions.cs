using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrnekUygulama.Extensions
{
    public static class Extensions
    {
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value = "", string placeHolder = null)
            => htmlHelper.TextBox(name, value, new
            {
                style = "background-color:black;color:white;font-size:30px;",
                @class = "form-input",
                a = "a",
                b = "b",
                placeholder = placeHolder
            });

    }
}
