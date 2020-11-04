using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace MongoDB.University.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("");
            var db = client.GetDatabase("sample_mflix");
            var collection = db.GetCollection<BsonDocument>("movies");
            var result = collection.Find("{ title: 'The Princess Bride' }").FirstOrDefault();
            Console.Write(result);

            var TenthLongestMovie = collection.Find("{}").SortByDescending(m => m["runtime"]).Project(m => m["title"]).Limit(10).ToList();
            Console.Write(TenthLongestMovie[9]);
            Console.WriteLine("Hello World!");
        }
    }
}
