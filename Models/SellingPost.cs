using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dog7.Models{
    public class SellingPost {
  [Key]
  public int sellingPostId {get;set;} //pk label="sellingPost"
  public int genderId {get;set;} //fk="Gender"  show="genderName" label="ชื่อสายพันธ์ุ"
  public Gender gender {get;set;} //np select="genderName"
  public int breedId {get;set;} //fk="Breed"  show="breedNameEng&breedNameThai" label="เพศ"
  public Breed breed {get;set;} //np select="breedNameEng&breedNameThai"
  public int sellerId {get;set;} //fk="Seller"  show="farmName"
  public Seller seller {get;set;} //np select="farmName"
  public int price {get;set;} //label="ราคา"
  public string sellingPostName {get;set;} //label="หัวข้อโพสต์"
  public string sellingPostDescription {get;set;} //label="คำอธิบายเพิ่มเติม"
  public DateTime dateOfBirth {get;set;} //label="วันเกิดของน้องหมา"
  public int pedegree {get;set;} //label="สามารถออกใบเพ็ดดีกรีให้ลูกค้าได้มั้ย"
  public DateTime sellingPostPostingDateTime {get;set;} //label="sellingPostPostingDateTime"
  public DateTime sellingPostPostExpiredDate {get;set;} //label="sellingPostPostExpiredDate"
  public int postLike {get;set;} //label="จำนวนไลค์"
  public int view {get;set;} //label="จำนวนครั้งที่คนเข้ามาดู"
  public string sellingPostPic1 {get;set;} //label="รูปที่1" dir="sellingPostPic" file
  public string sellingPostPic2 {get;set;} //label="รูปที่2" dir="sellingPostPic" file
  public string sellingPostPic3 {get;set;} //label="รูปที่3" dir="sellingPostPic" file
  public string sellingPostPic4 {get;set;} //label="รูปที่4" dir="sellingPostPic" file
  public string sellingPostPic5 {get;set;} //label="รูปที่5" dir="sellingPostPic" file
  public DateTime sellingPostPicUpdateDateTime {get;set;} //label="sellingPostPicUpdateDateTime"
  }//ec
}//en