using ABCMoneyTransfer.Models;

namespace ABCMoneyTransfer.Repositories
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayments();
        Payment GetPaymentById(int transferId);
        void AddPayment(Payment payment);
        List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate);

    }
}
