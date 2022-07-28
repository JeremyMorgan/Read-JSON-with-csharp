using System.Text.Json;

Console.WriteLine("Hello, World!");

/*
{"id":9,
"first_name":"Marsh",
"last_name":"Rosberg",
"email":"mrosberg8@cnbc.com",
"ip_address":"236.249.196.93"
},
*/

var incoming = new List<Person>();

using (StreamReader r = new StreamReader("customers.json"))
{
    string json = r.ReadToEnd();
    incoming = JsonSerializer.Deserialize<List<Person>>(json);
}

/*
if (incoming != null && incoming.Count > 0){
    foreach (var customer in incoming){
        Console.WriteLine($"{customer.first_name} {customer.last_name}");
    }

    Console.WriteLine("There are {0} total records", incoming.Count);
}
*/

if (incoming != null && incoming.Count > 0){
    var jnames = incoming.Where(p => p.first_name.StartsWith("J"));
    foreach (var customer in jnames){
        Console.WriteLine($"{customer.first_name} {customer.last_name}");
    }
}

public record struct Person (
    int id,
    string first_name,
    string last_name,
    string email,
    string ip_address
);