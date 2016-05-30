using System;
using System.Collections.Generic; 

using Task = System.Collections.Generic.KeyValuePair<int, int>; 

class TaskSchedule {

  public static void Main() {
    var tasks = new Heap<Task>((x,y) => x.Key - y.Key); 
    tasks.Insert(new Task(1,3));
    tasks.Insert(new Task(1,4)); 
    tasks.Insert(new Task(2,5)); 
    tasks.Insert(new Task(6,9)); 
    tasks.Insert(new Task(3,7)); 
    tasks.Insert(new Task(4,7)); 
    tasks.Insert(new Task(7,8)); 
    var scheduler = new TaskScheduler();
    while(tasks.Count > 0) {
      scheduler.Schedule(tasks.Remove()); 
    }
    scheduler.PrintTikz(); 
  }
}
