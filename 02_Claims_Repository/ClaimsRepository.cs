using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims_Repository
{
    //Need to retest and work on Queue,Dequeue and Enqueue -- during testing the N response does not move the next claim forward
    //Will address if I have time prior to turn in. **Work around is to only respond affirmatively
    public class ClaimsRepository
    {
        private readonly Queue<ClaimsContent> _claimsDirectory = new Queue<ClaimsContent>();
        //Add
        public bool AddClaimToDirectory(ClaimsContent claim)
        {
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Enqueue(claim);
            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<ClaimsContent> GetClaims()
        {
            return _claimsDirectory;
        }
        //Update
        public bool UpdateExistingClaim(int originalId, ClaimsContent updatedInfo)
        {
            ClaimsContent oldInfo = GetClaimById(originalId);

            if (oldInfo != null)
            {
                oldInfo.ClaimId = updatedInfo.ClaimId;
                oldInfo.ClaimType = updatedInfo.ClaimType;
                oldInfo.ClaimDescription = updatedInfo.ClaimDescription;
                oldInfo.DollarAmount = updatedInfo.DollarAmount;
                oldInfo.DateOfAccident = updatedInfo.DateOfAccident;
                oldInfo.DateOfClaim = updatedInfo.DateOfClaim;
                oldInfo.IsValid = updatedInfo.IsValid;

                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete old claim
        public bool DeleteOldestClaim()
        {
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Dequeue();
            bool wasDeleted = (_claimsDirectory.Count < startingCount) ? true : false;
            return wasDeleted;
        }

        public ClaimsContent GetClaimById(int id)
            //Needed for UpdateExistingClaim//
        {
            foreach (ClaimsContent claim in _claimsDirectory)
            {
                if (claim.ClaimId.Equals(id))
                {
                    return claim;
                }
            }

            return null;
        }
    }
}

