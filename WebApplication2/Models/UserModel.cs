using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace WebApplication2
{
    
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
    public class UserModel
    {
        IMongoCollection<UserSchema> userCollection;
        public UserModel() //constructor 
        {
            userCollection = MongoContext.db.GetCollection<UserSchema>("user");
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
        public UserSchema Query(string username)
        {
            var results = userCollection.Find(x => x.username == username).ToList();
            if (results.Count > 0)
            {
                return results[0];
            }
            else
            {
                return null;
            }
            
        }
        public void Update(UserSchema user)
        {
            var filter = Builders<UserSchema>.Filter.Eq("username", user.username);

            var update = Builders<UserSchema>.Update.Set("updatedAt", System.DateTime.UtcNow);

            update = Builders<UserSchema>.Update.Set("name", user.name);

            var result = userCollection.UpdateOne(filter, update);
        }
        public void Delete(string username)
        {
            userCollection.DeleteOne(Builders<UserSchema>.Filter.Eq("username", username));
        }
    }
}