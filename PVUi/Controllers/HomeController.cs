using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ModbusWrapper;

namespace PVUi.Controllers
{
    public class HomeController : Controller
    {
        private IDeyeModbus _deye;
        private readonly IOptionsMonitor<LanguageOptions> _LanguageOptions;
        public HomeController(IDeyeModbus deyeModbus, IOptionsMonitor<LanguageOptions> languageoptions)
        {
            _deye = deyeModbus;
            _LanguageOptions = languageoptions;
        }

        public IActionResult Index()
        {
            ViewBag.PV = _deye.ReadData();
            ViewBag.Language = _LanguageOptions.CurrentValue;
            return View();
        }
    }
}