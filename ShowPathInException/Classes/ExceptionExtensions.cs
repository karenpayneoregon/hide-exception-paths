namespace ShowPathInException.Classes;

public static class ExceptionExtensions
{
    public static IEnumerable<Exception> FlattenHierarchy(this Exception exception)
    {
        if (exception == null)
        {
            throw new ArgumentNullException(nameof(exception));
        }

        var innerException = exception;

        do
        {
            yield return innerException;
            innerException = innerException.InnerException;
        }

        while (innerException != null);
    }
    public static IEnumerable<T> InnerExceptions<T>(this Exception exception) where T : Exception
    {
        var list = new List<T>();

        Action<Exception> lambdaAction = null!;
        lambdaAction = (current) =>
        {
            var item = current as T;
            if (item != null)
            {
                list.Add(item);
            }

            if (current.InnerException != null)
            {
                lambdaAction!(current.InnerException);
            }

            if (current is AggregateException aggregateException)
            {
                foreach (var currentException in aggregateException.InnerExceptions)
                {
                    lambdaAction!(currentException);
                }
            }
        };

        lambdaAction(exception);

        return list;
    }
}