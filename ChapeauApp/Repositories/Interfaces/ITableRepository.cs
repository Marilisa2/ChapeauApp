using ChapeauApp.Models;

namespace ChapeauApp.Repositories.Interfaces
{
    public interface ITableRepository
    {
        public List<Table> GetAllTables();
        public Table GetTableById(int id);
        public Table UpdateTableStatus(Table table);
    }
}
