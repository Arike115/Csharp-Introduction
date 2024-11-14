//Quantifier Operators
///any,all, contain
///

var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

var result = numbers.Any(x => x > 2.5);
Console.WriteLine(result);

var value = numbers.All(x => x%2 == 0); 
Console.WriteLine(value);

var values = numbers.Contains(20);
Console.WriteLine(values);
Console.ReadKey();