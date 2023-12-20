namespace ParallelFileApp.FileDeleting.Abstraction;

public interface IDeleter
{
    void Delete(string path);
    void ManualThreadedDelete(string path);
}