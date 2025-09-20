namespace NMLabs.Labs.Lab1_Advection.Models;

public class AdvectionDataModel
{
    public double X { get; set; }
    public double Dx { get; set; }
    public double U { get; set; }
    public double T0 { get; set; }
    public double SafetyFactor { get; set; } = 0.2;
}
