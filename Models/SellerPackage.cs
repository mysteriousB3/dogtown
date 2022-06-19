using System;
using System.ComponentModel.DataAnnotations;
using dog7.Models;

namespace dog7.Models{
    public class SellerPackage {
  [Key]
  public int sellerPackageId {get;set;} //pk label="sellerPackage"
  public int packageDetailId {get;set;} //fk="PackageDetail"  show="packageDetailName" label="ชื่อแพ็กเกจ"
  public PackageDetail packageDetail {get;set;} //np select="packageDetailName"
  public DateTime packageBuyingDateTime {get;set;} //label="วันและเวลาที่ซื้อแพ็กเกจ"
  public DateTime packageStartingDateTime {get;set;} //label="วันและเวลาที่แพ็กเกจได้รับอนุญาต"
  public DateTime packageEndingDateTime {get;set;} //label="วันและเวลาที่แพ็กเกจหมดอายุ"
  public int totalPackagePurchase {get;set;} //label="จำนวนเงินที่ต้องชำระ"
  public string paymentEvidence {get;set;} //label="หลักฐานในการชำระเงิน" dir="evidencePic" file
  public int packageStatus {get;set;} //label="อนุญาตเริ่มใช้แพ็กเกจ"
  public int totalPostAvailable {get;set;} //label="จำนวนโพสมีอยู่"
  public int sellerId {get;set;}
  public Seller seller {get;set;}

}//ec
}//en