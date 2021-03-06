#pragma checksum "C:\Users\parin\web\dog7\Views\SellingPost2\ExploreEachBreed.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e32c5ff0361eeda413fc9d58318ad1887b204a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellingPost2_ExploreEachBreed), @"mvc.1.0.view", @"/Views/SellingPost2/ExploreEachBreed.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e32c5ff0361eeda413fc9d58318ad1887b204a8", @"/Views/SellingPost2/ExploreEachBreed.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_SellingPost2_ExploreEachBreed : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div id=""app1"">
    <v-app>
        <v-main>
            <v-card>
                <div class=""grey--text"" style=""font-size: 4rem; padding:20px; text-align:center;"">
                    {{breed.breedNameThai}}                    
                </div>
                <v-row>
                    <v-col cols=""6"">
                        <img style=""object-fit: contain;"" height=""600px"" width=""600px"" :src=""breed.breedPic"">
                    </v-col>
                    <v-col cols=""6"">
                        <div class=""grey--text"" style=""font-size:2rem"">
                            ????????????????????????????????????????????????????????????
                        </div><br>
                        <v-col cols=""10"">
                            <p class=""grey--text"" style=""font-size: 1rem; text-indent:50px"">
                                {{breed.breedDescription}}
                            </p>
                        </v-col>
                    </v-col>
                </v-row>
            </v-card>
            <br><br>");
            WriteLiteral(@"<br>
            <span class=""h1"">???????????????????????????????????????????????????????????????????????? {{breed.breedNameThai}}</span>
            <v-text-field v-model=""search"" append-icon=""mdi-magnify"" label=""???????????????"" single-line hide-details></v-text-field>
            <v-data-table :search='search' :headers='headers' :items='sellingPosts'  fixed-header
                :footer-props=""{ 'items-per-page-options': [25, 50,100] }"" :items-per-page=""25"" class='elevation-1' />
            <template v-slot:item.actions='{item}'>
                <img :src=""item.sellingPostPic1"" width=""250px"" />
                
            </template>
            <template v-slot:item.actions2='{item}'>
                                <v-btn large class=""white--text mr-1""color=""blue darken-1""
                                ");
            WriteLiteral(@"@click=""exploreSellingPost(item)""
                                >
                                    <v-icon>mdi-magnify</v-icon>
                                </v-btn>
                        </template>
            </v-data-table>
            
        </v-main>
    </v-app>

</div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
    var component = {
        vuetify: new Vuetify(theme())
        ,
        el: ""#app1""
        ,
        data: {
            breed:{},
            sellingPosts: [],
            search: """",
            headers: [
                { text: '????????????????????????????????????', value: 'actions', sortable: false, class: 'white--text blue darken-2' },
                { text: '??????????????????', value: 'sellingPostName', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                { text: '?????????', value: 'genderName', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                { text: '??????????????????', value: 'breedNameThai', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                { text: '????????????', value: 'price', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                { text: '????????????????????????????????????????????????', value: 'sellingPostPostingDateTime', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                { text: ");
                WriteLiteral(@"'????????????????????????', value: 'view', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                { text: '???????????????????????????????????????', value: 'postLike', align: 'left', sortable: true, class: 'white--text blue darken-2' },
                {text:'?????????????????????',value:'actions2',align:'left',sortable:true,class: 'white--text blue darken-2'}   
            ]
            
        }//edata
        ,
        created() {
            this.breed = ");
#nullable restore
#line 72 "C:\Users\parin\web\dog7\Views\SellingPost2\ExploreEachBreed.cshtml"
                    Write(Html.Raw(Json.Serialize(@ViewBag.breed)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n            this.breed.breedPic = \"/dogPic/\"+this.breed.breedId+\"breedPic.png\"\r\n            \r\n\r\n            this.sellingPosts = ");
#nullable restore
#line 76 "C:\Users\parin\web\dog7\Views\SellingPost2\ExploreEachBreed.cshtml"
                           Write(Html.Raw(Json.Serialize(@ViewBag.sellingPosts)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
            //edit date
            var nameOfMonth = ['??????????????????', '??????????????????????????????', '??????????????????', '??????????????????', '?????????????????????', '????????????????????????', '?????????????????????', '?????????????????????', '?????????????????????', '??????????????????', '???????????????????????????', '?????????????????????'];
            for (var i = 0; i < this.sellingPosts.length; i++) {
                var date = this.sellingPosts[i].sellingPostPostingDateTime.slice(8, 10);
                var month = this.sellingPosts[i].sellingPostPostingDateTime.slice(5, 7);
                var monthName = nameOfMonth[parseInt(month) - 1]
                var year = parseInt(this.sellingPosts[i].sellingPostPostingDateTime.slice(0, 4)) + 543;
                var time = this.sellingPosts[i].sellingPostPostingDateTime.slice(11, 16);
                this.sellingPosts[i].sellingPostPostingDateTime = date + "" "" + monthName + "" "" + year;
            }//eloop

            //edit price and add image
            internationalNumberFormat = new Intl.NumberFormat('en-US');
            for (var i of this.sellingPosts) {
                //price
       ");
                WriteLiteral(@"         i.price = internationalNumberFormat.format(i.price) + "" ?????????"";

                //image
                i.sellingPostPic1 = ""/sellingPostPic/"" + i.sellingPostId + ""sellingPostPic1.png""
            }//eloop
        }//ecreated
        ,
        methods: {
            exploreSellingPost(item){
                location = ""/SellingPost2/ExploreSellingPost/""+item.sellingPostId;
            }//ef
            

        }//emethods

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
