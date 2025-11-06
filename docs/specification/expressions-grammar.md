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

<<<<<<< Updated upstream
string = "'", { character | escapeSequence }, "'" ;
character   = ? любой символ Unicode, кроме необработанной одинарной кавычки ? ;
escapeSequence = "\\", ( "'" | "\\" | "n" | "r" | "t" ) ;
=======
<<<<<<< HEAD
string = "'", { character - "'" | escapeSequence }, "'" ;
character   = ? любой символ Unicode, кроме одинарной кавычки ? ;
escapeSequence = "\\", ( "'" | "\\" ) ;
=======
string = "'", { character | escapeSequence }, "'" ;
character   = ? любой символ Unicode, кроме необработанной одинарной кавычки ? ;
escapeSequence = "\\", ( "'" | "\\" | "n" | "r" | "t" ) ;
>>>>>>> b57f68845ce522324cdcd48958e6202e3516a790
>>>>>>> Stashed changes

boolean = "истина" | "заблуждение" ;

(* Операторы *)
arithmetic_operator = "+" | "-" | "*" | "/" | "%" | "**" ;
comparison_operator = ">" | ">=" | "<" | "<=" | "==" | "!=" ;
logical_operator = "&&" | "||" ;

(* === Грамматика выражений === *)

expression = assignment_expression ;

(* Присваивание, включая цепочку x = y = 5 *)
assignment_expression = logical_or_expression,
                        { "=", logical_or_expression } ;

logical_or_expression = logical_and_expression,
                        { "||", logical_and_expression } ;

logical_and_expression = equality_expression,
                         { "&&", equality_expression } ;

equality_expression = comparison_expression,
                      { ( "==" | "!=" ), comparison_expression } ;

comparison_expression = additive_expression,
                        { ( ">" | ">=" | "<" | "<=" ), additive_expression } ;

additive_expression = multiplicative_expression,
                      { ( "+" | "-" ), multiplicative_expression } ;

multiplicative_expression = power_expression,
                            { ( "*" | "/" | "%" ), power_expression } ;

power_expression = [ "+" | "-" ], primary_expression,
                   { "**", primary_expression } ;

primary_expression = literal
                   | identifier
                   | function_call_expression
                   | "(", expression, ")" ;

function_call_expression = identifier, "(", [ argument_list ], ")" ;
argument_list = expression, { ",", expression } ;

(* Встроенные функции *)
builtin_function = "abs", "(", expression, ")"
                 | "min", "(", argument_list, ")"
                 | "max", "(", argument_list, ")" ;
<<<<<<< HEAD
=======

(* Ввод/вывод *)
input_statement = identifier, "=", "receive", "(", ")", ";" ;
output_statement = "dispatch", "(", argument_list, ")", ";" ;
>>>>>>> b57f68845ce522324cdcd48958e6202e3516a790
```
