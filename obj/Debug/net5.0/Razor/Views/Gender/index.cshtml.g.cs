#pragma checksum "C:\Users\parin\web\dog7\Views\Gender\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c0fea0cc18a2e5e4d0ba1023ba006de560cb99d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gender_index), @"mvc.1.0.view", @"/Views/Gender/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c0fea0cc18a2e5e4d0ba1023ba006de560cb99d", @"/Views/Gender/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_Gender_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb breadcrumb-arrow"">
        <li class=""breadcrumb-item active"" aria-current=""page"">gender</li>
    </ol>
</nav>
<div id='app1' v-cloak>

    <v-app>
        <v-main>
             <v-btn
              class=""white--text""
              color=""green darken-1""
              ");
            WriteLiteral(@"@click='add_gender'
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
             :items   ='genders'
             :footer-props=""{ 'items-per-page-options': [25, 50,100] }""
             :items-per-page=""25""
              class='elevation-1'
             />
                  <template v-slot:item.actions='{item}'>
                        <v-btn small class=""white--text mr-1""color=""blue darken-1""
                        ");
            WriteLiteral("@click=\"edit_gender(item)\"\n                        >\n                            <v-icon>mdi-pencil</v-icon>\n                        </v-btn>\n                        <v-btn small class=\"white--text\"color=\"red darken-1\"\n                        ");
            WriteLiteral("@click=\"remove_gender(item)\"\n                        >\n                            <v-icon>mdi-trash-can</v-icon>\n                        </v-btn>\n                  </template>\n             </v-data-table>\n        </v-main>\n    </v-app>\n</div>\n");
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
                   genders:[]
                   ,
                   headers:[
                      {text:'gender',value:'genderId',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'?????????',value:'genderName',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'actions',value:'actions',align:'left',sortable:true,class: 'white--text blue darken-2'}

					]
                }//edata
                ,
                created(){
                  this.genders = ");
#nullable restore
#line 72 "C:\Users\parin\web\dog7\Views\Gender\index.cshtml"
                            Write(Html.Raw(Json.Serialize(@ViewBag.genders)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                }//ecreated
                ,
                methods:{
                    add_gender(){
                        window.location= '/gender/add';
                  
                        
                    }//ef
                    ,
                    edit_gender(item){
                        window.location = '/gender/edit/'+item.genderId;
                    }
                    ,
                    remove_gender(item){
                          if (confirm(""To proceed, please click OK"")) {
                              var id = item.genderId;
                              $.post( ""/gender/delete/""+item.genderId)
                              .done((res)=> {
                                  if(res.error == -1){
                                      this.genders = this.genders.filter(x=>x.genderId != item.genderId);
                                  }//endif

                              })
                              .fail(function(res) {
                                  aler");
                WriteLiteral(@"t( res.msg);
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
