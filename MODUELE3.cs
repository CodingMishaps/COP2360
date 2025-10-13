using System;

public class Wine
{
  public decimal Price;
  public int Year;
  public Wine (decimal price)
  {
    Price = price;
  }
  public Wine (decimal price, int year) : this (price)
  {
    Year = year;
  }
  public void addYear() 
{
  Year++;
}
}

public class Program 
{
  public static void Main()
  {
    Wine winny = new Wine(100000,2005);
    winny.addYear();
    Console.WriteLine($"Wine price: {winny.Price}, Year: {winny.Year}");
    
  }
}
