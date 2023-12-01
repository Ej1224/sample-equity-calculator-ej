using ApplicationCore.LoanModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquityCalculator.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        [HttpGet]
        public LoanModel AddLoan(decimal sellingPrice,
                                 DateOnly reserveDate,
                                 int equityTerm)
        {
            decimal rounded_selling_price = Math.Round(sellingPrice, 2);
            LoanModel loanModel = new LoanModel();
            loanModel.sellingPrice = rounded_selling_price;
            loanModel.reserveDate = reserveDate;
            loanModel.equityTerm = equityTerm;

            decimal monthlyAmount = rounded_selling_price / equityTerm;
            decimal monthlyBalance = rounded_selling_price;
            DateOnly dueDate;

            for (int i = 0; i < equityTerm; i++)
            {
                monthlyBalance -= monthlyAmount;
                dueDate = reserveDate.AddMonths(i + 1);
                int termNo = i + 1;
                decimal interest = monthlyBalance * 0.05M;
                decimal insurance = monthlyAmount * 0.01M;

                LoanDetails loanDetails = new LoanDetails();
                loanDetails.loanBalance = Math.Round(monthlyBalance, 2);
                loanDetails.dueDate = dueDate;
                loanDetails.termNo = termNo;
                loanDetails.monthlyAmount = Math.Round(monthlyAmount, 2);
                loanDetails.interest = Math.Round(interest, 2);
                loanDetails.insurance = Math.Round(insurance, 2);

                loanModel.AddLoanDetails(loanDetails);
            }

            return loanModel;
        }
    }
}
