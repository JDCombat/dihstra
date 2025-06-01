public class MinHeap
{
    public List<(int id, int distance)> Heap = new List<(int id, int distance)> ();

    public void Push(int id, int distance)
    {
        var index = Heap.Count;
        Heap.Add((id, distance));
        while (index != 0 && distance < Heap[GetParent(index)].distance)
        {
            var temp = Heap[GetParent(index)];
            Heap[index] = temp;
            Heap[GetParent(index)] = (id, distance);
            
            index = GetParent(index);
        }
    }

    public (int id, int distance)? Pop()
    {
        if (Heap.Count == 0)
        {
            return null;
        }
        var toReturn = Heap[0];
        Heap[0] = Heap.Last();
        Heap.RemoveAt(Heap.Count - 1);

        var currentIndex = 0;
        while (true)
        {
            if (GetRightChild(currentIndex) < Heap.Count && Heap[currentIndex].distance > Heap[GetRightChild(currentIndex)].distance &&
            Heap[GetLeftChild(currentIndex)].distance > Heap[GetRightChild(currentIndex)].distance)
            {
                (Heap[GetRightChild(currentIndex)], Heap[currentIndex]) = (Heap[currentIndex], Heap[GetRightChild(currentIndex)]);
                currentIndex = GetRightChild(currentIndex);
            }
            else if (GetLeftChild(currentIndex) < Heap.Count)
            {
                (Heap[GetLeftChild(currentIndex)], Heap[currentIndex]) = (Heap[currentIndex], Heap[GetLeftChild(currentIndex)]);
                currentIndex = GetLeftChild(currentIndex);
            }
            else
            {
                break;
            }


        }
        return toReturn;
    }

    public int GetParent(int index) => (index - 1) >> 1;

    public int GetLeftChild(int index) => 2 * index + 1;
    
    public int GetRightChild(int index) => 2 * index + 2;
}