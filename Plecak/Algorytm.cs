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


        public string[] select_the_best(Dictionary<string, int> slownik_plecakow_punktow)
        {
            
            string[] prime_specimen = slownik_plecakow_punktow.OrderByDescending(para => para.Value).Select(para => para.Key).Take(5).ToArray();                            

            return prime_specimen;

        }

        string crossover(string[] best_specimen)
        {
            Random random = new Random();
            string[] best_specimen_no_comas = new string[best_specimen.Length];
            for (int i = 0; i < best_specimen.Length; i++)
            {
                best_specimen_no_comas[i] = best_specimen[i].Replace(",", "");
            }

            string[] crossovered = new string[10];
            string word = "";

            string[] chosen_specimen = new string[2];
            for (int i = 0; i < 2; i++)
            {
                chosen_specimen[i] = best_specimen_no_comas[random.Next(0, best_specimen_no_comas.Length)];
            }


            for (int i = 0; i < chosen_specimen.Length - 1; i++)
            {
                for (int j = 0; j < chosen_specimen[i].Length; j++)
                {

                    if (chosen_specimen[i][j] == chosen_specimen[i + 1][j])
                    {
                        word = word + chosen_specimen[i][j];
                    }
                    else
                    {
                        word = word + Convert.ToString(random.Next(0, 2));
                    }

                    
                }

            }
            return word;

        }

        public int[,] crossoverAndBuild(List<Data> data, string[] best_specimen)
        {
            int[,] next_gen = new int[10, data.Count];
            string word;
            for (int i = 0; i < 10; i++){
                word = crossover(best_specimen);
                
                for (int j = 0;j < word.Length; j++)
                {
                    next_gen[i,j] = Convert.ToInt32(Convert.ToString(word[j]));
                }
            }

            return next_gen;
        }
    }

}
