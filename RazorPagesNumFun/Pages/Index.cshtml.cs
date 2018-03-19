using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesNumFun.Data;

namespace RazorPagesNumFun.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int UserInput
        {
            set;
            get;
        }

        [TempData]
        public String Primes { get; set; }

        [TempData]
        public String Prime { get; set; }

        [TempData]
        public String Perfect { get; set; }

        [TempData]
        public String Squareful { get; set; }

        [TempData]
        public String Squarefull { get; set; }

        [TempData]
        public String Palindrome { get; set; }

        [TempData]
        public int CheckNum { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            CheckNum = UserInput;
            if (FunNum.IsPrime(CheckNum))
                Prime = "Yes";
            else
                Prime = "No";
            if (FunNum.IsPerfect(CheckNum))
                Perfect = "Yes";
            else
                Perfect = "No";
            if (FunNum.IsSquareful(CheckNum))
                Squareful = "Yes";
            else
                Squareful = "No";
            if (FunNum.IsSquarefull(CheckNum))
                Squarefull = "Yes";
            else
                Squarefull = "No";
            if (FunNum.IsPalindromic(CheckNum))
                Palindrome = "Yes";
            else
                Palindrome = "No";
            Primes = FunNum.PrimeFactorsString(CheckNum);

            return RedirectToPage();
        }
    }
}
