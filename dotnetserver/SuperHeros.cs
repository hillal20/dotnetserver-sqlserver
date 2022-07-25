using System;
namespace dotnetserver
{
    public class SuperHeros
    {
        public SuperHeros(int id , String name, String city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
    }
}

