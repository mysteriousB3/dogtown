#pragma checksum "C:\Users\parin\web\dog7\Views\SellingPost\add.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a494ec491ff7cf6590d04045fb524b9e684fdf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_SellingPost_add), @"mvc.1.0.view", @"/Views/SellingPost/add.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a494ec491ff7cf6590d04045fb524b9e684fdf9", @"/Views/SellingPost/add.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d672f4c3101ed6d56c1976fdf1f3387578e7bea", @"/Views/_ViewImports.cshtml")]
    public class Views_SellingPost_add : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav aria-label='breadcrumb'>
  <ol class='breadcrumb breadcrumb-arrow'>
    <li class='breadcrumb-item'><a href='/sellingpost/index'>sellingpost</a></li>
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
          <v-select return-object outlined v-model=""select_gender"" :items=""genders"" item-text='value' menu-props=""auto""
            label=""???????????????????????????????????????"" show=""genderName""></v-select>
        </div>

        <div style=""margin:20px"">
          <v-select return-object outlined v-model=""select_breed"" :items=""breeds"" item-text='value' menu-props=""auto""
            label=""?????????"" show=""breedNameEng&breedNameThai""></v-select>
        </div>

        <div style=""margin:20px"">
          <v-select return-object outlined v-model=""select_seller"" :items=""sellers"" item-text='value' menu-props=""auto""
            label=""sellerId"" show=""farmName"">");
            WriteLiteral(@"</v-select>
        </div>

        <div style=""margin:20px"">
          <v-text-field v-model=""sellingpost.price"" label=""????????????""></v-text-field>
        </div>

        <div style=""margin:20px"">
          <v-text-field v-model=""sellingpost.sellingPostName"" label=""?????????????????????????????????""></v-text-field>
        </div>

        <div style=""margin:20px"">
          <v-text-field v-model=""sellingpost.sellingPostDescription"" label=""???????????????????????????????????????????????????""></v-text-field>
        </div>

        <v-date-picker v-model=""sellingpost.dateOfBirth"" class=""mt-4""></v-date-picker>

        <div style=""margin:20px"">
          <v-text-field v-model=""sellingpost.pedegree"" label=""????????????????????????????????????????????????????????????????????????????????????????????????????????????""></v-text-field>
        </div>

        <v-date-picker v-model=""sellingpost.sellingPostPostingDateTime"" class=""mt-4""></v-date-picker>

        <v-date-picker v-model=""sellingpost.sellingPostPostExpiredDate"" class=""mt-4""></v-date-picker>

        <div style=""margin:20px"">
          <v-text-field v-model=""sellingpost.postLike"" label=""");
            WriteLiteral(@"???????????????????????????""></v-text-field>
        </div>

        <div style=""margin:20px"">
          <v-text-field v-model=""sellingpost.view"" label=""?????????????????????????????????????????????????????????????????????""></v-text-field>
        </div>

        <v-col cols=""3"">
          <v-card>
            <v-card-text>
              <v-img :src=""sellingPostPic1Data""></v-img>
            </v-card-text>
            <v-card-actions>
              <v-file-input label=""??????????????????1"" v-model=""sellingPostPic1"" ");
            WriteLiteral(@"@change=""preview_sellingPostPic1""></v-file-input>
            </v-card-actions>
          </v-card>

        </v-col>


        <v-col cols=""3"">
          <v-card>
            <v-card-text>
              <v-img :src=""sellingPostPic2Data""></v-img>
            </v-card-text>
            <v-card-actions>
              <v-file-input label=""??????????????????2"" v-model=""sellingPostPic2"" ");
            WriteLiteral(@"@change=""preview_sellingPostPic2""></v-file-input>
            </v-card-actions>
          </v-card>

        </v-col>


        <v-col cols=""3"">
          <v-card>
            <v-card-text>
              <v-img :src=""sellingPostPic3Data""></v-img>
            </v-card-text>
            <v-card-actions>
              <v-file-input label=""??????????????????3"" v-model=""sellingPostPic3"" ");
            WriteLiteral(@"@change=""preview_sellingPostPic3""></v-file-input>
            </v-card-actions>
          </v-card>

        </v-col>


        <v-col cols=""3"">
          <v-card>
            <v-card-text>
              <v-img :src=""sellingPostPic4Data""></v-img>
            </v-card-text>
            <v-card-actions>
              <v-file-input label=""??????????????????4"" v-model=""sellingPostPic4"" ");
            WriteLiteral(@"@change=""preview_sellingPostPic4""></v-file-input>
            </v-card-actions>
          </v-card>

        </v-col>


        <v-col cols=""3"">
          <v-card>
            <v-card-text>
              <v-img :src=""sellingPostPic5Data""></v-img>
            </v-card-text>
            <v-card-actions>
              <v-file-input label=""??????????????????5"" v-model=""sellingPostPic5"" ");
            WriteLiteral(@"@change=""preview_sellingPostPic5""></v-file-input>
            </v-card-actions>
          </v-card>
        </v-col>


        <v-date-picker v-model=""sellingpost.sellingPostPicUpdateDateTime"" class=""mt-4""></v-date-picker>


      </v-card-text>
      <v-card-actions>
        <v-btn ");
            WriteLiteral("@click=\'add_sellingpost\' color=\'blue\' outlined>\n          <v-icon>\n            mdi-content-save-edit\n          </v-icon>\n        </v-btn>\n      </v-card-actions>\n\n    </v-card>\n  </v-app>\n</div>\n");
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
      sellingpost: {}
      ,
      genders: [],
      select_gender: {},
      breeds: [],
      select_breed: {},
      sellers: [],
      select_seller: {},
      sellingPostPic1Data: '',
      sellingPostPic1: [],

      sellingPostPic2Data: '',
      sellingPostPic2: [],

      sellingPostPic3Data: '',
      sellingPostPic3: [],

      sellingPostPic4Data: '',
      sellingPostPic4: [],

      sellingPostPic5Data: '',
      sellingPostPic5: [],


    }//edata
    ,
    created() {

      //=== begin gender ===
      this.genders = ");
#nullable restore
#line 177 "C:\Users\parin\web\dog7\Views\SellingPost\add.cshtml"
                Write(Html.Raw(Json.Serialize(@ViewBag.genders)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\n      this.select_gender = this.genders[0];\n      //=== begin gender ===\n\n\n      //=== begin breed ===\n      this.breeds = ");
#nullable restore
#line 183 "C:\Users\parin\web\dog7\Views\SellingPost\add.cshtml"
               Write(Html.Raw(Json.Serialize(@ViewBag.breeds)));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\n      this.select_breed = this.breeds[0];\n      //=== begin breed ===\n\n\n      //=== begin seller ===\n      this.sellers = ");
#nullable restore
#line 189 "C:\Users\parin\web\dog7\Views\SellingPost\add.cshtml"
                Write(Html.Raw(Json.Serialize(@ViewBag.sellers)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
      this.select_seller = this.sellers[0];
      //=== begin seller ===


    }//ecreated
    ,
    methods: {
      add_sellingpost() {
        this.sellingpost.genderId = this.select_gender.genderId;

        this.sellingpost.breedId = this.select_breed.breedId;

        this.sellingpost.sellerId = this.select_seller.sellerId;

        this.sellingpost.sellingPostPic1 = this.sellingPostPic1Data;
        this.sellingpost.sellingPostPic2 = this.sellingPostPic2Data;
        this.sellingpost.sellingPostPic3 = this.sellingPostPic3Data;
        this.sellingpost.sellingPostPic4 = this.sellingPostPic4Data;
        this.sellingpost.sellingPostPic5 = this.sellingPostPic5Data;

        var url = '/sellingpost/add';
        var param = this.sellingpost;
        $.post(url, param)
          .done(res => {
            //console.log(res);return;
            if (res.error == -1) {
              window.location = '/sellingpost/index';
            }
            else {
              alert(res.exception);
            }
    ");
                WriteLiteral(@"      });


      }//ef
      ,
      preview_sellingPostPic1() {
        const reader = new FileReader();
        reader.readAsDataURL(this.sellingPostPic1); //file1
        reader.onload = () => {
          this.sellingPostPic1Data = reader.result; //imageData
        }//ev
        reader.onerror = function (error) {
          console.log('Error: ', error)
        }//ev

      }//ef    
      ,
      preview_sellingPostPic2() {
        const reader = new FileReader();
        reader.readAsDataURL(this.sellingPostPic2); //file1
        reader.onload = () => {
          this.sellingPostPic2Data = reader.result; //imageData
        }//ev
        reader.onerror = function (error) {
          console.log('Error: ', error)
        }//ev

      }//ef    
      ,
      preview_sellingPostPic3() {
        const reader = new FileReader();
        reader.readAsDataURL(this.sellingPostPic3); //file1
        reader.onload = () => {
          this.sellingPostPic3Data = reader.result; //imageData
        }//ev
        rea");
                WriteLiteral(@"der.onerror = function (error) {
          console.log('Error: ', error)
        }//ev

      }//ef    
      ,
      preview_sellingPostPic4() {
        const reader = new FileReader();
        reader.readAsDataURL(this.sellingPostPic4); //file1
        reader.onload = () => {
          this.sellingPostPic4Data = reader.result; //imageData
        }//ev
        reader.onerror = function (error) {
          console.log('Error: ', error)
        }//ev

      }//ef    
      ,
      preview_sellingPostPic5() {
        const reader = new FileReader();
        reader.readAsDataURL(this.sellingPostPic5); //file1
        reader.onload = () => {
          this.sellingPostPic5Data = reader.result; //imageData
        }//ev
        reader.onerror = function (error) {
          console.log('Error: ', error)
        }//ev

      }//ef    
      ,


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
