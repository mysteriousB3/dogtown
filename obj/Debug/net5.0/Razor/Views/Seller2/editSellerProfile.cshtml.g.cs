#pragma checksum "C:\Users\parin\web\dog7\Views\Seller2\editSellerProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be821198e7c2f60fd7abc20125b00b0b4d9d02d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Seller2_editSellerProfile), @"mvc.1.0.view", @"/Views/Seller2/editSellerProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be821198e7c2f60fd7abc20125b00b0b4d9d02d4", @"/Views/Seller2/editSellerProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_Seller2_editSellerProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
                            <li>การแก้ไขข้อมูลโปรแล้วจะต้องรอ 7 วันหลังจากแก้ไขครั้งล่าสุด</li>
                        </ul>
                    <br>
                </v-col>
                <v-card>
                    <v-card-title>
                        <div>
                            <span  class=""h2 grey--text"">โปรไฟล์ร้านค้า</span>
                        </div>
                    </v-card-title>
                    <v-card-text>
                        <div style=""margin:20px"">
                            <span class=""h2"">ชื่อร้าน หรือ ชื่อฟาร์ม</span>
                            <span id=""farmCheck"" style=""color: red;""></span>
                       ");
            WriteLiteral(@"     <h6>ชื่อนี้จะเป็นชื่อที่โชว์บนโปรไฟล์ของร้านค้า หรือฟาร์มของคุณ</h6>
                            <v-text-field class=""inFo"" label=""ตัวอย่าง บ้านหมาน้อย"" v-model=""sellerProfile.farmName""></v-text-field>
                        </div>

                        <div style=""margin:20px"">
                            <span class=""h2"">คำอธิบายร้านค้า</span>
                            <span id=""disCheck"" style=""color: red;""></span>
                            <h6>คำอธิบายนี้จะอยู่บนโปรไฟล์ร้านค้าของคุณ</h6>
                            <v-text-field class=""inFo"" label=""ตัวอย่าง ร้านนี้ขายน้องหมานำเข้า..."" v-model=""sellerProfile.sellerProfileDescription""></v-text-field>
                        </div>

                        <div style=""margin:20px"">
                            <span class=""h2"">เบอร์โทรศัพท์</span>
                            <span id=""phoneCheck"" style=""color: red;""></span>
                            <h6>เบอร์นี้ควรจะเป็นเบอร์ที่ลูกค้าสามารโทรมาสอบถามได้โดยตรง</h6>
               ");
            WriteLiteral(@"             <v-text-field class=""inFo"" label=""ตัวอย่าง 0920192312"" v-model=""sellerProfile.sellerProfilePhoneNumber""></v-text-field>
                        </div>
                        
                        <div style=""margin:20px"">
                            <span class=""h2"">รูปโปรไฟล์ร้านค้า</span>
                            <h6>ตั้งรูปโปรไฟล์ร้านค้า</h6>
                            <span id=""picCheck"" class=""red--text""></span>
                            <v-col cols=""3"">
                                <v-card>
                                    <v-card-text>
                                        <v-img :src=""sellerProfilePicData""></v-img>
                                    </v-card-text>
                                    <v-card-actions>
                                        <v-file-input class=""inFo"" label=""รูปโปรไฟล์ร้านค้า"" v-model=""sellerProfilePic""
                                            ");
            WriteLiteral(@"@change=""preview_sellerProfilePic""></v-file-input>
                                    </v-card-actions>
                                </v-card>
                        </div>
                        </v-col>
                        <v-card-title>
                            <span class=""h1"" style=""margin: auto;"" >ที่อยู่</span>
                        </v-card-title>
                        <div style=""margin:20px"">
                            <v-row>
                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">บ้านเลขที่</span>
                                    <span id=""hNoCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.number""  label=""ตัวอย่าง 444/222""></v-text-field>
                                </v-col>

                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">ซอย</span>
                                ");
            WriteLiteral(@"    <span id=""soiCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.soi"" label=""ตัวอย่าง 2""></v-text-field>
                                </v-col>

                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">หมู่</span>
                                    <span id=""mooCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.moo"" label=""ตัวอย่าง 1""></v-text-field>
                                </v-col>

                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">ตำบล</span>
                                    <span id=""tambonCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.tambon"" label=""ตัวอย่าง บางบ่อ""></v-text-field>
                                </v-col>

                             ");
            WriteLiteral(@"   <v-col cols=""3"">
                                    <span class=""h2 grey--text"">อำเภอ</span>
                                    <span id=""amphoeCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.amphoe""  label=""ตัวอย่าง บางบ่อ""></v-text-field>
                                </v-col>

                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">ถนน</span>
                                    <span id=""streetCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.street""  label=""ตัวอย่าง เทพารักษ์""></v-text-field>
                                </v-col>

                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">จังหวัด</span>
                                    <span id=""provinceCheck"" class=""red--text""></span>
                                    <v-text-fi");
            WriteLiteral(@"eld class=""inFo"" v-model=""sellerProfile.province"" label=""ตัวอย่าง สมุทรปราการ""></v-text-field>
                                </v-col>

                                <v-col cols=""3"">
                                    <span class=""h2 grey--text"">รหัสไปรษณีย์</span>
                                    <span id=""postNumberCheck"" class=""red--text""></span>
                                    <v-text-field class=""inFo"" v-model=""sellerProfile.postNumber"" label=""ตัวอย่าง 10540""></v-text-field>
                                </v-col>

                            </v-row>    
                        </div>
                        <v-card-actions>
                            <v-btn ");
            WriteLiteral("@click=\'deactivateSeller\' color=\'red\' outlined>\r\n                                ยกเลิกการเป็นผู้ขาย\r\n                            </v-btn>\r\n                            <v-btn v-if=\"pullButton==0\" ");
            WriteLiteral("@click=\'askForEdit\' color=\'blue\' outlined>\r\n                                แก้ไข\r\n                            </v-btn>\r\n                            <v-btn v-if=\"pullButton==1\" ");
            WriteLiteral("@click=\'cancelEdit\' color=\'blue\' outlined>\r\n                                ยกเลิก\r\n                            </v-btn>\r\n                            <v-btn v-if=\"pullButton==1\" ");
            WriteLiteral(@"@click='confirmEdit' color='blue' outlined>
                                ยืนยันการแก้ไข
                            </v-btn>
                        </v-card-actions>
                    </v-card-text>
                </v-card>
            </v-container>
        </v-main>
    </v-app>
</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var component ={
            vuetify : new Vuetify(theme())
            ,
            el:""#app1""
            ,
            data:{
                today:"""",
                cInfo:"""",
                pullButton:0,

                sellerProfile:{},
                sellerProfilePic:[],
                sellerProfilePicData:""""
            }//edata
            ,
            methods:{
                preview_sellerProfilePic() {
                    const width = 400;
                    const height = 400;
                    const reader = new FileReader();
                    reader.readAsDataURL(this.sellerProfilePic); //file1
                    reader.onload = () => {
                        //1.create an image instance
                        const img = new Image();
                        
                        //2.get the image src from reader
                        img.src = event.target.result;

                        //3.when the image is fully load");
                WriteLiteral(@"ed, call onload
                        img.onload = () =>{
                            //4 create dynamic html element as elem
                            const elem = document.createElement('canvas')

                            //5.set width and height of elem
                            elem.width = width;
                            elem.height = height;

                            //6.setup the canvas as a blank2d drawing board
                            const ctx = elem.getContext('2d');

                            //7draw the content of the image instance  into the blank 2d drawing board
                            ctx.drawImage(img,0,0,width,height)

                            //8. convert  the data drwawing board into base64 data with 0.9 quality scale
                            this.sellerProfilePicData = ctx.canvas.toDataURL(img, ""image/*"", 0.9);
                        }
                    }
                    reader.onerror = function (error) {
                        ");
                WriteLiteral(@"console.log('Error: ', error)
                    }//ev
                }//ef
                ,
                askForEdit(){
                    if(this.cInfo>=7){
                        var allInfo = document.querySelectorAll("".inFo input"")
                        for(var i of allInfo){
                            i.removeAttribute(""disabled"")
                        }//ellop

                        var allInfo2 = document.querySelectorAll("".inFo"")
                        for(var i of allInfo2){
                            i.classList.remove(""v-input--is-disabled"")
                        }//ellop
                        var allInfo3 = document.querySelectorAll("".inFo button"")
                        for(var i of allInfo3){
                            i.removeAttribute(""disabled"")
                            i.classList.remove(""v-icon--disabled"")
                        }//ellop
                    this.pullButton=1;
                    }//econ
                    else{
            ");
                WriteLiteral(@"            alert(""คุณพึ่งทำการแก้ไขภายใน 7 วัน"")
                    }//econ
                }//ef
                ,
                cancelEdit(){
                    alert(""คุณได้ทำการยกเลิกการแก้ไข"")
                    location=""/Seller2/editSellerProfile/""+this.sellerProfile.sellerId;
                }//ef
                ,
                confirmEdit(){
                        var p1 = 0;
                        var p2 = 0;
                        var p3 = 0;
                        var p4 = 0;
                        if(this.sellerProfile.farmName == """" || this.sellerProfile.farmName == undefined){
                            document.getElementById(""farmCheck"").innerHTML=""กรุณาตั้งชื่อฟาร์ม""
                            p1 = 0;
                        }//econ
                        else if(this.sellerProfile.farmName != """"){
                            document.getElementById(""farmCheck"").innerHTML=""""
                            p1 = 1;
                        }//econ

         ");
                WriteLiteral(@"               if(this.sellerProfile.sellerProfileDescription == """"|| this.sellerProfile.sellerProfileDescription == undefined){
                            document.getElementById(""disCheck"").innerHTML=""กรุณากรอกคำธิบายฟาร์ม""
                            p2 = 0;
                        }//econ
                        else if(this.sellerProfile.sellerProfileDescription != """"){
                            document.getElementById(""disCheck"").innerHTML=""""
                            p2 = 1;
                        }//econ

                        if(this.sellerProfile.sellerProfilePhoneNumber == """" || this.sellerProfile.sellerProfilePhoneNumber == undefined){
                            document.getElementById(""phoneCheck"").innerHTML=""กรุณากรอกคำธิบายฟาร์ม""
                            p3 = 0;
                        }//econ
                        else if(this.sellerProfile.sellerProfilePhoneNumber != """"){
                            document.getElementById(""phoneCheck"").innerHTML=""""
              ");
                WriteLiteral(@"              p3 = 1;
                        }//econ

                        if(this.sellerProfilePicData == """" || this.sellerProfilePicData == undefined){
                            document.getElementById(""picCheck"").innerHTML=""กรุณาใส่รูป""
                            p4 = 0;
                        }//econ
                        else if(this.sellerProfilePicData != """"){
                            document.getElementById(""picCheck"").innerHTML=""""
                            p4 = 1;
                        }//econ

                        if(p1 != 1 || p2 != 1 || p3 != 1 || p4 != 1){
                            return;
                        }//econ

                        //address part
                    var a1 = 0;
                    var a2 = 0;
                    var a3 = 0;
                    var a4 = 0;
                    var a5 = 0;
                    var a6 = 0;
                    var a7 = 0;
                    var a8 = 0;
                    if(this.sellerProfi");
                WriteLiteral(@"le.number == """"){
                        document.getElementById(""hNoCheck"").innerHTML =""กรุณาใส่บ้านเลขที่""
                        a1=0;
                    }//econ
                    else if(this.sellerProfile.number != """"){
                        document.getElementById(""hNoCheck"").innerHTML =""""
                        a1=1;
                    }//econ

                    if(this.sellerProfile.soi == """"){
                        document.getElementById(""soiCheck"").innerHTML =""กรุณาใส่ซอย""
                        a2=0;
                    }//econ
                    else if(this.sellerProfile.soi != """"){
                        document.getElementById(""soiCheck"").innerHTML =""""
                        a2=1;
                    }//econ

                    if(this.sellerProfile.moo == """"){
                        document.getElementById(""mooCheck"").innerHTML =""กรุณาใส่หมู่""
                        a3=0;
                    }//econ
                    else if(this.sellerProfile.moo !");
                WriteLiteral(@"= """"){
                        document.getElementById(""mooCheck"").innerHTML =""""
                        a3=1;
                    }//econ

                    if(this.sellerProfile.tambon == """"){
                        document.getElementById(""tambonCheck"").innerHTML =""กรุณาใส่ตำบล""
                        a4=0;
                    }//econ
                    else if(this.sellerProfile.tambon != """"){
                        document.getElementById(""tambonCheck"").innerHTML =""""
                        a4=1;
                    }//econ

                    if(this.sellerProfile.amphoe == """"){
                        document.getElementById(""amphoeCheck"").innerHTML =""กรุณาใส่อำเภอ""
                        a5=0;
                    }//econ
                    else if(this.sellerProfile.amphoe != """"){
                        document.getElementById(""amphoeCheck"").innerHTML =""""
                        a5=1;
                    }//econ

                    if(this.sellerProfile.street == """"){");
                WriteLiteral(@"
                        document.getElementById(""streetCheck"").innerHTML =""กรุณาใส่ถนน""
                        a6=0;
                    }//econ
                    else if(this.sellerProfile.street != """"){
                        document.getElementById(""streetCheck"").innerHTML =""""
                        a6=1;
                    }//econ

                    if(this.sellerProfile.province == """"){
                        document.getElementById(""provinceCheck"").innerHTML =""กรุณาใส่จังหวัด""
                        a7=0;
                    }//econ
                    else if(this.sellerProfile.province != """"){
                        document.getElementById(""provinceCheck"").innerHTML =""""
                        a7=1;
                    }//econ

                    if(this.sellerProfile.postNumber == """"){
                        document.getElementById(""postNumberCheck"").innerHTML =""กรุณาใส่รหัสไปรษณีย์""
                        a8=0;
                    }//econ
                    else");
                WriteLiteral(@" if(this.sellerProfile.postNumber != """"){
                        document.getElementById(""postNumberCheck"").innerHTML =""""
                        a8=1;
                    }//econ

                    if(a1 !=1 || a2 !=1 || a3 !=1 || a4 !=1 || a5 !=1 || a6 !=1 || a7 !=1 || a8 !=1 ){
                        return;
                    }//econ
                    this.sellerProfile.sellerProfilePic= this.sellerProfilePicData;
                    $.post(""/Seller2/editSellerProfile"",this.sellerProfile).done(res =>{
                        if(res.error==-1){
                            alert(""แก้ไขข้อมูลโปรไฟล์ของร้านค้าเรียบร้อย"")
                            location = ""/Seller2/MyShop/""+this.sellerProfile.sellerId;
                        }
                        else{
                            alert(res.exception)
                        }
                    })
                }//ef
                ,
                deactivateSeller(){
                    if(confirm(""กดปุ่ม OK เพื่อยกเ");
                WriteLiteral(@"ลิกการเป็นผู้ขาย"")==true){
                    $.post(""/Seller2/DeactivateSeller"",this.sellerProfile).done(res=>{
                        if(res.error==-1){
                            alert(""ยกเลิกการเป็นผู้ขายเรียบร้อยแล้ว หากกลับมาเปิดร้านท่านจะได้ร้านเดิมกลับคืนมา"")
                            location =""/Home""
                        }//econ
                        else{
                            alert(res.exception);
                        }
                    })//epost
                }//econ
                }//ef
            }//emethods
            ,
            created(){
                this.sellerProfile = ");
#nullable restore
#line 373 "C:\Users\parin\web\dog7\Views\Seller2\editSellerProfile.cshtml"
                                Write(Html.Raw(Json.Serialize(@ViewBag.sellerProfile)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n                this.today  = ");
#nullable restore
#line 374 "C:\Users\parin\web\dog7\Views\Seller2\editSellerProfile.cshtml"
                         Write(Html.Raw(Json.Serialize(@ViewBag.today)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

                //assign image
                this.sellerProfilePicData= ""/sellerProfilePic/""+this.sellerProfile.sellerId+""sellerProfilePic.png""
                
                //disalbed all first
                var allInfo = document.querySelectorAll("".inFo"")
                for(var i of allInfo){
                    i.setAttribute(""disabled"",""disabled"")
                }//ellop

                //find differences in day between dates
                var today = new Date(this.today);
                var infoDate = new Date(this.sellerProfile.editProfileDatetime);
                var diffTime = Math.abs(today-infoDate);
                this.cInfo = Math.ceil(diffTime/(1000*60*60*24));
                console.log(this.cInfo)
            }//ecreated
            
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
