
namespace CsvFileProcessing;
internal struct Table
{
    internal string Name { get; }
    internal int Length { get; }
    internal int Width { get; }
    internal int Price { get; }

    internal Table(string name, int length, int width, int price)
    {
        Name = name;
        Length = length;
        Width = width;
        Price = price;
        Validate();
    }

    internal Table(string csvLine)
    {
        string[] values = csvLine.Split(';');
        Name = values[0].Trim();
        Length = int.Parse(values[1].Trim());
        Width = int.Parse(values[2].Trim());
        Price = int.Parse(values[3].Trim());
        Validate();
    }

    internal int Area()
    {
        return Length * Width;
    }

    private void Validate()
    {
        if (Name == null || Name == "") throw new ArgumentException("A név nem lehet üres");
        if (Length <= 0) throw new ArgumentOutOfRangeException("A hossz nem lehet 0 vagy negatív");
        if (Width <= 0) throw new ArgumentOutOfRangeException("A szélesség nem lehet 0 vagy negatív");
        if (Price < 0) throw new ArgumentOutOfRangeException("Az ár nem lehet negatív");
    }
}