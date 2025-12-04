# Пример для типа `text`: ReverseString

```
blueprint main()
{
    material s: text = receive("Enter text:");
    material i: int = 0;
    material j: int = len(s) - 1;

    cyclewhile (i < j)
    {
        material left: text = substring(s, i, 1);
        material right: text = substring(s, j, 1);

        s = replaceAt(s, i, right);
        s = replaceAt(s, j, left);

        i = i + 1;
        j = j - 1;
    }

    dispatch(s);
}
```