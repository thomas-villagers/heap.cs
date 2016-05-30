using System;

public static class HeapExtensions {

  private static void PrintNode<T>(T rootValue, T childValue) {
    Console.WriteLine("  \"{0}\" -> \"{1}\"", rootValue, childValue);
  }

  private static void PrintNode<T>(T value, int empties) {
    Console.WriteLine("  empty{0} [label=\"\", style=invis];", empties);
    Console.WriteLine("  \"{0}\" -> empty{1}", value,  empties);
  }

  private static void PrintSubTree<T>(Heap<T> heap, int index, ref int empties) {

    int leftChild = Heap<T>.LeftChildIndex(index);

    if (leftChild < heap.list.Count) {
      PrintNode(heap.list[index], heap.list[leftChild]);
      PrintSubTree(heap, leftChild, ref empties);
    } else {
      Console.WriteLine("  \"{0}\" [shape=rectangle];", heap.list[index]);
      PrintNode(heap.list[index], empties++);
    }

    int rightChild = Heap<T>.RightChildIndex(index); 
    if (rightChild < heap.list.Count) {
      PrintNode(heap.list[index], heap.list[rightChild]);
      PrintSubTree(heap, rightChild, ref empties);
    } else {
      PrintNode(heap.list[index], empties++);
    }
  }
  
  public static void PrintDot<T>(this Heap<T> heap) {
    Console.WriteLine("digraph G {");
    int empties = 0;
    PrintSubTree(heap, 0, ref empties); 
    Console.WriteLine("}"); 
  }
}
