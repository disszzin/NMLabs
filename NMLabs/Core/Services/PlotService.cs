using ScottPlot;

namespace NMLabs.Core.Services;

public interface IPlotSevice 
{
    void CreatePlot(string title, string xlabel, string ylabe, double width = 1024, double height = 768);
    void AddScatter(double[] xs, double[] ys, string label, Color color, double lineWidth = 1);
    void AddLine(double x1, double y1, double x2, double y2, string label, Color color, double lineWidth = 1);
    void SavePlot(string filePath);
    void ShowPlot();
}
public class PlotService : IPlotSevice
{
    private readonly Plot _plot = new();

    public void CreatePlot(string title, string xlabel, string ylabel, double width = 1024, double height = 768)
    {
        throw new NotImplementedException();
    }

    public void AddScatter(double[] xs, double[] ys, string label, Color color, double lineWidth = 1)
    {
        throw new NotImplementedException();
    }

    public void AddLine(double x1, double y1, double x2, double y2, string label, Color color, double lineWidth = 1)
    {
        throw new NotImplementedException();
    }

    public void SavePlot(string filePath)
    {
        throw new NotImplementedException();
    }

    public void ShowPlot()
    {
        throw new NotImplementedException();
    }
}
