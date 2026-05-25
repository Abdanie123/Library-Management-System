# Library Management System

## Description
A Library Management System developed using C# (Windows Forms) and MySQL. The system allows users to manage books and borrowers through a simple graphical interface with full database integration.

## Features
- Add, update, and delete books
- Add, update, and delete borrowers (members)
- Display books and borrower records using DataGridView
- Select records from table and auto-fill input fields
- Clear input fields and refresh data

## Technologies Used
- C# (Windows Forms)
- MySQL Database
- Visual Studio
- MySQL Connector (MySql.Data)

## Database Structure
The system uses a MySQL database named `library_db` with the following tables:

### Books Table
- book_id (Primary Key)
- title
- author
- year

### Members Table
- member_id (Primary Key)
- name
- email
- phone

## How to Run
1. Install MySQL or XAMPP
2. Create a database named: library_db
3. Create the required tables (books and members)
4. Open the project in Visual Studio
5. Update the connection string: server=localhost;database=library_db;uid=root;pwd=**YOUR_PASSWORD**;
