using MongoDB.Driver;
using System.Configuration;

namespace AspWithMongo.Utility
{
    public static class MDDatabase
    {
        public static MongoDatabase retreive_mongohq_db()
        {
           /* string connection = ConfigurationManager.AppSettings["connectionString"];
            var mongoUrl = new MongoUrl(connection);
            var mongoClient = new MongoClient(mongoUrl);
            var mongoServer = mongoClient.GetServer();
            var mongoDatabase = mongoServer.GetDatabase(mongoUrl.DatabaseName); 

            string con_str = ConfigurationManager.ConnectionStrings["mondodbDataBaseConnection"].ConnectionString.ToString();
            return MongoServer.Create(con_str).GetDatabase("test");*/

            MongoServer server = MongoServer.Create(ConfigurationManager.AppSettings["connectionString"]);
            return  server.GetDatabase("test");
        }
    }
}