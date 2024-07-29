namespace RiderMaker.Interfaces;

interface INeedFuel
{
    // Fields
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    // Methods
    public void GiveFuel(int Amount);
}