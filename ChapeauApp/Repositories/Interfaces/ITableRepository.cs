using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface ITableRepository
    {
        List<Table> GetAllTables();
        Table GetTableById(int id);
        Table UpdateTableStatus(Table table);
        Table? GetTableByTableNumber (int tableNumber);
    }
}
