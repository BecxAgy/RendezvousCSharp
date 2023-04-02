using System;
using System.Threading;

class Program
{
    static Semaphore sem1 = new Semaphore(0, 1);
    static Semaphore sem2 = new Semaphore(0, 1);
    static Semaphore sem3 = new Semaphore(0, 1);
    

    static void Main(string[] args)
    {
        Thread t1 = new Thread(Processo1);
        Thread t2 = new Thread(Processo2);
        Thread t3 = new Thread(Processo3);

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine("Todos os processos se encontraram!");
    }

    static void Processo1()
    {
        Console.WriteLine("Processo 1 está pronto para se encontrar com o Processo 2...");
        sem1.Release();
        sem2.WaitOne();

        Console.WriteLine("Processo 1 está pronto para se encontrar com o Processo 3...");
        sem1.Release();
        sem3.WaitOne(); //fecho o semforo 3 pra sincronizar com o processo 2

    }

    static void Processo2()
    {
        Console.WriteLine("Processo 2 está pronto para se encontrar com o Processo 1...");
        sem2.Release();
        sem1.WaitOne(); //fecho semaforo 1 para sincronizar com o processo 3

        Console.WriteLine("\n1-------------------3... esperando 2...\n");


        Console.WriteLine("Processo 2 está pronto para se encontrar com o Processo 3...");
        sem2.Release();
        sem3.WaitOne();

    }

    static void Processo3()
    {
        Console.WriteLine("\n1------------------------2... esperando 3...\n");

        Console.WriteLine("Processo 3 está pronto para se encontrar com o Processo 1...");
        sem3.Release();
        sem1.WaitOne();

        Console.WriteLine("Processo 3 está pronto para se encontrar com o Processo 2...");
        sem3.Release();
        sem2.WaitOne();

        Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!\n");

    }
}
