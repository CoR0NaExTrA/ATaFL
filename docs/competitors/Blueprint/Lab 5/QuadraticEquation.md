```
    blueprint solve(a: decimal, b: decimal, c: decimal): void
    {
        material d: decimal = b * b - 4.0 * a * c;

        check (d < 0)
        {
            dispatch(0);    # нет корней
            yield;
        }
        otherwise
        {
            check (d == 0)
            {
                material x: decimal = (-b) / (2.0 * a);
                dispatch(1, x);   # один корень
                yield;
            }
            otherwise
            {
                material sqrt_d: decimal = d ** 0.5;
                material x1: decimal = (-b + sqrt_d) / (2.0 * a);
                material x2: decimal = (-b - sqrt_d) / (2.0 * a);
                dispatch(2, x1, x2); # два корня
                yield;
            }
        }
    }

    blueprint main()
    {
        material a: decimal = receive('Введите a:');
        material b: decimal = receive('Введите b:');
        material c: decimal = receive('Введите c:');

        solve(a, b, c);
    }
```