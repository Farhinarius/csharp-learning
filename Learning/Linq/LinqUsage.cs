using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Learning.Linq.Resources;
using Learning.Classes.Resources.Vehicles;

namespace Learning.Linq;

public static class LinqUsage
{
    public static void TestQueryOverStrings()
    {
        string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

        // LINQ query operations syntax
        IEnumerable<string> videoGamesWithSpace =
            from g in currentVideoGames
            where g.Contains(" ")
            orderby g
            select g;

        // extension method syntax (Enumerable class extensions method)
        IEnumerable<string> videoGamesWithSpaceByExtensions =
            currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

        foreach (var game in videoGamesWithSpace)
        {
            Console.WriteLine(game);
        }
        ReflectOverQueryResults(videoGamesWithSpace);
        Console.WriteLine();

        foreach (var g in videoGamesWithSpaceByExtensions)
        {
            Console.WriteLine(g);
        }
        ReflectOverQueryResults(videoGamesWithSpaceByExtensions);
        Console.WriteLine();

        var videoGamesAlphabeticOrdered = currentVideoGames.OrderBy(g => g.First());
        foreach (var g in videoGamesAlphabeticOrdered)
        {
            Console.WriteLine(g);
        }
        ReflectOverQueryResults(videoGamesAlphabeticOrdered);
    }

    public static void ReflectOverQueryResults(object resultSet)
    {
        // Вывести тип результирующего набора.
        Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);

        // Вывести местоположение результирующего набора.
        Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
    }

    public static void TestQueryEvaluation()
    {
        int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

        // запрос linq выполняется в режиме отложенного выполнения (во время оценки)
        var intSelection = from i in numbers where i < 10 select i;

        // Оператор LINQ здесь оценивается!
        foreach (var number in intSelection)
        {
            Console.WriteLine("{0} < 10", number);
        }
        Console.WriteLine();

        // Изменить некоторые данные в массиве
        numbers[0] = 4;

        // Снова производится оценка! 
        foreach (var number in intSelection)
        {
            Console.WriteLine("{0} < 10", number);
        }
        Console.WriteLine();

        ReflectOverQueryResults(intSelection);
    }

    public static void ImmediateExecution()
    {
        Console.WriteLine();
        Console.WriteLine("Immediate Execution");
        int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };

        // Получить первый элемент в порядке последовательности
        int number = (from i in numbers select i).First();
        Console.WriteLine("First is {0}", number);

        // Получить первый элемент в чисел по возрастанию.
        number = (from i in numbers orderby i select i).First();
        Console.WriteLine("First is {0}", number);

        // Получить один элемент, который соответствует запросу,
        number = (from i in numbers where i > 30 select i).Single();
        Console.WriteLine("Single is {0}", number);
        try
        {
            // В случае возвращения более одного элемента генерируется исключение,
            number = (from i in numbers where i > 10 select i).Single();
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception occurred: {0}", ex.Message);
        }

        // Получить данные НЕМЕДЛЕННО как int[].
        int[] subsetAsIntArray =
            (from i in numbers where i < 10 select i).ToArray();

        // Получить данные НЕМЕДЛЕННО как List<int>.
        List<int> subsetAsListOfInts =
            (from i in numbers where i < 10 select i).ToList();
    }

    // not immediate execution 
    private static IEnumerable<string> GetStringSubset()
    {
        string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
        // Обратите внимание, что theRedColors является совместимым с IEnumerable<string> объектом.
        var theRedColors = from c in colors where c.Contains("Red") select c;
        return theRedColors;
    }

    private static string[] GetStringSubsetAsArray()
    {
        string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
        var theRedColorsAsString = (from c in colors where c.Contains("Red") select c).ToArray();
        return theRedColorsAsString;
    }

    public static void TestLinqReturnValue()
    {
        var stringSubsetAsEnumeration = GetStringSubset();

        // query expression evaluation 
        foreach (var str in stringSubsetAsEnumeration)
        {
            Console.WriteLine(str);
        }
        Console.WriteLine();

        var stringSubsetAsArray = GetStringSubsetAsArray();
        foreach (var str in stringSubsetAsArray)
        {
            Console.WriteLine(str);
        }

    }

    public static void TestLinqOverCollection()
    {
        var garage = new Garage();
        var garageSubset = garage.Vehicles.Where(v => v.MaxSpeed > 300);

        foreach (var vehicle in garageSubset)
        {
            Console.WriteLine(vehicle);
        }
    }

    public static void OfTypeAsFilter()
    {
        // Извлечь из ArrayList целочисленные значения
        ArrayList myStuff = new ArrayList();
        myStuff.AddRange(new object[] { 10, 400, 8, false, new Car(), "string data" });
        var mylnts = myStuff.OfType<int>();

        // Выводит только данные с целочисленными типами
        foreach (int i in mylnts)
        {
            Console.WriteLine("Int value: {0}", i);
        }
    }

    public static void TestLinqRequests()
    {
        // Этот массив будет основой для тестирования...
        ProductInfo[] itemsToStock = new[] {
        new ProductInfo{ Name = "Mac's Coffee",
            Description = "Coffee with TEETH", NumberInStock = 24 },
        new ProductInfo{ Name = "Milk Maid Milk",
            Description = "Milk cow's love", NumberInStock = 100},
        new ProductInfo{ Name = "Pure Silk Tofu",
            Description = "Bland as Possible", NumberInStock = 120},
        new ProductInfo{ Name = "Crunchy Pops",
            Description = "Cheezy, peppery goodness", NumberInStock = 2},
        new ProductInfo{ Name = "RipOff Water",
            Description = "From the tap to your wallet", NumberInStock = 100},
        new ProductInfo{ Name = "Classic Valpo Pizza",
            Description = "Everyone loves pizza!", NumberInStock = 73}
        };

        SelectEverything(itemsToStock);
        ListProductNames(itemsToStock);
        GetOverStock(itemsToStock);
        GetProductNamesAndDescriptions(itemsToStock);
        ListProjectedSubset(itemsToStock);
        ProjectIntoSpecificType(itemsToStock);
        ReverseEverything(itemsToStock);
        AlphabetizeProductNames(itemsToStock);
    }

    private static void SelectEverything(ProductInfo[] products)
    {
        Console.WriteLine("All product details:");
        var allProducts = from p in products select p;
        foreach (ProductInfo product in allProducts)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();
    }

    private static void ListProductNames(ProductInfo[] products)
    {
        Console.WriteLine("Only product names: ");
        var names = from p in products select p.Name;
        foreach (var n in names)
        {
            Console.WriteLine("Name: {0}", n);
        }
        Console.WriteLine();
    }

    private static void GetOverStock(ProductInfo[] products)
    {
        Console.WriteLine("Overstock products:");
        var overstock = from p in products where p.NumberInStock > 25 select p;
        foreach (var p in overstock)
        {
            Console.WriteLine(p);
        }
        Console.WriteLine();
    }

    private static void GetProductNamesAndDescriptions(ProductInfo[] products)
    {
        Console.WriteLine("Names and Descriptions: ");
        var productNamesAndDesc = from p in products select new { p.Name, p.Description };

        foreach (var pNameAndDesc in productNamesAndDesc)
        {
            Console.WriteLine(pNameAndDesc);
        }
        Console.WriteLine();
    }

    // Теперь возвращаемым значением является объект Array,
    private static Array GetProjectedSubset(ProductInfo[] products)
    {
        var nameDesc = from p in products select new { p.Name, p.Description };
        // Отобразить набор анонимных объектов на объект Array,
        return nameDesc.ToArray();
    }

    private static void ListProjectedSubset(ProductInfo[] products)
    {
        Console.WriteLine("List of projected from anonymous type product names and desc: ");
        Array productObjs = GetProjectedSubset(products);
        foreach (var prodObj in productObjs)
        {
            Console.WriteLine(prodObj);
        }
        Console.WriteLine();
    }

    private static void ProjectIntoSpecificType(ProductInfo[] products)
    {
        Console.WriteLine("Names and Descriptions projected to specific type:");
        IEnumerable<ProductInfoSmall> nameDesc =
            from p
            in products
            select new ProductInfoSmall { Name = p.Name, Description = p.Description };
        foreach (var item in nameDesc)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

    private static void ReverseEverything(ProductInfo[] products)
    {
        Console.WriteLine("Product reverse: ");
        foreach (var product in products.Reverse())
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();
    }

    private static void AlphabetizeProductNames(ProductInfo[] products)
    {
        // default ordering rule is ascending
        var subset = from p in products orderby p.Name /*ascending*/ select p;
        Console.WriteLine("Ordered by Name ascending: ");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();

        subset = from p in products orderby p.Name descending select p;
        Console.WriteLine("Order by name descending");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine();
    }

    public static void GetCountFromQuery()
    {
        string[] videoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System shock 2" };

        int numb = (from g in videoGames where g.Length > 6 select g).Count();

        Console.WriteLine("Number of video game names greater then 6");
    }

    public static void DisplayDiff()
    {
        List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

        var carDiff = myCars.Except(yourCars);
        Console.WriteLine("Here is what you don't have, but I do:");
        foreach (var c in carDiff)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    public static void DisplayIntersection()
    {
        List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

        var carIntersect = myCars.Intersect(yourCars);
        Console.WriteLine("Here is what we have in common: ");
        foreach (var c in carIntersect)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    public static void DisplayUnion()
    {
        List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

        var carUnion = myCars.Union(yourCars);
        Console.WriteLine("Here is everything");
        foreach (var c in carUnion)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    public static void DisplayConcat()
    {
        List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };

        var carConcat = myCars.Concat(yourCars);
        foreach (var c in carConcat)
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    public static void DisplayConcatNoDups()
    {
        List<string> myCars = new List<string> { "Yugo", "Aztec", "BMW" };
        List<string> yourCars = new List<string> { "BMW", "Saab", "Aztec" };
        var carConcat = myCars.Concat(yourCars);
        foreach (var c in carConcat.Distinct())
        {
            Console.WriteLine(c);
        }
        Console.WriteLine();
    }

    public static void AggregateOps()
    {
        double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
        // Разнообразные примеры агрегации.
        // Выводит максимальную температуру:
        Console.WriteLine("Max temp: {0}",
        (from t in winterTemps select t).Max());
        // Выводит минимальную температуру:
        Console.WriteLine("Min temp: {0}",
        (from t in winterTemps select t).Min());
        // Выводит среднюю температуру:
        Console.WriteLine("Average temp: {0}",
        (from t in winterTemps select t).Average());
        // Выводит сумму всех температур:
        Console.WriteLine("Sum of all temps: {0}",
        (from t in winterTemps select t).Sum());
    }

}
