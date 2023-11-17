using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace online_s.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "adress_address_id_seq");

            migrationBuilder.CreateSequence(
                name: "brand_brand_id_seq");

            migrationBuilder.CreateSequence(
                name: "cart_cart_user_id_seq");

            migrationBuilder.CreateSequence(
                name: "category_category_id_seq");

            migrationBuilder.CreateSequence(
                name: "color_color_id_seq");

            migrationBuilder.CreateSequence(
                name: "m2m_product_size_color_m2m_psc_id_seq");

            migrationBuilder.CreateSequence(
                name: "order_order_id_seq");

            migrationBuilder.CreateSequence(
                name: "product_product_id_seq");

            migrationBuilder.CreateSequence(
                name: "review_review_id_seq");

            migrationBuilder.CreateSequence(
                name: "section_section_id_seq");

            migrationBuilder.CreateSequence(
                name: "size_size_id_seq");

            migrationBuilder.CreateSequence(
                name: "user_user_id_seq");

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    brand_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"brand_brand_id_seq\"'::text)::regclass)"),
                    brand_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"category_category_id_seq\"'::text)::regclass)"),
                    category_subcategory_id = table.Column<long>(type: "bigint", nullable: true),
                    category_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_Category_Category",
                        column: x => x.category_subcategory_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    color_id = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "nextval(('\"color_color_id_seq\"'::text)::regclass)"),
                    color_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.color_id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    section_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"section_section_id_seq\"'::text)::regclass)"),
                    section_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.section_id);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    size_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval(('\"size_size_id_seq\"'::text)::regclass)"),
                    size_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.size_id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"user_user_id_seq\"'::text)::regclass)"),
                    user_type = table.Column<short>(type: "smallint", nullable: false),
                    user_email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    user_firstname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_lastname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    user_phone_number = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"product_product_id_seq\"'::text)::regclass)"),
                    product_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    product_brand_id = table.Column<long>(type: "bigint", nullable: false),
                    product_category_id = table.Column<long>(type: "bigint", nullable: false),
                    product_price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Brand",
                        column: x => x.product_brand_id,
                        principalTable: "Brand",
                        principalColumn: "brand_id");
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.product_category_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "M2M_section_category",
                columns: table => new
                {
                    m2m_section_category_section_id = table.Column<long>(type: "bigint", nullable: false),
                    m2m_section_category_category_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_M2M_section_category_Category",
                        column: x => x.m2m_section_category_category_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_M2M_section_category_Section",
                        column: x => x.m2m_section_category_section_id,
                        principalTable: "Section",
                        principalColumn: "section_id");
                });

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    address_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"adress_address_id_seq\"'::text)::regclass)"),
                    address_user_id = table.Column<long>(type: "bigint", nullable: false),
                    address_address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Adress_User",
                        column: x => x.address_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "M2M_Product_Size_Color",
                columns: table => new
                {
                    M2M_PSC_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"m2m_product_size_color_m2m_psc_id_seq\"'::text)::regclass)"),
                    M2M_PSC_product_id = table.Column<long>(type: "bigint", nullable: false),
                    M2M_PSC_size_id = table.Column<int>(type: "integer", nullable: false),
                    M2M_PSC_color_id = table.Column<short>(type: "smallint", nullable: false),
                    M2M_PSC_quantity = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M2M_Product_Size_Color", x => x.M2M_PSC_id);
                    table.ForeignKey(
                        name: "FK_M2M_Product_Size_Color_Color",
                        column: x => x.M2M_PSC_color_id,
                        principalTable: "Color",
                        principalColumn: "color_id");
                    table.ForeignKey(
                        name: "FK_M2M_Product_Size_Color_Product",
                        column: x => x.M2M_PSC_product_id,
                        principalTable: "Product",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_M2M_Product_Size_Color_Size",
                        column: x => x.M2M_PSC_size_id,
                        principalTable: "Size",
                        principalColumn: "size_id");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    review_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"review_review_id_seq\"'::text)::regclass)"),
                    review_user_id = table.Column<long>(type: "bigint", nullable: false),
                    review_product_id = table.Column<long>(type: "bigint", nullable: false),
                    review_rating = table.Column<short>(type: "smallint", nullable: false),
                    review_comment = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_Review_Product",
                        column: x => x.review_product_id,
                        principalTable: "Product",
                        principalColumn: "product_id");
                    table.ForeignKey(
                        name: "FK_Review_User",
                        column: x => x.review_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"order_order_id_seq\"'::text)::regclass)"),
                    order_price = table.Column<decimal>(type: "money", nullable: true),
                    order_user_id = table.Column<long>(type: "bigint", nullable: false),
                    order_address_id = table.Column<long>(type: "bigint", nullable: false),
                    order_status = table.Column<int>(type: "integer", nullable: false),
                    order_time_create = table.Column<DateTime>(type: "timestamp(6) without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Order_Adress",
                        column: x => x.order_address_id,
                        principalTable: "Adress",
                        principalColumn: "address_id");
                    table.ForeignKey(
                        name: "FK_Order_User",
                        column: x => x.order_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cart_user_id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "nextval(('\"cart_cart_user_id_seq\"'::text)::regclass)"),
                    cart_product_id = table.Column<long>(type: "bigint", nullable: false),
                    cart_quantity = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_User_Product", x => new { x.cart_user_id, x.cart_product_id });
                    table.ForeignKey(
                        name: "FK_Cart_M2M_Product_Size_Color",
                        column: x => x.cart_product_id,
                        principalTable: "M2M_Product_Size_Color",
                        principalColumn: "M2M_PSC_id");
                    table.ForeignKey(
                        name: "FK_Cart_User",
                        column: x => x.cart_user_id,
                        principalTable: "User",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "M2M_order_product",
                columns: table => new
                {
                    m2m_order_product_order_id = table.Column<long>(type: "bigint", nullable: false),
                    m2m_order_product_product_id = table.Column<long>(type: "bigint", nullable: false),
                    m2m_order_product_quantity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_M2M_order_product_M2M_Product_Size_Color",
                        column: x => x.m2m_order_product_product_id,
                        principalTable: "M2M_Product_Size_Color",
                        principalColumn: "M2M_PSC_id");
                    table.ForeignKey(
                        name: "FK_M2M_order_product_Order",
                        column: x => x.m2m_order_product_order_id,
                        principalTable: "Order",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateIndex(
                name: "IXFK_Adress_User",
                table: "Adress",
                column: "address_user_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Cart_M2M_Product_Size_Color",
                table: "Cart",
                column: "cart_product_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Cart_User",
                table: "Cart",
                column: "cart_user_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Category_Category",
                table: "Category",
                column: "category_subcategory_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_order_product_M2M_Product_Size_Color",
                table: "M2M_order_product",
                column: "m2m_order_product_product_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_order_product_Order",
                table: "M2M_order_product",
                column: "m2m_order_product_order_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_Product_Size_Color_Color",
                table: "M2M_Product_Size_Color",
                column: "M2M_PSC_color_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_Product_Size_Color_Product",
                table: "M2M_Product_Size_Color",
                column: "M2M_PSC_product_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_Product_Size_Color_Size",
                table: "M2M_Product_Size_Color",
                column: "M2M_PSC_size_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_section_category_Category",
                table: "M2M_section_category",
                column: "m2m_section_category_category_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_M2M_section_category_Section",
                table: "M2M_section_category",
                column: "m2m_section_category_section_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Order_Adress",
                table: "Order",
                column: "order_address_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Order_User",
                table: "Order",
                column: "order_user_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Product_Brand",
                table: "Product",
                column: "product_brand_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Product_Category",
                table: "Product",
                column: "product_category_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Review_Product",
                table: "Review",
                column: "review_product_id");

            migrationBuilder.CreateIndex(
                name: "IXFK_Review_User",
                table: "Review",
                column: "review_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "M2M_order_product");

            migrationBuilder.DropTable(
                name: "M2M_section_category");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "M2M_Product_Size_Color");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropSequence(
                name: "adress_address_id_seq");

            migrationBuilder.DropSequence(
                name: "brand_brand_id_seq");

            migrationBuilder.DropSequence(
                name: "cart_cart_user_id_seq");

            migrationBuilder.DropSequence(
                name: "category_category_id_seq");

            migrationBuilder.DropSequence(
                name: "color_color_id_seq");

            migrationBuilder.DropSequence(
                name: "m2m_product_size_color_m2m_psc_id_seq");

            migrationBuilder.DropSequence(
                name: "order_order_id_seq");

            migrationBuilder.DropSequence(
                name: "product_product_id_seq");

            migrationBuilder.DropSequence(
                name: "review_review_id_seq");

            migrationBuilder.DropSequence(
                name: "section_section_id_seq");

            migrationBuilder.DropSequence(
                name: "size_size_id_seq");

            migrationBuilder.DropSequence(
                name: "user_user_id_seq");
        }
    }
}
