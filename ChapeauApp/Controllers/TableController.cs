using ChapeauApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class TableController:Controller
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
