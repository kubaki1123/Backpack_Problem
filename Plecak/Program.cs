using System;
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

    algorytm.create_generation(Waga_plecaka, generacje);   

}



