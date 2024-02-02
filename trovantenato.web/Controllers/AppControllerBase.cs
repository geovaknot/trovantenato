using Microsoft.AspNetCore.Mvc;
using Trovantenato.Web.Common.Exceptions;

namespace Trovantenato.Web.Controllers
{
    public abstract class AppControllerBase : Controller
    {
        protected readonly ILogger _logger;

        protected AppControllerBase(
            ILogger logger)
        {
            _logger = logger;
        }

        protected async Task<IActionResult> AsyncHandler(Func<Task<IActionResult>> requestHandler)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogDebug("Iniciando a execução");
                    IActionResult ret = await requestHandler();
                    _logger.LogDebug("Finalizando a execução");

                    return ret;
                }
                else
                {
                    return View();
                }
            }

            catch (DomainException dex)
            {
                _logger.LogInformation(dex.Message, dex);

                if (dex.ErrorCode == "0401" || dex.ErrorCode == "0403")
                {
                    TempData["warning"] = $"{dex.ErrorCode} - {dex.Message}";
                    HttpContext.Session.Clear();
                    return RedirectToAction("login", "authentication", new { returnUrl = HttpContext.Request.Path });
                }

                TempData["error"] = $"{dex.ErrorCode} - {dex.Message}";

                return RedirectToAction("error", "home");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["error"] = $"0500 - Error processing your request.";

                return RedirectToAction("error", "home");
            }
        }

        protected async Task<IActionResult> AsyncHandler<TParam>(Func<TParam, Task<IActionResult>> requestHandler, TParam param)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _logger.LogDebug("Iniciando a execução");
                    IActionResult ret = await requestHandler(param);
                    _logger.LogDebug("Finalizando a execução");

                    return ret;
                }
                else
                {
                    _logger.LogError("ModelState: Invalid");

                    return View(param);
                }
            }
            catch (DomainException dex)
            {
                _logger.LogInformation(dex.Message, dex);
                TempData["error"] = $"{dex.ErrorCode} - {dex.Message}";

                if (dex.ErrorCode == "0401" || dex.ErrorCode == "0403")
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("login", "authentication");
                }

                return View(param);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                TempData["error"] = $"0500 - Error processing your request.";

                return RedirectToAction("error", "home");
            }
        }

        protected async Task<JsonResult> AsyncHandler(Func<Task<JsonResult>> requestHandler)
        {
            try
            {
                _logger.LogDebug("Iniciando a execução");
                JsonResult ret = await requestHandler();
                _logger.LogDebug("Finalizando a execução");

                return ret;
            }
            catch (DomainException dex)
            {
                _logger.LogInformation(dex.Message, dex);

                if (dex.ErrorCode == "0401" || dex.ErrorCode == "0403")
                {
                    HttpContext.Session.Clear();
                }

                return Json(new { Code = dex.ErrorCode, dex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Json(new { Code = "0500", Message = "Error processing your request." });
            }
        }

        protected async Task<JsonResult> AsyncHandler<TParam>(Func<TParam, Task<JsonResult>> requestHandler, TParam param)
        {
            try
            {

                _logger.LogDebug("Iniciando a execução");
                JsonResult ret = await requestHandler(param);
                _logger.LogDebug("Finalizando a execução");

                return ret;

            }
            catch (DomainException dex)
            {
                return Json(new { Code = dex.ErrorCode, dex.Message });
            }
            catch (Exception)
            {
                return Json(new { Code = "0500", Message = "Error processing your request." });
            }
        }
    }
}
