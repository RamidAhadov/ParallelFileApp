namespace ParallelFileApp.FileWriting.Abstraction;

public interface IWriter
{
    void Write(string path,string text);
}