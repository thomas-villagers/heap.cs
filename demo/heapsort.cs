using System; 
using System.Linq; 
using System.Collections.Generic; 
using System.Diagnostics; 

public class Heapsort {

  public static void Main() {

    int n = 1000000;
    var random = new Random();
    Console.WriteLine("Generating {0} random elements...", n); 
    var numbers = Enumerable.Range(0,n).Select(x => random.Next());

    Console.WriteLine("Sorting {0} random elements...", n); 
    var sw = Stopwatch.StartNew(); 
    var H = Heap<int>.FromList(numbers.ToList());
    
    var elapsedInsert = sw.ElapsedMilliseconds;
    while(H.Count > 0) 
      H.Remove();
    var elapsedRemove = sw.ElapsedMilliseconds;
    sw.Stop(); 
    Console.WriteLine("Insertion: {0} Removal: {1} Combined: {2}", elapsedInsert, elapsedRemove, elapsedInsert + elapsedRemove); 
  }
}
