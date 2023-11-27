using System;

//Lisco

interface IShape 
{
	int GetArea();
}

class Rectangle : IShape
{
	public int Width { get; set; }
	public int Height { get; set; }
	public int GetArea()
	{
		return Width * Height;
	}
	public Rectangle(int width, int height)
	{
		Width = width;
		Height = height;
	}
}

class Square : IShape
{
	public int Side { get; set; }
	public int GetArea()
	{
		return Side * Side;
	}

	public Square(int side)
	{
		Side = side;
	}
}
class Program
{
	static void Main(string[] args)
	{
		IShape rect = new Rectangle(5, 10);
		IShape square = new Square(5);

		Console.WriteLine(rect.GetArea());
		Console.WriteLine(square.GetArea());
		Console.ReadKey();
	}
}