using System;
using System.Collections.Generic;

namespace CECS475.Assignment3 {
    class StockBroker {

        private String brokerName;
        private List<Stock> stocks;
        private readonly object thisLock = new object();

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
            }
        }
    }
}
