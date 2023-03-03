using adminautentication.Interface;
using adminautentication.Models;
using MongoDB.Driver;

namespace adminautentication.Data
{
    public class SweetcateringDBContext : ISweetcatering
    {

        public MongoClient _mongoClient => new MongoClient("mongodb://127.0.0.1:27017");

        public IMongoDatabase _database => _mongoClient.GetDatabase("Sweetcatering");
        public IMongoCollection<CustomerEntity> _collection => _database.GetCollection<CustomerEntity>("customers");


        public IEnumerable<CustomerEntity> GetAllCustomers()
        {
            return _collection.Find(a => true).ToList();
        }

        public CustomerEntity GetCustomerdetail(string FullName)
        {
            var customerdetails = _collection.Find(m => m.FullName == FullName).FirstOrDefault();

            return customerdetails;
        }

        public void Create(CustomerEntity customerData)
        {
            _collection.InsertOne(customerData);
        }

        public void Update(string Id, CustomerEntity customerData)
        {
            var filter = Builders<CustomerEntity>.Filter.Eq(c => c.Id, Id);
            var update = Builders<CustomerEntity>.Update
                .Set("FullName", customerData.FullName)
                .Set("Phonenumber ", customerData.Phonenumber)

                .Set("Dateofevent", customerData.Dateofevent)

                .Set("Eventlocation", customerData.Eventlocation)
                .Set("Typeofevent", customerData.Typeofevent)
                .Set("Numberofguest", customerData.Numberofguest);
                
            _collection.UpdateOne(filter, update);
        }




        public void Delete(string FullName)
        {
            var filter = Builders<CustomerEntity>.Filter.Eq(c => c.FullName, FullName);

            _collection.DeleteOne(filter);
        }





    }

}
