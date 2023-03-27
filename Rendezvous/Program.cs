using System;
using System.Threading;

class Program
{
    static SemaphoreSlim semaphore1 = new SemaphoreSlim(0);
    static SemaphoreSlim semaphore2 = new SemaphoreSlim(0);

    static void Main(string[] args)
    {
        
        Thread thread1 = new Thread(Thread1Function);
        thread1.Start();

        
        Thread thread2 = new Thread(Thread2Function);
        thread2.Start();

        // Aguarda as threads terminarem
        thread1.Join();
        thread2.Join();

        Console.WriteLine("Programa finalizado");
    }

    static void Thread1Function()
    {
        Console.WriteLine("Thread 1 - primeira etapa"+ DateTime.Now);
        Thread.Sleep(10000); //as threads se encontraram depois de 5 segundos
        // Sinaliza o semáforo 1 para a thread 2 continuar
        semaphore1.Release();

        // Aguarda o semáforo 2 para continuar
        semaphore2.Wait();

        Console.WriteLine("Thread 1 - segunda etapa" + DateTime.Now );
    }

    static void Thread2Function()
    {
        Thread.Sleep(3000);
        Console.WriteLine("Thread 2 - primeira etapa" + DateTime.Now);

        // Aguarda o semáforo 1 para continuar
        semaphore1.Wait();

        // Sinaliza o semáforo 2 para a thread 1 continuar
        semaphore2.Release();

        Console.WriteLine("Thread 2 - segunda etapa"+ DateTime.Now);
    }
}
