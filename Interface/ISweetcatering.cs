using adminautentication.Models;
using MongoDB.Driver;

namespace adminautentication.Interface
{
    public interface ISweetcatering
    {

        MongoClient _mongoClient { get; }
        IMongoDatabase _database { get; }
        IMongoCollection<CustomerEntity> _collection { get; }

        IEnumerable<CustomerEntity> GetAllCustomers();

        CustomerEntity GetCustomerdetail(string FullName);

        void Create(CustomerEntity customerData);
        void Update(string _id, CustomerEntity customerData);

        void Delete(string FullName);



    }
}
