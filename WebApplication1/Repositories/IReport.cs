using ABCMoneyTransfer.Models;

namespace ABCMoneyTransfer.Repositories
{
    public interface IReport
    {
        List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate);

    }
}
