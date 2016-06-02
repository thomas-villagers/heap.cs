using System; 

public class TestCompare {

  public static void Main() {

    var H = new Heap<int>((x,y) => y - x);
    H.Insert(7);
    H.Insert(4);
    H.Insert(6);
    H.Insert(3);
    H.Insert(2);
    H.Insert(5);
    H.Insert(1);

    while(H.Count > 0) 
      Console.Write(H.Remove() + " ");
  }
}
