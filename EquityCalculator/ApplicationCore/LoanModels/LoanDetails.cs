using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.LoanModels
{
    public class LoanDetails
    {
        public decimal loanBalance { get; set; }
        public DateOnly dueDate { get; set; }
        public int termNo { get; set; }
        public decimal monthlyAmount { get; set; }
        public decimal interest { get; set; }
        public decimal insurance { get; set; }

        //public LoanDetails(decimal _loanBalance,
        //                   DateOnly _dueDate,
        //                   int _termNo,
        //                   decimal _monthlyAmount,
        //                   decimal _interest,
        //                   decimal _insurance)
        //{
        //    loanBalance = _loanBalance;
        //    dueDate = _dueDate;
        //    termNo = _termNo;
        //    monthlyAmount = _monthlyAmount;
        //    interest = _interest;
        //    insurance = _insurance;
        //}
    }
}
