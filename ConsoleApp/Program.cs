using ConsoleApp;

namespace ConsoleApp;

public interface Database
{
    public enum State
    {
        TransactionStarted,
        DataWritten,
        Invalid,
        Closed
    }
    public State DbState { get; set; }

    void BeginTransaction();
    void Write(string data);
    void EndTransaction();
    void Dispose();
}

public class Orm: IDisposable
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        if (database.DbState != Database.State.Closed) throw new InvalidOperationException();
        database.BeginTransaction();
    }

    public void Write(string data)
    {
        if (database.DbState != Database.State.TransactionStarted) throw new InvalidOperationException();
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException)
        {
            database.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException)
        {
            database.Dispose();
        }
    }

    public void Dispose() => database.Dispose();
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