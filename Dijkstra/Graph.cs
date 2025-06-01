public class Graph
{
    public List<Node> Nodes;

    public Graph(List<Node> nodes)
    {
        Nodes = nodes;
    }
}

public class Node
{
    public int Id;
    public List<Edge> Edges;

    public Node(int id, List<Edge> edges)
    {
        Id = id;
        Edges = edges;
    }
}

public class Edge
{
    public int TargetId;
    public int Cost;

    public Edge(int targetId, int cost)
    {
        TargetId = targetId;
        Cost = cost;
    }
}