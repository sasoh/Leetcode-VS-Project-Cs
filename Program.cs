public static class ErrorHandling
{
    public static void HandleErrorByThrowingException() => throw new Exception();

    public static int? HandleErrorByReturningNullableType(string input)
    {
        if (int.TryParse(input, out var r))
        {
            return r;
        }
        return default;
    }

    public static bool HandleErrorWithOutParam(string input, out int result)
    {
        if (int.TryParse(input, out var r))
        {
            result = r;
            return true;
        }
        result = -1;
        return false;
    }

    public static void DisposableResourcesAreDisposedWhenExceptionIsThrown(IDisposable disposableObject)
    {
        using var p = disposableObject;
        throw new Exception();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
    }
}