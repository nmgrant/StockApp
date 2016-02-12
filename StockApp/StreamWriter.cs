﻿using System.IO;

namespace CECS475.Assignment3 {
   class StreamWriterClass {
      private static readonly object thisLock = new object();

      public static void WriteToFile(object sender,
         StockToFileEventArgs e) {
         string currentDirectory = Path.GetDirectoryName(
            Path.GetDirectoryName(Directory.GetCurrentDirectory()));
         lock (thisLock) {
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
