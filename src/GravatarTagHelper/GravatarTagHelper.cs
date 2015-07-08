using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System.Security.Cryptography;
using System.Text;
    
namespace GravatarTagHelper
{
    [TargetElement("img", Attributes=EmailAttributeName)]
	public class GravatarTagHelper : TagHelper
	{
        private const string EmailAttributeName = "gravatar-email";

        [HtmlAttributeName(EmailAttributeName)]
        public string EmailAddress { get; set; }
        public int? GravatarSize { get; set; }

        public string GravatarDefault { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            using (var md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(EmailAddress));

                // Build the hash string by converting each byte
                // into hex and appending it to a StringBuilder
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("x2"));
                }

                var url = "http://www.gravatar.com/avatar/" + sb.ToString();
                if (!string.IsNullOrEmpty(GravatarDefault))
                {
                    url += "?d=" + GravatarDefault;
                }

                if (GravatarSize != null)
                {
                    url += "?s=" + GravatarSize;
                }
                output.Attributes["src"] = url;
            }
        }
    }
}