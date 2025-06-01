using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Graph graph = new Graph(
        [
            new Node(0, [new Edge(1, 4), new Edge(11, 7)]),
            new Node(1, [new Edge(0, 4), new Edge(2, 5), new Edge(4, 15), new Edge(11, 2), new Edge(12, 11)]),
            new Node(2, [new Edge(1, 5), new Edge(3, 6)]),
            new Node(3, [new Edge(2, 6), new Edge(4, 3)]),
            new Node(4, [new Edge(1, 15), new Edge(3, 3), new Edge(5, 8), new Edge(12, 13)]),
            new Node(5, [new Edge(4, 8), new Edge(6, 1)]),
            new Node(6, [new Edge(5, 1), new Edge(7, 6)]),
            new Node(7, [new Edge(6, 6), new Edge(8, 4)]),
            new Node(8, [new Edge(7, 4), new Edge(9, 3)]),
            new Node(9, [new Edge(8, 3), new Edge(10, 6), new Edge(11, 14), new Edge(12, 9)]),
            new Node(10, [new Edge(9, 6), new Edge(11, 3)]),
            new Node(11, [new Edge(0, 7), new Edge(1, 2), new Edge(9, 14), new Edge(10, 3), new Edge(12, 8)]),
            new Node(12, [new Edge(1, 11), new Edge(4, 13), new Edge(9, 9), new Edge(11, 8)])
        ]);

        var sw1 = Stopwatch.StartNew();

        var naiveResult = DijkstraNaive.FindPath(graph, 11, 6);

        sw1.Stop();

        System.Console.WriteLine("DijkstraNaive time: " + sw1.Elapsed.TotalMicroseconds + "us");
        System.Console.WriteLine("Naive path " + String.Join(" ", naiveResult.path));
        System.Console.WriteLine("Naive distance " + naiveResult.distance);

        var sw2 = Stopwatch.StartNew();

        var heapResult = DijkstraHeap.FindPath(graph, 11, 6);

        sw2.Stop();

        System.Console.WriteLine("DijkstraHeap time: " + sw2.Elapsed.TotalMicroseconds + "us");

        System.Console.WriteLine("Difference: " + sw1.Elapsed.Subtract(sw2.Elapsed).TotalMicroseconds + "us");

        Console.WriteLine("Heap Path: " + String.Join(" ", heapResult.path));
        Console.WriteLine("Heap Distance: " + heapResult.distance);


    }
    
}