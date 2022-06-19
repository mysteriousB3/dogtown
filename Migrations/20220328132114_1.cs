using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dog7.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "longtext", nullable: true),
                    lastName = table.Column<string>(type: "longtext", nullable: true),
                    userRegistrationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isSeller = table.Column<int>(type: "int", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    memo = table.Column<string>(type: "longtext", nullable: true),
                    editInfoDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    editInfoMemo = table.Column<string>(type: "longtext", nullable: true),
                    editPasswordDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    breedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    breedNameThai = table.Column<string>(type: "longtext", nullable: true),
                    breedNameEng = table.Column<string>(type: "longtext", nullable: true),
                    breedPic = table.Column<string>(type: "longtext", nullable: true),
                    breedDescription = table.Column<string>(type: "longtext", nullable: true),
                    total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breed", x => x.breedId);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    genderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    genderName = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.genderId);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetail",
                columns: table => new
                {
                    packageDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    packageDetailName = table.Column<string>(type: "longtext", nullable: true),
                    totalPostOfPackage = table.Column<int>(type: "int", nullable: false),
                    periodOfEachSellingPost = table.Column<int>(type: "int", nullable: false),
                    totalPeriodOfPackage = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetail", x => x.packageDetailId);
                });

            migrationBuilder.CreateTable(
                name: "SellerAddress",
                columns: table => new
                {
                    sellerAddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    number = table.Column<string>(type: "longtext", nullable: true),
                    soi = table.Column<string>(type: "longtext", nullable: true),
                    moo = table.Column<string>(type: "longtext", nullable: true),
                    tambon = table.Column<string>(type: "longtext", nullable: true),
                    amphoe = table.Column<string>(type: "longtext", nullable: true),
                    street = table.Column<string>(type: "longtext", nullable: true),
                    province = table.Column<string>(type: "longtext", nullable: true),
                    userId = table.Column<string>(type: "longtext", nullable: true),
                    postNumber = table.Column<string>(type: "longtext", nullable: true),
                    changeSellerAddress = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerAddress", x => x.sellerAddressId);
                });

            migrationBuilder.CreateTable(
                name: "TheUser",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "longtext", nullable: true),
                    lastName = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    userRegistrationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    isSeller = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheUser", x => x.userId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seller",
                columns: table => new
                {
                    sellerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: false),
                    sellerIdCard = table.Column<string>(type: "longtext", nullable: true),
                    sellerIdCardFront = table.Column<string>(type: "longtext", nullable: true),
                    sellerIdCardBack = table.Column<string>(type: "longtext", nullable: true),
                    selllerBookBankAccountPic = table.Column<string>(type: "longtext", nullable: true),
                    sellerFarmRegisterPic = table.Column<string>(type: "longtext", nullable: true),
                    farmRegister = table.Column<int>(type: "int", nullable: false),
                    sellerRegistrationDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    sellerApproveDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    farmName = table.Column<string>(type: "longtext", nullable: true),
                    sellerProfilePic = table.Column<string>(type: "longtext", nullable: true),
                    sellerProfilePhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    sellerProfileDescription = table.Column<string>(type: "longtext", nullable: true),
                    editProfileDatetime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    profileView = table.Column<int>(type: "int", nullable: false),
                    totalPost = table.Column<int>(type: "int", nullable: false),
                    totalPostView = table.Column<int>(type: "int", nullable: false),
                    totalLike = table.Column<int>(type: "int", nullable: false),
                    sellerAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seller", x => x.sellerId);
                    table.ForeignKey(
                        name: "FK_Seller_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seller_SellerAddress_sellerAddressId",
                        column: x => x.sellerAddressId,
                        principalTable: "SellerAddress",
                        principalColumn: "sellerAddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerFeedback",
                columns: table => new
                {
                    sellerFeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: false),
                    feedbackDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    feedbackStar = table.Column<int>(type: "int", nullable: false),
                    feedbackDescription = table.Column<string>(type: "longtext", nullable: true),
                    sellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerFeedback", x => x.sellerFeedbackId);
                    table.ForeignKey(
                        name: "FK_SellerFeedback_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerFeedback_Seller_sellerId",
                        column: x => x.sellerId,
                        principalTable: "Seller",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerFeedPost",
                columns: table => new
                {
                    sellerFeedPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sellerId = table.Column<int>(type: "int", nullable: false),
                    feedPostPic1 = table.Column<string>(type: "longtext", nullable: true),
                    feedPostPic2 = table.Column<string>(type: "longtext", nullable: true),
                    feedPostPic3 = table.Column<string>(type: "longtext", nullable: true),
                    feedPostPic4 = table.Column<string>(type: "longtext", nullable: true),
                    feedPostPic5 = table.Column<string>(type: "longtext", nullable: true),
                    postingDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerFeedPost", x => x.sellerFeedPostId);
                    table.ForeignKey(
                        name: "FK_SellerFeedPost_Seller_sellerId",
                        column: x => x.sellerId,
                        principalTable: "Seller",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerPackage",
                columns: table => new
                {
                    sellerPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    packageDetailId = table.Column<int>(type: "int", nullable: false),
                    packageBuyingDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    packageStartingDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    packageEndingDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    totalPackagePurchase = table.Column<int>(type: "int", nullable: false),
                    paymentEvidence = table.Column<string>(type: "longtext", nullable: true),
                    packageStatus = table.Column<int>(type: "int", nullable: false),
                    totalPostAvailable = table.Column<int>(type: "int", nullable: false),
                    sellerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerPackage", x => x.sellerPackageId);
                    table.ForeignKey(
                        name: "FK_SellerPackage_PackageDetail_packageDetailId",
                        column: x => x.packageDetailId,
                        principalTable: "PackageDetail",
                        principalColumn: "packageDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellerPackage_Seller_sellerId",
                        column: x => x.sellerId,
                        principalTable: "Seller",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellingPost",
                columns: table => new
                {
                    sellingPostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    genderId = table.Column<int>(type: "int", nullable: false),
                    breedId = table.Column<int>(type: "int", nullable: false),
                    sellerId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    sellingPostName = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostDescription = table.Column<string>(type: "longtext", nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    pedegree = table.Column<int>(type: "int", nullable: false),
                    sellingPostPostingDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    sellingPostPostExpiredDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    postLike = table.Column<int>(type: "int", nullable: false),
                    view = table.Column<int>(type: "int", nullable: false),
                    sellingPostPic1 = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostPic2 = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostPic3 = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostPic4 = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostPic5 = table.Column<string>(type: "longtext", nullable: true),
                    sellingPostPicUpdateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPost", x => x.sellingPostId);
                    table.ForeignKey(
                        name: "FK_SellingPost_Breed_breedId",
                        column: x => x.breedId,
                        principalTable: "Breed",
                        principalColumn: "breedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellingPost_Gender_genderId",
                        column: x => x.genderId,
                        principalTable: "Gender",
                        principalColumn: "genderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellingPost_Seller_sellerId",
                        column: x => x.sellerId,
                        principalTable: "Seller",
                        principalColumn: "sellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellingPostFeedback",
                columns: table => new
                {
                    sellingPostFeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(type: "int", nullable: false),
                    sellingPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPostFeedback", x => x.sellingPostFeedbackId);
                    table.ForeignKey(
                        name: "FK_SellingPostFeedback_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellingPostFeedback_SellingPost_sellingPostId",
                        column: x => x.sellingPostId,
                        principalTable: "SellingPost",
                        principalColumn: "sellingPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_sellerAddressId",
                table: "Seller",
                column: "sellerAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Seller_userId",
                table: "Seller",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFeedback_sellerId",
                table: "SellerFeedback",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFeedback_userId",
                table: "SellerFeedback",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerFeedPost_sellerId",
                table: "SellerFeedPost",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerPackage_packageDetailId",
                table: "SellerPackage",
                column: "packageDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerPackage_sellerId",
                table: "SellerPackage",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPost_breedId",
                table: "SellingPost",
                column: "breedId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPost_genderId",
                table: "SellingPost",
                column: "genderId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPost_sellerId",
                table: "SellingPost",
                column: "sellerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPostFeedback_sellingPostId",
                table: "SellingPostFeedback",
                column: "sellingPostId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPostFeedback_userId",
                table: "SellingPostFeedback",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SellerFeedback");

            migrationBuilder.DropTable(
                name: "SellerFeedPost");

            migrationBuilder.DropTable(
                name: "SellerPackage");

            migrationBuilder.DropTable(
                name: "SellingPostFeedback");

            migrationBuilder.DropTable(
                name: "TheUser");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PackageDetail");

            migrationBuilder.DropTable(
                name: "SellingPost");

            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Seller");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SellerAddress");
        }
    }
}
