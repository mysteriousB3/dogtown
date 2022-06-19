using System.ComponentModel.DataAnnotations;
using dog7.Data;
using dog7.Models;

namespace dog7.Models{
    public class SellingPostFeedback {
  [Key]
  public int sellingPostFeedbackId {get;set;} //pk label="sellingPostFeedback"
  public int userId {get;set;} //fk="User"  show="firstName&lastName" label="คนกดไลค์"
  public AppUser user {get;set;} //np select="firstName&lastName"
  public int sellingPostId {get;set;} //fk="SellingPost"  show="sellingPostId&sellingPostName"
  public SellingPost sellingPost {get;set;} //np select="sellingPostId&sellingPostName"

}//ec
}//en