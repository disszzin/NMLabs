using ScottPlot;
using ScottPlot.WinForms;

namespace NMLabs.Core.Services;

public interface IPlotSevice 
{
    void CreatePlot(string title, string xlabel, string ylabe);
    void AddScatter(double[] xs, double[] ys, ScottPlot.Color color);
    void AddLine(double x1, double y1, double x2, double y2, string label, ScottPlot.Color color, double lineWidth = 1);
    void SavePlot(string filePath);
    void ShowPlot();
}
public class PlotService : IPlotSevice
{
    private Plot _plot = new();

    public void CreatePlot(string title, string xlabel, string ylabel)
    {
        _plot = new();
        _plot.Title(title);
        _plot.XLabel(xlabel);
        _plot.YLabel(ylabel);
    }

    public void AddScatter(double[] xs, double[] ys, ScottPlot.Color color)
    {
        _plot.Add.Scatter(xs, ys, color);
        _plot.Axes.AutoScale();
    }

    public void AddLine(double x1, double y1, double x2, double y2, string label, ScottPlot.Color color, double lineWidth = 1)
    {
        throw new NotImplementedException();
    }

    public void SavePlot(string filePath)
    {
        _plot.SavePng(filePath, 1920, 1080);
    }

    public void ShowPlot()
    {
        FormsPlotViewer.Launch(_plot);
    }
}
