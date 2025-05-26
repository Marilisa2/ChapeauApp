using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface ITableService
    {
        public List<TableViewModel> GetAllTables();
        public Table GetTableById(int id);
        public Table UpdateTableStatus(TableViewModel table);
    }
}
