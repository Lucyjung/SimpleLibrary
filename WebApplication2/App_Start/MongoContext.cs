using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication2
{
    public class MongoContext
    {
        MongoClient client;
        public static IMongoDatabase db;
        string connectionString = "mongodb://127.0.0.1";

        public MongoContext()        //constructor   
        {
            client = new MongoClient(connectionString);
            db = client.GetDatabase("variables");           
        }
    }
}