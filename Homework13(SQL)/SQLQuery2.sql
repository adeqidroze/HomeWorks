/**გამოიტანეთ ყველა სტუდენტი რომელიც დაიბადა 1990 წლის შემდეგ**/
select* from dbo.Students
where DoB > '1990 -12-31'  

/**
გამოიტანეთ  იმ სტუდენთა სახელი გვარი ასაკი(CurrentYear- DoB)  რომლებიც არიან საქართველოდან და ლიბიიდან
**/
select Firstname,Lastname,datediff(year,Dob,(cast(getdate() as Date))) Age from dbo.Students
where Country in('Georgia', 'Libya')

/**
დაამატეთ ახალი სტუდენტი  მონაცემთა ბაზაში ნებისმიერი მონაცემებით 
**/
SET IDENTITY_INSERT [dbo].[Students] ON 
INSERT [dbo].[Students] ([StudentsID], [Lastname], [Firstname], [DoB], [Email], [Quiz1], [Quiz2], [MiddleTest], [FinalTest], [Country]) VALUES (101, N'nikq', N'kura', CAST(N'2000-05-24' AS Date), N'zdzd2000@ac.com', 6, 7, 17, 10, N'georgia')
SET IDENTITY_INSERT [dbo].[Students] OFF 

/**გამოიტანეთ TOP 5 შედეგის მქონე სტუდენტის სახელი და
ქულა  შუალედურზე ([MiddleTest]) მიღებული ქულის მიხედვით (აჩვენეთ ყველა შესაძლო ვარიანტი მაგ 
: 1 2 3 4 5 5  თუ მომდევნო ელემენტიც 5 ტოლია შედეგი უნდა იყოს 1,2,3,4,5,5**/

select top(5) Firstname,MiddleTest from dbo.Students
order by MiddleTest desc


/**
წაშალეთ ყველა სტუდენტი რომლებმაც ფინალურზე 19 ქულა მიიღეს და შედეგი გამოიტანეთ OUTPUT სახით
**/
delete Students where FinalTest = 19
select *from  Students where FinalTest = 19

/**
განაახლეთ მონაცემები ყველა სტუდენტს რომელსაც  შუალედურზე აქვს მიღებული 1 ქულა ფინალურ შეფასებაში ჩაუწერეთ 0
**/
update Students
set FinalTest = 0 where MiddleTest = 1




--------------------------------------------------persons---------------------------------------------------------------


/**
გამოიტანეთ სრული მონაცემები იმ პირების შესახებ რომელთა პირადი ნომერი PrivateId იწყება 163
**/
select * from Persons
where PrivateId like '163%'


/**
გამოიტანეთ  სრული მონაცემები იმ პირების რომელთა გვარი ემთხვევა იმ ქალაქის სახელწოდებას სადაც ცხოვრობენ
**/
select * from Persons
where Lastname = City

/**
გამოიტანეთ  სრული მონაცემები იმ პირების შესახებ რომლებიც ცხოვრობენ კანადაში 
ან მონაკოში არ გამოიყენოთ ტოლობა და Like  ოპერატორი
**/
select * from Persons
where Country in ('Canada','Monaco')
order by country 

/**
გამოიტანეთ იმ პირების სახელი ,გვარი და პირადი ნომერი რომლებსაც არ აქვთ იმეილი.
**/
select FirstName,LastName,PrivateId from Persons
where Email is null

/**
გამოიტანეთ სრული მონაცემები იმ პირების შესახებ რომლებიც
ცხოვრობენ ესპანეთში ან თურქეთში და ხელფასი არის 1000-3000 დიაპაზონში 
( არ გამოიყენოთ მეტობა/ნაკლებობის ნიშნები)
**/
select * from Persons
where Country in ('Spain','Turkey') and Salary between 1000 and 3000


/**
გამოიტანეთ კომპანიების სახელწოდება რომლებიც შეიცავენ LLC, PC , LLP
**/
select WorkPlace from Persons
where WorkPlace  like  '%LLC%'
or WorkPlace  like'%PC%'
or WorkPlace  like'%LLP%'


/**
შეამოწმეთ  რამდენი წერტილს შეიცავს მეილი 
თუ  წერტილების რაოდენობა მეტია 2 ზე ახალ ველში MAILINFO გამოიტანეთ 'more than 2 dots 
' თუ ნაკლები  'less than 2 dots'
**/

select Email, 
case 
	when LEN(email) - len(replace(email,'.','')) > 2 then 'more than 2 dots'
	when LEN(email) - len(replace(email,'.','')) = 2 then 'exactly 2 dots'
	else 'less than 2 dots'
End as MAILINFO
From Persons
order by MAILINFO desc 

/**
გამოიტანეთ სრული მონაცემები იმ პირების შესახებ რომელთა პინ კოდიც მთავრდება 51
**/
select * from Persons
where PINcode like '%51'

/**
დააჯგუფეთ ცხრილი ქვეყნების მიხედვით და გამოიტანეს საშუალო ხელფასი ქვეყნების მიხედვით
**/
select Country, AVG(Salary)Average_Salary from Persons
group by Country

