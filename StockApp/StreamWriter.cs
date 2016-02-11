using System.IO;

namespace CECS475.Assignment3 {
    class StreamWriterClass {
        private static readonly object thisLock = new object();

        public static void WriteToFile(object sender,
            StockToFileEventArgs e) {
            lock (thisLock) {
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Evan\Documents\Visual Studio 2015\Projects\CECS475.Assignment3\StockApp\StockFile.txt", true)) {
                    sw.WriteLine(e.DateTime.ToString().PadRight(20)
                        + e.Name.PadRight(20)
                        + e.CurrentValue.ToString().PadRight(15)
                        + e.InitialValue.ToString().PadRight(15));
                    sw.Close();
                }
            }
        }
    }
}
