using System;

namespace microServiceTwo.Domain
{
    public class User
    {
        public int Id{get;set;}
        public string UserName{get;set;}
        public string Password{get;set;}="111111";
        public bool Deleted{get;set;}
        public DateTime CreatedTime{get;set;}
    }
}