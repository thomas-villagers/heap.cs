using System;
using System.Collections.Generic; 

using Task = System.Collections.Generic.KeyValuePair<int, int>; 

class TaskSchedule {
  public static void Main() {

    int n = 16; 
    int maxStartTime = 10; 
    int maxRunningTime = 6; 

    var random = new Random(); 
    var tasks = new Heap<Task>((x,y) => x.Key - y.Key); 
    Func<int, int, Task> MakeTask = ((t1,t2) => {int x = random.Next(1,t1+1); return new Task(x, x+random.Next(1,t2+1));});

    for(int i = 0; i < n; i++)
      tasks.Insert(MakeTask(maxStartTime, maxRunningTime)); 

    var scheduler = new TaskScheduler();
    while(tasks.Count > 0) {
      scheduler.Schedule(tasks.Remove()); 
    }
    scheduler.PrintTikz(); 
  }
}
