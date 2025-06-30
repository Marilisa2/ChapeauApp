using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface ITableService
    {
        public TablesViewModel GetAllTables();
        public Table GetTableById(int id);
        public Table UpdateTableStatus(TableUpdateViewModel table);
    }
}
