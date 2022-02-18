// Copyright © 2022 Waters Corporation. All Rights Reserved.

using System.Collections.Generic;
using MassCalculator.Data;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MassCalculator.Store.IsotopePrediction;

public class IsotopePredictionState
{
    public IsotopePredictionState(string formula, Composition? composition,
        IEnumerable<DataPoint> predictedIsotopes)
    {
        Formula = formula;
        Composition = composition;
        PredictedIsotopes = predictedIsotopes;
        PlotViewModel = SetUpPlotModel();
    }

    private PlotModel SetUpPlotModel()
    {
        var xAxis = new LinearAxis { Position = AxisPosition.Bottom, Title = "Mass" };
        var yAxis = new LinearAxis { Position = AxisPosition.Left, Title = "Intensity", AbsoluteMinimum = 0, AbsoluteMaximum = 1};

        var plotModel = new PlotModel { LegendPosition = LegendPosition.TopRight };
        plotModel.Axes.Add(xAxis);
        plotModel.Axes.Add(yAxis);

        var rawDataSeries = new StemSeries
        {
            ItemsSource = PredictedIsotopes,
            StrokeThickness = 1,
            Color = OxyColor.FromRgb(15, 32, 128),
        };

        plotModel.Series.Add(rawDataSeries);

        plotModel.InvalidatePlot(true);
        plotModel.ResetAllAxes();

        return plotModel;
    }

    public string Formula { get; }
    public Composition? Composition { get; }
    public PlotModel PlotViewModel { get; }
    public IEnumerable<DataPoint> PredictedIsotopes { get; }
}