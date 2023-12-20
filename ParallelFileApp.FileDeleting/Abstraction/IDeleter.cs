namespace ParallelFileApp.FileDeleting.Abstraction;

public interface IDeleter
{
    void Delete(string path);
}