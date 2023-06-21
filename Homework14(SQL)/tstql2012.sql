/**გამოიტანეთ ლონდონელი და მადრიდელი კლიენტების გვარი, სახელი, ქალაქი და შეკვეთების თარიღები;**/ 
select c.contactname, c.city, o.orderdate from TSQL2012.Sales.Customers c
right join sales.Orders o on  o.custid=c.custid
where c.city in ('London','Madrid')

/**გამოიტანეთ იმ პროდუქტების სახელწოდება ზედა რეგისტრში, ფასი და კატეგორია, რომელთა ფასი 20-დან 40-მდეა; **/
select p.productname, p.unitprice,c.categoryname from Production.Products p
left join Production.Categories c on c.categoryid=p.categoryid
where p.unitprice between 20 and 40
order by c.categoryname

/**გამოიტანეთ გაყიდვების მენეჯერების გვარი, სახელი და შეკვეთების იდენტიფიკატორი (orderid), 
რომელსაც Sales Manager მოემსახურნენ. გამოიტანეთ მხოლოდ 50 -ზე მეტი წონის შეკვეთები; **/
 select e.lastname,e.firstname,o.orderid from hr.Employees e
 right join Sales.Orders o on o.empid = e.empid
 where o.freight > 50

/**გამოიტანეთ შეკვეთის თარიღი, კლიენტის გვარი, სახელი, ქალაქი და მისამართი იმ შეკვეთებისათვის,
რომლებიც გაკეთდა 2007 წელს ამერიკული კომპანიის მიერ; **/
select  o.orderdate,c.contactname,c.city,o.shipaddress from Sales.Customers c
right join sales.Orders o on  o.custid=c.custid
left join HR.Employees e on e.empid = o.empid
where YEAR(o.orderdate) = '2007' and e.country = 'USA'


/**გამოიტანეთ იმ ქალაქების სახელები, სადაც მოხდა კომპანიის თანამშრომელ Cameron -ის მიღებული 
შეკვეთების ტრანსპორტირება. მიღებულ ვირტუალურ ცხრილში ქალაქების სახელები არ განმეორდეს; **/
select distinct o.shipcity from Sales.Orders o
right join hr.Employees e on e.empid=o.empid
where e.lastname = 'Cameron'


/**გამოიტანეთ გადამზიდავი კომპანიების მიერ გერმანიაში და ავსტრიაში ტრანსპორტირებული
შეკვეთების id (orderid), ასევე ქვეყანა და ქალაქი, სადაც მოხდა შეკვეთის ტრანსპორტირება;**/ 
select o.orderid,o.shipcountry,o.shipcity from Sales.Orders o
where o.shipcountry in ('Germany','Austria')


/**გამოიტანეთ სრული მონაცემები ტოკიოდან (Tokyo) მოწოდებული იმ პროდუქტების შესახებ,
რომლებზეც მოქმედებს ფასდაკლება; **/
select * from Production.Products  p
left join Production.Suppliers s on s.supplierid=p.supplierid
where s.city = 'Tokyo'


/**გამოიტანეთ იაპონიიდან მოწოდებული ზღვის პროდუქტების და
სასმელების დასახელებები კატეგორიის სახელწოდებებთან ერთად; **/
select * from Production.Products  p
left join Production.Suppliers s on s.supplierid=p.supplierid
left join Production.Categories c on  c.categoryid=p.categoryid
where c.categoryname='Seafood' and s.country='Japan'

/**გამოიტანეთ კომპანიის თანამშრომლების სახელი და გვარი და გადამზიდავი კომპანიების სახელწოდებები,
რომლებმაც 2007 წელს გადაზიდეს შეკვეთები, რომლებსაც მოემსახურნენ სარა დევისი (Sara Davis) და
მარია ქემერონი (Maria Cameron); **/
select e.firstname,e.lastname,s.companyname from HR.Employees e
right join sales.Orders o on o.empid=e.empid
left join Sales.Shippers s on s.shipperid = o.shipperid
where YEAR(o.orderdate) = '2007' and e.firstname+' '+e.lastname in ('Sara Davis','Maria Cameron') 



/**გამოიტანეთ ამერიკელი მწარმოებლების მიერ წარმოებული იმ პროდუქტების სახელწოდებები და კატეგორიები,
რომლებიც არ მიეკუთვნება ზღვის პროდუქტების და წვენების კატეგორიას; **/
select p.productname,c.categoryname from Production.Suppliers s
right join Production.Products p on p.supplierid = s.supplierid
left join Production.Categories c on c.categoryid = p.categoryid
where s.country = 'USA' and c.categoryname not in ('Seafood','Beverages')


/**გამოიტანეთ შეკვეთის ნომერი, კომპანიის თანამშრომლის გვარი, სახელი და საცხოვრებელი ქალაქი,
კლიენტის სახელი და გვარი იმ შეკვეთებისათვის, რომლის კლიენტი და კომპანიის თანამშრომელი ცხოვრობენ ერთ ქალაქში; **/
select o.orderid,e.lastname,e.firstname,e.city,c.contactname from Sales.Orders o
left join hr.Employees e on e.empid = o.empid
left join Sales.Customers c on c.custid = o.custid
where e.city=c.city


/**გამოიტანეთ იმ კლიენტების სახელი და გვარი, რომლებმაც შეუკვეთეს სასმელები (Beverages) ან
რძის პროდუქტები (Dairy Products). ერთი და იგივე კლიენტის სახელი და გვარი გამოიტანეთ მხოლოდ ერთხელ. **/
select distinct cus.contactname from Sales.Orders o
left join Sales.Customers cus on cus.custid =  o.custid
left join Sales.OrderDetails d on d.orderid = o.orderid
left join Production.Products p on p.productid =  d.productid
left join Production.Categories cat on cat.categoryid = p.categoryid
where cat.categoryname in ('Beverages', 'Dairy Products') 

-------------------------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------------------------


