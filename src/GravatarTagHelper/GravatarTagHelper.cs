using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Security.Cryptography;
using System.Text;
    
namespace Infusion.AspNet.TagHelpers
{
    [TargetElement("img", Attributes=EmailAttributeName)]
	public class GravatarTagHelper : TagHelper
	{
        private const string EmailAttributeName="gravatar-email";
        
        [HtmlAttributeName(EmailAttributeName)]
        public string EmailAddress { get; set; }
        
		public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using(var md5 = MD5.Create())
            {                
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(EmailAddress));
                
                // Build the final string by converting each byte
                // into hex and appending it to a StringBuilder
                StringBuilder sb = new StringBuilder();
                for (int i=0;i<hash.Length;i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }
                output.Attributes["src"] ="http://www.gravatar.com/avatar/" +  sb.ToString();
            }
	   }
    }
}