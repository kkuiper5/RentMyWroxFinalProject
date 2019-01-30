CREATE PROCEDURE [dbo].[UserDemographicsTimeInArea] 
AS
	select BirthRange, count(*) as Total, AVG(MonthsInArea) as AverageMonths 
	from
		(select      
		case         
			when Birthdate between  DATEADD(YEAR, -20, getdate()) and GetDate() 
	then ' < 20 '
			when birthdate between DATEADD(YEAR, -40, getdate()) 
				and DATEADD(YEAR, -20, getdate()) then '20-40'        
			when birthdate between DATEADD(YEAR, -60, getdate())             
				and DATEADD(YEAR, -40, getdate()) then '40-60'        
			else ' >60 '     
		end as BirthRange,    
		DATEDIFF(month, DateMovedIntoArea, getdate()) as MonthsInArea    
		from UserDemographics) details 
group by BirthRange
 
