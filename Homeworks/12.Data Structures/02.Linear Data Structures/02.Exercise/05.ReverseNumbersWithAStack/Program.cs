var input = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(x=>int.Parse(x))
    .ToList();

if(input is null || !input.Any())
{
    Console.WriteLine("empty");
}

Stack<int> stack= new();

input.ForEach(x => stack.Push(x));

Console.WriteLine(String.Join(' ', stack));

//   Input	        Output
// 1 2 3 4 5	   5 4 3 2 1
//     1	           1
//  (empty)	     (empty)
//   1 -2	      -2 1