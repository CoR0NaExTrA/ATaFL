# Пример вычисления площади круга по радиусу на языке Blueprint

```
    blueprint main()
    {
        fixed PI: decimal = 3.14159;
        material r: decimal = receive("Enter radius:");
        material s: decimal = PI * r * r;
        dispatch("Circle area =", s);
    }
```