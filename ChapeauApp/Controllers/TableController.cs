using ChapeauApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    public class TableController
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
