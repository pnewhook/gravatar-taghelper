using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    
namespace Infusion.AspNet.TagHelpers
{
    [TargetElement("img", Attributes=EmailAttributeName)]
	public class GravatarTagHelper : TagHelper
	{
        private const string EmailAttributeName="gravatar-email";
        
		public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
        }
	}
}