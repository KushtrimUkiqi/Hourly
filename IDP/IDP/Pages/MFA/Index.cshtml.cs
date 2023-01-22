namespace IDP.Pages.MFA
{
    using IdentityModel;
    using IDP.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;

    [SecurityHeaders]
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILocalUserService _localUserService;

        private readonly char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123U567890".ToCharArray();

        public ViewModel View { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public IndexModel(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }

        public async void OnGet()
        {
            var tokenData = RandomNumberGenerator.GetBytes(64);

            var result = new StringBuilder(16);

            for( int i =0; i<16; i++ ) 
            {
                var rnd = BitConverter.ToUInt32(tokenData, i * 4);

                var index = rnd % chars.Length;

                result.Append(chars[index]);
            }

            string secret = result.ToString();

            string subject = User.FindFirst(JwtClaimTypes.Subject)?.Value;

            Entities.User user = await _localUserService.GetUserBySubjectAsync(subject);

            string keyUri = string.Format(
                "otpauth://totp/{0}:{1}?secret={2}&issuer={0}",
                WebUtility.UrlEncode("Hourly"),
                WebUtility.UrlEncode(user.Email),
                secret);

            View = new ViewModel()
            {
                KeyUri = keyUri
            };

            Input = new InputModel()
            {
                Secret = secret
            };

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var subject = User.FindFirst(JwtClaimTypes.Subject)?.Value;
                if (await _localUserService
                    .AddUserSecret(subject, "TOTP", Input.Secret))
                {
                    await _localUserService.SaveChangesAsync();
                    // return to the root 
                    return Redirect("~/");
                }
                else
                {
                    throw new Exception("MFA registration error");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
