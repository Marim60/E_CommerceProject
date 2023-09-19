# Simple E-Commerce Website with ASP.NET Core MVC Authentication

This is a simple E-commerce website built using ASP.NET Core MVC with authentication. It has two parts first for Admin second for customer.
It allows admins to add product , edit product, delete product, show a details of an product and show all products and add a new category.
It allows users to browse products, add them to their cart, and make purchases. The authentication system ensures that only registered users can access certain features like placing orders and managing their profile.
## Table of Contents
- [Features](#features)
- [Installation](#installation)
## Features
- User Authentication: Register, log in, and log out securely.
- Product Catalog: Browse products.
- Shopping Cart: Add and remove products from the shopping cart.
- Checkout: Review your cart and complete purchases.
- Filter Products by thier categories 
- User Profile: Edit your profile information.
- Admin Panel (for admin users):
  - Manage Products: Add, edit, show all, delete products,and show all details of a product.
  - Manage Categories: Add, edit, and delete product categories.
  - User Panel

## Installation
1. Clone this repository to your local machine.
   ```bash
   git clone https://github.com/yourusername/e-commerce-website.git
2- "ConnectionStrings": {
    "DefaultConnection": "YourDatabaseConnectionStringHere"
}
3- Apply database migrations to create the required database schema.
update-database
4- Run the application
Usage
- Register for an account on the website.
- Browse the product catalog and add products to your cart.
- Review your cart and proceed to checkout.
- Optionally, edit your profile information in the user profile section.
Admin Users:
To access the admin panel, log in with an account that has the "AdminRole" role assigned. email: admin@gmail.com, password Admin@123
