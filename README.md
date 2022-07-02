# FiguresLibrary

Задание 2:

Отношение между таблицами: Многие ко многим
Должна присутствовать скорее всего какая-нибудь промежуточная таблица

![task 2](https://user-images.githubusercontent.com/79198388/177004204-c436e215-dfa9-4c9f-b1f6-46a844e89a74.png)


Sql запрос для второго задания:

	select t.TovarName, c.CategoryName
	from Tovar t left outer join [Tover-Category] tc 
	on t.IdTovara = tc.IdTovara left join Category c
	on tc.IdCategory = c.IdCategory
