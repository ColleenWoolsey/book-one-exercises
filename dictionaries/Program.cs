using System;
using System.Collections.Generic;

namespace dictionaries {

    class Program {
        private static object display;

        static void PrintDictionary(Dictionary<string, string> dict)
        {
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                Console.WriteLine($"key: {kvp.Key}, value: {kvp.Value}");
            }
        }

        static void planetPrinter(List<string> stringList){
            foreach(string item in stringList) {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args) {
            // Dictionary<KeyType, ValueType> Name = new Dictionary<KeyType, ValueType>();
            // The KeyType represents a type for our key in a collection. The ValueType
            // represents the value assigned to the key. So, we can extract our 
            // value from a collection by using the key inside the square brackets:       
            // DictionaryName[key];

            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");           
            stocks.Add("TOY", "Toyota");
            stocks.Add("LWS", "Lowes");

            foreach (KeyValuePair<string, string> kvp in stocks)
            {
                Console.WriteLine("***** Dictionary of stocks *****");
                Console.WriteLine($"key: {kvp.Key}, value: {kvp.Value}");
            }

            List<Dictionary<string, double>> purchases = new List<Dictionary<string, double>>();

            purchases.Add (new Dictionary<string, double>(){ {"GM", 230.21} });
            purchases.Add (new Dictionary<string, double>(){ {"GM", 580.98} });
            purchases.Add (new Dictionary<string, double>(){ {"GM", 406.34} });
            purchases.Add (new Dictionary<string, double>(){ {"CAT", 131.26} });
            purchases.Add (new Dictionary<string, double>(){ {"CAT", 282.95} });
            purchases.Add (new Dictionary<string, double>(){ {"TOY", 303.34} });
            purchases.Add (new Dictionary<string, double>(){ {"TOY", 434.23} });
            purchases.Add (new Dictionary<string, double>(){ {"LWS", 585.92} });
            purchases.Add (new Dictionary<string, double>(){ {"LWS", 606.31} });

    // Define a new Dictionary to hold the aggregated purchase information.
    // - The key should be a string that is the full company name.
    // - The value will be the total valuation of each stock
    Dictionary<string, double> stockReport = new Dictionary<string, double>();

    // From the three purchases above, one of the entries
    // in this new dictionary will be...
    //     {"General Electric", 1217.53}
    // Iterate over the purchases and record the valuation for each stock.
    
    foreach (Dictionary<string, double> purchase in purchases) {
    
        foreach (KeyValuePair<string, double> kvp in purchase) {
            
            // Declare a variable to hold the company name from the stocks Dictionary.
            // You have the value of "GE", so how can you look
            // the value of "GE" in the `stocks` dictionary
            // to get the value of "General Electric"?
           // Does the full company name key already exist in the `stockReport`?

            if (stockReport.ContainsKey(kvp.Key)) {

            // If it does, update the total valuation
            // We can extract our value from a collection by using the key inside the square brackets: DictionaryName[key];
                // double currentCost = stockReport[kvp.Key];
                // stockReport[kvp.Key] = currentCost + kvp.Value;

                // OR

                stockReport[kvp.Key] += kvp.Value;
        
            // If not, add the new key and set its value.
        
            } else {
                stockReport.Add($"{kvp.Key}", kvp.Value);
            }
        }
    }
        
    // Now that the report dictionary is populated, display the final results.

            foreach(KeyValuePair<string, double> item in stockReport)
            {
                Console.WriteLine($"The position in {item.Key} is worth {item.Value}");
            }

// *********************** Planets ***********************
// Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto

    List<string> planetList = new List<string>(){"Mercury", "Venus", "Earth", 
    "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto"};

    planetPrinter(planetList);

    List<Dictionary<string, string>> probes = new List<Dictionary<string, string>>();

    // List<Dictionary<string, string>> probes = new List<Dictionary<string, string>>() {
    //     new Dictionary<string, string>(){ {"Mercury", "probe16"} },
    //     new Dictionary<string, string>(){ {"Venus", "probe15"} }
    // }  ***** This is how Andy wrote it - Initializing with the date as opposed to adding

    probes.Add(new Dictionary<string, string>(){ 
        {"Mercury", "probe16"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Venus", "probe15"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Earth", "probe14"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Mars", "probe13"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Jupiter", "probe12"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Saturn", "probe11"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Uranus", "probe10"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Neptune", "probe9"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Pluto", "probe8"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Mercury", "probe7"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Venus", "probe6"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Earth", "probe5"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Mars", "probe4"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Jupiter", "probe3"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Saturn", "probe2"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Uranus", "probe1"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Neptune", "probe17"} });
    probes.Add(new Dictionary<string, string>(){ 
        {"Pluto", "probe18"} });

    foreach(string planet in planetList) {
                
        List<string> matchingProbes = new List<string>();

        foreach(Dictionary<string, string> probe in probes) {

        // Does the current Dictionary contain the key of
        // the current planet? If so, add the current spacecraft to `matchingProbes`.
        // Is the planet I'm currently looking at been visited by the probe - Does the dictionary
        // contain the key for that planet - Take the value of the key and add it to the list
        // We only want to get the values that match ourplanet

        //if the dictionary contains more than one key value pair with ie: Mars and Earth 
        // and I only want to reference one of them would chage the if statement to:

        // if (probe.ContainsKey(planet)) {
        //     string probeName = probe[planet];
        //     matchingProbes.Add(probe[probeName]);
        //     }


            if (probe.ContainsKey(planet)) {
                        matchingProbes.Add(probe[planet]);
            }
            
        }
        // Can break it into two steps by
        // string planetListString = string.Join(", ", matchingProbes);
        // Console.WriteLine ($"{"planet}: {planetListString});

        //This planet has been visited by these probes
        Console.WriteLine($"{planet} has been visited by these probes: {String.Join(", ", matchingProbes)}");   
    }   
        }   
    }
}


// Dictionary<string<List<DateTime>> mydict = new Dictionary<string, List<DateTime>>()
            // mydict.Add("Monday", newList<DateTime>());
            // mydict["Monday"].Add(DateTime.Now);
