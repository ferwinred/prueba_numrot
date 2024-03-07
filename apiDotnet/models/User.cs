using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiDotnet.models
{
    public class User
    {
        public int? Id {get; set;}

        public required string FirstName {get; set;}

        public string? SecondName {get; set;}

        public required string FatherLastName {get; set;}

        public string? MotherLastName {get; set;}

        public string? Email {get; set;}

        public string? Phone {get; set;}

        public required string Address {get; set;}

        public required int Age {get; set;}

        public required string Genre {get; set;}

    }
}