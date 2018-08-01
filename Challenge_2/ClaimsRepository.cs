using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimsRepository
    {
        //Fields
        private Queue<Claims> _claimsQueue = new Queue<Claims>();
        private bool _isValid;

        //Methods
        public Queue<Claims> GetClaims()
        {
            return _claimsQueue;
        }

        public void AddClaimToQueue(Claims claim)
        {
            _claimsQueue.Enqueue(claim);
        }
        
        public Queue<Claims> RemoveQueueItem()
        {
            _claimsQueue.Dequeue();
            return _claimsQueue;
        }

        public bool GetBoolean(Claims claim)
        {
             TimeSpan TimeSinceIncident = Convert.ToDateTime(claim.ClaimDate) - Convert.ToDateTime(claim.IncidentDate);

            bool IsValid;
            if (TimeSinceIncident.Days <= 30)
            {
                _isValid = true;
            }
            else _isValid = false;

            IsValid= _isValid;
            return IsValid;
        }
    }
}
