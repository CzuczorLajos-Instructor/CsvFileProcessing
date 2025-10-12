namespace CsvFileProcessing;
internal class Program
{
    const string relDataFile = "Data/Asztalok.csv"; // relative to the project folder
    static void Main()
    {
        string projectFolder = Path.Combine(AppContext.BaseDirectory, "../../..");
        string dataFile = Path.GetFullPath(Path.Combine(projectFolder, relDataFile)); // combine then normalise

        List<Table> tables = ReadTableData(dataFile);
        Query(tables);
    }

    private static List<Table> ReadTableData(string dataFile)
    {
        List<Table> data = ReadTableData0(dataFile, out List<string> invalidLines);
        if (invalidLines.Count == 0) { Console.WriteLine($"1. : A fájl hibátlan, nincs problémás adatsora."); }
        else
        {
            Console.WriteLine($"1. : A fájlban {invalidLines.Count} adatsor nem értelmezhető, ez(ek) a következő(k):");
            foreach (string line in invalidLines) { Console.WriteLine($"    {line}"); }
        }
        return data;
    }

    private static void Query(List<Table> tables)
    {
        Console.WriteLine($"2. : A fájlban {tables.Count} asztal adatai szerepelnek (amelyek értelmezhetők voltak)");
        Console.WriteLine($"3. : XXX olyan asztal van, amelyeknek a hosszuk kisebb, mint a szélességük");
        // TODO add the remaining queries here
    }

    //**********************************************************************************
    // Read table data from CSV file
    //
    private static List<Table> ReadTableData0(string dataFile, out List<string> invalidLines)
    {
        List<Table> data = new();
        invalidLines = new();
        using StreamReader reader = new(dataFile);
        reader.ReadLine(); // skip header line
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine() ?? "";
            try
            {
                Table table = new(line);
                data.Add(table);
            }
            catch (Exception)
            {
                invalidLines.Add(line);
            }
        }
        return data;
    }

    //**********************************************************************************
    // Query table data
    //
    int CountTablesWithWeirdDimensions(List<Table> tables)
    {
        int count = 0;
        foreach (var table in tables)
        {
            if (table.Length < table.Width) { count++; }
        }
        return count;
    }

    (int, int) CountTablesWithMinMaxArea(List<Table> tables)
    {
        int minArea = int.MaxValue;
        int maxArea = int.MinValue;
        foreach (var table in tables)
        {
            minArea = Math.Min(minArea, table.Area());
            maxArea = Math.Max(maxArea, table.Area());
        }
        return (minArea, maxArea);
    }

    int CountTablesWhithAreaGreaterThanTreshold(List<Table> tables, int treshold)
    {
        int count = 0;
        foreach (var table in tables)
        {
            if (table.Area() > treshold) { count++; }
        }
        return count;
    }

    int CalculateTotalPrice(List<Table> tables, IEnumerable<char> namePrefixes)
    {
        int totalPrice = 0;
        foreach (var table in tables)
        {
            if (namePrefixes.Contains(table.Name[0])) { totalPrice += table.Price; }
        }
        return totalPrice;
    }

    static int CalculateTotalArea(List<Table> tables, string nameSuffix, int priceThreshold)
    {
        return 0; // TODO implement this method
    }
}
