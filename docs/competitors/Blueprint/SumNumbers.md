# Пример программы для сложения 2 чисел на языке Blueprint

```
    blueprint main()
    {
        material a: int = receive("Enter first number:");
        material b: int = receive("Enter second number:");
        material sum: int = a + b;
        dispatch("Sum =", sum);
    }
```