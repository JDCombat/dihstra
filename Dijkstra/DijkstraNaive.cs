public class DijkstraNaive
{
    public static (List<int> path, int distance) FindPath(Graph graph, int startId, int endId)
    {
        HashSet<int> notVisited = new HashSet<int>(graph.Nodes.Select(n => n.Id));

        Dictionary<int, int?> parents = new Dictionary<int, int?>();

        Dictionary<int, int> distances = new Dictionary<int, int>();


        graph.Nodes.ForEach(n =>
        {
            distances[n.Id] = int.MaxValue;
            parents[n.Id] = null;
        });

        distances[startId] = 0;


        while (notVisited.Count > 0)
        {
            var list = distances.ToList().FindAll(e=>notVisited.Contains(e.Key));
            list.Sort((a, b) => a.Value - b.Value);
            (int nodeId, int value) = list.First();
            var node = graph.Nodes.Find(e => e.Id == nodeId);
            node!.Edges.ForEach(e =>
            {
                if (distances[nodeId] + e.Cost < distances[e.TargetId])
                {
                    distances[e.TargetId] = distances[nodeId] + e.Cost;
                    parents[e.TargetId] = nodeId;
                }
            });
            notVisited.Remove(nodeId);
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