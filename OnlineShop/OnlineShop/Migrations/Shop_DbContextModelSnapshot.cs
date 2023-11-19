﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineShop.Models.ScaffDir;

#nullable disable

namespace OnlineShop.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class Shop_DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("adress_address_id_seq");

            modelBuilder.HasSequence("brand_brand_id_seq");

            modelBuilder.HasSequence("cart_cart_user_id_seq");

            modelBuilder.HasSequence("category_category_id_seq");

            modelBuilder.HasSequence("color_color_id_seq");

            modelBuilder.HasSequence("m2m_product_size_color_m2m_psc_id_seq");

            modelBuilder.HasSequence("order_order_id_seq");

            modelBuilder.HasSequence("product_product_id_seq");

            modelBuilder.HasSequence("review_review_id_seq");

            modelBuilder.HasSequence("section_section_id_seq");

            modelBuilder.HasSequence("size_size_id_seq");

            modelBuilder.HasSequence("user_user_id_seq");

            modelBuilder.Entity("OnlineShop.ScaffDir.Adress", b =>
                {
                    b.Property<long>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("address_id")
                        .HasDefaultValueSql("nextval(('\"adress_address_id_seq\"'::text)::regclass)");

                    b.Property<string>("AddressAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address_address");

                    b.Property<long>("AddressUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("address_user_id");

                    b.HasKey("AddressId");

                    b.HasIndex(new[] { "AddressUserId" }, "IXFK_Adress_User");

                    b.ToTable("Adress", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Brand", b =>
                {
                    b.Property<long>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("brand_id")
                        .HasDefaultValueSql("nextval(('\"brand_brand_id_seq\"'::text)::regclass)");

                    b.Property<string>("BrandName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("brand_name");

                    b.HasKey("BrandId");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Cart", b =>
                {
                    b.Property<long>("CartUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("cart_user_id")
                        .HasDefaultValueSql("nextval(('\"cart_cart_user_id_seq\"'::text)::regclass)");

                    b.Property<long>("CartProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("cart_product_id");

                    b.Property<short?>("CartQuantity")
                        .HasColumnType("smallint")
                        .HasColumnName("cart_quantity");

                    b.HasKey("CartUserId", "CartProductId")
                        .HasName("PK_Cart_User_Product");

                    b.HasIndex(new[] { "CartProductId" }, "IXFK_Cart_M2M_Product_Size_Color");

                    b.HasIndex(new[] { "CartUserId" }, "IXFK_Cart_User");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("category_id")
                        .HasDefaultValueSql("nextval(('\"category_category_id_seq\"'::text)::regclass)");

                    b.Property<string>("CategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("category_name");

                    b.Property<long?>("CategorySubcategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("category_subcategory_id");

                    b.HasKey("CategoryId");

                    b.HasIndex(new[] { "CategorySubcategoryId" }, "IXFK_Category_Category");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Color", b =>
                {
                    b.Property<short>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasColumnName("color_id")
                        .HasDefaultValueSql("nextval(('\"color_color_id_seq\"'::text)::regclass)");

                    b.Property<string>("ColorName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("color_name");

                    b.HasKey("ColorId");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mOrderProduct", b =>
                {
                    b.Property<long>("M2mOrderProductOrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("m2m_order_product_order_id");

                    b.Property<long>("M2mOrderProductProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("m2m_order_product_product_id");

                    b.Property<string>("M2mOrderProductQuantity")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("m2m_order_product_quantity");

                    b.HasIndex(new[] { "M2mOrderProductProductId" }, "IXFK_M2M_order_product_M2M_Product_Size_Color");

                    b.HasIndex(new[] { "M2mOrderProductOrderId" }, "IXFK_M2M_order_product_Order");

                    b.ToTable("M2M_order_product", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mProductSizeColor", b =>
                {
                    b.Property<long>("M2mPscId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("M2M_PSC_id")
                        .HasDefaultValueSql("nextval(('\"m2m_product_size_color_m2m_psc_id_seq\"'::text)::regclass)");

                    b.Property<short>("M2mPscColorId")
                        .HasColumnType("smallint")
                        .HasColumnName("M2M_PSC_color_id");

                    b.Property<long>("M2mPscProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("M2M_PSC_product_id");

                    b.Property<int?>("M2mPscQuantity")
                        .HasColumnType("integer")
                        .HasColumnName("M2M_PSC_quantity");

                    b.Property<int>("M2mPscSizeId")
                        .HasColumnType("integer")
                        .HasColumnName("M2M_PSC_size_id");

                    b.HasKey("M2mPscId");

                    b.HasIndex(new[] { "M2mPscColorId" }, "IXFK_M2M_Product_Size_Color_Color");

                    b.HasIndex(new[] { "M2mPscProductId" }, "IXFK_M2M_Product_Size_Color_Product");

                    b.HasIndex(new[] { "M2mPscSizeId" }, "IXFK_M2M_Product_Size_Color_Size");

                    b.ToTable("M2M_Product_Size_Color", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mSectionCategory", b =>
                {
                    b.Property<long>("M2mSectionCategoryCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("m2m_section_category_category_id");

                    b.Property<long>("M2mSectionCategorySectionId")
                        .HasColumnType("bigint")
                        .HasColumnName("m2m_section_category_section_id");

                    b.HasIndex(new[] { "M2mSectionCategoryCategoryId" }, "IXFK_M2M_section_category_Category");

                    b.HasIndex(new[] { "M2mSectionCategorySectionId" }, "IXFK_M2M_section_category_Section");

                    b.ToTable("M2M_section_category", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("order_id")
                        .HasDefaultValueSql("nextval(('\"order_order_id_seq\"'::text)::regclass)");

                    b.Property<long>("OrderAddressId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_address_id");

                    b.Property<decimal?>("OrderPrice")
                        .HasColumnType("money")
                        .HasColumnName("order_price");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer")
                        .HasColumnName("order_status");

                    b.Property<DateTime?>("OrderTimeCreate")
                        .HasColumnType("timestamp(6) without time zone")
                        .HasColumnName("order_time_create");

                    b.Property<long>("OrderUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_user_id");

                    b.HasKey("OrderId");

                    b.HasIndex(new[] { "OrderAddressId" }, "IXFK_Order_Adress");

                    b.HasIndex(new[] { "OrderUserId" }, "IXFK_Order_User");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("product_id")
                        .HasDefaultValueSql("nextval(('\"product_product_id_seq\"'::text)::regclass)");

                    b.Property<long>("ProductBrandId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_brand_id");

                    b.Property<long>("ProductCategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_category_id");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("product_name");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("money")
                        .HasColumnName("product_price");

                    b.HasKey("ProductId");

                    b.HasIndex(new[] { "ProductBrandId" }, "IXFK_Product_Brand");

                    b.HasIndex(new[] { "ProductCategoryId" }, "IXFK_Product_Category");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Review", b =>
                {
                    b.Property<long>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("review_id")
                        .HasDefaultValueSql("nextval(('\"review_review_id_seq\"'::text)::regclass)");

                    b.Property<string>("ReviewComment")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("review_comment");

                    b.Property<long>("ReviewProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("review_product_id");

                    b.Property<short>("ReviewRating")
                        .HasColumnType("smallint")
                        .HasColumnName("review_rating");

                    b.Property<long>("ReviewUserId")
                        .HasColumnType("bigint")
                        .HasColumnName("review_user_id");

                    b.HasKey("ReviewId");

                    b.HasIndex(new[] { "ReviewProductId" }, "IXFK_Review_Product");

                    b.HasIndex(new[] { "ReviewUserId" }, "IXFK_Review_User");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Section", b =>
                {
                    b.Property<long>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("section_id")
                        .HasDefaultValueSql("nextval(('\"section_section_id_seq\"'::text)::regclass)");

                    b.Property<string>("SectionName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("section_name");

                    b.HasKey("SectionId");

                    b.ToTable("Section", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("size_id")
                        .HasDefaultValueSql("nextval(('\"size_size_id_seq\"'::text)::regclass)");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("size_name");

                    b.HasKey("SizeId");

                    b.ToTable("Size", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id")
                        .HasDefaultValueSql("nextval(('\"user_user_id_seq\"'::text)::regclass)");

                    b.Property<string>("UserEmail")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserFirstname")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_firstname");

                    b.Property<string>("UserLastname")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_lastname");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_password");

                    b.Property<string>("UserPhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_phone_number");

                    b.Property<short>("UserType")
                        .HasColumnType("smallint")
                        .HasColumnName("user_type");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Adress", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.User", "AddressUser")
                        .WithMany("Adresses")
                        .HasForeignKey("AddressUserId")
                        .IsRequired()
                        .HasConstraintName("FK_Adress_User");

                    b.Navigation("AddressUser");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Cart", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.M2mProductSizeColor", "CartProduct")
                        .WithMany("Carts")
                        .HasForeignKey("CartProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_M2M_Product_Size_Color");

                    b.HasOne("OnlineShop.ScaffDir.User", "CartUser")
                        .WithMany("Carts")
                        .HasForeignKey("CartUserId")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_User");

                    b.Navigation("CartProduct");

                    b.Navigation("CartUser");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Category", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Category", "CategorySubcategory")
                        .WithMany("InverseCategorySubcategory")
                        .HasForeignKey("CategorySubcategoryId")
                        .HasConstraintName("FK_Category_Category");

                    b.Navigation("CategorySubcategory");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mOrderProduct", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Order", "M2mOrderProductOrder")
                        .WithMany()
                        .HasForeignKey("M2mOrderProductOrderId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_order_product_Order");

                    b.HasOne("OnlineShop.ScaffDir.M2mProductSizeColor", "M2mOrderProductProduct")
                        .WithMany()
                        .HasForeignKey("M2mOrderProductProductId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_order_product_M2M_Product_Size_Color");

                    b.Navigation("M2mOrderProductOrder");

                    b.Navigation("M2mOrderProductProduct");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mProductSizeColor", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Color", "M2mPscColor")
                        .WithMany("M2mProductSizeColors")
                        .HasForeignKey("M2mPscColorId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_Product_Size_Color_Color");

                    b.HasOne("OnlineShop.ScaffDir.Product", "M2mPscProduct")
                        .WithMany("M2mProductSizeColors")
                        .HasForeignKey("M2mPscProductId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_Product_Size_Color_Product");

                    b.HasOne("OnlineShop.ScaffDir.Size", "M2mPscSize")
                        .WithMany("M2mProductSizeColors")
                        .HasForeignKey("M2mPscSizeId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_Product_Size_Color_Size");

                    b.Navigation("M2mPscColor");

                    b.Navigation("M2mPscProduct");

                    b.Navigation("M2mPscSize");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mSectionCategory", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Category", "M2mSectionCategoryCategory")
                        .WithMany()
                        .HasForeignKey("M2mSectionCategoryCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_section_category_Category");

                    b.HasOne("OnlineShop.ScaffDir.Section", "M2mSectionCategorySection")
                        .WithMany()
                        .HasForeignKey("M2mSectionCategorySectionId")
                        .IsRequired()
                        .HasConstraintName("FK_M2M_section_category_Section");

                    b.Navigation("M2mSectionCategoryCategory");

                    b.Navigation("M2mSectionCategorySection");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Order", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Adress", "OrderAddress")
                        .WithMany("Orders")
                        .HasForeignKey("OrderAddressId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_Adress");

                    b.HasOne("OnlineShop.ScaffDir.User", "OrderUser")
                        .WithMany("Orders")
                        .HasForeignKey("OrderUserId")
                        .IsRequired()
                        .HasConstraintName("FK_Order_User");

                    b.Navigation("OrderAddress");

                    b.Navigation("OrderUser");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Product", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Brand", "ProductBrand")
                        .WithMany("Products")
                        .HasForeignKey("ProductBrandId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Brand");

                    b.HasOne("OnlineShop.ScaffDir.Category", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("ProductCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Product_Category");

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Review", b =>
                {
                    b.HasOne("OnlineShop.ScaffDir.Product", "ReviewProduct")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewProductId")
                        .IsRequired()
                        .HasConstraintName("FK_Review_Product");

                    b.HasOne("OnlineShop.ScaffDir.User", "ReviewUser")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewUserId")
                        .IsRequired()
                        .HasConstraintName("FK_Review_User");

                    b.Navigation("ReviewProduct");

                    b.Navigation("ReviewUser");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Adress", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Category", b =>
                {
                    b.Navigation("InverseCategorySubcategory");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Color", b =>
                {
                    b.Navigation("M2mProductSizeColors");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.M2mProductSizeColor", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Product", b =>
                {
                    b.Navigation("M2mProductSizeColors");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.Size", b =>
                {
                    b.Navigation("M2mProductSizeColors");
                });

            modelBuilder.Entity("OnlineShop.ScaffDir.User", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}