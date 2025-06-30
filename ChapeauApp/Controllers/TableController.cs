using ChapeauApp.Services.Interfaces;
using ChapeauApp.Enums;
using Microsoft.AspNetCore.Mvc;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Controllers
{
   
    public class TableController : Controller
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
                TablesViewModel tablesViewModels = _tableService.GetAllTables();
                ViewData["place"] = "TableIndex";
                return View(tablesViewModels);
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"The tables could not be loaded: {ex.Message}.";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Update(TableViewModel tableViewModel) 
        {
            try
            {
                ViewData["OldStatus"] = tableViewModel.TableStatus;
                return View(tableViewModel);
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Something went wrong: {ex.Message}.";//This message should be update to give the client a clear idea of what went wrong.
                return RedirectToAction("Index", "Table");
            }
        }
        [HttpPost]
        public IActionResult Update(TableUpdateViewModel tableUpdateViewModel)
        {
            try
            {
                _tableService.UpdateTableStatus(tableUpdateViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Something went wrong: {ex.Message}.";//This message should be update to give the client a clear idea of what went wrong.
                return RedirectToAction("Index", "Table");
            }
        }
    }
}
