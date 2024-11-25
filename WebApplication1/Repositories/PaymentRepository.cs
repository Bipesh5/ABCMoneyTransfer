using ABCMoneyTransfer.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace ABCMoneyTransfer.Repositories
{

    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaymentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<Payment> GetAllPayments()
        {
            var query = "SELECT TransferId, SFirstName, RFirstName, TransferAmount, PaymentDate FROM pay_payment";
            return _dbConnection.Query<Payment>(query).AsList();
        }

        public Payment GetPaymentById(int transferId)
        {
            var query = "SELECT * FROM pay_payment WHERE TransferId = @TransferId";
            return _dbConnection.QuerySingleOrDefault<Payment>(query, new { TransferId = transferId });
        }

        public void AddPayment(Payment payment)
        {
            var query = @"
                INSERT INTO pay_payment (
                    SFirstName, SMiddleName, SLastName, SCountry, SAddress,
                    RFirstName, RMiddleName, RLastName, RCountry, RAddress,
                    BankName, AccountNumber, TransferAmount, ExchangeRate,
                    PayoutAmount, PaymentDate
                ) VALUES (
                    @SFirstName, @SMiddleName, @SLastName, @SCountry, @SAddress,
                    @RFirstName, @RMiddleName, @RLastName, @RCountry, @RAddress,
                    @BankName, @AccountNumber, @TransferAmount, @ExchangeRate,
                    @PayoutAmount, @PaymentDate
                )";
            _dbConnection.Execute(query, payment);
        }

        public List<Payment> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.Date.AddDays(1).AddMilliseconds(-1);

            string query = @"SELECT * FROM pay_payment 
                     WHERE PaymentDate >= @StartDate AND PaymentDate <= @EndDate";

            return _dbConnection.Query<Payment>(query, new { StartDate = startDate, EndDate = endDate }).AsList();
        }

    }
}
