using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiDotnet.models
{
    public class Genre
    {
        public int Count {get; set;}

        public required List<User> UserList {get; set;}
    }
}