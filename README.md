# Implementação do Algoritmo de Rendezvous com C# e .NET
Este é um projeto simples que implementa o algoritmo de rendezvous em C# usando o .NET Framework. O algoritmo de rendezvous é usado para sincronizar a execução de duas threads ou processos, permitindo que eles troquem informações em um ponto de encontro.

O projeto consiste em um programa com duas threads que executam funções diferentes. A primeira thread executa a função "Thread1Function()" e a segunda thread executa a função "Thread2Function()". Essas funções simulam um ponto de encontro entre as duas threads.

O programa usa a classe SemaphoreSlim do .NET para controlar a sincronização das threads. Há dois semáforos: semaphore1 e semaphore2. A primeira thread aguarda o semáforo 2 antes de continuar, enquanto a segunda thread aguarda o semáforo 1 antes de continuar. Quando as threads se encontram, elas trocam informações e a execução continua.

Para executar o programa, basta compilar o código em um ambiente de desenvolvimento .NET e rodar o arquivo gerado. As threads serão iniciadas e o ponto de encontro será simulado. Depois de concluídas as execuções das threads, uma mensagem será exibida no console.
