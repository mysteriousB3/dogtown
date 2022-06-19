using System;
using System.ComponentModel.DataAnnotations;
using dog7.Data;

namespace dog7.Models
{

    public class Seller {
  [Key]
  public int sellerId {get;set;} //pk label="seller"
  public int userId {get;set;} //fk="User"  show="firstName&lastName" label="ชื่อผู้ใช้งาน"
  public AppUser user {get;set;} //np select="firstName&lastName"
  public string sellerIdCard {get;set;} //label="เลข 13 หลัก บัตรประชาชน"
  public string sellerIdCardFront {get;set;} //label="รูปภาพด้านหน้าของบัตรประชาชน" dir="sellerRegisterPic" file
  public string sellerIdCardBack {get;set;} //label="รูปภาพด้านหลังของบัตรประชาชน" dir="sellerRegisterPic" file
  public string selllerBookBankAccountPic {get;set;} //label="รูปภาพสมุดบัญชีธนาคาร" dir="sellerRegisterPic" file
  public string sellerFarmRegisterPic {get;set;} //label="รูปภาพใบลงทะเบียนฟาร์มสุนัข" dir="sellerRegisterPic" file
  public int farmRegister {get;set;}
  
  public DateTime sellerRegistrationDateTime {get;set;} //label="เวลาในการสมัครเปิดร้าน"
  public DateTime sellerApproveDateTime {get;set;} //label="เวลาในอนุมัติเป็นผู้ขายโดยผู้ดูแลระบบ"

  public string farmName {get;set;}
  public string sellerProfilePic {get;set;}
  public string sellerProfilePhoneNumber {get;set;}
  public string sellerProfileDescription {get;set;}
  public DateTime editProfileDatetime {get;set;}
  public int profileView {get;set;}
  public int totalPost {get;set;}
  public int totalPostView{get;set;}
  public int totalLike {get;set;}

  public int sellerAddressId {get;set;} //fk="SellerAddress"  show="number&tambon&amphoe&street&province" label="ที่อยู่ฟาร์ม"
  public SellerAddress sellerAddress {get;set;} //np select="number&tambon&amphoe&street&province"

}//ec
}//en