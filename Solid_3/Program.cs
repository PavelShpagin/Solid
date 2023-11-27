using System;

//Lisco

class Rectangle
{
	public int Width { get; set; }
	public int Height { get; set; }

	public int GetRectangleArea()
	{
		return Width * Height;
	}
}

class Square
{
	public int Side { get; set; }
	public int GetSquareArea()
	{
		return Side * Side;
	}
}
class Program
{
	static void Main(string[] args)
	{
		Rectangle rect = new Rectangle();
		rect.Width = 5;
		rect.Height = 10;

		Console.WriteLine(rect.GetRectangleArea());
		Console.ReadKey();
	}
}