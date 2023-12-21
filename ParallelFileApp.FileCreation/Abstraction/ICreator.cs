namespace ParallelFileApp.FileCreation.Abstraction;

public interface ICreator
{
    void CreateFile(string path,int fileCount);
}