# Switch Statements

For when you want to switch any non-const value
Or to make your switches prettier and more compact

## Usage

### The full package
```cs
var statement = new SwitchStatement<string, int>()
{
    { 
        "abc", 
        () => Console.WriteLine("This is executed if the value matches 'abc'"), 
        5 
    },
    { "def", null, 7 },
    { "ghi", () => {}, 42 },
};
var result1 = statement.Execute("abc"); // result = { Matched = true, Result = 5 }
var result2 = statement.Execute("xyz"); // result = { Matched = false }
```
You can also define a Default case. Because we cannot use collection initializer and object initializer at the same time, use the Cases Property:
```cs
var statement = new SwitchStatement<string, int>()
{
    Cases = 
    {
        { "abc", () => {}, 5 },
        { "def", () => DoSomething(), 7 },
    },
    Default = { Action = null, Result = -1 },
};
var result = statement.Execute("xyz"); // result = { Matched = true, Result = -1 }
```

### The 'classical' switch
If you do not need to return a value for the matched value, use SwitchStatement with only one type parameter
```cs
var statement = new SwitchStatement<string>()
{
    { "abc", () => {} },
    { "def", null},
};
```
or with Default Case
```cs
var statement = new SwitchStatement<string>()
{
    Cases =
    {
        { "abc", () => {} },
    },
    Default = { Action = null },
};
```

### The map statement
It is also possible to have no Action executed, but a result value returned. In this Case, use the MapStatement
```cs
var statement = new MapStatement<string, int>()
{
    { "abc", 3 },
    { "def", 5 },
};
```
again, you can specify a Default Case
```cs
var statement = new MapStatement<string, int>()
{
    Cases =
    {
        { "abc", 3 },
    },
    Default = { Result = 9 },
};
```

### Practical Example: 
One of my projects had a switch that looked something like this to extract all properties out of an xml document:
```cs
float f1, f2, f3, f4, f5, f6, f7, f8, f9, other;
foreach (var attribute in someXmlCollection)
{
    switch(attribute.Name)
    {
        case "f1":
            f1 = (float) attribute.Value;
            break;
        case "f2":
            f2 = (float) attribute.Value;
            break;
        case "f3":
            f3 = (float) attribute.Value;
            break;
        case "f4":
            f4 = (float) attribute.Value;
            break;
        case "f5":
            f5 = (float) attribute.Value;
            break;
        case "f6":
            f6 = (float) attribute.Value;
            break;
        case "f7":
            f7 = (float) attribute.Value;
            break;
        case "f8":
            f8 = (float) attribute.Value;
            break;
        case "f9":
            f9 = (float) attribute.Value;
            break;
        case "other":
            other = (float) attribute.Value;
            break;
    }
}
```

What a bulk switch. And inside the loop, too. After introducing the SwitchStatement, it can look like this
```cs
float f1, f2, f3, f4, f5, f6, f7, f8, f9, other;
foreach (var attribute in someXmlCollection)
{
    float ToFloat() => (float) attribute.Value;
    new SwitchStatement<string>()
    {
        { "f1", () => f1 = ToFloat() },
        { "f2", () => f2 = ToFloat() },
        { "f3", () => f3 = ToFloat() },
        { "f4", () => f4 = ToFloat() },
        { "f5", () => f5 = ToFloat() },
        { "f6", () => f6 = ToFloat() },
        { "f7", () => f7 = ToFloat() },
        { "f8", () => f8 = ToFloat() },
        { "f9", () => f9 = ToFloat() },

        {"other", () => other = ToFloat() },
    }.Execute(attribute.Name);
}
```