using ParallelFileApp.FileCreation.Abstraction;

namespace ParallelFileApp.FileCreation;

public class FileCreator:ICreator
{
    public void CreateFile(string path,int fileCount)
    {
        //Thread.Sleep(5000);
        for (int i = 1; i <= fileCount; i++)
        {
            string fullPath = Path.Combine(path, $"example{i}.txt");
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                
            }
        }
    }
}