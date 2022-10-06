using System;
using System.IO;

namespace SPPI
{
	class SPPI
	{
		static void Main(string[] args)
		{
			int[] prices = {70, 60, 55, 150, 80, 20, 20, 25, 80, 10, 20, 40, 40, 40, 40, 30, 60, 10, 15};
			int[] totalPrices = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
			bool open = true;
			string cmdInput, purCmd = "purchase";
			string[] products =
			{"apples", "bananas", "oranges", "milk",
			 "flour", "beds", "baths", "beyond",
			 "redbull", "ice", "cake", "laptops",
			 "pepsi", "pizza", "bacon", "condoms",
			 "cookies", "pollos", "methylamine"};
			string[] adminCmds = {"cmdlist", "prdlist", "money", "exit"};
			
			while(open == true)
			{
				Console.Write("-> ");
				cmdInput = Console.ReadLine();
				for(int i = 0; i < 19; i++)
				{
					if(cmdInput == purCmd + " " + products[i])
					{
						totalPrices[i] += prices[i];
						Console.WriteLine("The product \"" + products[i] + "\" has been purchased.");
					}
				}
				
				if(cmdInput == adminCmds[0])
				{
					Console.WriteLine("Command list:");
					Console.Write(purCmd + ", ");
					for(int i = 0; i < 3; i++)
					{
						Console.Write(adminCmds[i] + ", ");
					}
					Console.WriteLine(adminCmds[3] + ".");
				}
				if(cmdInput == adminCmds[1])
				{
					Console.WriteLine("Products:");
					for(int i = 0; i < 18; i++)
					{
						Console.Write(products[i] + ", ");
					}
					Console.WriteLine(products[18] + ".");
				}
				if(cmdInput == adminCmds[2])
				{
					Console.WriteLine("Money earned so far:");
					for(int i = 0; i < 18; i++)
					{
						Console.Write(products[i] + ": ");
						Console.Write(totalPrices[i] + ", ");
					}
					Console.Write(products[18] + ": ");
					Console.WriteLine(totalPrices[18] + ".");
				}
				if(cmdInput == adminCmds[3])
				{
					using(StreamWriter sw = new StreamWriter("MONEY.TXT"))
					{
						sw.WriteLine("Money earned so far:");
						for(int i = 0; i < 18; i++)
						{
							sw.Write(products[i] + ": ");
							sw.Write(totalPrices[i] + ", ");
						}
						sw.Write(products[18] + ": ");
						sw.WriteLine(totalPrices[18] + ".");
					}
					open = false;
				}
			}
		}
	}
}
