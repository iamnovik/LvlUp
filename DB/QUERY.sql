


SELECT p.*
FROM "Product" p
JOIN "Brand" b ON p.product_brand_id = b.brand_id
WHERE b.brand_name = 'Brand Y';


SELECT b.brand_name, COUNT(p.product_id) AS num_products
FROM "Brand" b
LEFT JOIN "Product" p ON b.brand_id = p.product_brand_id
GROUP BY b.brand_id, b.brand_name
ORDER BY num_products DESC;

SELECT *
FROM "M2M_Product_Size_Color" m
LEFT JOIN "Product" p ON p.product_id = m."M2M_PSC_product_id"
LEFT JOIN "Brand" b ON p.product_brand_id = b.brand_id WHERE b.brand_name = 'Brand X'



SELECT p.product_name
FROM "Product" p
LEFT JOIN "M2M_section_category" m ON p.product_category_id = m."m2m_section_category_category_id" 
LEFT JOIN "Section" s ON s.section_id = m."m2m_section_category_section_id" 
LEFT JOIN "Category" c ON c.category_id = m."m2m_section_category_category_id"
WHERE s.section_name = 'Section 1' AND c.category_name = 'Shirt'

SELECT * FROM "Order" WHERE order_status = 1 ORDER BY order_time_create DESC



CREATE OR REPLACE VIEW Review_Product_View AS
SELECT r.review_rating, r.review_comment, u.user_firstname, u.user_lastname
FROM "Review" r
JOIN "User" u ON r.review_user_id = u.user_id
INNER JOIN "Product" p ON p.product_id = r.review_product_id WHERE p.product_name = 'Product 1'