using System;
using System.Threading;

class Program
{
    static SemaphoreSlim friend1Arrived = new SemaphoreSlim(0,1);
    static SemaphoreSlim friend2Arrived = new SemaphoreSlim(0,1);
    static SemaphoreSlim friend3Arrived = new SemaphoreSlim(0,1);

    static void Main(string[] args)
    {
        Thread friend1Thread = new Thread(Friend1);
        Thread friend2Thread = new Thread(Friend2);
        Thread friend3Thread = new Thread(Friend3);

        friend1Thread.Start();
        friend2Thread.Start();
        friend3Thread.Start();

        friend1Arrived.Wait(); // espera até que o amigo 1 encontre os outros amigos

        Console.WriteLine("Todos estão juntos, podem viajar!");
    }

    static void Friend1()
    {
        Console.WriteLine("O amigo 1 chegou no aeroporto.");
        friend2Arrived.Wait(); // espera pelo amigo 2
       
        Console.WriteLine("o amigo 1 encontrou o amigo 2 e 3");
        friend1Arrived.Release(); // sinaliza que encontrou os amigos
    }

    static void Friend2()
    {
        Console.WriteLine("O amigo 2 chegou no aeroporto.");
        
        friend3Arrived.Wait(); // espera pelo amigo 3
    }

    static void Friend3()
    {
        Console.WriteLine("O amigo 3 chegou no aeroporto");
      
        friend2Arrived.Release();
        friend3Arrived.Release(); // sinaliza que chegou ao amigo 1
    }
}
