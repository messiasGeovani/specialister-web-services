using Application.Common.Interfaces;
using Http.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProfileAPI.Controllers
{
    [ApiController]
    [Route("/api/profiles")]
    public class ProfileController : MainController
    {
        public ProfileController(IErrorNotifier errorNotifier) : base(errorNotifier)
        {

        }

        [HttpPost]
        public async Task<ActionResult> CreateProfile()
        {
            throw new NotImplementedException();
        }
    };
}