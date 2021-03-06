#pragma checksum "C:\Users\parin\web\dog7\Views\TheUser2\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f9243b3fabedde938987176a1a93bd16df62fc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TheUser2_Index), @"mvc.1.0.view", @"/Views/TheUser2/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\parin\web\dog7\Views\_ViewImports.cshtml"
using dog7;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\parin\web\dog7\Views\_ViewImports.cshtml"
using dog7.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f9243b3fabedde938987176a1a93bd16df62fc6", @"/Views/TheUser2/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_TheUser2_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""app1"">
    <v-app>
        <v-main>
            <v-container>
                <v-col cols=""8"">
                    <div style=""text-align: center;"">
                        <span  class=""h1 grey--text"">นโยบาย</span>
                    </div>
                    <br>
                        <ul class=""grey--text h6"">
                            <li>การแก้ไขข้อมูลจะต้องรอ 15 วันหลังจากแก้ไข</li>
                            <li>การแก้ไขรหัสผ่านจะต้องรอ 30 วันหลังจากแก้ไข</li>
                        </ul>
                    <br>
                    
                    <v-card>
                        <v-card-title >
                            <span style=""margin: auto;"" class=""h2 grey--text"">ข้อมูลผู้ใช้</span>
                        </v-card-title>
                        <div style=""margin: 0 0 0 30px;"">
                            <span class=""h4 grey--text"">ชื่อ:</span>
                            <input class=""h4 grey--text inFo"" disabled v-model=""user.firstName"">
       ");
            WriteLiteral(@"                 </div>
                        <div style=""margin: 0 0 0 30px;"">
                            <span class=""h4 grey--text"">นามสกุล:</span>
                            <input class=""h4 grey--text inFo"" disabled v-model=""user.lastName"">
                        </div>
                        <div style=""margin: 0 0 0 30px;"">
                            <span class=""h4 grey--text"">อีเมล:</span>
                            <span id=""emailCheck"" class=""red--text""></span>
                            <input class=""h4 grey--text inFo"" disabled v-model=""user.email"">
                        </div>
                        <div style=""margin: 0 0 0 30px;"">
                            <span class=""h4 grey--text"">เบอร์:</span>
                            <span id=""phoneNumberCheck"" class=""red--text""></span>
                            <input class=""h4 grey--text inFo"" disabled v-model=""user.phoneNumber"">
                        </div>
                        <div style=""text-align: center;"">
 ");
            WriteLiteral("                           <input v-if=\"pullButtonInfo == 1\" style=\"margin: 10px 10px;\" type=\"button\"  class=\"btn btn-danger white--text btn-large col-5\" value=\"ยกเลิกการแก้ไข้ข้อมูล\" ");
            WriteLiteral("@click=\"cancelInfo();\">\r\n                            <input v-if=\"pullButtonInfo == 1\" style=\"margin: 10px 10px;\" type=\"button\" class=\"btn btn-success white--text btn-large col-5\" value=\"ยืนยันการแก้ไขข้อมูล\" ");
            WriteLiteral("@click=\"confirmInfo();\">\r\n\r\n");
            WriteLiteral("                            <input v-if=\"pullButtonInfo == 0\" id=\"changeInfo\" style=\"margin: 10px 10px;\" type=\"button\" class=\"btn success white--text btn-large col-5\" value=\"แก้ไขข้อมูล\" ");
            WriteLiteral("@click=\"changeInFo2();\">\r\n                            <input v-if=\"pullButtonInfo == 0\" style=\"margin: 10px 10px;\" type=\"button\" class=\"btn success white--text btn-large col-5\" value=\"แก้ไขรหัสผ่าน\" ");
            WriteLiteral("@click=\"changePassword()\">\r\n                            <br>\r\n                            <input  style=\"margin: 10px 10px;\" type=\"button\" class=\"btn red white--text btn-large col-5\" value=\"ยกเลิกบัญชีผู้ใช้งาน\" ");
            WriteLiteral("@click=\"deactivateUser()\">\r\n                        </div>\r\n                    </v-card>\r\n                </v-col>\r\n            </v-container>\r\n        </v-main>\r\n    </v-app>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var component ={
            vuetify : new Vuetify(theme())
            ,
            el:""#app1""
            ,
            data:{
                user:{},
                today:"""",

                eInfo:"""",
                ePass:"""",

                cInfo:"""",
                cPass:"""",

                pullButtonInfo:0,

                //original content
                oF:"""",
                oL:"""",
                oE:"""",
                oP:"""",

                pass1:0,
                pass6:0
            }//edata
            ,
            methods:{
                //to pull button to edit info
                changeInFo2(){
                    //get all element to remove disabled
                    var listInfo = document.querySelectorAll("".inFo"")
                    for(var i of listInfo){
                        i.removeAttribute(""disabled"");
                        i.classList.remove(""grey--text"");
                        i.classList.add(""bossBo");
                WriteLiteral(@"rder"");
                        this.pullButtonInfo = 1;
                    }//eloop
                }//ef
                ,
                //to cancel change in info
                cancelInfo(){
                    //first method just refresh the page
");
                WriteLiteral(@"
                    //second method assign back to its original value
                    this.user.lastName      = this.oL
                    this.user.firstName     = this.oF
                    this.user.email         = this.oE
                    this.user.phoneNumber   = this.oP
                    
                    //disabled input
                    var listInfo = document.querySelectorAll("".inFo"")
                    for(var i of listInfo){
                        i.setAttribute(""disabled"",""disabled"");
                        i.classList.add(""grey--text"");
                        i.classList.remove(""bossBorder"");
                        this.pullButtonInfo = 0;
                    }//eloop
                    var checkMemo = """";
                }//ef
                ,
                confirmInfo(){
                    var checkMemo = """";
                    if(this.oF != this.user.firstName){
                        checkMemo+= ""first name ""
                    }//econ
   ");
                WriteLiteral(@"                 if(this.oL != this.user.lastName){
                        checkMemo+=""last name ""
                    }//econ
                    if(this.oE != this.user.email){
                        checkMemo+=""email ""
                    }//econ
                    if(this.oP != this.user.phoneNumber){
                        checkMemo+=""phone number""
                    }//econ

                    var sign = """);
                WriteLiteral(@"@"";
                    sign = sign[0];
                    //check email completeness
                    if(this.user.email.indexOf(sign)==-1){
                        document.querySelector(""#emailCheck"").innerHTML=""รูปแบบของอีเมลไม่ถูกต้อง"";
                        this.pass1=0;
                    }//econ
                    else if(this.user.email.indexOf(sign)!=-1){
                        document.querySelector(""#emailCheck"").innerHTML="""";
                        this.pass1=1;
                    }//econ
                    if(this.user.phoneNumber == undefined || this.user.phoneNumber.length !=10){
                        document.querySelector(""#phoneNumberCheck"").innerHTML=""กรุณาตรวจสอบความถูกต้องหรือความสมบูรณ์ของเบอร์โทรศัพท์"";
                        this.pass6=0;
                    }//econ

                    if(this.user.phoneNumber != undefined && this.user.phoneNumber.length ==10){
                        
                        if(this.user.phoneNumber[0]!=""0""){
      ");
                WriteLiteral(@"                      document.querySelector(""#phoneNumberCheck"").innerHTML=""กรุณาตรวจสอบความถูกต้องหรือความสมบูรณ์ของเบอร์โทรศัพท์"";
                            this.pass6=0;
                            return;
                        }//econ
                        this.user.phoneNumber = parseInt(this.user.phoneNumber);
                        this.user.phoneNumber = this.user.phoneNumber.toString()
                        
                        if(this.user.phoneNumber==""NaN""){
                            document.querySelector(""#phoneNumberCheck"").innerHTML=""กรุณาตรวจสอบความถูกต้องหรือความสมบูรณ์ของเบอร์โทรศัพท์"";
                            this.pass6=0;
                            this.user.phoneNumber = undefined;
                        }//econ
                        else{
                            this.user.phoneNumber = ""0"" + this.user.phoneNumber.toString()
                            document.querySelector(""#phoneNumberCheck"").innerHTML="""";
                            this.pas");
                WriteLiteral(@"s6=1;
                        }
                    }//econ
                    if(this.pass1 != 1 || this.pass6 != 1){
                        alert(""ข้อมูลยังไม่ถูกต้อง"")
                        return;
                    }//econ

                    var param ={id:this.user.id,editInfoMemo:checkMemo,firstName:this.user.firstName,lastName:this.user.lastName
                                ,email:this.user.email,phoneNumber:this.user.phoneNumber
                    }
                    console.log(param)
                    $.post(""/TheUser2/ConfirmInfo"",param).done(res=>{
                       alert(res.message);
                       location = ""/TheUser2""
                    })

                }//ef
                ,
                changePassword(){
                    location = ""/TheUser2/Changepassword/""+ this.user.id;
                }//ef
                ,
                deactivateUser(){
                    if(confirm(""กด OK เพื่อยกเลิกบัญชีผู้ใช้งาน"")==true){
       ");
                WriteLiteral(@"                 $.post(""/Seller2/DeactivateUser"",this.user).done(res=> {
                            if(res.error ==-1){
                                alert(""ยกเลิกบัญชีผู้ใช้เรียบร้อย"");
                                location=""/Security/logout"";
                            }
                            else{
                                alert(res.exception);
                            }
                        })
                    }//econ
                }//ef
            }//emethods
            ,
            created(){
                this.today  = ");
#nullable restore
#line 206 "C:\Users\parin\web\dog7\Views\TheUser2\Index.cshtml"
                         Write(Html.Raw(Json.Serialize(@ViewBag.today)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n                this.user   = ");
#nullable restore
#line 207 "C:\Users\parin\web\dog7\Views\TheUser2\Index.cshtml"
                         Write(Html.Raw(Json.Serialize(@ViewBag.user)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                
                //find differences in day between dates
                var today = new Date(this.today);
                var infoDate = new Date(this.user.editInfoDateTime);
                var diffTime = Math.abs(today-infoDate);
                this.cInfo = Math.ceil(diffTime/(1000*60*60*24));
                console.log(this.cInfo)
                
                

                //assign original content
                this.oF = this.user.firstName;
                this.oL = this.user.lastName;
                this.oE = this.user.email;
                this.oP = this.user.phoneNumber;
                console.log(this.user)
            }//ecreated
            ,
            mounted(){
                //set the einfo to allow user to change info 15 day interval
                if(this.user.editInfoDateTime.substr(0,4)== ""0001""){
                    this.cInfo == 16;
");
                WriteLiteral(@"                }//econ
                else if(this.user.editInfoDateTime.substr(0,4) != ""0001""){
                    if(this.cInfo <15){
                        document.getElementById(""changeInfo"").setAttribute(""disabled"",""disabled"")
                    }
                }//econ
                
                
            }
            
        }//ecomponent
        var app = new Vue(component);
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
