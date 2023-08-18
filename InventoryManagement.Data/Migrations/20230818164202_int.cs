using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagement.Data.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(maxLength: 128, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CostPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(maxLength: 128, nullable: true),
                    CustomerName = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    CustomerAddress = table.Column<string>(maxLength: 500, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Paid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AccountTransactionCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "(0.00)"),
                    Due = table.Column<decimal>(nullable: false, computedColumnSql: "(([TotalAmount]+[ReturnAmount]+[AccountTransactionCharge])-([TotalDiscount]+[Paid]+[PurchaseAdjustedAmount])) PERSISTED"),
                    PurchaseAdjustedAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DueLimit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Designation = table.Column<string>(maxLength: 255, nullable: true),
                    IsIndividual = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    ExpenseCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => x.ExpenseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseFixed",
                columns: table => new
                {
                    ExpenseFixedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    IntervalDays = table.Column<int>(nullable: false),
                    CostPerDay = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "([Amount]/[IntervalDays]) PERSISTED"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseFixed", x => x.ExpenseFixedId);
                });

            migrationBuilder.CreateTable(
                name: "PageLinkCategory",
                columns: table => new
                {
                    LinkCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(maxLength: 128, nullable: false),
                    IconClass = table.Column<string>(maxLength: 128, nullable: true),
                    SN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLinkCategory", x => x.LinkCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCatalogType",
                columns: table => new
                {
                    CatalogTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogType = table.Column<string>(maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalogType", x => x.CatalogTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Validation = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    Type = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    FatherName = table.Column<string>(maxLength: 128, nullable: true),
                    Designation = table.Column<string>(maxLength: 128, nullable: true),
                    DateofBirth = table.Column<string>(maxLength: 50, nullable: true),
                    NationalID = table.Column<string>(maxLength: 128, nullable: true),
                    Address = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PS = table.Column<string>(maxLength: 50, nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCompanyName = table.Column<string>(maxLength: 128, nullable: false),
                    VendorName = table.Column<string>(maxLength: 128, nullable: true),
                    VendorAddress = table.Column<string>(maxLength: 500, nullable: true),
                    VendorPhone = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalDiscount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Paid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Due = table.Column<decimal>(nullable: false, computedColumnSql: "(([TotalAmount]+[ReturnAmount])-([TotalDiscount]+[Paid])) PERSISTED"),
                    Photo = table.Column<byte[]>(nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "AccountDeposit",
                columns: table => new
                {
                    AccountDepositId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    DepositDateUtc = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDeposit", x => x.AccountDepositId);
                    table.ForeignKey(
                        name: "FK_AccountDeposit_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "AccountWithdraw",
                columns: table => new
                {
                    AccountWithdrawId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    WithdrawAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    WithdrawDateUtc = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountWithdraw", x => x.AccountWithdrawId);
                    table.ForeignKey(
                        name: "FK_AccountWithdraw_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateTable(
                name: "Institution",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherCountdown = table.Column<int>(nullable: false),
                    InstitutionName = table.Column<string>(maxLength: 500, nullable: false),
                    DialogTitle = table.Column<string>(maxLength: 256, nullable: true),
                    Established = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    City = table.Column<string>(maxLength: 128, nullable: true),
                    State = table.Column<string>(maxLength: 128, nullable: true),
                    LocalArea = table.Column<string>(maxLength: 128, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Website = table.Column<string>(maxLength: 50, nullable: true),
                    InstitutionLogo = table.Column<byte[]>(nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    DefaultAccountId = table.Column<int>(nullable: true),
                    Capital = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "(0.00)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institution", x => x.InstitutionId);
                    table.ForeignKey(
                        name: "FK_Institution_Account_DefaultAccountId",
                        column: x => x.DefaultAccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "CustomerPhone",
                columns: table => new
                {
                    CustomerPhoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false, defaultValueSql: "((0))"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPhone", x => x.CustomerPhoneId);
                    table.ForeignKey(
                        name: "FK_CustomerPhone_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PageLink",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkCategoryId = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(maxLength: 128, nullable: true),
                    Controller = table.Column<string>(maxLength: 128, nullable: false),
                    Action = table.Column<string>(maxLength: 128, nullable: false),
                    Title = table.Column<string>(maxLength: 128, nullable: false),
                    IconClass = table.Column<string>(maxLength: 128, nullable: true),
                    SN = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLink", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_PageLink_PageLinkCategory",
                        column: x => x.LinkCategoryId,
                        principalTable: "PageLinkCategory",
                        principalColumn: "LinkCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCatalog",
                columns: table => new
                {
                    ProductCatalogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatalogTypeId = table.Column<int>(nullable: true),
                    CatalogName = table.Column<string>(maxLength: 500, nullable: false),
                    CatalogLevel = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    ItemCount = table.Column<int>(nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCatalog", x => x.ProductCatalogId);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_ProductCatalogType",
                        column: x => x.CatalogTypeId,
                        principalTable: "ProductCatalogType",
                        principalColumn: "CatalogTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCatalog_ProductCatalog",
                        column: x => x.ParentId,
                        principalTable: "ProductCatalog",
                        principalColumn: "ProductCatalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdminMoneyCollection",
                columns: table => new
                {
                    AdminMoneyCollectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    CollectionAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMoneyCollection", x => x.AdminMoneyCollectionId);
                    table.ForeignKey(
                        name: "FK_AdminMoneyCollection_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherNo = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: false),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExpenseFor = table.Column<string>(maxLength: 256, nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expense_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_ExpenseCategory",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategory",
                        principalColumn: "ExpenseCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expense_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTransportation",
                columns: table => new
                {
                    ExpenseTransportationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: true),
                    VoucherNo = table.Column<int>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExpenseNote = table.Column<string>(maxLength: 500, nullable: true),
                    ExpenseDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTransportation", x => x.ExpenseTransportationId);
                    table.ForeignKey(
                        name: "FK_ExpenseTransportation_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseTransportation_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_ExpenseTransportation_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                });

            migrationBuilder.CreateTable(
                name: "SellingPayment",
                columns: table => new
                {
                    SellingPaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ReceiptSN = table.Column<int>(nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 50, nullable: true),
                    AccountTransactionCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "(0.00)"),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AccountId = table.Column<int>(nullable: true),
                    AccountCost = table.Column<decimal>(nullable: false, computedColumnSql: "([PaidAmount] * ([AccountCostPercentage]/100)) PERSISTED"),
                    AccountCostPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPayment", x => x.SellingPaymentId);
                    table.ForeignKey(
                        name: "FK_SellingPayment_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingPayment_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingPayment_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    ServiceSN = table.Column<int>(nullable: false),
                    ServiceTotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ServiceDiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ServiceDiscountPercentage = table.Column<decimal>(nullable: false, computedColumnSql: "(case when [ServiceTotalPrice]=(0) then (0) else ([ServiceDiscountAmount]*(100))/[ServiceTotalPrice] end) PERSISTED"),
                    ServicePaidAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ServiceDueAmount = table.Column<decimal>(nullable: false, computedColumnSql: "([ServiceTotalPrice]-([ServiceDiscountAmount]+[ServicePaidAmount])) PERSISTED"),
                    ServicePaymentStatus = table.Column<string>(unicode: false, maxLength: 4, nullable: false, computedColumnSql: "(case when ([ServiceTotalPrice]-([ServiceDiscountAmount]+[ServicePaidAmount]))<=(0) then 'Paid' else 'Due' end) PERSISTED"),
                    ServiceDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    PurchaseSN = table.Column<int>(nullable: false),
                    PurchaseTotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchaseDiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchaseDiscountPercentage = table.Column<decimal>(nullable: false, computedColumnSql: "(case when [PurchaseTotalPrice]=(0) then (0) else ([PurchaseDiscountAmount]*(100))/[PurchaseTotalPrice] end) PERSISTED"),
                    PurchasePaidAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchaseReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchaseDueAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "(([PurchaseTotalPrice]+[PurchaseReturnAmount])-([PurchaseDiscountAmount]+[PurchasePaidAmount])) PERSISTED"),
                    PurchasePaymentStatus = table.Column<string>(unicode: false, maxLength: 4, nullable: false, computedColumnSql: "(case when (([PurchaseTotalPrice]+[PurchaseReturnAmount])-([PurchaseDiscountAmount]+[PurchasePaidAmount]))<=(0) then 'Paid' else 'Due' end) PERSISTED"),
                    MemoNumber = table.Column<string>(maxLength: 50, nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchase_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Purchase_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePayment",
                columns: table => new
                {
                    PurchasePaymentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    ReceiptSN = table.Column<int>(nullable: false),
                    PaidAmount = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<string>(maxLength: 50, nullable: true),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePayment", x => x.PurchasePaymentId);
                    table.ForeignKey(
                        name: "FK_PurchasePayment_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePayment_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePayment_Vendor",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageLinkAssign",
                columns: table => new
                {
                    LinkAssignId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    LinkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLinkAssign", x => x.LinkAssignId);
                    table.ForeignKey(
                        name: "FK_PageLinkAssign_PageLink",
                        column: x => x.LinkId,
                        principalTable: "PageLink",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageLinkAssign_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCatalogId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Warranty = table.Column<string>(maxLength: 128, nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "0"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_ProductCatalog",
                        column: x => x.ProductCatalogId,
                        principalTable: "ProductCatalog",
                        principalColumn: "ProductCatalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDevice",
                columns: table => new
                {
                    ServiceDeviceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCatalogId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    DeviceCode = table.Column<string>(maxLength: 128, nullable: false),
                    DeviceName = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDevice", x => x.ServiceDeviceId);
                    table.ForeignKey(
                        name: "FK_ServiceDevice_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceDevice_ProductCatalog",
                        column: x => x.ProductCatalogId,
                        principalTable: "ProductCatalog",
                        principalColumn: "ProductCatalogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTransportationList",
                columns: table => new
                {
                    ExpenseTransportationListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseTransportationId = table.Column<int>(nullable: false),
                    NumberOfPerson = table.Column<int>(nullable: false),
                    ExpenseFor = table.Column<string>(maxLength: 256, nullable: false),
                    Vehicle = table.Column<string>(maxLength: 128, nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTransportationList", x => x.ExpenseTransportationListId);
                    table.ForeignKey(
                        name: "FK_ExpenseTransportationList_ExpenseTransportation_ExpenseTransportationId",
                        column: x => x.ExpenseTransportationId,
                        principalTable: "ExpenseTransportation",
                        principalColumn: "ExpenseTransportationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicePaymentList",
                columns: table => new
                {
                    ServicePaymentListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellingPaymentId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    ServicePaidAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePaymentList", x => x.ServicePaymentListId);
                    table.ForeignKey(
                        name: "FK_ServicePaymentList_SellingPayment",
                        column: x => x.SellingPaymentId,
                        principalTable: "SellingPayment",
                        principalColumn: "SellingPaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicePaymentList_Service",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentReturnRecord",
                columns: table => new
                {
                    PurchasePaymentReturnRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CurrentReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NetReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "([CurrentReturnAmount]-[PrevReturnAmount]) PERSISTED"),
                    AccountId = table.Column<int>(nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    PurchaseId = table.Column<int>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentReturnRecord", x => x.PurchasePaymentReturnRecordId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReturnRecord_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReturnRecord_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentReturnRecord_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selling",
                columns: table => new
                {
                    SellingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    SellingSN = table.Column<int>(nullable: false),
                    SellingTotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SellingDiscountAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SellingDiscountPercentage = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "(case when [SellingTotalPrice]=(0.00) then (0.00) else ([SellingDiscountAmount]*(100.00))/[SellingTotalPrice] end) PERSISTED"),
                    SellingPaidAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SellingReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SellingDueAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "(([SellingTotalPrice]+[ServiceCharge]+[SellingReturnAmount]+[AccountTransactionCharge])-([SellingDiscountAmount]+[SellingPaidAmount]+[PurchaseAdjustedAmount])) PERSISTED"),
                    SellingPaymentStatus = table.Column<string>(unicode: false, maxLength: 4, nullable: false, computedColumnSql: "(case when (([SellingTotalPrice]+[ServiceCharge]+[SellingReturnAmount]+[AccountTransactionCharge])-([SellingDiscountAmount]+[SellingPaidAmount]+[PurchaseAdjustedAmount]))<=(0.00) then 'Paid' else 'Due' end) PERSISTED"),
                    SellingDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    LastUpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    PromisedPaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ServiceCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ServiceChargeDescription = table.Column<string>(maxLength: 1024, nullable: true),
                    ExpenseTotal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AccountTransactionCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "(0.00)"),
                    BuyingTotalPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SellingAccountCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ServiceProfit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "([ServiceCharge]-[ServiceCost]) PERSISTED"),
                    SellingProfit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "([SellingTotalPrice]-[BuyingTotalPrice]) PERSISTED"),
                    SellingNetProfit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "(([SellingTotalPrice]+[AccountTransactionCharge])-([BuyingTotalPrice]+[SellingAccountCost]+[ExpenseTotal])) PERSISTED"),
                    GrandProfit = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "((([SellingTotalPrice]+[AccountTransactionCharge])-([BuyingTotalPrice]+[SellingDiscountAmount]+[SellingAccountCost]+[ExpenseTotal]))+([ServiceCharge]-[ServiceCost])) PERSISTED"),
                    PurchaseAdjustedAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchaseDescription = table.Column<string>(maxLength: 1024, nullable: true),
                    PurchaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selling", x => x.SellingId);
                    table.ForeignKey(
                        name: "FK_Selling_Customer",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selling_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId");
                    table.ForeignKey(
                        name: "FK_Selling_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentList",
                columns: table => new
                {
                    PurchasePaymentListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasePaymentId = table.Column<int>(nullable: false),
                    PurchaseId = table.Column<int>(nullable: false),
                    PurchasePaidAmount = table.Column<decimal>(nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentList", x => x.PurchasePaymentListId);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentList_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasePaymentList_PurchasePayment",
                        column: x => x.PurchasePaymentId,
                        principalTable: "PurchasePayment",
                        principalColumn: "PurchasePaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseList",
                columns: table => new
                {
                    PurchaseListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Warranty = table.Column<string>(maxLength: 128, nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "0"),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseList", x => x.PurchaseListId);
                    table.ForeignKey(
                        name: "FK_PurchaseList_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_PurchaseList_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceList",
                columns: table => new
                {
                    ServiceListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(nullable: false),
                    ServiceDeviceId = table.Column<int>(nullable: false),
                    ServiceCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Problem = table.Column<string>(maxLength: 500, nullable: true),
                    Solution = table.Column<string>(maxLength: 500, nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceList", x => x.ServiceListId);
                    table.ForeignKey(
                        name: "FK_ServiceList_ServiceDevice",
                        column: x => x.ServiceDeviceId,
                        principalTable: "ServiceDevice",
                        principalColumn: "ServiceDeviceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceList_Service",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellingExpense",
                columns: table => new
                {
                    SellingExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellingId = table.Column<int>(nullable: false),
                    Expense = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExpenseDescription = table.Column<string>(maxLength: 1024, nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    AccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingExpense", x => x.SellingExpenseId);
                    table.ForeignKey(
                        name: "FK_SellingExpense_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingExpense_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellingList",
                columns: table => new
                {
                    SellingListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellingId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "0"),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Warranty = table.Column<string>(maxLength: 128, nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingList", x => x.SellingListId);
                    table.ForeignKey(
                        name: "FK_SellingList_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SellingList_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellingPaymentList",
                columns: table => new
                {
                    SellingPaymentListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellingPaymentId = table.Column<int>(nullable: false),
                    SellingId = table.Column<int>(nullable: false),
                    SellingPaidAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AccountTransactionCharge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValueSql: "(0.00)"),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPaymentList", x => x.SellingPaymentListId);
                    table.ForeignKey(
                        name: "FK_SellingPaymentList_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingPaymentList_SellingPayment",
                        column: x => x.SellingPaymentId,
                        principalTable: "SellingPayment",
                        principalColumn: "SellingPaymentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellingPaymentReturnRecord",
                columns: table => new
                {
                    SellingPaymentReturnRecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrevReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CurrentReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    NetReturnAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, computedColumnSql: "([CurrentReturnAmount]-[PrevReturnAmount]) PERSISTED"),
                    AccountId = table.Column<int>(nullable: true),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    SellingId = table.Column<int>(nullable: false),
                    RegistrationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPaymentReturnRecord", x => x.SellingPaymentReturnRecordId);
                    table.ForeignKey(
                        name: "FK_SellingPaymentReturnRecord_Account",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingPaymentReturnRecord_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingPaymentReturnRecord_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellingPromiseDateMiss",
                columns: table => new
                {
                    SellingPromiseDateMissId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    SellingId = table.Column<int>(nullable: false),
                    MissDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPromiseDateMiss", x => x.SellingPromiseDateMissId);
                    table.ForeignKey(
                        name: "FK_SellingPromiseDateMiss_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                    table.ForeignKey(
                        name: "FK_SellingPromiseDateMiss_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId");
                });

            migrationBuilder.CreateTable(
                name: "ProductStock",
                columns: table => new
                {
                    ProductStockId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(maxLength: 128, nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SellingListId = table.Column<int>(nullable: true),
                    PurchaseListId = table.Column<int>(nullable: false),
                    IsSold = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => x.ProductStockId);
                    table.ForeignKey(
                        name: "FK_ProductStock_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStock_PurchaseList",
                        column: x => x.PurchaseListId,
                        principalTable: "PurchaseList",
                        principalColumn: "PurchaseListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStock_SellingList",
                        column: x => x.SellingListId,
                        principalTable: "SellingList",
                        principalColumn: "SellingListId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductDamaged",
                columns: table => new
                {
                    ProductDamagedId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductStockId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1024, nullable: true),
                    DamagedDate = table.Column<DateTime>(type: "date", nullable: false),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDamaged", x => x.ProductDamagedId);
                    table.ForeignKey(
                        name: "FK_ProductDamaged_ProductStock",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStock",
                        principalColumn: "ProductStockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLog",
                columns: table => new
                {
                    ProductLogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductStockId = table.Column<int>(nullable: false),
                    Details = table.Column<string>(maxLength: 1024, nullable: false),
                    LogStatus = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())"),
                    ActivityByRegistrationId = table.Column<int>(nullable: false),
                    SellingId = table.Column<int>(nullable: true),
                    PurchaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLog", x => x.ProductLogId);
                    table.ForeignKey(
                        name: "FK_ProductLog_Registration",
                        column: x => x.ActivityByRegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId");
                    table.ForeignKey(
                        name: "FK_ProductLog_ProductStock",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStock",
                        principalColumn: "ProductStockId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLog_Purchase",
                        column: x => x.PurchaseId,
                        principalTable: "Purchase",
                        principalColumn: "PurchaseId");
                    table.ForeignKey(
                        name: "FK_ProductLog_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId");
                });

            migrationBuilder.CreateTable(
                name: "SellingAdjustment",
                columns: table => new
                {
                    SellingAdjustmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    SellingId = table.Column<int>(nullable: false),
                    ProductStockId = table.Column<int>(nullable: false),
                    AdjustmentStatus = table.Column<string>(maxLength: 128, nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingAdjustment", x => x.SellingAdjustmentId);
                    table.ForeignKey(
                        name: "FK_SellingAdjustment_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingAdjustment_ProductStock",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStock",
                        principalColumn: "ProductStockId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingAdjustment_Registration",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "RegistrationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingAdjustment_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warranty",
                columns: table => new
                {
                    WarrantyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SellingId = table.Column<int>(nullable: false),
                    ProductStockId = table.Column<int>(nullable: false),
                    ChangedProductCatalogId = table.Column<int>(nullable: true),
                    WarrantySn = table.Column<int>(nullable: false),
                    AcceptanceDescription = table.Column<string>(maxLength: 1024, nullable: true),
                    AcceptanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeliveryDescription = table.Column<string>(maxLength: 1024, nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    ChangedProductName = table.Column<string>(maxLength: 128, nullable: true),
                    ChangedProductCode = table.Column<string>(maxLength: 50, nullable: true),
                    IsDelivered = table.Column<bool>(nullable: false),
                    InsertDateUtc = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranty", x => x.WarrantyId);
                    table.ForeignKey(
                        name: "FK_Warranty_ProductCatalog",
                        column: x => x.ChangedProductCatalogId,
                        principalTable: "ProductCatalog",
                        principalColumn: "ProductCatalogId");
                    table.ForeignKey(
                        name: "FK_Warranty_ProductStock",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStock",
                        principalColumn: "ProductStockId");
                    table.ForeignKey(
                        name: "FK_Warranty_Selling",
                        column: x => x.SellingId,
                        principalTable: "Selling",
                        principalColumn: "SellingId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5A71C6C4-9488-4BCC-A680-445A34C6E721", "5A71C6C4-9488-4BCC-A680-445A34C6E721", "admin", "ADMIN" },
                    { "F73A5277-2535-48A4-A371-300508ADDD2F", "F73A5277-2535-48A4-A371-300508ADDD2F", "SubAdmin", "SUBADMIN" },
                    { "95A97547-7B72-4E5C-855C-AA1F8CA327E8", "95A97547-7B72-4E5C-855C-AA1F8CA327E8", "SalesPerson", "SALESPERSON" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "A0456563-F978-4135-B563-97F23EA02FDA", 0, "A0456563-F978-4135-B563-97F23EA02FDA", "admin@gmail.com", true, true, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEDch3arYEB9dCAudNdsYEpVX7ryywa8f3ZIJSVUmEThAI50pLh9RyEu7NjGJccpOog==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Institution",
                columns: new[] { "InstitutionId", "Address", "City", "DefaultAccountId", "DialogTitle", "Email", "Established", "InstitutionLogo", "InstitutionName", "LocalArea", "Phone", "PostalCode", "State", "VoucherCountdown", "Website" },
                values: new object[] { 1, null, null, null, null, null, null, null, "Institution", null, null, null, null, 0, null });

            migrationBuilder.InsertData(
                table: "Registration",
                columns: new[] { "RegistrationId", "Address", "Balance", "DateofBirth", "Designation", "Email", "FatherName", "Image", "Name", "NationalID", "Phone", "PS", "Type", "UserName" },
                values: new object[] { 1, null, 0m, null, null, null, null, null, "Admin", null, null, "Admin_121", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "A0456563-F978-4135-B563-97F23EA02FDA", "5A71C6C4-9488-4BCC-A680-445A34C6E721" });

            migrationBuilder.CreateIndex(
                name: "IX_AccountDeposit_AccountId",
                table: "AccountDeposit",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountWithdraw_AccountId",
                table: "AccountWithdraw",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminMoneyCollection_RegistrationId",
                table: "AdminMoneyCollection",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhone_CustomerId",
                table: "CustomerPhone",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_AccountId",
                table: "Expense",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseCategoryId",
                table: "Expense",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_RegistrationId",
                table: "Expense",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTransportation_AccountId",
                table: "ExpenseTransportation",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTransportation_CustomerId",
                table: "ExpenseTransportation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTransportation_RegistrationId",
                table: "ExpenseTransportation",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTransportationList_ExpenseTransportationId",
                table: "ExpenseTransportationList",
                column: "ExpenseTransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_Institution_DefaultAccountId",
                table: "Institution",
                column: "DefaultAccountId",
                unique: true,
                filter: "[DefaultAccountId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PageLink_LinkCategoryId",
                table: "PageLink",
                column: "LinkCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinkAssign_LinkId",
                table: "PageLinkAssign",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLinkAssign_RegistrationId",
                table: "PageLinkAssign",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCatalogId",
                table: "Product",
                column: "ProductCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_CatalogTypeId",
                table: "ProductCatalog",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCatalog_ParentId",
                table: "ProductCatalog",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDamaged_ProductStockId",
                table: "ProductDamaged",
                column: "ProductStockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductLog_ActivityByRegistrationId",
                table: "ProductLog",
                column: "ActivityByRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLog_ProductStockId",
                table: "ProductLog",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLog_PurchaseId",
                table: "ProductLog",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLog_SellingId",
                table: "ProductLog",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_PurchaseListId",
                table: "ProductStock",
                column: "PurchaseListId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_SellingListId",
                table: "ProductStock",
                column: "SellingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RegistrationId",
                table: "Purchase",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_VendorId",
                table: "Purchase",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseList_ProductId",
                table: "PurchaseList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseList_PurchaseId",
                table: "PurchaseList",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_AccountId",
                table: "PurchasePayment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_RegistrationId",
                table: "PurchasePayment",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_VendorId",
                table: "PurchasePayment",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentList_PurchaseId",
                table: "PurchasePaymentList",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentList_PurchasePaymentId",
                table: "PurchasePaymentList",
                column: "PurchasePaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReturnRecord_AccountId",
                table: "PurchasePaymentReturnRecord",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReturnRecord_PurchaseId",
                table: "PurchasePaymentReturnRecord",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePaymentReturnRecord_RegistrationId",
                table: "PurchasePaymentReturnRecord",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Selling_CustomerId",
                table: "Selling",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Selling_PurchaseId",
                table: "Selling",
                column: "PurchaseId",
                unique: true,
                filter: "[PurchaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Selling_RegistrationId",
                table: "Selling",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingAdjustment_ProductId",
                table: "SellingAdjustment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingAdjustment_ProductStockId",
                table: "SellingAdjustment",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingAdjustment_RegistrationId",
                table: "SellingAdjustment",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingAdjustment_SellingId",
                table: "SellingAdjustment",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingExpense_AccountId",
                table: "SellingExpense",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingExpense_SellingId",
                table: "SellingExpense",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingList_ProductId",
                table: "SellingList",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingList_SellingId",
                table: "SellingList",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPayment_AccountId",
                table: "SellingPayment",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPayment_CustomerId",
                table: "SellingPayment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPayment_RegistrationId",
                table: "SellingPayment",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentList_SellingId",
                table: "SellingPaymentList",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentList_SellingPaymentId",
                table: "SellingPaymentList",
                column: "SellingPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReturnRecord_AccountId",
                table: "SellingPaymentReturnRecord",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReturnRecord_RegistrationId",
                table: "SellingPaymentReturnRecord",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPaymentReturnRecord_SellingId",
                table: "SellingPaymentReturnRecord",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPromiseDateMiss_RegistrationId",
                table: "SellingPromiseDateMiss",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPromiseDateMiss_SellingId",
                table: "SellingPromiseDateMiss",
                column: "SellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CustomerId",
                table: "Service",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_RegistrationId",
                table: "Service",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDevice_CustomerId",
                table: "ServiceDevice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDevice_ProductCatalogId",
                table: "ServiceDevice",
                column: "ProductCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceList_ServiceDeviceId",
                table: "ServiceList",
                column: "ServiceDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceList_ServiceId",
                table: "ServiceList",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePaymentList_SellingPaymentId",
                table: "ServicePaymentList",
                column: "SellingPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePaymentList_ServiceId",
                table: "ServicePaymentList",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranty_ChangedProductCatalogId",
                table: "Warranty",
                column: "ChangedProductCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranty_ProductStockId",
                table: "Warranty",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Warranty_SellingId",
                table: "Warranty",
                column: "SellingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountDeposit");

            migrationBuilder.DropTable(
                name: "AccountWithdraw");

            migrationBuilder.DropTable(
                name: "AdminMoneyCollection");

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
                name: "CustomerPhone");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "ExpenseFixed");

            migrationBuilder.DropTable(
                name: "ExpenseTransportationList");

            migrationBuilder.DropTable(
                name: "Institution");

            migrationBuilder.DropTable(
                name: "PageLinkAssign");

            migrationBuilder.DropTable(
                name: "ProductDamaged");

            migrationBuilder.DropTable(
                name: "ProductLog");

            migrationBuilder.DropTable(
                name: "PurchasePaymentList");

            migrationBuilder.DropTable(
                name: "PurchasePaymentReturnRecord");

            migrationBuilder.DropTable(
                name: "SellingAdjustment");

            migrationBuilder.DropTable(
                name: "SellingExpense");

            migrationBuilder.DropTable(
                name: "SellingPaymentList");

            migrationBuilder.DropTable(
                name: "SellingPaymentReturnRecord");

            migrationBuilder.DropTable(
                name: "SellingPromiseDateMiss");

            migrationBuilder.DropTable(
                name: "ServiceList");

            migrationBuilder.DropTable(
                name: "ServicePaymentList");

            migrationBuilder.DropTable(
                name: "Warranty");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropTable(
                name: "ExpenseTransportation");

            migrationBuilder.DropTable(
                name: "PageLink");

            migrationBuilder.DropTable(
                name: "PurchasePayment");

            migrationBuilder.DropTable(
                name: "ServiceDevice");

            migrationBuilder.DropTable(
                name: "SellingPayment");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ProductStock");

            migrationBuilder.DropTable(
                name: "PageLinkCategory");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "PurchaseList");

            migrationBuilder.DropTable(
                name: "SellingList");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Selling");

            migrationBuilder.DropTable(
                name: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Purchase");

            migrationBuilder.DropTable(
                name: "ProductCatalogType");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
