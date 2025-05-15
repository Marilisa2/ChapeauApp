using ChapeauApp.Models;

namespace ChapeauApp.Services.Interfaces
{
    public interface ITableService
    {
        public List<Table> GetAllTables();
        public Table GetTableById(int id);
        public Table UpdateTableStatus(Table table);
    }
}
