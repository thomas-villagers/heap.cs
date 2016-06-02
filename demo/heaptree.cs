class HeapTree {
  public static void Main() {
    var H = new Heap<int>();
    H.Insert(8);
    H.Insert(5);
    H.Insert(6);
    H.Insert(2);
    H.Insert(7);
    H.Insert(1);
    H.Insert(3);
    H.Insert(4);
    H.PrintDot(); 
  }
}
