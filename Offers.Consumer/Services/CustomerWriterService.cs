using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Offers.Consumer.Abstractions;
using Offers.Consumer.Data;
using StackExchange.Redis;

namespace Offers.Consumer.Services
{
    public class CustomerWriterService : ICustomerWriterService
    {
        private readonly IConnectionMultiplexer _connection;

        public CustomerWriterService(IConnectionMultiplexer conn)
        {
            _connection = conn;
        }
        
        public bool WriteToRedis(IList<Customer> customers)
        {
            try
            {
                foreach (var customer in customers)
                {
                    _connection.GetDatabase().StringGetSet($"{customer.CustomerId}_type",customer.CustomerType.ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}