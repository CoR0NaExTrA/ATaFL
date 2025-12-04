# Пример для типа `decimal`: CircleArea

```
blueprint main()
{
    fixed PI: decimal = 3.14159;
    material r: decimal = receiveDecimal("Enter radius:");
    material area: decimal = PI * r * r;
    dispatch("Area:", area);
}
```