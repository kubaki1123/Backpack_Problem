using System;
using System.Runtime.InteropServices;
using Plecak;

main();


void main()
{

    
    Read_file input_file = new Read_file();
    
    List<Data> data = new List<Data>();

    data = input_file.read();

    Console.WriteLine("podaj maksymalna wage zeczy w plecaku");

    double Waga_plecaka = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("podaj ilosc generacji algorytmu");
    
    int generacje = Convert.ToInt32(Console.ReadLine());

    Algorytm algorytm = new Algorytm();

    int[,] item_list = new int[10, data.Count()];

    item_list = algorytm.create_generation(data);

    Dictionary<string, int> evaluated_list = new Dictionary<string, int>();

    evaluated_list = algorytm.evaluate(item_list, Waga_plecaka, data);

    foreach (var para in evaluated_list) {
        Console.WriteLine($"Plecak: {para.Key} -> pukty {para.Value}");
    }
    

}



