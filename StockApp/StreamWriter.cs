using System.IO;

namespace CECS475.Assignment3 {
    class StreamWriterClass {
        public static void WriteToFile(object sender,
            StockNotificationEventArgs e) {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Evan\Documents\Visual Studio 2015\Projects\CECS475.Assignment3\StockApp\StockFile.txt")) {

                sw.WriteLine();
                sw.Close();
            }
        }
    }
}
