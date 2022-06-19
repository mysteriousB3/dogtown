using System.ComponentModel.DataAnnotations;

namespace dog7.Models{
    public class PackageDetail {
  [Key]
  public int packageDetailId {get;set;} //pk label="packageDetail"
  public string packageDetailName {get;set;} //label="ชื่อแพ็กเกจ"
  public int totalPostOfPackage {get;set;} //label="จำนวนโพสต์ของแพ็กเกจ"
  public int periodOfEachSellingPost {get;set;} //label="ระยะเวลาของแต่ละโพส"
  public int totalPeriodOfPackage {get;set;} //label="ระยะเวลาของแพ็กเก็จ"
  public int price {get;set;} //label="ราคา"

}//ec
}//en