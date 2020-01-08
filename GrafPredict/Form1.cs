using Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GrafPredict
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IDictionary<string, double> data = new Dictionary<string, double>();
        private void button1_Click(object sender, EventArgs e)
        {

            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = @"C:\Users\pogon\AppData\Roaming\MetaQuotes\Terminal\D0E8209F77C8CF37AD8BF550E51FF075\MQL5\Files";
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var csv = File.ReadAllText(filePath);
                    foreach (var line in CsvReader.ReadFromText(csv))
                    {
                        try
                        {
                            data.Add(line["TimeFrame"], float.Parse(line["Value"]));
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильные данные", "Ошибка ", MessageBoxButtons.OK);
                            return;
                        }

                    }
                    DrawChat();
                    string fd = string.Empty;
                    foreach (var item in data)
                    {
                        fd +=" "+ item.Key + "     " + Math.Round(item.Value,5).ToString()+ Environment.NewLine;
                    }
                    
                    txtBox.Text= fd;
                }
            }


        }

        private void DrawChat()
        {
            // chart.ChartAreas.Add(new ChartArea("Предсказанная цена"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.

            this.chart.ChartAreas[0].AxisY.Minimum = data.Min(n => n.Value);
            this.chart.ChartAreas[0].AxisY.Maximum = data.Max(n => n.Value);
         

            this.chart.ChartAreas[0].AxisX.Interval = 1;
            for (int i = 0; i < data.Count; i++)
            {
                //  mySeriesOfPoint.Points.AddXY(i, data.ElementAt(i).Value);
                this.chart.Series[0].Points.AddXY(data.ElementAt(i).Key, data.ElementAt(i).Value);
            }
            //Добавляем созданный набор точек в Chart
            // this.chart.Series.Add(mySeriesOfPoint);
            //chart.Series.Add(mySeriesOfPoint);
        }
    }
}
