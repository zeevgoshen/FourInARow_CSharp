namespace FourInARowModel {}
public class Cell
{
    public int RowNumber { get; set; }
    public int ColumnNumber { get; set; }
    public bool CurrentlyOccupied { get; set; }
    public string Symbol { get; set; }

    public Cell(int x, int y)
    {
        RowNumber = x;
        ColumnNumber = y;
    }
}

