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
			int selectedCmd = 0;
			bool open = true;
			string cmdInput;
			string[] products =
			{"apples", "bananas", "oranges", "milk",
			 "flour", "beds", "baths", "beyond",
			 "redbull", "ice", "cake", "laptops",
			 "pepsi", "pizza", "bacon", "condoms",
			 "cookies", "pollos", "methylamine"};
			string[] adminCmds = {"help", "products", "buy", "money", "exit"};
			
			while(open == true)
			{
				Console.Write("-> ");
				cmdInput = Console.ReadLine();
				
				for(int i = 0; i < adminCmds.Length; i++)
				{
					if(!cmdInput.StartsWith(adminCmds[i]))
					{
						selectedCmd = -1;
					}
					if(cmdInput.StartsWith(adminCmds[i]))
					{
						selectedCmd = i;
						Console.WriteLine(selectedCmd + "");
						break;
					}
				}
				
				switch(selectedCmd)
				{
					case 0:
						Console.WriteLine("Command list:");
						for(int i = 0; i < adminCmds.Length - 1; i++)
						{
							Console.Write(adminCmds[i] + ", ");
						}
						Console.WriteLine(adminCmds[adminCmds.Length - 1] + ".");
						break;
					case 1:
						Console.WriteLine("Products:");
						for(int i = 0; i < products.Length - 1; i++)
						{
							Console.Write(products[i] + ", ");
						}
						Console.WriteLine(products[products.Length - 1] + ".");
						break;
					case 2:
						for(int i = 0; i < products.Length; i++)
						{
							if(cmdInput.EndsWith(products[i]))
							{
								totalPrices[i] += prices[i];
								Console.WriteLine("The product \"" + products[i] + "\" has been purchased for the price of $" + prices[i] + ".");
							}
						}
						break;
					case 3:
						Console.WriteLine("Money earned so far:");
						for(int i = 0; i < 18; i++)
						{
							Console.Write(products[i] + ": ");
							Console.Write(totalPrices[i] + ", ");
						}
						Console.Write(products[18] + ": ");
						Console.WriteLine(totalPrices[18] + ".");
						break;
					case 4:
						using(StreamWriter sw = new StreamWriter("MONEY.TXT"))
						{
							sw.WriteLine("Money earned so far:");
							for(int i = 0; i < products.Length; i++)
							{
								sw.Write(products[i] + ": ");
								sw.Write(totalPrices[i] + ", ");
							}
							sw.Write(products[products.Length - 1] + ": ");
							sw.WriteLine(totalPrices[totalPrices.Length - 1] + ".");
						}
						open = false;
						break;
					default:
						Console.WriteLine("Command \"" + cmdInput + "\" was not found.");
						break;
				}
			}
		}
	}
}
