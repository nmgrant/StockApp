using System.IO;

namespace CECS475.Assignment3 {
   class StreamWriterClass {

      // A lock object used to ensure only one thread writes
      // to the file at any given time
      private static readonly object thisLock = new object();

      // Event handler used to write event information to a file
      // when a stock's threshold is reached
      public static void WriteToFile(object sender,
         StockToFileEventArgs e) {
         // Get the directory that holds the file to write to
         string currentDirectory = Path.GetDirectoryName(
            Path.GetDirectoryName(Directory.GetCurrentDirectory()));

         // Using a lock ensures only one thread writes to the file
         // at any given time
         lock (thisLock) {

            // Use a streamwriter to write the stock event data
            // to the StockFile text file
            using (StreamWriter sw = new StreamWriter(@currentDirectory
               + "StockFile.txt", true)) {
               sw.WriteLine(e.DateTime.ToString().PadRight(25)
                  + e.Name.PadRight(15)
                  + e.CurrentValue.ToString().PadRight(10)
                  + e.InitialValue.ToString().PadRight(10));
               sw.Close();
            }
         }
      }
   }
}
