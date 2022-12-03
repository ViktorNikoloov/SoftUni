var input = int.Parse(Console.ReadLine());

Queue<int> queue = new();
Queue<int> result = new();

for (int i = 0; i < 50; i++)
{
    if (queue.Count == 0)
    {
        queue.Enqueue(input);
        result.Enqueue(input);
    }

    var velue = queue.Dequeue();

    int valueOne = velue + 1;
    int valueTwo = 2 * velue + 1;
    int valueThree = velue + 2;

    queue.Enqueue(valueOne);
    queue.Enqueue(valueTwo);
    queue.Enqueue(valueThree);

    result.Enqueue(valueOne);
    result.Enqueue(valueTwo);
    result.Enqueue(valueThree);
}

Console.WriteLine(String.Join(", ", result));
