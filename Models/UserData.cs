using System;
using System.ComponentModel.DataAnnotations;

namespace WellaApi.Models
{
    public class UserData
    {
        [Key]
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public int Phonenumber {get; set;}
    }
    
}