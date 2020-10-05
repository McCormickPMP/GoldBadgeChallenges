using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    public enum TypeOfClaim
    {
        Car = 1,
        Home,
        Theft
    }

    public class ClaimsContent
    {
        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal DollarAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public ClaimsContent() { }
        public ClaimsContent(int claimId, TypeOfClaim type, string claimDescription, decimal dollarAmount,
            DateTime dateOfAccident, DateTime dateOfClaim, bool isValid)
        {
            ClaimId = claimId;
            ClaimType = type;
            ClaimDescription = claimDescription;
            DollarAmount = dollarAmount;
            DateOfAccident = dateOfAccident;
            DateOfClaim = dateOfClaim;
            IsValid = isValid;
        }

    }
}
