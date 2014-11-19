using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspWithMongo
{
    public class PersonModel
    {
        public MongoDB.Bson.BsonObjectId id { get; set; }
        public string name { get; set; }
        public string languages { get; set; }
        public string country { get; set; }
    }
}
