using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dog7.Models{
    public class ExpiredSellingPost {
        public ExpiredSellingPost(int sellingPostId, string gender, string breed, int sellerId, string farmName, int price, string sellingPostName, string sellingPostDescription, DateTime dateOfBirth, string pedegree, DateTime sellingPostPostingDateTime, DateTime sellingPostPostExpiredDate, int postLike, int view, DateTime sellingPostPicUpdateDateTime)
        {
            this.sellingPostId = sellingPostId;
            this.gender = gender;
            this.breed = breed;
            this.sellerId = sellerId;
            this.farmName = farmName;
            this.price = price;
            this.sellingPostName = sellingPostName;
            this.sellingPostDescription = sellingPostDescription;
            this.dateOfBirth = dateOfBirth;
            this.pedegree = pedegree;
            this.sellingPostPostingDateTime = sellingPostPostingDateTime;
            this.sellingPostPostExpiredDate = sellingPostPostExpiredDate;
            this.postLike = postLike;
            this.view = view;
            this.sellingPostPicUpdateDateTime = sellingPostPicUpdateDateTime;
        }

        [Key]
  public int ExpiredSellingPostId {get;set;}
  public int sellingPostId {get;set;} 
  public string gender {get;set;} 
  public string breed {get;set;} 
  public int sellerId {get;set;} 
  public string farmName {get;set;} 
  public int price {get;set;} 
  public string sellingPostName {get;set;}
  public string sellingPostDescription {get;set;} 
  public DateTime dateOfBirth {get;set;} 
  public string pedegree {get;set;} 
  public DateTime sellingPostPostingDateTime {get;set;} 
  public DateTime sellingPostPostExpiredDate {get;set;} 
  public int postLike {get;set;}
  public int view {get;set;} 
  public DateTime sellingPostPicUpdateDateTime {get;set;} 
  }//ec
}//en