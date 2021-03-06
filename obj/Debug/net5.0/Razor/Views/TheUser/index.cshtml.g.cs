#pragma checksum "C:\Users\parin\web\dog7\Views\TheUser\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8613573bcd6c689c6c5da4579e6eb172e95a175a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TheUser_index), @"mvc.1.0.view", @"/Views/TheUser/index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8613573bcd6c689c6c5da4579e6eb172e95a175a", @"/Views/TheUser/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_TheUser_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div id=\'app1\' v-cloak>\n\n    <v-app>\n        <v-main>\n            \n             <v-btn\n              class=\"white--text\"\n              color=\"green darken-1\"\n              ");
            WriteLiteral(@"@click='add_theuser'
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
             :items   ='theUsers'
             :footer-props=""{ 'items-per-page-options': [25, 50,100] }""
             :items-per-page=""25""
              class='elevation-1'
             />
                  <template v-slot:item.actions='{item}'>
                        <v-btn small class=""white--text mr-1""color=""blue darken-1""
                        ");
            WriteLiteral("@click=\"edit_theuser(item)\"\n                        >\n                            <v-icon>mdi-pencil</v-icon>\n                        </v-btn>\n                        <v-btn small class=\"white--text\"color=\"red darken-1\"\n                        ");
            WriteLiteral("@click=\"remove_theuser(item)\"\n                        >\n                            <v-icon>mdi-trash-can</v-icon>\n                        </v-btn>\n                  </template>\n             </v-data-table>\n        </v-main>\n    </v-app>\n</div>\n");
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
                   theUsers:[]
                   ,
                   headers:[
                      {text:'user',value:'userId',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'????????????????????????',value:'firstName',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'?????????????????????',value:'lastName',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'???????????????',value:'phoneNumber',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'???????????????',value:'email',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'???????????????????????????????????????????????????????????????????????????',value:'userRegistrationDateTime',align:'left',sortable:true,class: 'white--");
                WriteLiteral(@"text blue darken-2'},
                      {text:'otp',value:'otp',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'???????????????????????????????????????????????????',value:'isSeller',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'????????????????????????',value:'password',align:'left',sortable:true,class: 'white--text blue darken-2'},
                      {text:'actions',value:'actions',align:'left',sortable:true,class: 'white--text blue darken-2'}

					]
                }//edata
                ,
                created(){
                  this.theUsers = ");
#nullable restore
#line 76 "C:\Users\parin\web\dog7\Views\TheUser\index.cshtml"
                             Write(Html.Raw(Json.Serialize(@ViewBag.theUsers)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
                }//ecreated
                ,
                methods:{
                    add_theuser(){
                        window.location= '/theuser/add';
                  
                        
                    }//ef
                    ,
                    edit_theuser(item){
                        window.location = '/theuser/edit/'+item.userId;
                    }
                    ,
                    remove_theuser(item){
                          if (confirm(""To proceed, please click OK"")) {
                              var id = item.theUserId;
                              $.post( ""/theuser/delete/""+item.theUserId)
                              .done((res)=> {
                                  if(res.error == -1){
                                      this.theUsers = this.theUsers.filter(x=>x.theUserId != item.theUserId);
                                  }//endif

                              })
                              .fail(function(res) {
                            ");
                WriteLiteral(@"      alert( res.msg);
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
