using Microsoft.AspNetCore.Identity;

namespace dog7.Data{

    public class AppRole:IdentityRole<int>{
 
        public AppRole(string Name):base(Name){}
        
    }
}