using ChapeauApp.Models;
using ChapeauApp.Repositories.Interfaces;

namespace ChapeauApp.Repositories
{
    public class DbBillsRepository : IBillsRepository
    {
        private readonly string? _connectionString;

        public DbBillsRepository(IConfiguration configuration)
        {
            //get database connectionstring from appsettings
            _connectionString = configuration.GetConnectionString("Chapeau");
        }

        public void BillCheckOut(Bill bill)
        {
            throw new NotImplementedException();
        }

        public Bill? GetByBillId(int billId)
        {
            throw new NotImplementedException();
        }
    }
}
