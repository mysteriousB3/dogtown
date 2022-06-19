using System;
using System.ComponentModel.DataAnnotations;

namespace dog7.Models{
    public class SellerFeedPost {
  [Key]
  public int sellerFeedPostId {get;set;} //pk label="sellerFeedPost"
  public int sellerId {get;set;} //fk="Seller"  show="sellerId" 
  public Seller seller {get;set;} //np select="sellerId"
  public string feedPostPic1 {get;set;} //label="รูปภาพฟีดโพสต์1" dir="feedPostPic" file
  public string feedPostPic2 {get;set;} //label="รูปภาพฟีดโพสต์2" dir="feedPostPic" file
  public string feedPostPic3 {get;set;} //label="รูปภาพฟีดโพสต์3" dir="feedPostPic" file
  public string feedPostPic4 {get;set;} //label="รูปภาพฟีดโพสต์4" dir="feedPostPic" file
  public string feedPostPic5 {get;set;} //label="รูปภาพฟีดโพสต์5" dir="feedPostPic" file
  public DateTime postingDateTime {get;set;} //label="postingDateTime"
  public string description {get;set;} //label="คำบรรยายฟีดโพสต์"

}//ec
}//en