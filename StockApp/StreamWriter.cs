using System.IO;

namespace CECS475.Assignment3 {
    class StreamWriterClass {
        public static void WriteToFile(object sender,
            StockToFileEventArgs e) {
            lock (sender) {
                using (StreamWriter sw = new StreamWriter("StockFile.txt")) {
                    sw.WriteLine(e.DateTime.ToString().PadRight(15)
                        + e.Name.PadRight(20)
                        + e.CurrentValue.ToString().PadRight(15)
                        + e.InitialValue.ToString().PadRight(15));
                    sw.Close();
                }
            }
        }
    }
}
