/**1.	გამოიტანეთ ევროპაში გამართულ მოვლენების რაოდენობა; **/
select count(*) from dbo.Event e
left join dbo.Country c on c.CountryID =e.CountryID
left join dbo.Continent con on con.ContinentID = c.ContinentID
where con.ContinentName = 'Europe'

/**2.	გამოიტანეთ აფრიკაში ყველაზე ადრე გამართული მოვლენის თარიღი; **/
select min(e.EventDate) from dbo.Event e
left join dbo.Country c on c.CountryID =e.CountryID
left join dbo.Continent con on con.ContinentID = c.ContinentID
where con.ContinentName = 'Africa'  

/**3.	გამოიტანეთ ჩრდილოეთ და სამხრეთ ამერიკაში არსებული ქვეყნების რაოდენობა; **/
select count(*) from dbo.Country c 
left join dbo.Continent con on con.ContinentID = c.ContinentID
where con.ContinentName in ('North America','South Amerika')

/**4.	გამოიტანეთ ახალ წელს გამართული ეკონომიკასთან დაკავშირებული მოვლენების რაოდენობა; **/
select count(*) from dbo.Event e
left join dbo.Category c on c.CategoryID =e.CategoryID
where c.CategoryName = 'Economy'
  

/**5.	გამოიტანეთ ევროპაში ყველაზე გვიან გამართული, სპორტის კატეგორიასთან დაკავშირებული მოვლენის თარიღი. **/
select min(e.EventDate) from dbo.Event e
left join dbo.Category cat on cat.CategoryID =e.CategoryID
left join dbo.Country c on c.CountryID =e.CountryID
left join dbo.Continent con on con.ContinentID = c.ContinentID
where con.ContinentName = 'Europe' and cat.CategoryName = 'Sports' 