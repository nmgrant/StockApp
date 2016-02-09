using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp {
    class Stock {

        private String name;
        private readonly int initialValue;
        private int currentValue;
        private int changeOfValue;
        private readonly int threshold;
        private readonly int maxChange;

        public Stock(String name, int initialValue, int maxChange, int threshold) {
            this.name = name;
            this.initialValue = initialValue;
            this.threshold = threshold;
            this.maxChange = maxChange;
            currentValue = initialValue;
            changeOfValue = 0;
            // Initializes a thread using a lambda expression as the run behavior
            Thread thread = new Thread(() => {
                for (int i = 0; i < 3; i ++) {
                    changeOfValue += new Random().Next(-maxChange, maxChange);
                    Console.WriteLine("{0} value before: {1} after: {2}", name, currentValue, currentValue += changeOfValue);
                    Thread.Sleep(500);
                }
            });
            thread.Start();
        }
    }
}
