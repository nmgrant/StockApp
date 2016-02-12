using System;
using System.Collections.Generic;

namespace CECS475.Assignment3 {
   class StockBroker {

      private String brokerName;
      private List<Stock> stocks;
      private readonly object thisLock = new object();
      private const int MAX_STOCK_COUNTER = 20;
      private int printCounter = 0;

      public StockBroker(String name) {
         this.brokerName = name;
         stocks = new List<Stock>();
      }

      public void AddStock(Stock stock) {
         stock.stockEvent += stockThresholdReached;
         stock.stockToFileEvent += StreamWriterClass.WriteToFile;
         stocks.Add(stock);
      }

      public void stockThresholdReached(object sender,
         StockNotificationEventArgs e) {
         lock (thisLock) {
            Console.WriteLine(brokerName.PadRight(20) + e.Name.PadRight(20)
            + e.CurrentValue.ToString().PadRight(15)
            + e.NumberOfChanges.ToString().PadRight(15));

            printCounter++;

            if (printCounter == MAX_STOCK_COUNTER) {
               if (userContinuePrintOut()) {
                  Environment.Exit(0);
               }
               printCounter = 0;
            }
         }
      }

      public bool userContinuePrintOut() {
         Console.WriteLine("\nWould you like to view more threads? Y/N\n");
         while (true) {
            string userInput = Console.ReadLine();
            if (userInput.Equals("Y") || userInput.Equals("y")) {
               return false;
            } else if (userInput.Equals("N") || userInput.Equals("n")) {
               return true;
            } else {
               Console.WriteLine("Invalid input was entered.");
            }
         }
      }
   }
}
