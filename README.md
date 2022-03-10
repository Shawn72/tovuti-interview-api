# tovuti-interview-api
EF Core used, Code First Approach, MySQl used

clone both the api and web app into your local machine

Download and restore the database backup attached (tovuti_db.sql)

Host the TovutiApi on port 8020

Postman was used for api testing

Some of endpoints urls:

    Creating User roles ( Admin, Novice )

POST: localhost:8020/api/roles/createrole

json body

{ "name":"Admin" }

{ "name":"Novice" }

    View Roles, and note the Id of the role GET: localhost:8020/api/roles/

    Add user to role POST: localhost:8020/api/roles/addusertorole

    View All Sales GET: localhost:8020/api/Sale/

    Sales Invoice localhost:8020/api/SaleInvoices

    Make a payment POST: localhost:8020/api/Payments/MakePayment

Git repos https://github.com/Shawn72/tovuti-interview-api.git https://github.com/Shawn72/tovuti-interview-ui.git
