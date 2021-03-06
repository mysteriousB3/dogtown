#pragma checksum "C:\Users\parin\web\dog7\Views\PackageDetail\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d3df4dfde10ad7f33b79ed39baaae2d71390e34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PackageDetail_index), @"mvc.1.0.view", @"/Views/PackageDetail/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d3df4dfde10ad7f33b79ed39baaae2d71390e34", @"/Views/PackageDetail/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_PackageDetail_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb breadcrumb-arrow"">
        <li class=""breadcrumb-item active"" aria-current=""page"">packageDetail</li>
    </ol>
</nav>
<div id='app1' v-cloak>

    <v-app>
        <v-main>
             <v-btn
              class=""white--text""
              color=""green darken-1""
              ");
            WriteLiteral(@"@click='add_packagedetail'
             >
                 <v-icon>
                   mdi-plus
                 </v-icon>
                 
             </v-btn>
			<v-text-field
                    v-model=""search""
                    append-icon=""mdi-magnify""
                    label=""Search""
                    single-line
                    hide-details
                ></v-text-field>
             <v-data-table
			 :search = 'search'
             :headers ='headers'
             :items   ='packageDetails'
             :footer-props=""{ 'items-per-page-options': [25, 50,100] }""
             :items-per-page=""25""
              class='elevation-1'
             />
                  <template v-slot:item.actions='{item}'>
                        <v-btn small class=""white--text mr-1""color=""blue darken-1""
                        ");
            WriteLiteral("@click=\"edit_packagedetail(item)\"\n                        >\n                            <v-icon>mdi-pencil</v-icon>\n                        </v-btn>\n                        <v-btn small class=\"white--text\"color=\"red darken-1\"\n                        ");
            WriteLiteral("@click=\"remove_packagedetail(item)\"\n                        >\n                            <v-icon>mdi-trash-can</v-icon>\n                        </v-btn>\n                  </template>\n             </v-data-table>\n        </v-main>\n    </v-app>\n</div>\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var app;
            var component = {
                vuetify: new Vuetify(theme())
                ,
                el:'#app1'
                ,
                data:{
                   search :'',
                   packageDetails:[]
                   ,
                   headers:[
                      {text:'packageDetail',value:'packageDetailId',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'?????????????????????????????????',value:'packageDetailName',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'????????????????????????????????????????????????????????????',value:'totalPostOfPackage',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'?????????????????????????????????????????????????????????',value:'periodOfEachSellingPost',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'?????????????????????????????????????????????????????????',value:'totalPeriodOfPackage',align:'left',sortable:true,class: 'white--text blue darken-2'},
            ");
                WriteLiteral(@"          {text:'????????????',value:'price',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'actions',value:'actions',align:'left',sortable:true,class: 'white--text blue darken-2'}

					]
                }//edata
                ,
                created(){
                  this.packageDetails = ");
#nullable restore
#line 76 "C:\Users\parin\web\dog7\Views\PackageDetail\index.cshtml"
                                   Write(Html.Raw(Json.Serialize(@ViewBag.packageDetails)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                }//ecreated
                ,
                methods:{
                    add_packagedetail(){
                        window.location= '/packagedetail/add';
                  
                        
                    }//ef
                    ,
                    edit_packagedetail(item){
                        window.location = '/packagedetail/edit/'+item.packageDetailId;
                    }
                    ,
                    remove_packagedetail(item){
                          if (confirm(""To proceed, please click OK"")) {
                              var id = item.packageDetailId;
                              $.post( ""/packagedetail/delete/""+item.packageDetailId)
                              .done((res)=> {
                                  if(res.error == -1){
                                      this.packageDetails = this.packageDetails.filter(x=>x.packageDetailId != item.packageDetailId);
                                  }//endif

                              })");
                WriteLiteral(@"
                              .fail(function(res) {
                                  alert( res.msg);
                              });
                          } //end if 
                    }//ef

                }//emethods
                ,
                computed:{

                }//ecomputed
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
