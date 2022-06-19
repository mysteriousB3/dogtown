using System.ComponentModel.DataAnnotations;

namespace dog7.Models{
    public class Gender {
  [Key]
  public int genderId {get;set;} //pk label="gender"
  public string genderName {get;set;} //label="เพศ"

}//ec
}//en