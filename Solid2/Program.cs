﻿using System;

//Який принцип S.O.L.I.D. порушено? Виправте!

/*Зверніть увагу на клас EmailSender. Крім того, що за допомогою методу Send, він відправляє повідомлення, 
він ще і вирішує як буде вестися лог. В даному прикладі лог ведеться через консоль.
Якщо трапиться так, що нам доведеться міняти спосіб логування, то ми будемо змушені внести правки в клас EmailSender.
Хоча, здавалося б, ці правки не стосуються відправки повідомлень. Очевидно, EmailSender виконує кілька обов'язків і, 
щоб клас ні прив'язаний тільки до одного способу вести лог, потрібно винести вибір балки з цього класу.*/

//dependence inversion, single responibility, open closed
class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}

interface ILogger
{
    void Output(Email email);
}

class ConsoleLogger : ILogger 
{
    public void Output(Email email) 
    {
		Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
	}
}

class EmailSender
{
    private ILogger _logger;
	public EmailSender(ILogger logger)
	{
		_logger = logger;
	}

	public void Send(Email email)
    {
		// ... sending...
		_logger.Output(email);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        ILogger logger = new ConsoleLogger();
        EmailSender es = new EmailSender(logger);
        es.Send(e1);
        es.Send(e2);
        es.Send(e3);
        es.Send(e4);
        es.Send(e5);
        es.Send(e6);

        Console.ReadKey();
    }
}