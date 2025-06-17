using ChapeauApp.Enums;
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

        public List<TableViewModel> GetAllTables()
        {
            List<Table> tables= _tableRepository.GetAllTables();
            List<TableViewModel> tableViewModels = new List<TableViewModel>();
            foreach (var table in tables) 
            { 
                TableViewModel tableViewModel = new TableViewModel(table);
                tableViewModels.Add(tableViewModel);
            }
            return tableViewModels;
        }

        public Table GetTableById(int id)
        {
            return _tableRepository.GetTableById(id);
        }

        public Table UpdateTableStatus(TableUpdateViewModel table)
        {

            Table table1=new Table(table.TableNumber,table.NewStatus);
            return _tableRepository.UpdateTableStatus(table1);
        }
    }
}
