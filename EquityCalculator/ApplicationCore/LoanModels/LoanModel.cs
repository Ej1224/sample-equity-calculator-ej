using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.LoanModels
{
    public class LoanModel
    {
        public decimal sellingPrice { get; set; }
        public DateOnly reserveDate { get; set; }
        public int equityTerm { get; set; }
        public List<LoanDetails> loanDetails { get; set; } = new List<LoanDetails>();

        //public LoanModel(decimal _sellingPrice,
        //                 DateOnly _reserveDate,
        //                 int _equityTerm)
        //{
        //    sellingPrice = _sellingPrice;
        //    reserveDate = _reserveDate;
        //    equityTerm = _equityTerm;
        //}

        public void AddLoanDetails(LoanDetails _loanDetail)
        {
            loanDetails.Add(_loanDetail);
        }
    }
}
