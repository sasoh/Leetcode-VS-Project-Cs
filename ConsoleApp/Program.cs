using System;
namespace ConsoleApp;

public interface Database
{
    void BeginTransaction();
    void Write(string data);
    void EndTransaction();
    void Dispose();
}

public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        try
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        catch (InvalidOperationException)
        {
            database.Dispose();
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        var result = false;
        try
        {
            database.BeginTransaction();
            database.Write(data);
            database.EndTransaction();
        }
        catch
        {
            database.Dispose();
        }
        return result;
    }
}

public class Program
{
    private static void RunTests()
    {
        Console.WriteLine("Running tests");
        
        Console.WriteLine("Finished tests");
    }

    public static void Main(string[] args)
    {
        RunTests();
    }
}