using ChapeauApp.Enums;
using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;
using ChapeauApp.Repositories.Interfaces;
using ChapeauApp.Services.Interfaces;
using System.Collections.Generic;

namespace ChapeauApp.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;
        private readonly IOrdersRepository _ordersRepository;

        public TableService(ITableRepository tableRepository, IOrdersRepository ordersRepository)
        {
            _tableRepository = tableRepository;
            _ordersRepository = ordersRepository;
        }

        public TablesViewModel GetAllTables()
        {
            List<Table> tablesWithoutOrders = _tableRepository.GetAllTables();//All tables but without their orders
            
            List <TableViewModel> tableViewModels = new List<TableViewModel>();//All tables with their orders
            foreach (Table table in tablesWithoutOrders)
            {
                List<Order> orders = _ordersRepository.GetOrdersByTableNumber(table.TableNumber);
                Table newTable = new Table(table.TableNumber, table.TableStatus, orders);
                TableViewModel tableViewModel = new TableViewModel(table);
                tableViewModels.Add(tableViewModel);
            }
            TablesViewModel tablesViewModel = new (tableViewModels);
            return tablesViewModel;
        }

        public Table GetTableById(int id)
        {
            return _tableRepository.GetTableById(id);
        }
        public List<Order> GetAllOrders()
        {
            return _ordersRepository.GetAllOrders();
        }
        public List<Order> GetOrdersByTableNumber(int tableNumber)
        {
            return _ordersRepository.GetOrdersByTableNumber(tableNumber);
        }

        public Table UpdateTableStatus(TableUpdateViewModel table)
        {

            Table table1 = new(table.TableNumber,table.NewStatus, GetOrdersByTableNumber(table.TableNumber));
            return _tableRepository.UpdateTableStatus(table1);
        }
    }
}
