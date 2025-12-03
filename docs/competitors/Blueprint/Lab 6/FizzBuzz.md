# Пример для типа `number`: FizzBuzz

```
blueprint main()
{
    material x: int = receiveInt("Enter count:");

    material i: int = 1;
    cyclewhile (i <= x)
    {
        if (i % 15 == 0) { dispatch("FizzBuzz"); }
        else if (i % 3 == 0) { dispatch("Fizz"); }
        else if (i % 5 == 0) { dispatch("Buzz"); }
        else { dispatch(i); }

        i = i + 1;
    }
}
```