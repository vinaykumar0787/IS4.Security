using IdentityModel.Client;
using LMS.Services.Models;
using LMS.UI.Services;
using Microsoft.AspNetCore.Components;


namespace LMS.UI.Pages
{
    public partial class SamplePage
    {
        private List<LMSEntityModel> Entities = new();
        [Inject] private HttpClient HttpClient { get; set; }
        [Inject] private IConfiguration Config { get; set; }
        [Inject] private ITokenService TokenService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenResponse = await TokenService.GetToken("api.read");
            HttpClient.SetBearerToken(tokenResponse.AccessToken);

            var result = await HttpClient.GetAsync(Config["apiUrl"] + "/api/lms");

            if (result.IsSuccessStatusCode)
            {
                Entities = await result.Content.ReadFromJsonAsync<List<LMSEntityModel>>();
            }
        }

        public SamplePage()
        {
            


        }
    }
}
