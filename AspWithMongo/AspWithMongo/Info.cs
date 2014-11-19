using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspWithMongo
{
    public class Info
    {
        public ObjectId _id { get; set; }
        public string personId { get; set; }
        public string Name { get; set; }
    }
}