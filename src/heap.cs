using System;
using System.Collections.Generic; 

public class Heap<T> {

  public List<T> list;  
  Func<T, T, int> compare; 

  public Heap(Func<T, T, int> compare) {
    list = new List<T>();
    this.compare = compare; 
  }

  public Heap() : this((x,y) => Comparer<T>.Default.Compare(x,y)) { }

  public int Count {
    get { return list.Count; }
  }

  public void Insert(T value) {
    int index = list.Count; 
    list.Add(value); 
    int parentIndex = ParentIndex(index); 
    while(index > 0 && compare(list[index], list[parentIndex]) < 0) {
      Swap(index, parentIndex);
      index = parentIndex; 
      parentIndex = ParentIndex(index); 
    }
  }

  public T Remove() {
    if (list.Count == 0) throw new ArgumentOutOfRangeException("Cannot remove Element from empty Heap"); 
    T value = list[0];
    list[0] = list[list.Count-1];
    list.RemoveAt(list.Count-1); 
    Heapify(0); 
    return value; 
  }

  public static Heap<T> FromList(List<T> list, Func<T, T, int> compare) {
    Heap<T> H = new Heap<T>(compare); 
    if (list.Count == 0) return H; 
    H.list = list; 
    for (int i = list.Count/2-1; i>=0; i--)
      H.Heapify(i);
    return H; 
  }

  public static Heap<T> FromList(List<T> list) {
    return FromList(list, (x,y) => Comparer<T>.Default.Compare(x,y)); 
  }

  private void Heapify(int index) {
    while(index < list.Count) {

      int leftChildIndex = LeftChildIndex(index);
      if (leftChildIndex >= list.Count) break; 

      int childIndex = leftChildIndex; 
      int rightChildIndex = RightChildIndex(index); 
      if (rightChildIndex < list.Count && compare(list[rightChildIndex], list[leftChildIndex]) < 0 ) {
        childIndex = rightChildIndex;
      } 
      if (compare(list[index], list[childIndex]) < 0) break; 
      Swap(index,childIndex);
      index = childIndex;
    }
  }

  public static int ParentIndex(int index) { return (index-1)/2; } 
  public static int LeftChildIndex(int index) { return index*2+1; } 
  public static int RightChildIndex(int index) { return index*2+2; } 

  private void Swap(int i1, int i2) {
    T temp = list[i1];
    list[i1] = list[i2];
    list[i2] = temp; 
  }
}
