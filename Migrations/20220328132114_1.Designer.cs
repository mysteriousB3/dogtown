// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dog7.Data;

namespace dog7.Migrations
{
    [DbContext(typeof(dog7DbContext))]
    [Migration("20220328132114_1")]
    partial class _1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("dog7.Data.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("dog7.Data.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<DateTime>("editInfoDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("editInfoMemo")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("editPasswordDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext");

                    b.Property<int>("isSeller")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .HasColumnType("longtext");

                    b.Property<string>("memo")
                        .HasColumnType("longtext");

                    b.Property<int>("otp")
                        .HasColumnType("int");

                    b.Property<DateTime>("userRegistrationDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("dog7.Models.Breed", b =>
                {
                    b.Property<int>("breedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("breedDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("breedNameEng")
                        .HasColumnType("longtext");

                    b.Property<string>("breedNameThai")
                        .HasColumnType("longtext");

                    b.Property<string>("breedPic")
                        .HasColumnType("longtext");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.HasKey("breedId");

                    b.ToTable("Breed");
                });

            modelBuilder.Entity("dog7.Models.Gender", b =>
                {
                    b.Property<int>("genderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("genderName")
                        .HasColumnType("longtext");

                    b.HasKey("genderId");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("dog7.Models.PackageDetail", b =>
                {
                    b.Property<int>("packageDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("packageDetailName")
                        .HasColumnType("longtext");

                    b.Property<int>("periodOfEachSellingPost")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("totalPeriodOfPackage")
                        .HasColumnType("int");

                    b.Property<int>("totalPostOfPackage")
                        .HasColumnType("int");

                    b.HasKey("packageDetailId");

                    b.ToTable("PackageDetail");
                });

            modelBuilder.Entity("dog7.Models.Seller", b =>
                {
                    b.Property<int>("sellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("editProfileDatetime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("farmName")
                        .HasColumnType("longtext");

                    b.Property<int>("farmRegister")
                        .HasColumnType("int");

                    b.Property<int>("profileView")
                        .HasColumnType("int");

                    b.Property<int>("sellerAddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("sellerApproveDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("sellerFarmRegisterPic")
                        .HasColumnType("longtext");

                    b.Property<string>("sellerIdCard")
                        .HasColumnType("longtext");

                    b.Property<string>("sellerIdCardBack")
                        .HasColumnType("longtext");

                    b.Property<string>("sellerIdCardFront")
                        .HasColumnType("longtext");

                    b.Property<string>("sellerProfileDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("sellerProfilePhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("sellerProfilePic")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("sellerRegistrationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("selllerBookBankAccountPic")
                        .HasColumnType("longtext");

                    b.Property<int>("totalLike")
                        .HasColumnType("int");

                    b.Property<int>("totalPost")
                        .HasColumnType("int");

                    b.Property<int>("totalPostView")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("sellerId");

                    b.HasIndex("sellerAddressId");

                    b.HasIndex("userId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("dog7.Models.SellerAddress", b =>
                {
                    b.Property<int>("sellerAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("amphoe")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("changeSellerAddress")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("moo")
                        .HasColumnType("longtext");

                    b.Property<string>("number")
                        .HasColumnType("longtext");

                    b.Property<string>("postNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("province")
                        .HasColumnType("longtext");

                    b.Property<string>("soi")
                        .HasColumnType("longtext");

                    b.Property<string>("street")
                        .HasColumnType("longtext");

                    b.Property<string>("tambon")
                        .HasColumnType("longtext");

                    b.Property<string>("userId")
                        .HasColumnType("longtext");

                    b.HasKey("sellerAddressId");

                    b.ToTable("SellerAddress");
                });

            modelBuilder.Entity("dog7.Models.SellerFeedPost", b =>
                {
                    b.Property<int>("sellerFeedPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("longtext");

                    b.Property<string>("feedPostPic1")
                        .HasColumnType("longtext");

                    b.Property<string>("feedPostPic2")
                        .HasColumnType("longtext");

                    b.Property<string>("feedPostPic3")
                        .HasColumnType("longtext");

                    b.Property<string>("feedPostPic4")
                        .HasColumnType("longtext");

                    b.Property<string>("feedPostPic5")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("postingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("sellerId")
                        .HasColumnType("int");

                    b.HasKey("sellerFeedPostId");

                    b.HasIndex("sellerId");

                    b.ToTable("SellerFeedPost");
                });

            modelBuilder.Entity("dog7.Models.SellerFeedback", b =>
                {
                    b.Property<int>("sellerFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("feedbackDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("feedbackDescription")
                        .HasColumnType("longtext");

                    b.Property<int>("feedbackStar")
                        .HasColumnType("int");

                    b.Property<int>("sellerId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("sellerFeedbackId");

                    b.HasIndex("sellerId");

                    b.HasIndex("userId");

                    b.ToTable("SellerFeedback");
                });

            modelBuilder.Entity("dog7.Models.SellerPackage", b =>
                {
                    b.Property<int>("sellerPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("packageBuyingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("packageDetailId")
                        .HasColumnType("int");

                    b.Property<DateTime>("packageEndingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("packageStartingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("packageStatus")
                        .HasColumnType("int");

                    b.Property<string>("paymentEvidence")
                        .HasColumnType("longtext");

                    b.Property<int>("sellerId")
                        .HasColumnType("int");

                    b.Property<int>("totalPackagePurchase")
                        .HasColumnType("int");

                    b.Property<int>("totalPostAvailable")
                        .HasColumnType("int");

                    b.HasKey("sellerPackageId");

                    b.HasIndex("packageDetailId");

                    b.HasIndex("sellerId");

                    b.ToTable("SellerPackage");
                });

            modelBuilder.Entity("dog7.Models.SellingPost", b =>
                {
                    b.Property<int>("sellingPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("breedId")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("genderId")
                        .HasColumnType("int");

                    b.Property<int>("pedegree")
                        .HasColumnType("int");

                    b.Property<int>("postLike")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("sellerId")
                        .HasColumnType("int");

                    b.Property<string>("sellingPostDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("sellingPostName")
                        .HasColumnType("longtext");

                    b.Property<string>("sellingPostPic1")
                        .HasColumnType("longtext");

                    b.Property<string>("sellingPostPic2")
                        .HasColumnType("longtext");

                    b.Property<string>("sellingPostPic3")
                        .HasColumnType("longtext");

                    b.Property<string>("sellingPostPic4")
                        .HasColumnType("longtext");

                    b.Property<string>("sellingPostPic5")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("sellingPostPicUpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("sellingPostPostExpiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("sellingPostPostingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("view")
                        .HasColumnType("int");

                    b.HasKey("sellingPostId");

                    b.HasIndex("breedId");

                    b.HasIndex("genderId");

                    b.HasIndex("sellerId");

                    b.ToTable("SellingPost");
                });

            modelBuilder.Entity("dog7.Models.SellingPostFeedback", b =>
                {
                    b.Property<int>("sellingPostFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("sellingPostId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("sellingPostFeedbackId");

                    b.HasIndex("sellingPostId");

                    b.HasIndex("userId");

                    b.ToTable("SellingPostFeedback");
                });

            modelBuilder.Entity("dog7.Models.TheUser", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<string>("firstName")
                        .HasColumnType("longtext");

                    b.Property<int>("isSeller")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .HasColumnType("longtext");

                    b.Property<int>("otp")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("userRegistrationDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("userId");

                    b.ToTable("TheUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("dog7.Data.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("dog7.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("dog7.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("dog7.Data.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("dog7.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("dog7.Models.Seller", b =>
                {
                    b.HasOne("dog7.Models.SellerAddress", "sellerAddress")
                        .WithMany()
                        .HasForeignKey("sellerAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Data.AppUser", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sellerAddress");

                    b.Navigation("user");
                });

            modelBuilder.Entity("dog7.Models.SellerFeedPost", b =>
                {
                    b.HasOne("dog7.Models.Seller", "seller")
                        .WithMany()
                        .HasForeignKey("sellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seller");
                });

            modelBuilder.Entity("dog7.Models.SellerFeedback", b =>
                {
                    b.HasOne("dog7.Models.Seller", "seller")
                        .WithMany()
                        .HasForeignKey("sellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Data.AppUser", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seller");

                    b.Navigation("user");
                });

            modelBuilder.Entity("dog7.Models.SellerPackage", b =>
                {
                    b.HasOne("dog7.Models.PackageDetail", "packageDetail")
                        .WithMany()
                        .HasForeignKey("packageDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Models.Seller", "seller")
                        .WithMany()
                        .HasForeignKey("sellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("packageDetail");

                    b.Navigation("seller");
                });

            modelBuilder.Entity("dog7.Models.SellingPost", b =>
                {
                    b.HasOne("dog7.Models.Breed", "breed")
                        .WithMany()
                        .HasForeignKey("breedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Models.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("genderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Models.Seller", "seller")
                        .WithMany()
                        .HasForeignKey("sellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("breed");

                    b.Navigation("gender");

                    b.Navigation("seller");
                });

            modelBuilder.Entity("dog7.Models.SellingPostFeedback", b =>
                {
                    b.HasOne("dog7.Models.SellingPost", "sellingPost")
                        .WithMany()
                        .HasForeignKey("sellingPostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dog7.Data.AppUser", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("sellingPost");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
