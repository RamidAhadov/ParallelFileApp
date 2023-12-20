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
}