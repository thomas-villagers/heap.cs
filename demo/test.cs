using System; 
using System.Linq; 
using System.Collections.Generic; 

public class Test {

  public static void Main() {

    var H = new Heap<int>();
    H.Insert(7);
    H.Insert(4);
    H.Insert(6);
    H.Insert(3);
    H.Insert(2);
    H.Insert(5);
    H.Insert(1);
    H.Insert(8);

    while(H.Count > 0) 
      Console.Write(H.Remove() + " ");

    var L = Enumerable.Range(1,8); 
    Console.WriteLine();
    H = Heap<int>.FromList(L.ToList()); 

    while(H.Count > 0) 
      Console.Write(H.Remove() + " ");

  }
}
