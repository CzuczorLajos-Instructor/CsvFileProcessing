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
        throw new NotImplementedException();
    }

    //**********************************************************************************
    // Read table data from CSV file
    //
    private static List<Table> ReadTableData0(string dataFile, out List<string> invalidLines)
    {
        throw new NotImplementedException();
    }

    //**********************************************************************************
    // Query table data
    //

}
