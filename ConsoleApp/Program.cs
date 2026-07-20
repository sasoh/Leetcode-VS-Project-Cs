using System.Collections;

namespace ConsoleApp;

public class SimpleLinkedList<T>: IEnumerable<T>
{
    private readonly Stack<T> _stack = [];

    public int Count => _stack.Count;

    public SimpleLinkedList() { }
    public SimpleLinkedList(T value) => Push(value);
    public SimpleLinkedList(IEnumerable<T> values)
    {
        foreach (var item in values)
        {
            Push(item);
        }
    }

    public void Push(T value) => _stack.Push(value);

    public T Pop() => _stack.Pop();

    public IEnumerator GetEnumerator() => _stack.GetEnumerator();
    IEnumerator<T> IEnumerable<T>.GetEnumerator() => _stack.GetEnumerator();
}

public class Program
{
    public static void Main(string[] args)
    {
        SimpleLinkedList<int> l = new(3);
        Console.WriteLine(l.Count);
        l.Push(2);
        Console.WriteLine(l.Pop());
        Console.WriteLine(l.Count);
        Console.WriteLine(l.Pop());
        Console.WriteLine(l.Count);
    }
}