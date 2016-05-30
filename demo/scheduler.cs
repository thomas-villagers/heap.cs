using System;
using System.Collections.Generic; 

using Task = System.Collections.Generic.KeyValuePair<int, int>; 

public class TaskScheduler {
  
  public class Machine {
    public List<Task> tasks; 
    public Machine() {  
      tasks = new List<Task>(); 
    }

    public static bool Overlaps(Task task1, Task task2) {
      if (task1.Value <= task2.Key) return false;
      if (task2.Value <= task1.Key) return false;
      return true; 
    }

    public bool Conflicts(Task task) {
      foreach(var t in tasks) {
        if (Overlaps(t, task) == true) return true; 
      }
      return false;
    }

    public void Add(Task task) {
      tasks.Add(task); 
    }
  }

  List<Machine> machines; 

  public TaskScheduler() {
    machines = new List<Machine>();
  }
  
  public void Schedule(Task task) {
    bool scheduled = false; 
    foreach(var m in machines) {
      if (!m.Conflicts(task)) {
        m.Add(task);
        scheduled = true;
        break;
      } 
    }
    if (scheduled == false) {
      var newMachine = new Machine();
      newMachine.Add(task);
      machines.Add(newMachine);
    }
  }

  public void PrintTikz() {
    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB"); 
    Console.WriteLine("\\begin{tikzpicture}[>=latex]");
    int y = 1;
    int maxTime = 0; 
    foreach (var machine in machines) {
      foreach(var task in machine.tasks) { 
        Console.WriteLine("  \\draw[fill=blue!40]({0},{1}) rectangle ({2},{3});",task.Key, y+0.1, task.Value, y+0.8);  
        maxTime = maxTime < task.Value ? task.Value : maxTime; 
      }
      y++; 
    }
    Console.WriteLine("  \\draw[thick,->](-0.2,0.8) -- ++(0,{0});", machines.Count+1); 
    for (int i = 0; i < machines.Count; i++) 
      Console.WriteLine("    \\draw(-0.4, {0}) node[left]{{Machine {1}}} -- ++ (0.4,0);", i+1+0.5, i+1); 

    Console.WriteLine("  \\draw[thick,->](-0.2,0.8) -- ++({0},0) node[right]{{time}};", maxTime+1); 
    for (int i = 0; i < maxTime; i++) 
      Console.WriteLine("    \\draw({0}, 0.6) node[below]{{{1}}} -- ++ (0,0.4);", i+1, i+1); 

    Console.WriteLine("\\end{tikzpicture}");
  }

}
