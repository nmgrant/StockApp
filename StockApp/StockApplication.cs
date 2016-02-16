namespace CECS475.Assignment3 {
    class StockApplication {
        static void Main(string[] args) {
            // Initialize four stocks with varying values
            Stock stock1 = new Stock("Technology", 160, 5, 15);
            Stock stock2 = new Stock("Retail", 30, 2, 6);
            Stock stock3 = new Stock("Banking", 90, 4, 10);
            Stock stock4 = new Stock("Commodity", 500, 20, 50);

            // Create Broker 1 and add two stocks to Broker 1
            StockBroker b1 = new StockBroker("Broker 1");
            b1.AddStock(stock1);
            b1.AddStock(stock2);

            // Create Broker 2 and add three stocks to Broker 2
            StockBroker b2 = new StockBroker("Broker 2");
            b2.AddStock(stock1);
            b2.AddStock(stock3);
            b2.AddStock(stock4);

            // Create Broker 3 and add two stocks to Broker 3
            StockBroker b3 = new StockBroker("Broker 3");
            b3.AddStock(stock1);
            b3.AddStock(stock3);

            // Create Broker 4 and add four stocks to Broker 4
            StockBroker b4 = new StockBroker("Broker 4");
            b4.AddStock(stock1);
            b4.AddStock(stock2);
            b4.AddStock(stock3);
            b4.AddStock(stock4);

            // Write to console for formatting purposes
            System.Console.WriteLine("Broker".PadRight(20)
               + "Stock".PadRight(20) + "Value".PadRight(15)
               + "Changes".PadRight(15) + "\n");
        }
    }
}
