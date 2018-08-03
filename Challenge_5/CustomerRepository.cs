using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();
        private Customer customer = new Customer();

        public void AddCustomerToList(Customer customer)
        {
            _customerList.Add(customer);
        }

        public List<Customer> GetCustomerList()
        {
            return _customerList;
        }
    }
}
