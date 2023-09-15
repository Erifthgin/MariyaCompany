-- Написать и приложить скрипты для: 
-- выборки всех сотрудников
select * from Employees

-- сотрудников у кого зп выше 10000, 
select empl.id, empl.FirstName, empl.MiddleName, empl.LastName, pos.Salary 
from Employees as empl
	left join CompanyPositions as pos 
		on empl.CompanyPositionId = pos.Id
where pos.Salary > 1000

-- удаления сотрудников старше 70 лет
delete from Employees
where datediff(year,Birthday,getdate()) > 70

-- обновить зп до 15000  тем сотрудникам, у которых она меньше.
update CompanyPositions
set Salary = 15000
where Salary < 15000