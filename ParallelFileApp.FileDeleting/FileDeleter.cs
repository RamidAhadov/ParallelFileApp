using ParallelFileApp.FileDeleting.Abstraction;

namespace ParallelFileApp.FileDeleting;

public class FileDeleter:IDeleter
{
    public void Delete(string path)
    {
        for (int i = 1; i <= 1000; i++)
        {
            string fullPath = Path.Combine(path, $"example{i}.txt");
            File.Delete(fullPath);
        }
    }
}