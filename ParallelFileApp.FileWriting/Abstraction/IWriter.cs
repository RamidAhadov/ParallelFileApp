namespace ParallelFileApp.FileWriting.Abstraction;

public interface IWriter
{
    void Write(string path,string text);
    void ManualThreadedWrite(string path, string text);
}