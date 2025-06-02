using ChapeauApp.Models;
using ChapeauApp.Repositories;
using ChapeauApp.Repositories.Interfaces;

namespace ChapeauApp.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public List<Table> GetAllTables()
        {
            return _tableRepository.GetAllTables();
        }

        public Table GetTableById(int id)
        {
            return _tableRepository.GetTableById(id);
        }

        public Table UpdateTableStatus(Table table)
        {
            return _tableRepository.UpdateTableStatus(table);
        }
    }
}
