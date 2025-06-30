using ChapeauApp.Services.Interfaces;
using ChapeauApp.Enums;
using Microsoft.AspNetCore.Mvc;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Controllers
{
   
    public class TablesController : Controller
    {
        private readonly ITableService _tableService;

        public TablesController(ITableService tableService)
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
                TempData["ErrorMessage"] = $"The tables could not be loaded: {ex.Message}.";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpGet]
        public IActionResult Table(int tableNumber)
        {
            try
            {
                TableViewModel tableViewModel = _tableService.GetTableById(tableNumber);
                return View(tableViewModel);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}.";//This message should be updated to give the client a clear idea of what went wrong.
                return RedirectToAction("Index", "Table");
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
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}.";//This message should be updated to give the client a clear idea of what went wrong.
                return RedirectToAction("Index", "Table");
            }
        }
        [HttpPost]
        public IActionResult Update(TableUpdateViewModel tableUpdateViewModel)
        {
            try
            {
                _tableService.UpdateTableStatus(tableUpdateViewModel);
                TempData["Message"] = "TableStatus was succesfully updated.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Something went wrong: {ex.Message}.";//This message should be updated to give the client a clear idea of what went wrong.
                return RedirectToAction("Index", "Table");
            }
        }
    }
}
