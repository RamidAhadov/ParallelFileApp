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
    
    public void ManualThreadedDelete(string path)
    {
        int threadCount = 4;

        Thread[] threads = new Thread[threadCount];

        for (int i = 0; i < threadCount; i++)
        {
            int threadNumber = i;
            threads[i] = new Thread(() => DeleteFiles(path, threadNumber));
            threads[i].Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
        
    static void DeleteFiles(string path,int threadNumber)
    {
        for (int i = 1; i <= 20000; i++)
        {
            string fullPath = Path.Combine(path, $"example{i*threadNumber}.txt");

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}