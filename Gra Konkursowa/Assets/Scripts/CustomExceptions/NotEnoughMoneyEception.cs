using System;

public class NotEnoughMoneyEception : Exception
{
    public NotEnoughMoneyEception()
    {

    }

    public NotEnoughMoneyEception(string message) : base(message)
    {

    }

    public NotEnoughMoneyEception(string message, Exception inner) : base(message, inner)
    {

    }
}
