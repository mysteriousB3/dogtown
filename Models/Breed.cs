using System.ComponentModel.DataAnnotations;

namespace dog7.Models{
    public class Breed {
  [Key]
  public int breedId {get;set;} //pk label="breed"
  public string breedNameThai {get;set;} //label="ชื่อสายพันธุ์ภาษาไทย"
  public string breedNameEng{get;set;} //label="ชื่อสายพันธุ์ภาษาอังกฤษ"
  public string breedPic {get;set;} //label="รูปสายพันธ์ุ" dir="dogPic" file
  public string breedDescription {get;set;} //label="คำอธิบายสายพันธ์"
  public int total {get;set;} //label="จำนวนทั้งหมด"

}//ec
}//en