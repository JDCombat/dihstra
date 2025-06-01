public class DijkstraHeap
{
    public static (List<int> path, int distance) FindPath(Graph graph, int startId, int endId)
    {
        HashSet<int> notVisited = new HashSet<int>(graph.Nodes.Select(n => n.Id));

        MinHeap priorityQueue = new MinHeap();

        Dictionary<int, int?> parents = new Dictionary<int, int?>();

        Dictionary<int, int> distances = new Dictionary<int, int>();


        graph.Nodes.ForEach(n =>
        {
            distances[n.Id] = int.MaxValue;
            parents[n.Id] = null;
        });

        distances[startId] = 0;

        priorityQueue.Push(startId, 0);


        while (priorityQueue.Heap.Count > 0)
        {
            var current = priorityQueue.Pop()!.Value;

            if (current.id == endId)
            {
                break;
            }
            if (!notVisited.Contains(current.id))
            {
                continue;
            }

            var node = graph.Nodes.Find(e => e.Id == current.id);
            node!.Edges.ForEach(e =>
            {
                if (distances[current.id] + e.Cost < distances[e.TargetId])
                {
                    distances[e.TargetId] = distances[current.id] + e.Cost;
                    parents[e.TargetId] = current.id;
                    priorityQueue.Push(e.TargetId, e.Cost);
                }
            });
            notVisited.Remove(current.id);
        }

        if (distances[endId] == int.MaxValue)
        {
            return ([], int.MaxValue);
        }

        int? currentNode = endId;
        var path = new List<int>();

        while (currentNode != null)
        {
            path.Add(currentNode.Value);
            currentNode = parents[currentNode.Value];
        }

        path.Reverse();
        return (path, distances[endId]);
    }
}