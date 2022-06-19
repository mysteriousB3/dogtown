#pragma checksum "C:\Users\parin\web\dog7\Views\Admin\ApproveSeller2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "18ca1b9915317f52d81d8576fedfa52352075338"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ApproveSeller2), @"mvc.1.0.view", @"/Views/Admin/ApproveSeller2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"18ca1b9915317f52d81d8576fedfa52352075338", @"/Views/Admin/ApproveSeller2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ApproveSeller2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label='breadcrumb'>
    <ol class='breadcrumb breadcrumb-arrow'>
        <li class='breadcrumb-item'><a href='/seller/index'>seller</a></li>
        <li class='breadcrumb-item active' aria-current='page'>edit</li>
    </ol>
</nav>
<div id='app1' v-cloak>

    <v-app>

        <v-card>
            <v-card-title>
            </v-card-title>
            <v-card-text>
                <div style=""margin:20px"">
                    <div style=""margin:20px"">
                        <v-text-field disabled v-model=""user.value"" label=""ชื่อผู้ใช้งาน""></v-text-field>
                    </div>
                </div>
                <div style=""margin:20px"">
                    <div style=""margin:20px"">
                        <v-text-field disabled v-model=""user.phoneNumber"" label=""เบอร์โทร""></v-text-field>
                    </div>
                </div>

                <div style=""margin:20px"">
                    <div style=""margin:20px"">
                        <v-text-field disa");
            WriteLiteral(@"bled v-model=""seller.sellerIdCard"" label=""เลข 13 หลัก บัตรประชาชน"">
                        </v-text-field>
                    </div>
                </div>

                <v-col cols=""3"">

                    <v-card>
                        <v-card-text>
                            <v-img ");
            WriteLiteral(@"@click=""overlay1 = !overlay1"" :src=""sellerIdCardFrontData""></v-img>
                            <v-card-title>
                                <span class=""h6"">รูปภาพด้านหน้าของบัตรประชาชน</span>
                                <v-overlay :z-index=""zIndex"" :value=""overlay1"">
                                    <v-img ");
            WriteLiteral(@"@click=""overlay1 = false"" :src=""sellerIdCardFrontData""></v-img>
                                </v-overlay>
                        </v-card-text>
                    </v-card>

                </v-col>


                <v-col cols=""3"">
                    <v-card>
                        <v-card-text>
                            <v-img ");
            WriteLiteral(@"@click=""overlay2 = !overlay2"" :src=""sellerIdCardBackData""></v-img>
                            <span class=""h6"">รูปภาพด้านหลังของบัตรประชาชน</span>
                            <v-overlay :z-index=""zIndex"" :value=""overlay2"">
                                    <v-img ");
            WriteLiteral(@"@click=""overlay2 = false"" :src=""sellerIdCardBackData""></v-img>
                            </v-overlay>
                        </v-card-text>
                    </v-card>

                </v-col>


                <v-col cols=""3"">
                    <v-card>
                        <v-card-text>
                            <v-img ");
            WriteLiteral(@"@click=""overlay3 = !overlay3"" :src=""selllerBookBankAccountPicData""></v-img>
                            <span class=""h6"">รูปภาพสมุดบัญชีธนาคาร</span>
                            <v-overlay :z-index=""zIndex"" :value=""overlay3"">
                                    <v-img ");
            WriteLiteral(@"@click=""overlay3 = false"" :src=""selllerBookBankAccountPicData""></v-img>
                            </v-overlay>
                            </v-card-actions>
                    </v-card>

                </v-col>


                <v-col cols=""3"">
                    <v-card>
                        <v-card-text>
                            <v-img ");
            WriteLiteral(@"@click=""overlay4 = !overlay4"" :src=""sellerFarmRegisterPicData""></v-img>
                            <span class=""h6"">รูปภาพการจดทะเบียนฟาร์มสุนัข</span>
                            <v-overlay :z-index=""zIndex"" :value=""overlay4"">
                                    <v-img ");
            WriteLiteral(@"@click=""overlay4 = false"" :src=""sellerFarmRegisterPicData""></v-img>
                            </v-overlay>
                        </v-card-text>
                    </v-card>
                </v-col>

                <div style=""margin:20px"">
                    <span id=""memoCheck"" class=""red--text""></span>
                    <div style=""margin:20px"">
                        <v-text-field v-model=""memo"" label=""หากปฏิเสธ โปรดให้เหตุผล""></v-text-field>
                    </div>
                </div>


            </v-card-text>
            <v-card-actions>
                <v-btn ");
            WriteLiteral("@click=\'approveSeller2\' color=\'blue\' outlined>\r\n                    <v-icon>\r\n                        mdi-content-save-edit\r\n                    </v-icon>\r\n                </v-btn>\r\n                <v-btn ");
            WriteLiteral("@click=\'rejectSeller2\' color=\'blue\' outlined>\r\n                    <v-icon>\r\n                        mdi-cancel\r\n                    </v-icon>\r\n                </v-btn>\r\n            </v-card-actions>\r\n\r\n        </v-card>\r\n    </v-app>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
<script>
    var app;
    var component = {
        vuetify: new Vuetify(theme())
        ,
        el: '#app1'
        ,
        data: {
            seller: {},
            user: {},
            sellerIdCardFrontData: '',
            sellerIdCardFront: [],

            sellerIdCardBackData: '',
            sellerIdCardBack: [],

            selllerBookBankAccountPicData: '',
            selllerBookBankAccountPic: [],

            sellerFarmRegisterPicData: '',
            sellerFarmRegisterPic: [],

            memo: """",

            //overlay part for pop up image
            overlay1: false,
            overlay2:false,
            overlay3:false,
            overlay4:false,
            zIndex: 1

        }//edata
        ,
        created() {
            this.seller = ");
#nullable restore
#line 149 "C:\Users\parin\web\dog7\Views\Admin\ApproveSeller2.cshtml"
                     Write(Html.Raw(Json.Serialize(@ViewBag.seller)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            this.user = ");
#nullable restore
#line 150 "C:\Users\parin\web\dog7\Views\Admin\ApproveSeller2.cshtml"
                   Write(Html.Raw(Json.Serialize(@ViewBag.user)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
            this.user = this.user[0];
            


            this.sellerIdCardFrontData = ""/sellerRegisterPic/"" + this.seller.sellerId + ""sellerIdCardFront.png"";
            this.sellerIdCardBackData = ""/sellerRegisterPic/"" + this.seller.sellerId + ""sellerIdCardBack.png"";
            this.selllerBookBankAccountPicData = ""/sellerRegisterPic/"" + this.seller.sellerId + ""selllerBookBankAccountPic.png"";
            this.sellerFarmRegisterPicData = this.seller.sellerFarmRegisterPic;
            console.log(this.sellerFarmRegisterPicData);

            console.log(this.user);




        }//ecreated
        ,
        methods: {
            approveSeller2() {
                var url = '/Admin/approveSeller2';
                var param = { uId: this.user.id, sellerId: this.seller.sellerId, status: 1, memo: this.memo };
                $.post(url, param)
                    .done(res => {
                        if (res.error == -1) {
                            alert(res.message)
      ");
                WriteLiteral(@"                      window.location = '/Admin/approveSeller';
                        }
                        else {
                            alert(res.exception);
                        }
                    });

            }//ef
            ,
            rejectSeller2() {
                if (this.memo == """" || this.memo == undefined || this.memo == null) {
                    document.getElementById(""memoCheck"").innerHTML = ""กรุณาให้เหตุผลหากปฎิเสธ""
                    return;
                }
                var url = '/Admin/approveSeller2';
                var param = { uId: this.user.id, sellerId: this.seller.sellerId, status: -1, memo: this.memo };
                $.post(url, param)
                    .done(res => {
                        if (res.error == -1) {
                            alert(res.message)
                            window.location = '/Admin/approveSeller';
                        }
                        else {
                            alert(re");
                WriteLiteral(@"s.exception);
                        }
                    });

            }//ef

        }//emethod
        ,
        computed: {
        }//ecomputed
        ,
        mounted(){
            
        }//emounted
    };
    app = new Vue(component);


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
