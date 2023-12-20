using ParallelFileApp.FileCreation.Abstraction;

namespace ParallelFileApp.FileCreation;

public class FileCreator:ICreator
{
    public void CreateFile(string path)
    {
        Thread.Sleep(5000);
        for (int i = 1; i <= 20000; i++)
        {
            string fullPath = Path.Combine(path, $"example{i}.txt");
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                
            }
        }
    }
}