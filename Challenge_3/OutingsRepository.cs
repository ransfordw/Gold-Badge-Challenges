using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{

    public class OutingsRepository
    {
        private List<Outings> _outingsList = new List<Outings>();
        private List<Decimal> _totalCostList = new List<decimal>();

        public List<Outings> GetList()
        {
            return _outingsList;
        }

        public List<Decimal> GetDecimalList()
        {
            return _totalCostList;
        }

        public void AddToList(Outings outing)
        {
            _outingsList.Add(outing);
        }

        public void AddToCostList (decimal totalEventCost)
        {
            _totalCostList.Add(totalEventCost);
        }
    }
}
