using System;

namespace ToDoList.Application.Exceptions;

public class NotDeletedException : Exception
{
    public NotDeletedException(string name, object key) : base($"{name} ({key}) was not deleted")
    {
    }
}
