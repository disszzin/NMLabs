using ScottPlot;
using ScottPlot.WinForms;
using ScottPlot.TickGenerators;

namespace NMLabs.Core.Services;

public interface IPlotSevice 
{
    void CreatePlot(string title, string xlabel = "", string ylabel = "");
    void AddScatter(double[] xs, double[] ys, string label = "", ScottPlot.Color? color = null, float lineWidth = 1);
    void ShowPlot();
}
public class PlotService : IPlotSevice
{
    private Plot _plot = new();
    NumericAutomatic _yTickGenerator;

    public PlotService() 
    {
        _yTickGenerator = new();
        _yTickGenerator.LabelFormatter = (double value) =>
        {
            return value.ToString("E1");
        };
    }

    public void CreatePlot(string title, string xlabel = "", string ylabel = "")
    {
        _plot = new();
        _plot.Title(title);
        _plot.XLabel(xlabel);
        _plot.YLabel(ylabel);
        _plot.Axes.Left.TickGenerator = _yTickGenerator;
    }

    public void AddScatter(double[] xs, double[] ys, string label = "", ScottPlot.Color? color = null, float lineWidth = 1)
    {
        var scatter = _plot.Add.Scatter(xs, ys, color);
        scatter.LineWidth = lineWidth;
        scatter.LegendText = label;
        scatter.MarkerSize = 0;
        _plot.Axes.AutoScale();
    }

    public void ShowPlot()
    {
        FormsPlotViewer.Launch(_plot);
    }
}
