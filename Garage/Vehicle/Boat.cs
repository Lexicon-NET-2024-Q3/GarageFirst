class Boat : Vehicle
{
    public uint Length { get; set; }

    public Boat(string regNr, uint wheelCount, string color, uint length)
        : base(regNr, wheelCount, color)
    {
        Length = length;
    }

    public override string ToString()
    {
        return base.ToString() + $" Length: {Length}";
    }
}
