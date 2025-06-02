using ChapeauApp.Services.Interfaces;
using ChapeauApp.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ChapeauApp.Controllers
{
    using ChapeauApp.Models.ViewModels;
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
            try
            {
                List<TableViewModel> tableViewModels = _tableService.GetAllTables();
                ViewData["place"] = "TableIndex";
                return View(tableViewModels);
            }
            catch (Exception) 
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Update(TableViewModel tableViewModel) 
        {
            ViewData["OldStatus"] = tableViewModel.TableStatus;
            return View(tableViewModel);   
        }
        [HttpPost]
        public IActionResult Update(TableUpdateViewModel tableUpdateViewModel)
        {
            _tableService.UpdateTableStatus(tableUpdateViewModel);
            return RedirectToAction("Index");
        }
    }
}
