// 生产者消费者问题
using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
public class Program{
    public static void Main(){
        PCProblem pcProblem = new PCProblem();
        Thread producer1 = new Thread(new ThreadStart(pcProblem.producer));
        producer1.Name = "生产者1";
        Thread producer2 = new Thread(new ThreadStart(pcProblem.producer));
        producer2.Name = "生产者2";
        Thread producer3 = new Thread(new ThreadStart(pcProblem.producer));
        producer3.Name = "生产者3";
        Thread consumer1 = new Thread(new ThreadStart(pcProblem.consumer));
        consumer1.Name = "消费者1";
        Thread consumer2 = new Thread(new ThreadStart(pcProblem.consumer));
        consumer2.Name = "消费者2";
        producer1.Start();
        producer2.Start();
        producer3.Start();
        consumer1.Start();
        consumer2.Start();
    }
}
internal class PCProblem{
    int goodsNum = 0;
    Queue<int> goods = new Queue<int>();
    Semaphore buffer = new Semaphore(1, 1);// 缓冲区
    Semaphore empty = new Semaphore(5, 5);// 生产者能够生产的物品数量
    Semaphore full = new Semaphore(0, 5);// 消费者能够消费的物品数量

    public void producer(){
        while(true){
            empty.WaitOne(); // 等待生产者信号量
            buffer.WaitOne();
            goodsNum++;
            goods.Enqueue(goodsNum);
            Console.WriteLine(Thread.CurrentThread.Name + "生产者生产了物品" + goodsNum.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("当前有" + goods.Count + "个物品");
            Thread.Sleep(1000);
            full.Release(); // 释放一个消费者信号量
            buffer.Release();
        }
    }
    public void consumer(){
        while(true){
            full.WaitOne(); // 等待消费者信号量
            buffer.WaitOne(); 
            int goodNum = goods.Dequeue();
            Console.WriteLine(Thread.CurrentThread.Name + "消费者消费了物品" + goodNum.ToString());
            Thread.Sleep(1000);
            Console.WriteLine("当前有" + goods.Count + "个物品");
            Thread.Sleep(1000);
            empty.Release(); // 释放一个生产者信号量
            buffer.Release();
        }
    }
}