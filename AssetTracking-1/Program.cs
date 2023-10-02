using System.Xml.Schema;

Console.WriteLine("My Devices");

//Creating device list
List<Electronics> items = new List<Electronics>
{
    new Computer("Computer", "MacBook", "SD" , "Sweden",Convert.ToDateTime("2023-03-22"), 1200, "SEK"),
    new Phone("Mobile", "Samsung", "SD" , "USA",Convert.ToDateTime("2022-03-12"), 200, "USD"),
    new Phone("Mobile", "Motorolla", "HD" , "India",Convert.ToDateTime("2020-12-22"), 300, "INR"),
    new Computer("Computer", "Asus", "HD", "India", Convert.ToDateTime("2021-01-05"), 500, "INR"),
    new Computer("Computer", "HP", "Note", "Sweden", Convert.ToDateTime("2022-05-17"), 500, "SEK"),
    new Phone("Mobile", "Apple", "iPhone12", "Sweden", Convert.ToDateTime("2020-05-19"), 699, "SEK"),
    new Computer("Computer", "Lenovo", "IdeaPad", "India", Convert.ToDateTime("2022-07-17"), 999, "INR"),
    new Computer("Computer", "Dell", "ThinkPad", "USA", Convert.ToDateTime("2014-06-17"), 499, "USD"),
    new Phone("Mobile", "Apple", "iPhone14", "USA", Convert.ToDateTime("2022-05-19"), 999, "USD"),
    new Computer("Computer", "Lenovo", "AZ22", "Sweden", Convert.ToDateTime("2022-05-19"), 599, "SEK"),
    new Phone("Mobile", "Apple", "iPhone11", "USA", Convert.ToDateTime("2019-05-19"), 599, "USD"),
    new Phone("Mobile", "Apple", "iPhone13", "Sweden", Convert.ToDateTime("2016-07-10"), 799, "SEK"),
    new Computer("Computer", "Lenovo", "SD", "India", Convert.ToDateTime("2022-05-17"), 400, "INR"),
    new Phone("Mobile", "Apple", "iPhone15", "Sweden", Convert.ToDateTime("2021-01-10"), 1999, "SEK"),
};

Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15)+ "Model".PadRight(15) +"Office".PadRight(15)+ "PurchaseDate".PadRight(15) + "Price in USD".PadRight(15) + "Currency".PadRight(15) + "Local price today");

items = items.OrderBy(item => item.Office).ThenBy(item => item.Date).ToList();

TimeSpan timeDiff;
foreach (var item in items)
{
    /*
     * Calculating localPrice depending on set currency.
     */
    var LocalPrice = 0;
    timeDiff = DateTime.Now - item.Date;
    if(item.Currency.Equals("INR"))
    {
         LocalPrice = item.Price * 83; 
    }
    else if(item.Currency == "SEK")
    {
         LocalPrice = item.Price * 11;
    }
    else
    {
         LocalPrice = item.Price;
    }

    //Checking if device purchase date less than 3 months away from 3 years
    if (timeDiff.Days >= 1005)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(item.Type.PadRight(15) + item.Brand.PadRight(15) +
        item.Model.PadRight(15) + item.Office.PadRight(15) + item.Date.ToString("yyyy/MM/dd").PadRight(15) + item.Price.ToString().PadRight(15) + item.Currency.PadRight(15) + LocalPrice);
        Console.ResetColor();
    }
    ////Checking if device purchase date less than 6 months away from 3 years
    else if (timeDiff.Days >= 915 && timeDiff.Days <1005)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(item.Type.PadRight(15) + item.Brand.PadRight(15) +
        item.Model.PadRight(15) + item.Office.PadRight(15) + item.Date.ToString("yyyy/MM/dd").PadRight(15) + item.Price.ToString().PadRight(15) + item.Currency.PadRight(15) + LocalPrice);
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine(item.Type.PadRight(15) + item.Brand.PadRight(15) +
        item.Model.PadRight(15) + item.Office.PadRight(15) + item.Date.ToString("yyyy/MM/dd").PadRight(15) + item.Price.ToString().PadRight(15) + item.Currency.PadRight(15) + LocalPrice);
        
    }

}

class Electronics
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    public DateTime Date { get; set; }
    public string Office { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }   
}
class Computer : Electronics
{
    public Computer(string type, string brand, string model, string office, DateTime date, int price, string currency)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        Date = date;
        Price = price;
        Currency = currency;
    }

}

class Phone : Electronics
{
    public Phone(string type, string brand, string model,string office, DateTime date, int price, string currency)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Office = office;
        Date = date;
        Price = price;
        Currency = currency;
    }
}