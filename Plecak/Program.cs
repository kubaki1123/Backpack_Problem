using System;
using Plecak;

main();


void main()
{

    
    Read_file input_file = new Read_file();
    
    List<Data> data = new List<Data>();

    data = input_file.read();

    foreach (Data data_item in data)
    {
        Console.WriteLine($"{data_item.przedmiot} {data_item.waga} {data_item.punkty}");
    }
    


}



