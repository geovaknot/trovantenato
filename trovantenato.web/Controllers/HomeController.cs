using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trovantenato.Web.ExternalServices.AppApi.Contact.Models.Request;
using Trovantenato.Web.ExternalServices.AppApi.Immigrant.Models.Request;
using Trovantenato.Web.Models;
using IAppApiContactService = Trovantenato.Web.ExternalServices.AppApi.Contact.Interfaces.IAppApiService;
using IAppApiImmigrantService = Trovantenato.Web.ExternalServices.AppApi.Immigrant.Interfaces.IAppApiService;

namespace Trovantenato.Web.Controllers
{
    public class HomeController : AppControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppApiContactService _appApiContactService;
        private readonly IAppApiImmigrantService _appApiImmigrantService;

        public HomeController(
            ILogger<HomeController> logger
            , IAppApiContactService appApiContactService
            , IAppApiImmigrantService appApiImmigrantService)
            : base(logger)
        {
            _logger = logger;
            _appApiContactService = appApiContactService;
            _appApiImmigrantService = appApiImmigrantService;
        }

        public async Task<IActionResult> Index()
        {
            return await AsyncHandler(async () =>
            {
                return View();
            });

        }

        [HttpGet]
        public async Task<JsonResult> GetImmigrantBySurname(string surname)
        {
            return await AsyncHandler(async () =>
            {
                var request = new GetImmigrantsBySurnameRequest()
                {
                    Surname = surname
                };

                var response = await _appApiImmigrantService.GetImmigrantsBySurname(request);

                return Json(new { Code = "0200", Message = "Successfully.", Data = response.Immigrants });

            });
        }

        [HttpPost]
        public async Task<JsonResult> CreateContact(string name, string email, string subject, string message)
        {
            return await AsyncHandler(async () =>
            {
                var request = new CreateContactRequest()
                {
                    Name = name,
                    Email = email,
                    Subject = subject,
                    Message = message
                };

                var response = await _appApiContactService.CreateContact(request);

                return Json(new { Code = "0200", Message = "Successfully.", Data = response });

            });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}