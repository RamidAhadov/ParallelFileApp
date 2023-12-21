using ParallelFileApp.FileWriting.Abstraction;

namespace ParallelFileApp.FileWriting;

public class FileWriter:IWriter
{
    public void Write(string path,string text)
    {
        for (int i = 1; i <= 1000; i++)
        {
            //string path = $"/Users/macbook/Desktop/ParallelFileAppFolder/example{i}.txt";
            
            string fullPath = Path.Combine(path, $"example{i}.txt");
            if (File.Exists(fullPath))
            {
                using (StreamWriter writer = new StreamWriter(fullPath, true))
                {
                    writer.WriteLine(text);
            
                    writer.Flush();
                }
            }
            //Console.WriteLine(fullPath);
        }

        
        // Parallel.For(1, 1001, i =>
        // {
        //     string fullPath = Path.Combine(path, $"example{i}.txt");
        //
        //     if (File.Exists(fullPath))
        //     {
        //         using (StreamWriter writer = new StreamWriter(fullPath, true))
        //         {
        //             writer.WriteLine(text);
        //             writer.Flush();
        //         }
        //     }
        // });
    }
    
    public void ManualThreadedWrite(string path, string text)
    {
        int threadCount = 4;

        Thread[] threads = new Thread[threadCount];

        for (int i = 0; i < threadCount; i++)
        {
            int threadNumber = i + 1;
            threads[i] = new Thread(() =>
            {
                WriteFiles(path, text, threadNumber, threadCount);
                Console.Write(threadNumber);
            });
            threads[i].Start();
            
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }
    }
        
    static void WriteFiles(string path, string text,int threadNumber,int threadCount)
    {
        for (int i = 1; i <= 2000; i++)
        {
            // if (i%threadNumber == 0)
            // {
            //                 
            // }
            string fullPath = Path.Combine(path, $"example{i*threadNumber}.txt");

            if (File.Exists(fullPath))
            {
                // lock (typeof(Program))
                // {
                    using (StreamWriter writer = new StreamWriter(fullPath, false))
                    {
                        Console.WriteLine($"{i}-{threadNumber}");
                        writer.WriteLine(text+$"-{i}"+$"-{threadNumber}");
                        writer.Flush();
                    //}
                }
            }
        }
    }
}