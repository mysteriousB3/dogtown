using System;
using Microsoft.AspNetCore.Identity;

namespace dog7.Data{

    public class AppUser:IdentityUser<int>{
        public string firstName {get;set;} 
        public string lastName {get;set;}
        public DateTime userRegistrationDateTime {get;set;}
        public int isSeller {get;set;}
        public int otp {get;set;}
        public string memo {get;set;}

        public DateTime editInfoDateTime {get;set;}
        public string editInfoMemo {get;set;}
        public DateTime editPasswordDateTime{get;set;}   
        
    }
}