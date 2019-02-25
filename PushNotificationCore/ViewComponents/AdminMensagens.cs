using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PushNotificationCore.ViewComponents
{
    public class AdminMensagens : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.FromResult<object>(null);
            return View();
        }
    }
}
