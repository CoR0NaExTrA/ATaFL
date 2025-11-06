# Пример вычисления среднего геометрического 2 чисел на языке Blueprint

```
    blueprint main()
    {
        material x: decimal = receive("Enter first number:");
        material y: decimal = receive("Enter second number:");
        material mean: decimal = (x * y) ** 0.5;
        dispatch("Geometric mean =", mean);
    }
```