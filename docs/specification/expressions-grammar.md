# Грамматика выражений языка Blueprint

## Синтаксис выражений
Выражения могут содержать:
- литералы чисел: целые - `number`, вещественные - `decimal`
- литералы строк(`text`)
- логические литералы: `raised`, `lowered`
- бинарные арифметические операторы
- операторы сравнения
- логические операторы

## Операторы

Арифметические операторы:
|Символы|Операция                 |
|-------|-------------------------|
|`+`    |сложение или унарный `+` |
|`-`    |вычитание или унарный `-`|
|`*`    |умножение                |
|`/`    |целочисленное деление    |
|`%`    |деление с остатком       |
|`**`   |возведение с степень     |

Операторы сравнения:
|Символы|Операция                |
|-------|------------------------|
|`>`    |строго больше           |
|`>=`   |нестрого больше         |
|`<`    |строго меньше           |
|`<=`   |нестрого меньше         |
|`==`   |равенство               |
|`!=`   |неравенство             |

Логические операторы:
|Символы|Операция                |
|-------|------------------------|
|`&&`   |Логическое И            |
|`\|\|` |Логическое ИЛИ          |

## Приоритет операторов

|Приоритет|Операция                 |
|---------|-------------------------|
|1        |`**`                     |
|2        |`+`, `-` (унарные)       |
|3        |`*`, `/`, `%`            |
|4        |`+`, `-`                 |
|5        |`>`, `>=`, `<`, `<=`     |
|6        |`==`, `!=`               |
|7        |`&&`                     |
|8        |`\|\|`                   |

## Встроенные функции для чисел
|Функция          |Описание                                 |
|-----------------|-----------------------------------------|
|`abs(x)`         |Возвращает модуль числа                  |
|`min(x, y, ...)` |Возвращает наименьшее из переданных чисел|
|`max(x, y, ...)` |Возвращает наибольшее из переданных чисел|

## Грамматика в нотации EBNF

```ebnf
(* Базовые символы *)
digit = "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" ;

letter = "a" | "b" | "c" | "d" | "e" | "f" | "g" | "h" | "i" | "j" 
       | "k" | "l" | "m" | "n" | "o" | "p" | "q" | "r" | "s" | "t" 
       | "u" | "v" | "w" | "x" | "y" | "z" 
       | "A" | "B" | "C" | "D" | "E" | "F" | "G" | "H" | "I" | "J" 
       | "K" | "L" | "M" | "N" | "O" | "P" | "Q" | "R" | "S" | "T" 
       | "U" | "V" | "W" | "X" | "Y" | "Z" ;

(* Идентификаторы *)
identifier  = ( letter | "_" ), { letter | digit | "_" } ;

(* Литералы *)
literal = number | string | boolean ;

number = integer | real ;
integer = digit, { digit } ;
real = digit, { digit }, ".", digit, { digit } ;

string = "'", { character | escapeSequence }, "'" ;
character   = ? любой символ Unicode, кроме необработанной одинарной кавычки ? ;
escapeSequence = "\\", ( "'" | "\\" | "n" | "r" | "t" ) ;

boolean     = "raised" | "lowered" ;

(* Типы данных *)
type = "text" | "number" | "decimal" | "flag" | "sequence" ;

(* Ключевые слова - регистронезависимые *)
keyword = "material" | "fixed" | "receive" | "dispatch" | "blueprint" 
        | "yield" | "check" | "otherwise" | "inspect" | "cyclewhile" 
        | "cyclefor" | "break" | "continue" ;

(* Операторы *)
operator = arithmetic_operator | comparison_operator | logical_operator ;

arithmetic_operator = "+" | "-" | "*" | "/" | "%" | "**" ;
comparison_operator = ">" | ">=" | "<" | "<=" | "==" | "!=" ;
logical_operator = "&&" | "||" ;

(* Разделители *)
delimiter = ";" | ":" | "," | "=" | "(" | ")" | "{" | "}" ;

(* Комментарии *)
comment = "#", { character - newline }, newline ;
newline = ? символ новой строки ? ;

(* Синтаксическая структура *)

(* Программа *)
program = { statement } ;

(* Операторы *)
statement = variable_declaration
          | assignment
          | function_call
          | function_definition
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

(* Вызов функции *)
function_call = identifier, "(", [ argument_list ], ")", ";" ;
argument_list = expression, { ",", expression } ;

(* Определение функции *)
function_definition = "blueprint", identifier, "(", [ parameter_list ], ")", block ;
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

(* Выражения *)
expression = logical_or_expression ;

logical_or_expression = logical_and_expression, { "||", logical_and_expression } ;
logical_and_expression = equality_expression, { "&&", equality_expression } ;
equality_expression = comparison_expression, { ( "==" | "!=" ), comparison_expression } ;
comparison_expression = additive_expression, { ( ">" | ">=" | "<" | "<=" ), additive_expression } ;
additive_expression = multiplicative_expression, { ( "+" | "-" ), multiplicative_expression } ;
multiplicative_expression = power_expression, { ( "*" | "/" | "%" ), power_expression } ;
power_expression = [ "+" | "-" ], primary_expression, { "**", primary_expression } ;

primary_expression = literal
                   | identifier
                   | function_call_expression
                   | "(", expression, ")" ;

function_call_expression = identifier, "(", [ argument_list ], ")" ;

(* Встроенные функции *)
builtin_function = "abs", "(", expression, ")"
                 | "min", "(", argument_list, ")"
                 | "max", "(", argument_list, ")" ;

(* Ввод/вывод *)
input_statement = identifier, "=", "receive", "(", ")", ";" ;
output_statement = "dispatch", "(", argument_list, ")", ";" ;
```
