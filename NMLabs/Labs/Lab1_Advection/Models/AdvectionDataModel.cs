namespace NMLabs.Labs.Lab1_Advection.Models;

public class AdvectionParameters
{
    public double X { get; set; }
    public double Dx { get; set; }
    public double U { get; set; }
    public double T0 { get; set; }
    public double CFL { get; set; }
    public AdvectionType Type { get; set; }

    public enum AdvectionType
    {
        Central,
        Directional
    }

    public AdvectionParameters WithCFL(double cfl) => new()
    { 
        X = this.X,
        Dx = this.Dx,
        U = this.U,
        T0 = this.T0,
        CFL = cfl,
        Type = this.Type
    };

    public AdvectionParameters WithType(AdvectionType type) => new()
    {
        X = this.X,
        Dx = this.Dx,
        U = this.U,
        T0 = this.T0,
        CFL = this.CFL,
        Type = type
    };
}
