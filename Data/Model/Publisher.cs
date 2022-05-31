using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Data.Model
{
    public class Publisher
    {
        public int Id{ get; set; }
        public string Name { get; set; }

        // Creating a Relationship with the Book Model
        public List<Book> Books { get; set; }
    }
}
