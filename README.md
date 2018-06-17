# Evolent contact application


Submitted by Rajdeepsingh K.Khamare.

Completed project as discussed previously.

Following Details related to technologies & tools:

IDE : Visual Studio 2015 Professional

Technology Used : MVC5, WEBAPI

Design Pattern	: Repository Pattern 

Design Principle : Dependency Injection

ORM Module : Dapper

Design : BootStrap

Logging : NLOG

Database Server : SSMS 2012

----------------------------------
Created two different solutions.
1. Evolent.WebAPI
	This solution is for WebAPI services which where used repository design pattern
	Following are the projects within this solution
	
	    a. Evolent.DataAccess - This project is responsible for accessing & mapping data by using Dapper ORM.
	
        b. Evolent.Entities - In this project we define data transfer object model classes.
	
        c. Evolent.Service - This project responsible for fetching and delivering data to database.
	
        d. Evolent.WebAPI -  This project is responsible for generating API by using apicontroller.
	
        e. Evolent.WebAPI.Tests - This project responsible for generating unit test cases by using NUnit.

2. Evolent.Web-  This is user facing application, where it consumes above web API, in Helper and handler classes

*For better experience you need to change connection string in web.config file Evolent.WebAPI project in Evolent.WebAPI Solution.

----------------------------------

Database - Find Evolent_DB.sql file in DBScripts folder, this file contain code for stored procedure,create table and inserting demo data.
		   
In Stored_Procedure folder you will find stored procedure scripts which are used in our application.This folder is provided for your review.

----------------------------------

Please let me know if you have any queries.

Thanks,

Rajdeepsingh K.


