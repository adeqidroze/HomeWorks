/**გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომელთა მწარმოებელი
არის Hewlett-Packard; **/
select p.Name,p.Price from Products p
left join Manufacturers m on m.ManufacturerId=p.ManufacturerId
where m.Name = 'Hewlett-Packard'


/**გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომლებიც არ უწარმოებია
Fujitsu -ს; **/
select p.Name,p.Price from Products p
left join Manufacturers m on m.ManufacturerId=p.ManufacturerId
where m.Name != 'Fujitsu'


/**გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომელთა მწარმოებელი
არის Sony, Fujitsu, IBM ან Intel; **/
select p.Name,p.Price from Products p
left join Manufacturers m on m.ManufacturerId=p.ManufacturerId
where m.Name in ( 'Fujitsu','Sony','IBM','Intel')



/**გამოიტანეთ იმ კომპანიების სახელწოდებები, რომლებმაც აწარმოეს 200 -ზე უფრო მაღალი
ღირებულების მქონე პროდუქტები; **/
select distinct m.Name from Products p
left join Manufacturers m on m.ManufacturerId=p.ManufacturerId
where p.Price>200

/**გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომლებსაც არ აწარმოებს Genius და Dell **/
select p.Name,p.Price from Products p
left join Manufacturers m on m.ManufacturerId=p.ManufacturerId
where m.Name not in ( 'Genius','Dell')


/**გამოიტანეთ იმ მწარმოებელთა რაოდენობა, რომლებიც აწარმოებენ drive -ებს **/
select count(distinct m.name) from Manufacturers m
left join Products p on m.ManufacturerId=p.ManufacturerId
where p.Name like '%drive%'

/**გამოიტანეთ Intel -ის მიერ წარმოებული იმ პროდუქტების რაოდენობა, 
რომელთა ფასი აღემატება Intel -ის მიერ წარმოებული პროდუქტების საშუალო ფასს. **/
select count(*) from Products p
left join Manufacturers m on m.ManufacturerId=p.ManufacturerId
where m.Name = 'Intel' and 
p.Price > (select AVG(p.price) from Products p 
			left join Manufacturers m on m.ManufacturerId=p.ManufacturerId 
			where m.Name = 'Intel')
								
