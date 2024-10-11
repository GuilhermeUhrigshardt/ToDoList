using System;

namespace ToDoList.Application.Exceptions;

public class NotUpdatedException : Exception
{
    public NotUpdatedException(string name, object key) : base($"{name} ({key}) was not deleted")
    {
    }
}
