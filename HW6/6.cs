// using System;
// using System.Threading.Tasks;
// using static System.Console;
// using static System.Threading.Thread;

// class Program
// {
// 	static int TaskMethod(string name, int seconds)
// 	{
// 		WriteLine(
// 		    $"Task {name} is running on a thread id " +
// 		    $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
// 		    $"{CurrentThread.IsThreadPoolThread}");
// 		Sleep(TimeSpan.FromSeconds(seconds));
		
// 		throw new Exception("err");

// 		return 42 * seconds;
// 	}

// 	static void Main(string[] args)
// 	{
// 		var firstTask  = new Task<int>(() => TaskMethod("First Task", 3));
// 		var secondTask = new Task<int>(() => TaskMethod("Second Task", 2));

// 		//使用ContinueWith组合任务
// 		firstTask.ContinueWith(
// 			t => WriteLine(
// 			    $"The first answer is {t.Result}. Thread id " +
// 			    $"{CurrentThread.ManagedThreadId}, is thread pool thread: " +
// 			    $"{CurrentThread.IsThreadPoolThread}"),
// 			TaskContinuationOptions.OnlyOnRanToCompletion);
// 		// `TaskContinuationOptions.OnlyOnRanToCompletion` 的作用是确保延续操作只在前一个任务成功完成时(即没有抛出异常)执行。
	
// 		firstTask.Start();
// 		secondTask.Start();

// 		Sleep(TimeSpan.FromSeconds(4));

		

// 		//firstTask: Faulted
// 		//secondTask: Faulted
// 		//firstTask: RanToCompletion
// 		//secondTask: RanToCompletion
// 		WriteLine($"firstTask: {firstTask.Status}");
// 		WriteLine($"secondTask: {secondTask.Status}");

				
// 		Task continuation = secondTask.ContinueWith(
// 			t => WriteLine(
// 			    $"The second answer is {t.Result}. Thread id " +
// 			    $"{CurrentThread.ManagedThreadId}, is thread pool thread: " +
// 			    $"{CurrentThread.IsThreadPoolThread}"),
// 			TaskContinuationOptions.OnlyOnRanToCompletion 
//             | TaskContinuationOptions.ExecuteSynchronously);

// 		Sleep(TimeSpan.FromSeconds(2));
// 		WriteLine("------------------------------------------------------");


// 		//return;
		
// 		firstTask = new Task<int>(() =>
// 		{
// 			var innerTask = Task.Factory.StartNew(() => TaskMethod("Second Task", 5),
//                 TaskCreationOptions.AttachedToParent);

// 			innerTask.ContinueWith(t => TaskMethod("Third Task", 2),
//                 TaskContinuationOptions.AttachedToParent);

// 			return TaskMethod("First Task", 2);
// 		});

// 		firstTask.Start();

// 		while (!firstTask.IsCompleted)
// 		{
// 			WriteLine(firstTask.Status);
// 			Sleep(TimeSpan.FromSeconds(0.5));
// 		}
// 		WriteLine(firstTask.Status);

// 		Sleep(TimeSpan.FromSeconds(10));
// 	}
// }