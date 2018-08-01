using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum EventType : int { Golf = 1, Bowling, AmusmentPark, Concert, Other }

    public class Outings
    {
        public Outings() {}
        public Outings(EventType category, int numPpl, string date, decimal totalCostPerson, decimal totalEventCost)
        {
            Category = category;
            NumPpl = numPpl;
            DateOfEvent = date;
            PerPersonCost = totalCostPerson;
            TotalEventCost = totalEventCost;
        }

        public EventType Category { get; set; }
        public int NumPpl { get; set; }
        public string DateOfEvent { get; set; }
        public decimal PerPersonCost { get; set; }
        public decimal TotalEventCost { get; set; }
    }
}
