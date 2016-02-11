using System;
using System.Collections.Generic;

namespace CECS475.Assignment3 {
    class StockBroker {

        private String brokerName;
        private List<Stock> stocks;

        public StockBroker(String name) {
            this.brokerName = name;
            stocks = new List<Stock>();
        }

        public string BrokerName { get; set; }

        public void AddStock(Stock stock) {
            stock.stockEvent += StreamWriterClass.WriteToFile;
            stock.stockEvent += stockThresholdReached;
            stocks.Add(stock);
        }

        public void stockThresholdReached(object sender, 
            StockNotificationEventArgs e) {
            Console.WriteLine(brokerName.PadRight(20) + e.Name.PadRight(20) 
                + e.CurrentValue.ToString().PadRight(15) 
                + e.NumberOfChanges.ToString().PadRight(15));
        }

        public override string ToString() {
            return brokerName;
        }
    }
}
