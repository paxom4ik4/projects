using System;
using System.Collections.Generic;
using TaskLinqLib;
using System.Linq; 

namespace TaskLinqApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Repository repository = new Repository();
			var employees = repository.GetEmployees();
			var departments = repository.GetDepartments();

						Console.WriteLine("Первый запрос:");
						var res1 = from employee in employees where employee.Position == "Manager" select new { employee.Name, employee.Position, employee.Salary };
						foreach(var i in res1)
						{
								Console.WriteLine(i);
						}
						Console.WriteLine("Второй запрос:");
						var res2 = (from employee in employees
												group employee by new { employee.Position }
												into position

												select new { position.Key, Av = position.Average(p => p.Salary) });
						foreach(var i in res2)
						{
								Console.WriteLine(i);
						}

						Console.WriteLine("Третий запрос:");
						var res3 = (from employee in employees
												join parent in employees
												on employee.ParentId equals parent.ParentId
												select new { employee.Name, employee.Position, ChieName = parent.Name });
												
						foreach(var i in res3)
						{
								Console.WriteLine(i);
						}

						Console.WriteLine("Четвертый запрос:");

						var res4 = (from department in departments
												join employee in employees
												on department.Id equals employee.DepartmentId
												into gr
												select new { DepartmentName = department.Name, CountEmployees = gr.Count(), Sum = gr.Sum(p => p.Salary) });

						foreach (var i in res4)
						{
								Console.WriteLine(i);
						}

						Console.WriteLine("Пятый запрос:");

						/*var res5 = (from dep in departments
												where dep.Max(p = p.DateCreated)
												select new { DeartmentName = dep.Name, DateCreated = dep.DateCreated,});

						foreach(var i in res5)
						{
								Console.WriteLine(i);
						}*/
						// 5. Вывести информацию о сотрудниках отдела, который был создан самым  последним
						// Вывод - DepartmentName, DateCreated, Список сотрудников (Name, Position)

						/*Console.WriteLine("Шестой запрос:");
						var res6 =(from dep in departments
											 where dep.DateCreated == "2010, 02, 10")*/
						// 6. Вевести информацию о должностях отделов, которые были созданы в марте и феврале 2010 года
						// Сортировка по наименованию отдела, дате создания, должности
						// Вывод - DepartmentName,DateCreated, Список должностей

						Console.ReadKey();
		}
	}
}
