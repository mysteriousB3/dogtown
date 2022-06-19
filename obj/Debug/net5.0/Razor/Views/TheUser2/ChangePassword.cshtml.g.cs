#pragma checksum "C:\Users\parin\web\dog7\Views\TheUser2\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21b5641152e024fc7ab739bc3fa4ae3d000ab1ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TheUser2_ChangePassword), @"mvc.1.0.view", @"/Views/TheUser2/ChangePassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"21b5641152e024fc7ab739bc3fa4ae3d000ab1ae", @"/Views/TheUser2/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_TheUser2_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
                            <span style=""margin: auto;"" class=""h2 grey--text"">เปลี่ยนรหัสผ่าน</span>
                            
                        </v-card-title>
                        <div style=""margin: 0 0 0 30px;"">
                            <span id=""error"" class=""red--text h6""></span>
                            <br>
                            <span");
            WriteLiteral(@" class=""h4 grey--text cp"">รหัสผ่านปัจจุบัน</span>
                            <input class=""h4 grey--text inFo bossBorder"" v-model=""changePassword.currentPassword"">
                        </div>
                        <div style=""margin: 0 0 0 30px;"">
                            <span class=""red--text h6 nnp""></span><br>
                            <span class=""h4 grey--text np"">รหัสผ่านใหม่</span>
                            <input class=""h4 grey--text inFo bossBorder"" v-model=""changePassword.newPassword"">
                        </div>
                        <div style=""margin: 0 0 0 30px;"">
                            <span class=""h4 grey--text cnp"">ยืนยันรหัสผ่านใหม่</span>
                            <input class=""h4 grey--text inFo bossBorder"" v-model=""comfirmPassword"">
                        </div>
                        <div style=""text-align: center;"">
                            <input id=""cc"" style=""margin: 10px 10px;"" type=""button""  class=""btn btn-danger white--text btn-large col");
            WriteLiteral("-5\" value=\"ยกเลิกการแก้ไขรหัสผ่าน\" ");
            WriteLiteral("@click=\"cancelChangePassword();\">\r\n                            <input id=\"cf\" style=\"margin: 10px 10px;\" type=\"button\" class=\"btn btn-success white--text btn-large col-5\" value=\"ยืนยันการแก้ไขรหัสผ่าน\" ");
            WriteLiteral("@click=\"confirmChangePassword();\">\r\n\r\n                        </div>\r\n                    </v-card>\r\n                </v-col>\r\n            </v-container>\r\n        </v-main>\r\n    </v-app>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var component ={
            vuetify : new Vuetify(theme())
            ,
            el:""#app1""
            ,
            data:{
                editPasswordDateTime:"""",
                today:"""",
                diffDay:0,
                changePassword:{},
                comfirmPassword:"""",

                pass1:0,
                pass2:0,
                pass3:0,
                pass4:0               
            }//edata
            ,
            methods:{
                cancelChangePassword(){
                    location = ""/TheUser2""
                }//ef
                ,
                confirmChangePassword(){
                    //check completeness
                    if(this.changePassword.currentPassword == undefined || this.changePassword.currentPassword == """"){
                        document.querySelector("".cp"").innerHTML=""รหัสผ่านปัจจุบัน"";
                        document.querySelector("".cp"").innerHTML+="" <b class='red--text h6'> กรุณาใ");
                WriteLiteral(@"ส่รหัสผ่านปัจจุบัน <b>"";
                            this.pass1 = 0;
                    }//econ
                    else if(this.changePassword.currentPassword != undefined && this.changePassword.currentPassword != """"){
                    document.querySelector("".cp"").innerHTML=""รหัสผ่านปัจจุบัน"";
                    var set = ""1234567890""
                    var theCount = 0;
                    for(var i of this.changePassword.currentPassword){
                        if(set.includes(i)){
                            theCount++;
                        }//econ
                    }//eloop
                    if(theCount<4){
                        document.querySelector("".cp"").innerHTML+=""<b class='red--text h6'>กรุณาเลือกใช้รหัสผ่านที่ประกอบไปด้วยตัวเลข 4 ตัวขึ้นไป<b>"";
                        this.pass1=0;
                        return;
                    }//ef
                    this.pass1=1;
                }//econ


                if(this.changePassword.newPassword == undefine");
                WriteLiteral(@"d || this.changePassword.newPassword == """"){
                        document.querySelector("".np"").innerHTML=""รหัสผ่านใหม่"";
                        document.querySelector("".np"").innerHTML+="" <b class='red--text h6'> กรุณาใส่ใหม่ที่ต้องการจะเปลี่ยน <b>"";
                        this.pass2 = 0;
                    }//econ
                    else if(this.changePassword.newPassword != undefined && this.changePassword.newPassword != """"){
                    document.querySelector("".np"").innerHTML=""รหัสผ่านใหม่"";
                    var set = ""1234567890""
                    var theCount = 0;
                    for(var i of this.changePassword.newPassword){
                        if(set.includes(i)){
                            theCount++;
                        }//econ
                    }//eloop
                    if(theCount<4){
                        document.querySelector("".np"").innerHTML+=""<b class='red--text h6'>กรุณาเลือกใช้รหัสผ่านที่ประกอบไปด้วยตัวเลข 4 ตัวขึ้นไป<b>"";
             ");
                WriteLiteral(@"           this.pass2=0;
                        return;
                    }//ef
                    this.pass2=1;
                }//econ


                if(this.changePassword.newPassword != this.comfirmPassword){
                    document.querySelector("".cnp"").innerHTML=""ยืนยันรหัสผ่านใหม่"";
                    document.querySelector("".np"").innerHTML+="" <b class='red--text h6'> รหัสผ่านไม่ตรงกัน <b>"";
                    document.querySelector("".cnp"").innerHTML+="" <b class='red--text h6'> รหัสผ่านไม่ตรงกัน <b>"";
                        this.pass3=0;
                }//econ
                if(this.changePassword.newPassword == this.comfirmPassword){
                    document.querySelector("".cnp"").innerHTML=""ยืนยันรหัสผ่านใหม่"";
                    document.querySelector("".np"").innerHTML+=""รหัสผ่านใหม่"";
                    this.pass3=1;
                }//econ

                //check new password should not be equal to old password
                if(this.changePassword.curren");
                WriteLiteral(@"tPassword == this.changePassword.newPassword && this.changePassword.currentPassword != undefined && this.changePassword.currentPassword != """"){
                    this.pass4=0;
                    document.querySelector("".nnp"").innerHTML="""";
                    document.querySelector("".nnp"").innerHTML+=""รหัสผ่านใหม่ไม่ควรซ้ำกับรหัสผ่านเก่า กรุณาเลือกใช้รหัสผ่านอื่น"";
                }//econ
                else if(this.changePassword.currentPassword != this.changePassword.newPassword){
                    this.pass4=1;
                    document.querySelector("".nnp"").innerHTML="""";
                }//econ

                if(this.pass1==1&&this.pass2==1&&this.pass3==1&&this.pass4==1){
                    param = {id:this.changePassword.id,currentPassword:this.changePassword.currentPassword,newPassword:this.changePassword.newPassword}
");
                WriteLiteral(@"                    $.post(""/TheUser2/ChangePassword"",param).done(res=>{
                        if(res.error==1){
                            document.getElementById(""error"").innerHTML = res.message;
                        }
                        else{
                            location=""/Security/Logout""
                        }
                    })
                }//econ
                


                }//ef
               
            }//emethods
            ,
            created(){
                //receive datetime of today and last datetime of change password of this user
                var editPasswordDateTime2 = ");
#nullable restore
#line 164 "C:\Users\parin\web\dog7\Views\TheUser2\ChangePassword.cshtml"
                                       Write(Html.Raw(Json.Serialize(@ViewBag.editPasswordDateTime)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                this.editPasswordDateTime = editPasswordDateTime2[0].editPasswordDateTime;
                this.today = editPasswordDateTime2[0].today;

                //convert it into DateTime type
                this.editPasswordDateTime = new Date(this.editPasswordDateTime);
                this.today = new Date(this.today);
                
                //find different between dates in day
                var diffTime = Math.abs(this.today-this.editPasswordDateTime);
                this.diffDay = Math.ceil(diffTime/(1000*60*60*24));

                this.changePassword.id = ");
#nullable restore
#line 176 "C:\Users\parin\web\dog7\Views\TheUser2\ChangePassword.cshtml"
                                    Write(Html.Raw(Json.Serialize(@ViewBag.id)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                
                
            }//ecreated
            ,
            mounted(){
                if(this.editPasswordDateTime.getFullYear()==1){
                    this.diffDay = 31;
                }//econ
                else{
                    if(this.diffDay <= 30){
                        document.getElementById(""cc"").setAttribute(""disabled"",""disabled"");
                        document.getElementById(""cf"").setAttribute(""disabled"",""disabled"");
                        var listInfo = document.querySelectorAll("".inFo"")
                        for(var i of listInfo){
                            i.setAttribute(""disabled"",""disabled"");
                            i.classList.remove(""bossBorder"");
                        }//eloop
                    }//econ
                }//econ
            }//emount
            
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
