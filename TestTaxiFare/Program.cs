using Csv;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestTaxiFareML.ConsoleApp;
using TestTaxiFareML.Model;

namespace TestTaxiFare
{
    class Program
    {
        //Dataset to use for predictions 
        private const string DATA_FILE_DIRECTORY = @"C:\Users\pogon\AppData\Roaming\MetaQuotes\Terminal\D0E8209F77C8CF37AD8BF550E51FF075\MQL5\Files\";
        private const string DATA_FILEPATH_LAST5min = DATA_FILE_DIRECTORY+ "Last5minExport.csv";
        private const string DATA_FILEPATH_LAST10min = DATA_FILE_DIRECTORY + "Last10minExport.csv";
        private const string DATA_FILEPATH_LAST20min = DATA_FILE_DIRECTORY + "Last20minExport.csv";
        private const string DATA_FILEPATH_LAST30min = DATA_FILE_DIRECTORY + "Last30minExport.csv";
        private const string DATA_FILEPATH_LAST1H = DATA_FILE_DIRECTORY + "Last1Hexport.csv";
        private const string DATA_FILEPATH_LAST2H = DATA_FILE_DIRECTORY + "Last2Hexport.csv";
        private const string DATA_FILEPATH_LAST3H = DATA_FILE_DIRECTORY + "Last3Hexport.csv";
        private const string DATA_FILEPATH_LAST4H = DATA_FILE_DIRECTORY + "Last4Hexport.csv";
        private const string DATA_FILEPATH_LAST6H = DATA_FILE_DIRECTORY + "Last6Hexport.csv";
        private const string DATA_FILEPATH_LAST8H = DATA_FILE_DIRECTORY + "Last8Hexport.csv";
        private const string DATA_FILEPATH_LAST12H = DATA_FILE_DIRECTORY + "Last12Hexport.csv";


        private const string DATA_FILE_DATASET_5min = DATA_FILE_DIRECTORY + "mt5minExport.csv";
        private const string DATA_FILE_DATASET_10min = DATA_FILE_DIRECTORY + "mt10minExport.csv";
        private const string DATA_FILE_DATASET_20min = DATA_FILE_DIRECTORY + "mt20minExport.csv";
        private const string DATA_FILE_DATASET_30min = DATA_FILE_DIRECTORY + "mt30minExport.csv";
        private const string DATA_FILE_DATASET_1H = DATA_FILE_DIRECTORY + "mt1Hexport.csv";
        private const string DATA_FILE_DATASET_2H = DATA_FILE_DIRECTORY + "mt2Hexport.csv";
        private const string DATA_FILE_DATASET_3H = DATA_FILE_DIRECTORY + "mt3Hexport.csv";
        private const string DATA_FILE_DATASET_4H = DATA_FILE_DIRECTORY + "mt4Hexport.csv";
        private const string DATA_FILE_DATASET_6H = DATA_FILE_DIRECTORY + "mt6Hexport.csv";
        private const string DATA_FILE_DATASET_8H = DATA_FILE_DIRECTORY + "mt8Hexport.csv";
        private const string DATA_FILE_DATASET_12H = DATA_FILE_DIRECTORY + "mt12Hexport.csv";


        private const string PATH_MODEL5m = DATA_FILE_DIRECTORY + "MLModel5m.zip";
        private const string PATH_MODEL10m = DATA_FILE_DIRECTORY + "MLModel10m.zip";
        private const string PATH_MODEL20m = DATA_FILE_DIRECTORY + "MLModel20m.zip";
        private const string PATH_MODEL30m = DATA_FILE_DIRECTORY + "MLModel30m.zip";
        private const string PATH_MODEL1H = DATA_FILE_DIRECTORY + "MLModel1H.zip";
        private const string PATH_MODEL2H = DATA_FILE_DIRECTORY + "MLModel2H.zip";
        private const string PATH_MODEL3H = DATA_FILE_DIRECTORY + "MLModel3H.zip";
        private const string PATH_MODEL4H = DATA_FILE_DIRECTORY + "MLModel4H.zip";
        private const string PATH_MODEL6H = DATA_FILE_DIRECTORY + "MLMode6H.zip";
        private const string PATH_MODEL8H = DATA_FILE_DIRECTORY + "MLModel8H.zip";
        private const string PATH_MODEL12H = DATA_FILE_DIRECTORY + "MLModel12H.zip";
        private const string PATH_RESULT = DATA_FILE_DIRECTORY + "Result.csv";
        static void Main(string[] args)
        {
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_5min, PATH_MODEL5m);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_10min, PATH_MODEL10m);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_20min, PATH_MODEL20m);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_30min, PATH_MODEL30m);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_1H, PATH_MODEL1H);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_2H, PATH_MODEL2H);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_3H, PATH_MODEL3H);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_4H, PATH_MODEL4H);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_6H, PATH_MODEL6H);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_8H, PATH_MODEL8H);
            //ModelBuilder.CreateModel(DATA_FILE_DATASET_12H, PATH_MODEL12H);

            ICollection<ModelOutput> ListResult = new List<ModelOutput>();
            IDictionary<string, float> resultDic = new Dictionary<string, float>();
            ModelInput sampleDataList5m = CreateSingleDataSample(DATA_FILEPATH_LAST5min).FirstOrDefault();
            ModelInput sampleDataList10m = CreateSingleDataSample(DATA_FILEPATH_LAST10min).FirstOrDefault();
            ModelInput sampleDataList20m = CreateSingleDataSample(DATA_FILEPATH_LAST20min).FirstOrDefault();
            ModelInput sampleDataList30m = CreateSingleDataSample(DATA_FILEPATH_LAST30min).FirstOrDefault();
            ModelInput sampleDataList1h = CreateSingleDataSample(DATA_FILEPATH_LAST1H).FirstOrDefault();
            ModelInput sampleDataList2h = CreateSingleDataSample(DATA_FILEPATH_LAST2H).FirstOrDefault();
            ModelInput sampleDataList3h = CreateSingleDataSample(DATA_FILEPATH_LAST3H).FirstOrDefault();
            ModelInput sampleDataList4h = CreateSingleDataSample(DATA_FILEPATH_LAST4H).FirstOrDefault();
            ModelInput sampleDataList6h = CreateSingleDataSample(DATA_FILEPATH_LAST6H).FirstOrDefault();
            ModelInput sampleDataList8h = CreateSingleDataSample(DATA_FILEPATH_LAST8H).FirstOrDefault();
            ModelInput sampleDataList12h = CreateSingleDataSample(DATA_FILEPATH_LAST12H).FirstOrDefault();


            ModelOutput predictionResult5m = ConsumeModel.Predict(sampleDataList5m, PATH_MODEL5m);
            ModelOutput predictionResult10m = ConsumeModel.Predict(sampleDataList10m, PATH_MODEL10m);
            ModelOutput predictionResult20m = ConsumeModel.Predict(sampleDataList20m, PATH_MODEL20m);
            ModelOutput predictionResult30m = ConsumeModel.Predict(sampleDataList30m, PATH_MODEL30m);
            ModelOutput predictionResult1h = ConsumeModel.Predict(sampleDataList1h, PATH_MODEL1H);
            ModelOutput predictionResult2h = ConsumeModel.Predict(sampleDataList2h, PATH_MODEL2H);
            ModelOutput predictionResult3h = ConsumeModel.Predict(sampleDataList3h, PATH_MODEL3H);
            ModelOutput predictionResult4h = ConsumeModel.Predict(sampleDataList4h, PATH_MODEL4H);
            ModelOutput predictionResult6h = ConsumeModel.Predict(sampleDataList6h, PATH_MODEL6H);
            ModelOutput predictionResult8h = ConsumeModel.Predict(sampleDataList8h, PATH_MODEL8H);
            ModelOutput predictionResult12h = ConsumeModel.Predict(sampleDataList12h, PATH_MODEL12H);

            resultDic.Add("5m", predictionResult5m.Score);
            resultDic.Add("10m", predictionResult10m.Score);
            resultDic.Add("20m", predictionResult20m.Score);
            resultDic.Add("30m", predictionResult30m.Score);
            resultDic.Add("1H", predictionResult1h.Score);
            resultDic.Add("2H", predictionResult2h.Score);
            resultDic.Add("3H", predictionResult3h.Score);
            resultDic.Add("4H", predictionResult4h.Score);
            resultDic.Add("6H", predictionResult6h.Score);
            resultDic.Add("8H", predictionResult8h.Score);
            resultDic.Add("12H", predictionResult12h.Score);

            ListResult.Add(predictionResult5m);
            ListResult.Add(predictionResult10m);
            ListResult.Add(predictionResult20m);
            ListResult.Add(predictionResult30m);
            ListResult.Add(predictionResult1h);
            ListResult.Add(predictionResult2h);
            ListResult.Add(predictionResult3h);
            ListResult.Add(predictionResult4h);
            ListResult.Add(predictionResult6h);
            ListResult.Add(predictionResult8h); 
            ListResult.Add(predictionResult12h);

            foreach (var item in resultDic)
            {
                Console.WriteLine($"Таймфрейм {item.Key} Прогнозированная цена {item.Value}");
            }

            var columnNames = new[] { "TimeFrame", "Value" };
            ICollection<string[]> rows = new List<string[]>();
            for (int i = 0; i < resultDic.Count; i++)
            {
                string[] mas = new[] { resultDic.ElementAt(i).Key.ToString(), resultDic.ElementAt(i).Value.ToString() };
                rows.Add(mas);
            }
         
  
            var csv = CsvWriter.WriteToText(columnNames, rows, ',');
            File.WriteAllText(PATH_RESULT, csv);

            //ICollection<float> resultList = new List<float>();
            //// Create single instance of sample data from first line of dataset for model input
            //// ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);
            //for (int i = 0; i < sampleDataList.Count(); i++)
            //{
            //    ModelOutput predictionResult = ConsumeModel.Predict(sampleDataList.ElementAt(i), PATH_MODEL5m);
            //    resultList.Add(predictionResult.Score);

            //}
            //for (int i = 1; i < sampleDataList.Count(); i++)
            //{
            //    Console.WriteLine($"Actual CLOSE: {sampleDataList.ElementAt(i).CLOSE} \nPredicted CLOSE: {resultList.ElementAt(i)}");
            //    Console.WriteLine($"Actual CLOSE: {sampleDataList.ElementAt(i ).CLOSE - sampleDataList.ElementAt(i - 1).CLOSE}");
            //    Console.WriteLine($"Predict CLOSE: {resultList.ElementAt(i ) - resultList.ElementAt(i - 1)}\n");
            //}
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
