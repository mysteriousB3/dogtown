using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace dog7.Models{
    public class TheUser:IdentityUser<int>{
  [Key]
  public int userId {get;set;} //pk label="user"
  public string firstName {get;set;} //label="ชื่อจริง"
  public string lastName {get;set;} //label="นามสกุล"
  public string PhoneNumber {get;set;} //label="เบอร์"
  public string Email {get;set;} //label="อีเมล"
  public DateTime userRegistrationDateTime {get;set;} //label="เวลาที่สมัครเป็นผู้ใช้งาน"
  public int otp {get;set;} //label="otp"
  public int isSeller {get;set;} //label="เป็นผู้ขายหรือยัง"
  public string password {get;set;} //label="รหัสผ่าน"

}//ec
}//en