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
        Console.WriteLine($"2. : A fájlban {tables.Count} asztal adatai szerepelnek (amelyek értelmezhetők voltak).");
        Console.WriteLine($"3. : {CountTablesWithWeirdDimensions(tables):N0} olyan asztal van, amelyeknek a hosszuk kisebb, mint a szélességük.");

        // TODO replace XXX with the actual values in the following lines
        (int minArea, int maxArea) = CalculateTablesMinMaxArea(tables);
        Console.WriteLine($"4. : A legkisebb felszínű asztal [lapjának] felszíne {minArea:N0}, a legnagyobbé pedig {maxArea:N0}.");
        double areaRatioThreshold = 0.8;
        Console.WriteLine($"5. : {CountTablesWhithAreaGreaterThan(tables, (int)(areaRatioThreshold * maxArea))} olyan asztal van, " +
            $"amely(ek) lapjának felszíne meghaladja a legnagyobb asztallap felszínének {areaRatioThreshold:P0}-át.");
        char[] namePrefixes = { 'I', 'Í' };
        Console.WriteLine($"6. : Azon asztalok összesített ára {CalculateTotalPrice(tables, namePrefixes):N0} egység, " +
            $"amelyekhez {string.Join(" vagy ", namePrefixes)} betűkkel kezdődő nevek tartoznak.");
        char suffix = 'a';
        int priceThreshold = 50000;
        Console.WriteLine($"7. : Azon asztalok teljes felszíne {CalculateTotalArea(tables, suffix, priceThreshold):N0}, " +
            $"amelyekhez {suffix} betűre végződő nevek tartoznak és az áruk meghaladja a(z) {priceThreshold:N0} egységet.");
        double sizeRatioThreshold = 2.5;
        Console.WriteLine($"8. : {CountTablesWithExtremeSizeRatio(tables, sizeRatioThreshold)} olyan asztal van, amelyek hossza." +
            $" legalább {sizeRatioThreshold:F1}-szerese a szélességének.");
        Console.WriteLine($"9. : Az asztalok átlagára {CalculateAveragePrice(tables)} egység.");
    }

    //**********************************************************************************
    // Read table data from CSV file
    //
    private static List<Table> ReadTableData0(string dataFile, out List<string> invalidLines)
    {
        List<Table> data = new();
        invalidLines = new();
        using StreamReader reader = new(dataFile);
        for (string? line = reader.ReadLine(); (line = reader.ReadLine()) != null;) // skip header line
        {
            try { data.Add(new Table(line)); }
            catch (Exception) { invalidLines.Add(line); }
        }
        return data;
    }

    //**********************************************************************************
    // Query table data
    //
    static int CountTablesWithWeirdDimensions(List<Table> tables)
    {
        int count = 0;
        foreach (var table in tables)
        {
            if (table.Length < table.Width) { count++; }
        }
        return count;
    }

    static (int, int) CalculateTablesMinMaxArea(List<Table> tables)
    {
        int minArea = int.MaxValue;
        int maxArea = int.MinValue;
        foreach (Table table in tables)
        {
            //if (table.Area() < minArea) minArea = table.Area();
            //if (table.Area() > maxArea) maxArea = table.Area();
            minArea = Math.Min(minArea, table.Area());
            maxArea = Math.Max(maxArea, table.Area());
        }
        return (minArea, maxArea);
    }

    static int CountTablesWhithAreaGreaterThan(List<Table> tables, int areaThreshold)
    {
        int count = 0;
        foreach (var table in tables)
        {
            if (table.Area() > areaThreshold) { count++; }
        }
        return count;
    }

    static int CalculateTotalPrice(List<Table> tables, char[] namePrefixes)
    {
        int totalPrice = 0;
        foreach (var table in tables)
        {
            if (namePrefixes.Contains(table.Name[0]))
            {
                totalPrice += table.Price;
            }
        }
        return totalPrice;
    }

    static int CalculateTotalArea(List<Table> tables, char nameSuffix, int priceThreshold)
    {
        int totalArea = 0;
        foreach (var table in tables)
        {
            if (table.Name.EndsWith(nameSuffix) && table.Price > priceThreshold)
            {
                totalArea += table.Area();
            }
        }
        return totalArea;
    }

    static int CountTablesWithExtremeSizeRatio(List<Table> tables, double sizeRatioThreshold)
    {
        int count = 0;
        foreach (var table in tables)
        {
            if ((double)table.Length / table.Width >= sizeRatioThreshold) { count++; }
        }
        return count;
    }

    static double CalculateAveragePrice(List<Table> tables)
    {
        if (tables.Count == 0) return 0.0;
        int totalPrice = 0;
        foreach (var table in tables)
        {
            totalPrice += table.Price;
        }
        return (double)totalPrice / tables.Count;
    }
}
