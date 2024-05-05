using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;

class Program
{
	static int TaskMethod(string name, int seconds)
	{
		WriteLine(
		    $"Task {name} is running on a thread id " +
		    $"{CurrentThread.ManagedThreadId}. Is thread pool thread: " +
		    $"{CurrentThread.IsThreadPoolThread}");

		Sleep(TimeSpan.FromSeconds(seconds));
		return 42 * seconds;
	}

	static void Main(string[] args)
	{
		var firstTask = new Task<int>(() => TaskMethod("First Task", 3));
		var secondTask = new Task<int>(() => TaskMethod("Second Task", 2));

		//(1)使用WhenAll等待所有任务完成

		var whenAllTask = Task.WhenAll(firstTask, secondTask);

		whenAllTask.ContinueWith(t =>
			WriteLine($"The first answer is {t.Result[0]}, the second is {t.Result[1]}"),
			TaskContinuationOptions.OnlyOnRanToCompletion);

		firstTask.Start();
		secondTask.Start();

		Sleep(TimeSpan.FromSeconds(4));

		//(2)使用WhenAll等待所有任务完成
		var tasks = new List<Task<int>>();
		for (int i = 1; i < 4; i++)
		{
			int counter = i;
			var task = new Task<int>(() => TaskMethod($"Task {counter}", counter));
			tasks.Add(task);
			task.Start();
		}

		while (tasks.Count > 0)
		{
			var completedTask = Task.WhenAny(tasks).Result;
			tasks.Remove(completedTask);
			WriteLine($"A task has been completed with result {completedTask.Result}.");
		}

		Sleep(TimeSpan.FromSeconds(1));
	}
}