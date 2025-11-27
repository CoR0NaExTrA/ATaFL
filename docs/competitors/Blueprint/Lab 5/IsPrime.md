```
    blueprint is_prime(n: int): int
    {
        check (n <= 1)
        {
            yield 0;        # не простое
        }

        material i: int = 2;
        material limit: int = n / 2;
        material prime: int = 1;

        cyclefor (i = 2; i <= limit; i = i + 1)
        {
            check ((n % i) == 0)
            {
                prime = 0;
                break;
            }
        }

        yield prime;
    }

    blueprint main()
    {
        material x: int = receive('Введите N:');
        material result: int = is_prime(x);
        dispatch('Простое ли число? (1/0):', result);
    }
```