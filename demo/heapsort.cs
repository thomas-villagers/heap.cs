using System; 
using System.Collections.Generic; 
using System.Diagnostics; 

public class Heapsort {

  public static void Main() {

    int n = 1000000;
    var random = new Random();
    var L = new List<int>(n);
    Console.WriteLine("Generating {0} random elements...", n); 
    for(int i = 0; i < n; i++)
      L.Add(random.Next()); 

    var H = new Heap<int>();
    Console.WriteLine("Sorting {0} random elements...", n); 
    var sw = Stopwatch.StartNew(); 
    foreach(var i in L) 
      H.Insert(i); 
    var elapsedInsert = sw.ElapsedMilliseconds;
    while(H.Count > 0) 
      H.Remove();
    var elapsedRemove = sw.ElapsedMilliseconds;
    sw.Stop(); 
    Console.WriteLine("Insertion: {0} Removal: {1} Combined: {2}", elapsedInsert, elapsedRemove, elapsedInsert + elapsedRemove); 
  }
}
