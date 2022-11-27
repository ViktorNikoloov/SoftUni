Console.WriteLine("Custom List");

Problem01.List.List<int> customList = new() { 1, 2, 3, 4, 5, 6, 7, 8};
Console.WriteLine(String.Join(", ", customList));

customList.Add(9);
Console.WriteLine(String.Join(", ", customList));

customList.Remove(3);
Console.WriteLine(String.Join(", ", customList));

customList.RemoveAt(1);
Console.WriteLine(String.Join(", ", customList));

Console.WriteLine(customList.IndexOf(5));

customList.Insert(2, 22);
Console.WriteLine(String.Join(", ", customList));

Console.WriteLine(customList.IndexOf(22));


Console.WriteLine(new String('-', 20));
Console.WriteLine("Custom Stack");


Problem02.Stack.Stack<int> customStack = new();

customStack.Push(1);
customStack.Push(2);
customStack.Push(3);
Console.WriteLine(String.Join(", ", customStack));

Console.WriteLine(customStack.Peek());
Console.WriteLine(String.Join(", ", customStack));

Console.WriteLine(customStack.Pop());
Console.WriteLine(String.Join(", ", customStack));


Console.WriteLine(new String('-', 20));
Console.WriteLine("Custom Queue");


Problem03.Queue.Queue<int> customQueue = new();
customQueue.Enqueue(1);
customQueue.Enqueue(2);
customQueue.Enqueue(3);
Console.WriteLine(String.Join(", ", customQueue));

Console.WriteLine(customQueue.Peek());
Console.WriteLine(String.Join(", ", customQueue));

Console.WriteLine(customQueue.Dequeue());
Console.WriteLine(String.Join(", ", customQueue));


Console.WriteLine(new String('-', 20));
Console.WriteLine("Custom Singly Linked List");


Problem04.SinglyLinkedList.SinglyLinkedList<int> customSinglyLinkedList = new();
customSinglyLinkedList.AddFirst(1);
customSinglyLinkedList.AddFirst(2);
customSinglyLinkedList.AddFirst(3);
Console.WriteLine(String.Join(", ", customSinglyLinkedList));

customSinglyLinkedList.AddLast(3);
customSinglyLinkedList.AddLast(2);
customSinglyLinkedList.AddLast(1);
Console.WriteLine(String.Join(", ", customSinglyLinkedList));

Console.WriteLine(customSinglyLinkedList.GetFirst());
Console.WriteLine(String.Join(", ", customSinglyLinkedList));

Console.WriteLine(customSinglyLinkedList.RemoveFirst());
Console.WriteLine(String.Join(", ", customSinglyLinkedList));

Console.WriteLine(customSinglyLinkedList.GetLast());
Console.WriteLine(String.Join(", ", customSinglyLinkedList));

Console.WriteLine(customSinglyLinkedList.RemoveLast());
Console.WriteLine(String.Join(", ", customSinglyLinkedList));