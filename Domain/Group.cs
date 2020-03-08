using System;

namespace microServiceOne.Domain
{
    public class Customer
    {
        public int Id{get;set;}
        public string Name{get;set;}
        public bool Deleted{get;set;}
        public DateTime CreatedTime{get;set;}
    }
}