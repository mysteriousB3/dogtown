#pragma checksum "C:\Users\parin\web\dog7\Views\Breed\add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff0b15bc88026387c0a99be4c2535107e4bdad8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Breed_add), @"mvc.1.0.view", @"/Views/Breed/add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff0b15bc88026387c0a99be4c2535107e4bdad8b", @"/Views/Breed/add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_Breed_add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label='breadcrumb'>
  <ol class='breadcrumb breadcrumb-arrow'>
    <li class='breadcrumb-item'><a href='/breed/index'>breed</a></li>
    <li class='breadcrumb-item active' aria-current='page'>create</li>
  </ol>
</nav>
<div id='app1' v-cloak>

  <v-app>

    <v-card>
      <v-card-title>
      </v-card-title>
      <v-card-text>
        <div style=""margin:20px"">
          <v-text-field v-model=""breed.breedNameThai"" label=""ชื่อสายพันธุ์ภาษาไทย""></v-text-field>
        </div>

        <div style=""margin:20px"">
          <v-text-field v-model=""breed.breedNameEng"" label=""ชื่อสายพันธุ์ภาษาอังกฤษ""></v-text-field>
        </div>

        <v-col cols=""3"">
          <v-card>
            <v-card-text>
              <v-img :src=""breedPicData""></v-img>
            </v-card-text>
            <v-card-actions>
              <v-file-input label=""รูปสายพันธ์ุ"" v-model=""breedPic"" ");
            WriteLiteral(@"@change=""preview_breedPic""></v-file-input>
            </v-card-actions>
          </v-card>

        </v-col>


        <div style=""margin:20px"">
          <v-text-field v-model=""breed.breedDescription"" label=""คำอธิบายสายพันธ์""></v-text-field>
        </div>

        <div style=""margin:20px"">
          <v-text-field v-model=""breed.total"" label=""จำนวนทั้งหมด""></v-text-field>
        </div>


      </v-card-text>
      <v-card-actions>
        <v-btn ");
            WriteLiteral("@click=\'add_breed\' color=\'blue\' outlined>\n          <v-icon>\n            mdi-content-save-edit\n          </v-icon>\n        </v-btn>\n      </v-card-actions>\n\n    </v-card>\n  </v-app>\n</div>\n");
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
      breed: {}
      ,
      breedPicData: '',
      breedPic: [],


    }//edata
    ,
    created() {

    }//ecreated
    ,
    methods: {
      add_breed() {
        this.breed.breedPic = this.breedPicData;

        var url = '/breed/add';
        var param = this.breed;
        $.post(url, param)
          .done(res => {
            //console.log(res);return;
            if (res.error == -1) {
              window.location = '/breed/index';
            }
            else {
              alert(res.exception);
            }
          });


      }//ef
      ,
      preview_breedPic() {
");
                WriteLiteral(@"

        const width = 300;
        const height = 500;
        const reader = new FileReader();
        reader.readAsDataURL(this.breedPic); //file1
        reader.onload = () => {
          //1.create an image instance
          const img = new Image();

          //2.get the image src from reader
          img.src = event.target.result;

          //3.when the image is fully loaded, call onload
          img.onload = () => {
            //4 create dynamic html element as elem
            const elem = document.createElement('canvas')

            //5.set width and height of elem
            elem.width = width;
            elem.height = height;

            //6.setup the canvas as a blank2d drawing board
            const ctx = elem.getContext('2d');

            //7draw the content of the image instance  into the blank 2d drawing board
            ctx.drawImage(img, 0, 0, width, height)

            //8. convert  the data drwawing board into base64 data with 0.9 quality scale
            this.breedPicData ");
                WriteLiteral(@"= ctx.canvas.toDataURL(img, ""image/*"", 0.9);
          }
        }
        reader.onerror = function (error) {
          console.log('Error: ', error)
        }//ev

      }//ef    
      


    }//emethod
    ,
    computed: {

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
