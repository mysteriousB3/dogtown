using System;
using System.ComponentModel.DataAnnotations;
using dog7.Data;

namespace dog7.Models{
    public class SellerFeedback {
  [Key]
  public int sellerFeedbackId {get;set;} //pk label="SellerFeedback"
  public int userId {get;set;} //fk="User"  show="firstName&lastName" label="คนรีวิว"
  public AppUser user {get;set;} //np select="firstName&lastName"
  public DateTime feedbackDateTime {get;set;} //label="เวลาที่รีวิว"
  public int feedbackStar {get;set;} //label="จำนวนดาวที่ให้"
  public string feedbackDescription {get;set;} //label="บทความรีวิว"
  public int sellerId {get;set;} //fk="Seller"  show="sellerId&farmName" label="ฟาร์มที่ถูกรีวิว"
  public Seller seller {get;set;} //np select="sellerId&farmName"

}//ec
}//en