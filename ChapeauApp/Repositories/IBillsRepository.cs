using ChapeauApp.Models;
using ChapeauApp.Models.ViewModels;

namespace ChapeauApp.Repositories
{
    public interface IBillsRepository
    {
        Bill? GetByBillId(int billId);
        public void BillCheckOut (Bill bill);

    }
}
