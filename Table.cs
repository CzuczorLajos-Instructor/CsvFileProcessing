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
    }

    internal int Area()
    {
        return Length * Width;
    }
}