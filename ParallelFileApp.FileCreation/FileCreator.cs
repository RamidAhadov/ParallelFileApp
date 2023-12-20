using ParallelFileApp.FileCreation.Abstraction;

namespace ParallelFileApp.FileCreation;

public class FileCreator:ICreator
{
    public void CreateFile(string path)
    {
        for (int i = 1; i <= 1000; i++)
        {
            string fullPath = Path.Combine(path, $"example{i}.txt");
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                
            }
        }
    }
}