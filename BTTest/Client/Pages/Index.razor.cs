using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BTTest.Client.Pages
{
    public partial class Index
    {
        [Inject] HttpClient Http { get; set; }

        public class Model
        {
            public string HandRep { get; set; }
        }
        public Model FormModel { get; set; } = new Model();

        public string ErrorMessage { get; set; }
        public int CalculatedValue { get; set; } = -1;

        public async Task FormSubmitted(EditContext editContext)
        {
            var opResult = await Http.GetAsync($"Cards?rep={FormModel.HandRep}");
            if (opResult.StatusCode == HttpStatusCode.OK)
            {
                ErrorMessage = string.Empty;
                CalculatedValue = Convert.ToInt32(await opResult.Content.ReadAsStringAsync());
            }
            else
            {
                ErrorMessage = await opResult.Content.ReadAsStringAsync();
                CalculatedValue = -1;
            }
        }
    }
}
