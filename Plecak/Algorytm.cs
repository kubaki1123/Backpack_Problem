using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;



namespace Plecak
{
    internal class Algorytm
    {
        public int[,] create_generation(List<Data> data)
        {
           int[,] item_list = new int[10,data.Count()];
           Random random = new Random();
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < data.Count(); i++)
                {
                    
                    item_list[j,i] = random.Next(0, 2);

                }
                
                
            }
            return item_list;
        }
    
        public Dictionary<string,int> evaluate(int[,] lista_plecakow,double max_waga,List<Data> data)
        {

            Dictionary<string, int> slownik_generacji = new Dictionary<string, int>();
            

            for (int j = 0; j < lista_plecakow.GetLength(0); j++)
            {
                int[] plecak = new int[data.Count()];
                double total_waga = 0;
                int total_punkty = 0;
                for (int i = 0; i < data.Count(); i++)
                {
                    plecak[i] = lista_plecakow[j, i];

                    if (plecak[i] == 1)
                    {
                        total_waga += data[i].waga;
                        total_punkty += data[i].punkty;
                    }
                }

                
                if (total_waga > max_waga)
                {
                    total_punkty = 0;
                }

                string klucz = string.Join(",", plecak);

                try
                {
                    slownik_generacji.Add(klucz, total_punkty);
                }
                catch(System.ArgumentException) {
                    continue;

                }
            }


            return slownik_generacji;
        }


    }
}
