using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;

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

        public Table UpdateTableStatus(TableViewModel table)
        {
            Table table1=new Table(table.TableNumber,table.TableStatus);
            return _tableRepository.UpdateTableStatus(table1);
        }
    }
}
