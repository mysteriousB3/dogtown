using dog7.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dog7.Data
{
    public class dog7DbContext : IdentityDbContext<AppUser,AppRole,int>{
         public dog7DbContext(DbContextOptions<dog7DbContext> options):base(options){
            
         }//ef
         protected override void OnModelCreating(ModelBuilder builder)
        {
 
            base.OnModelCreating(builder);
        }

        #region Table mapping
		public DbSet<AppUser> AppUsers {get;set;}
		public DbSet<TheUser> TheUser {get;set;}
		public DbSet<Seller> Seller {get;set;}
		public DbSet<SellerAddress> SellerAddress {get;set;}
		public DbSet<PackageDetail> PackageDetail {get;set;}
		public DbSet<Breed> Breed {get;set;}
		public DbSet<Gender> Gender {get;set;}
		public DbSet<SellingPost> SellingPost {get;set;}
		public DbSet<SellerPackage> SellerPackage {get;set;}
		public DbSet<SellingPostFeedback> SellingPostFeedback {get;set;}
		public DbSet<SellerFeedback> SellerFeedback {get;set;}
		public DbSet<SellerFeedPost> SellerFeedPost {get;set;}
		public DbSet<ExpiredSellingPost> ExpiredSellingPost {get;set;}

		#endregion
        
    
     }//ec
}//en