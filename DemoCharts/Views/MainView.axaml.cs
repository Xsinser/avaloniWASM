using Avalonia.Controls;
using ScottPlot;
using ScottPlot.Avalonia;
using System.Collections.Generic;
using System.Linq;

namespace DemoCharts.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        //double[] dataX = { 1, 2, 3, 4, 5 };
        //double[] dataY = { 1, 4, 9, 16, 25 };

        //AvaPlot avaPlot1 = this.Find<AvaPlot>("AvaPlot1");
        //avaPlot1.Plot.Add.Scatter(dataX, dataY);
        //avaPlot1.Refresh();
        {
            List<PieSlice> slices = new()
        {
            new() { Value = 10, Label = "Заявки-Покупка", FillColor = Colors.Red },
            new() { Value = 5, Label = "Заявки-Продажа", FillColor = Colors.DarkRed },
            new() { Value = 13, Label = "Сделки-Покупка", FillColor = Colors.Green },
            new() { Value = 9, Label = "Сделки-Продажа", FillColor = Colors.DarkGreen }
        };
            ScottPlot.Plot myPlot = this.Find<AvaPlot>("AvaPlot1").Plot;
            myPlot.Add.Coxcomb(slices);

            myPlot.Axes.Frameless();
            myPlot.ShowLegend();
            myPlot.HideGrid();
        }
        {
            ScottPlot.Plot myPlot = this.Find<AvaPlot>("AvaPlot2").Plot;
            myPlot.Add.Palette = new ScottPlot.Palettes.Nord();
            double[] values = { 140021, 32534, 12334, 2000 };

            var radialGaugePlot = myPlot.Add.RadialGaugePlot(values);
            radialGaugePlot.Labels = new string[] { "ОБъем торгов", "Объем сделок по иснтурменту", "Объем сделок по клиенту", "Объем подозрительных транзакций" };
            myPlot.ShowLegend();
        }
        {
            ScottPlot.Plot myPlot = this.Find<AvaPlot>("AvaPlot3").Plot;
            List<RadarSeries> radarSeries = new()
            {
                new() { Values = new double[] { 56875, 20210, 30045, 25488 }, Label = "Обычный профиль клиента", FillColor = Colors.Green.WithAlpha(.5) },
                new() { Values = new double[] { 36781, 1514, 22214, 13332 }, Label = "Подозрительный профиль клиента", FillColor = Colors.Blue.WithAlpha(.5) },
            };

            // add radar data to the plot
            var radar = myPlot.Add.Radar(radarSeries);

            // customize radar axis labels (5 axes because each RadarSeries has 5 values)
            radar.Labels = new string[] { "Объем покупки", "Объем продажи", "Сумма покупок", "Сумма продаж" }
                .Select(s => new LabelStyle() { Text = s, Alignment = Alignment.MiddleCenter })
                .ToArray();

            myPlot.Axes.Frameless();
            myPlot.Axes.Margins(0.5, 0.5);
            myPlot.ShowLegend();
            myPlot.HideGrid();

        }
        {
            ScottPlot.Plot myPlot = this.Find<AvaPlot>("AvaPlot4").Plot;
            myPlot.Add.Palette = new ScottPlot.Palettes.Nord();
            double[] values = { 25114, 3811, 844, 11115 };

            var radialGaugePlot = myPlot.Add.RadialGaugePlot(values);
            radialGaugePlot.GaugeMode = ScottPlot.RadialGaugeMode.SingleGauge;
            radialGaugePlot.MaximumAngle = 180;
            radialGaugePlot.StartingAngle = 180;
            radialGaugePlot.Labels = new string[] { "Заявки-Покупка", "Заявки-Продажа", "Сделки-Покупка", "Сделки-Продажа" };
            myPlot.Axes.Frameless();
            myPlot.Axes.Margins(0.5, 0.5);
            myPlot.ShowLegend();
            myPlot.HideGrid();
        }

    }
}
