using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Offers.Consumer.Data;

namespace Offers.Consumer.Abstractions
{
    public interface ICustomerWriterService
    {
        bool WriteToRedis(IList<Customer> customers);
    }
}