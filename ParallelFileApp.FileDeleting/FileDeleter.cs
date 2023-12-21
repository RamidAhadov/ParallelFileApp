using ParallelFileApp.FileDeleting.Abstraction;

namespace ParallelFileApp.FileDeleting;

public class FileDeleter:IDeleter
{
    public void Delete(string path)
    {
        for (int i = 1; i <= 20000; i++)
        {
            string fullPath = Path.Combine(path, $"example{i}.txt");
            File.Delete(fullPath);
        }
    }
    
    private static object fileLock = new object();
    public void ManualThreadedDelete(string path)
    {
        int threadCount = 2;

        Thread[] threads = new Thread[threadCount];

        for (int i = 0; i < threadCount; i++)
        {
            int threadNumber = i + 1;
            threads[i] = new Thread(() => DeleteFiles(path, threadNumber,threadCount));
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
        
    static void DeleteFiles(string path,int threadNumber,int threadCount)
    {
        for (int i = 0; i < 20000/threadCount; i++)
        {
            string fullPath = Path.Combine(path, $"example{threadNumber + (i * threadCount)}.txt");

            if (File.Exists(fullPath))
            {
                // lock (fileLock)
                // {
                    File.Delete(fullPath);
                    Console.Write(i + " ");
                //}
            }
        }
    }
}