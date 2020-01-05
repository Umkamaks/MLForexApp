using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using TestTaxiFareML.Model;

namespace TestTaxiFare
{
    class Program
    {
        //Dataset to use for predictions 
        private const string DATA_FILEPATH = @"C:\Users\Umkamaks\AppData\Roaming\MetaQuotes\Terminal\36A64B8C79A6163D85E6173B54096685\MQL5\Files\LastData.csv";

        static void Main(string[] args)
        {
            IEnumerable<ModelInput> sampleDataList = CreateSingleDataSample(DATA_FILEPATH);
            ICollection<float> resultList = new List<float>();
            // Create single instance of sample data from first line of dataset for model input
            // ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);
            for (int i = 0; i < sampleDataList.Count(); i++)
            {
                ModelOutput predictionResult = ConsumeModel.Predict(sampleDataList.ElementAt(i));
                resultList.Add(predictionResult.Score);

            }
            for (int i = 1; i < sampleDataList.Count(); i++)
            {
                Console.WriteLine($"Actual CLOSE: {sampleDataList.ElementAt(i).CLOSE} \nPredicted CLOSE: {resultList.ElementAt(i)}");
                Console.WriteLine($"Actual CLOSE: {sampleDataList.ElementAt(i ).CLOSE - sampleDataList.ElementAt(i - 1).CLOSE}");
                Console.WriteLine($"Predict CLOSE: {resultList.ElementAt(i ) - resultList.ElementAt(i - 1)}\n");
            }
            //foreach (var sampleData in sampleDataList)
            //{
            //    // Make a single prediction on the sample data and print results
            //    ModelOutput predictionResult = ConsumeModel.Predict(sampleData);

            //    //Console.WriteLine("Using model to make single prediction -- Comparing actual CLOSE with predicted CLOSE from sample data...\n\n");
            //    //Console.WriteLine($"DATE: {sampleData.DATE}");
            //    //Console.WriteLine($"TIME: {sampleData.TIME}");
            //    //Console.WriteLine($"MA: {sampleData.MA}");
            //    //Console.WriteLine($"RSI: {sampleData.RSI}");
            //    //Console.WriteLine($"Volumes: {sampleData.Volumes}");
            //    Console.WriteLine($"\nActual CLOSE: {sampleData.CLOSE} \nPredicted CLOSE: {predictionResult.Score}\n");
            //    Console.WriteLine($"{sampleData.CLOSE}");
            //    //   Console.WriteLine("=============== End of process, hit any key to finish ===============");

            //}
            Console.ReadKey();
        }

        // Change this code to create your own sample data
        #region CreateSingleDataSample
        // Method to load single row of dataset to try a single prediction
        private static IEnumerable<ModelInput> CreateSingleDataSample(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            IEnumerable<ModelInput> sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false);

            //ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
            //                                                            .First();
            return sampleForPrediction;
        }
        #endregion
    }

}
