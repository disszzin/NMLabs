namespace NMLabs.Labs.Lab1_Advection.Models;

public class AdvectionParameters
{
    public double X { get; set; }
    public double Dx { get; set; }
    public double U { get; set; }
    public double T0 { get; set; }
    public double CFL_Directional { get; set; }
    public double CFL_Central { get; set; }
}
