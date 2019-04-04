using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication2
{
    public class MongoContext
    {
        MongoClient client;
        IMongoDatabase db;
        string connectionString = "mongodb://10.164.232.31";
        IMongoCollection<UserSchema> userCollection;
        public class UserSchema
        {
            [BsonId]
            public ObjectId _id { get; set; }

            public string name { get; set; }
            public string username { get; set; }
            public string role { get; set; }
            public string password { get; set; }
            public string avatarFd { get; set; }
            public BsonDateTime createdAt { get; set; }
            public BsonDateTime updatedAt { get; set; }
        }
        public MongoContext()        //constructor   
        {
            
            client = new MongoClient(connectionString);
            db = client.GetDatabase("variables");
            userCollection = db.GetCollection<UserSchema>("user");
           
        }
        public void Create()
        {
            UserSchema newUser = new UserSchema();
            newUser.username = "0999";
            newUser.name = "Prayut";
            newUser.role = "ROLE-USER";
            newUser.password = "1234";
            newUser.avatarFd = "";
            var utcNow = System.DateTime.UtcNow;
            newUser.createdAt = new BsonDateTime(utcNow);
            newUser.updatedAt = new BsonDateTime(utcNow);
            userCollection.InsertOne(newUser);

        }
        public void Query()
        {
            var results = userCollection.Find(x => x.username == "0251").ToList();
        }
    }
}