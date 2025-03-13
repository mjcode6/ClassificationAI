using Microsoft.ML;
using Microsoft.ML.Data;

namespace Classification{
    public class MovieReview{
        [LoadColumn(0)]
        public string ?text {get;set;}
        [LoadColumn(1)]
        [ColumnName("Label")]
        public bool sentiment {get;set;}

    }

    public class Program{
        public static void Main(string[] args){
            MLContext mlContext = new MLContext();

            string dataPath = @"C:\Users\mjsiv\Desktop\SentimentAnalyisClassification\SentimentAnalyisClassification\Train.csv";
;
            string text = File.ReadAllText(dataPath);

            using(StreamReader sr = new StreamReader(dataPath)){
               text = text.Replace("\'", "");
            }
            File.WriteAllText(dataPath, text);

            IDataView dataView = mlContext.Data.LoadFromTextFile<MovieReview>(dataPath, hasHeader: true, allowQuoting: true, separatorChar:',');
           Console.WriteLine("Data Loaded succesefully...");
           Console.WriteLine("");

           var preview = dataView.Preview();
           foreach(var row in preview.RowView){
            Console.WriteLine($"{row.Values[0]} | {row.Values[1]}");
           }
        }
    }
}