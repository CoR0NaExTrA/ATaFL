```
    blueprint factorial(n: int): int
{
    material result: int = 1;
    material i: int = 1;

    cyclewhile (i <= n)
    {
        result = result * i;
        i = i + 1;
    }

    yield result;
}

    blueprint main()
    {
        material x: int = receive("Enter a number:");
        material result: int = factorial(x);
        dispatch("Factorial:", result);
    }
```