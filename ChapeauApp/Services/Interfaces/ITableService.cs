using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Services.Interfaces
{
    public interface ITableService
    {
        public List<Table> GetAllTables();
        public Table GetTableById(int id);
        public Table UpdateTableStatus(TableViewModel table);
    }
}
