using System;
using System.ComponentModel.DataAnnotations;
using dog7.Data;

namespace dog7.Models{
    public class SellerAddress {
  [Key]
  public int sellerAddressId {get;set;} //pk label="sellerAddress"
  public string number {get;set;} //label="บ้านเลขที่"
  public string soi {get;set;} //label="ซอย"
  public string moo {get;set;} //label="หมู่"
  public string tambon {get;set;} //label="ตำบล"
  public string amphoe {get;set;} //label="อำเภอ"
  public string street {get;set;} //label="ถนน"
  public string province {get;set;} //label="จังหวัด"
  public string userId {get;set;} //label="รหัสประจำตัวผู้ใช้"
  public string postNumber {get;set;}
  public DateTime changeSellerAddress {get;set;} //label= วันเวลาที่แก้ไข

}//ec
}//en