using System;

namespace ABCMoneyTransfer.Models
{
    public class Payment
    {
        public int TransferId { get; set; }
        public string SFirstName { get; set; }
        public string? SMiddleName { get; set; }
        public string SLastName { get; set; }
        public string SCountry { get; set; }
        public string SAddress { get; set; }
        public string RFirstName { get; set; }
        public string? RMiddleName { get; set; }
        public string RLastName { get; set; }
        public string RCountry { get; set; }
        public string RAddress { get; set; }
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal PayoutAmount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
