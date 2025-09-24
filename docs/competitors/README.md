# Сравнение Python и C# для реализации учебного компилятора

## 1. Инструменты структурного программирования
### Python
```python
if x > 0:
    print("positive")
elif x == 0:
    print("zero")
else:
    print("negative")

for i in range(5):
    print(i)
```

- Отступы определяют блоки

- Нет switch

- Нет do...while

### C#
```C#
f (x > 0)
{
    Console.WriteLine("positive");
}
else if (x == 0)
{
    Console.WriteLine("zero");
}
else
{
    Console.WriteLine("negative");
}

for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```

- Блоки через {}

- Есть switch, do...while

## 2. Набор операторов
### Python
```python
a += 1
b = not a
# нет ++ или --
```

### C#
```C#
a++;
b = !a;
var c = cond ? x : y;
```

- В C# больше операторов (++, --, ?:, ??, ?.).

- Python минималистичен, часть операторов заменяется вызовами функций.

## 3. Базовые типы данных
### Python
```python
x = 10      # int (большая разрядность)
y = 3.14    # float
s = "text"  # str
```

- Динамическая типизация.

- Всё — объекты.

### C#
```C#
int x = 10;
double y = 3.14;
string s = "text";
```

- Статическая типизация.

- Есть различие между value-type и reference-type.

## 4. Пользовательские функции
### Python
```python
def fact(n):
    if n == 0:
        return 1
    return n * fact(n - 1)

print(fact(5))
```

- Нет явных типов.

- Поддержка *args/**kwargs.

### C#
```C#
int Fact(int n)
{
    if (n == 0) return 1;
    return n * Fact(n - 1);
}
```

- Явное указание типов.

- Есть перегрузка, ref, out, params.

## 5. Пользовательские структуры
### Python
```python
def fact(n):
    if n == 0:
        return 1
    return n * fact(n - 1)

print(fact(5))
```

- Всё объекты.

- Есть dataclasses, namedtuple..

### C#
```C#
int Fact(int n)
{
    if (n == 0) return 1;
    return n * Fact(n - 1);
}
```

- Есть class и struct.

- struct — value-type, копируется по значению.

## 6. Работа со строками
### Python
```python
s = "compiler"
print(s[0:3])  # "com"
print(f"value = {42}")
```

- Срезы, f-строки.

- Юникод по умолчанию.

### C#
```C#
string s = "compiler";
Console.WriteLine(s.Substring(0, 3)); // "com"
Console.WriteLine($"value = {42}");
```

- Нет срезов, но есть методы Substring.

- Для изменения используется StringBuilder.

## 7. Работа с массивами
### Python
```python
arr = [1, 2, 3]
arr.append(4)
print(arr[1:3])  # [2, 3]
```

- Динамический список.

- Разные типы в одном списке.

### C#
```C#
int[] arr = {1, 2, 3};
var list = new List<int> {1, 2, 3};
list.Add(4);
```

- Массив фиксированной длины.

- List<T> и Dictionary<K,V> — стандартные коллекции.

## 8. Управление памятью
- **Python**: GC + подсчёт ссылок, полный контроль скрыт.

- **C#**: GC, но есть using, IDisposable, Span<T>, unsafe-код для ручного контроля.

## 9. Обработка ошибок
### Python
```python
try:
    x = int("abc")
except ValueError as e:
    print("Ошибка:", e)
```

- Исключения часто применяются даже для стандартных ситуаций.

### C#
```C#
try
{
    int x = int.Parse("abc");
}
catch (FormatException e)
{
    Console.WriteLine("Ошибка: " + e.Message);
}
```

- Исключения — для исключительных ситуаций.

- Распространён паттерн TryParse:
```C#
if (int.TryParse("123", out int result))
    Console.WriteLine(result)
```

# Итог

- **Python**: динамика, простота, богатые строки и коллекции → быстрое прототипирование.

- **C#**: строгая типизация, контроль структур и памяти → надёжная промышленная реализация.