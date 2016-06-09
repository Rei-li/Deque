Индивидуальная практическая работа №2

Задание

Цели работы:

1.	Изучить понятие класса в языке C#.
2.	Изучить использование элементов класса   полей, методов, свойств, констант.
3.	Изучить понятие статического элемента и статического класса.
4.	Изучить синтаксис расширяемых методов.
5.	Изучить понятия делегата и ?-выражения.
6.	Изучить понятие исключительной ситуации.
7.	Получить представление о пространствах имен в среде .Net Framework.

Постановка задачи. В задании необходимо реализовать класс согласно указанному варианту. Предусмотреть необходимый набор методов, свойств и индексаторов в реализуемых классах. Изучить статические классы и статические элементы класса. Расширить созданные ранее классы статическими элементами (например, для работы с уникальным числовым идентификатором объекта) и методами расширения. Расширить классы событиями. Предусмотреть возможность генерирования исключительных ситуаций (как системных, так и пользовательских). Создать собственные пространства имен, в которые поместить написанные классы

Вариант 3

Дек (deque, двунаправленная очередь) для строк



Решение:
Был реализован класс Deque  и консольный клиент для тестирования


Список доступных команд для тестирования:

create DequeName - creates new deque
pushb DequeName Value - push value to the end of the deque

pushf DequeName Value - push value to the begining of the deque

popf DequeName - get value of the first element of the deque

popb DequeName - get value of the last element of the deque

peekf DequeName - get value of the first element of the deque (deque not changes)

peekb DequeName  - get value of the last element of the deque (deque not changes)

clear DequeName - clear deque

count DequeName - get count of elements of the deque contains such value

contain DequeName Value - check if the deque

clone DequeName NewDequeName - create new deque with values from the current one

arr DequeName - create new array with values from the deque and display all values

-help - display all available commands

q - exit
