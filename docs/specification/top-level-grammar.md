# Грамматика программы языка Blueprint

## Примеры кода 
```
    blueprint main()
    {
        fixed PI: decimal = 3.14159;
        material radius: decimal = receive("Enter radius:");
        material area: decimal = PI * radius * radius;
        dispatch("Area:", area);
    }
```

```
    blueprint factorial(n: int): int
    {
        if (n <= 1) 
        {
            yield 1;
        } 
        else 
        {
            yield n * factorial(n - 1);
        }
    }

    blueprint main()
    {
        material x: int = receive("Enter a number:");
        material result: int = factorial(x);
        dispatch("Factorial:", result);
    }
```

## Ключевые особенности языка Blueprint

1. **Императивный и типизированный язык**.
2. Поддерживает **функции (blueprints)** с передачей параметров и возвратом значений через оператор `yield`.
3. Имеет **строгую типизацию**: каждая переменная и константа имеет тип (`int`, `decimal`, `text`, `flag`, и др.).
4. Разделяет переменные на:
    - `material` — изменяемые,
    - `fixed` — константы.
5. Поддерживает **ввод/вывод** через встроенные функции `receive()` и `dispatch()`.
6. Управляющие конструкции:
   - `if ... else` — ветвление;
   - `cyclewhile` и `cyclefor` — циклы;
   - `break`, `continue`, `yield` — управляющие инструкции.
7. Основная программа всегда начинается с функции `blueprint main()`.
8. Поддерживает составные блоки `{ ... }`, определяющие **области видимости**.

## Семантические правила
1. **Идентификаторы чувствительны к регистру** (в отличие от ключевых слов). \
`Value` и `value` — разные переменные.
2. **Область видимости** переменной или функции — это блок, в котором она объявлена, включая вложенные блоки.
3. **Повторное объявление** переменной или функции с тем же именем в пределах одной области видимости запрещено.
4. **Неизменяемость констант**:\
    Переменные, объявленные с модификатором `fixed`, не могут быть изменены после инициализации.
5. **Типизация**:
    - Все выражения должны быть типо-согласованы.
    - Операции применяются только к допустимым типам (например, сложение чисел, конкатенация текстов).
6. **Функции**:
    - Должны иметь уникальные имена в пределах программы.
    - Могут вызывать другие функции (включая рекурсивно).
    - Возврат значения осуществляется оператором `yield`.
7. **Точка входа**: \
    Программа должна содержать хотя бы одну функцию blueprint main() без параметров.
8. **Ошибки времени компиляции**:
    - использование необъявленной переменной;
    - несоответствие типов в выражении;
    - изменение `fixed`-переменной;
    - отсутствие `main()`.

## Грамматика в нотации EBNF

```ebnf
(* Программа *)
program = { top_level_statement } ;
top_level_statement = "blueprint", "main", "(", [ parameter_list ], ")", ":", type, block ;

(* Операторы *)
statement = variable_declaration
          | assignment
          | function_call
          | function_definition
          | input_statement
          | output_statement
          | conditional_statement
          | loop_statement
          | break_statement
          | continue_statement
          | return_statement
          | block ;

(* Объявление переменной *)
variable_declaration = ( "material" | "fixed" ), identifier, ":", type, [ "=", expression ], ";" ;

(* Присваивание *)
assignment = identifier, "=", expression, ";" ;

(* Определение функции *)
function_definition = "blueprint", identifier, "(", [ parameter_list ], ")", ":", type, block ;
parameter_list = parameter, { ",", parameter } ;
parameter = identifier, ":", type ;

(* Условные операторы *)
conditional_statement = "check", "(", expression, ")", block, [ "otherwise", block ] ;
multi_branch_statement = "inspect", "(", expression, ")", "{", { case }, [ default_case ], "}" ;
case = "check", expression, ":", block ;
default_case = "otherwise", ":", block ;

(* Циклы *)
loop_statement = while_loop | for_loop ;
while_loop = "cyclewhile", "(", expression, ")", block ;
for_loop = "cyclefor", "(", [ for_init ], ";", [ expression ], ";", [ for_update ], ")", block ;
for_init = variable_declaration | assignment | expression ;
for_update = assignment | function_call ;

(* Управление потоком *)
break_statement = "break", ";" ;
continue_statement = "continue", ";" ;
return_statement = "yield", [ expression ], ";" ;

(* Блок кода *)
block = "{", { statement }, "}" ;

(* Ввод-вывод *)
input_statement = identifier, "=", "receive", "(", ")", ";" ;
output_statement = "dispatch", "(", argument_list, ")", ";" ;
```
