using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment11
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines(@"IMDB-Movie-Data.csv")
                .Skip(1)
                .Select(line => new IMDBData(line));
            Console.WriteLine($"The film with highest metascore : {data.GetHighestMetascore().Title}");

            // If necessary, you can use more than one extension method to calculate these answers.
            Console.WriteLine($"Under 100 movies distinct geners : {data.Under100Minutesgeners()}");
            Console.WriteLine($"Films that have been directed by Vin Diesel : {data.VinDieselFilms()}");
            Console.WriteLine($"The movie with the most votes in 2016: {data. MaxRated()}");
            Console.WriteLine($"Bryan Singer films with their revenue : {data.BryanSingerFilms()}");
            Console.WriteLine($"Total sales of all films released in 2016 : {data.TotalSalesOfAllFilmsReleasedIn2016()}");
            Console.WriteLine($"10 of the best-selling action movies that are longer than two hours : {data.TenMostVotedActionFilms()}");
            Console.WriteLine($"Movies that have a number in their name : {data.MoviesThatHaveNumbersInTheirName()}");
            Console.WriteLine($"Jennifer Lawrence And Anne Hathaway : {data.JenniferLawrenceAndAnneHathaway()}");
            Console.WriteLine($"Drama and comedy rating: {data.DramaAndComedyRating()}");
            Console.WriteLine($"Worst actor : {data.BadActor()}");

        }
    }

    public static class Extensions
    {
        public static Nullable<int> ParseIntOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? int.Parse(str) as Nullable<int> : null;
        public static string ParseStringOrNull(this string str)
            => !string.IsNullOrEmpty(str) ? str : null;

        //For example
        public static IMDBData GetHighestMetascore(this IEnumerable<IMDBData> data)
            => data.OrderByDescending(x => x.Metascore).First();

        /// <summary>
        /// you must modify the name of this method and its 
        /// implementation to fit your need and create more methods like this
        /// 
        // Q1 :
        public static string Under100Minutesgeners(this IEnumerable<IMDBData> data)
        {
            string output = "";
            string[] geners ;
            geners = data.Where(x => x.Runtime < 100).Select(x => x.Genre).Distinct().ToArray();
            for(int i=0; i<geners.Length; i++)
            {
                output += geners[i] + " , ";
            }
            output = output.Remove(output.Length - 2);
            return output;
        }

        // Q2 :
        public static string VinDieselFilms(this IEnumerable<IMDBData> data)
        {
            string output = "";
            string[] titles;
            titles = data.Where(x => x.Actor1.Contains("Vin Diesel") || x.Actor2.Contains("Vin Diesel") || x.Actor3.Contains("Vin Diesel") || x.Actor4.Contains("Vin Diesel")).Select(x => x.Director).ToArray();
            for (int i = 0; i < titles.Length; i++)
            {
                output += titles[i] + " , ";
            }
            output = output.Remove(output.Length - 2);
            return output;
        }

        // Q3 :
        public static string MaxRated(this IEnumerable<IMDBData> data)
        {
            string output ;
            IMDBData key ;
            key = data.Where(x => x.Year == 2016).OrderByDescending(x => x.Votes).First();
            output = $"Rank : {key.Rank} , Title : {key.Title} , Genre : {key.Genre} , Director : {key.Director} , Actor1 : {key.Actor1}" +
                $" Actor2 : {key.Actor2} , Actor3 : {key.Actor3} , Actor4 : {key.Actor4} , Year : {key.Year} , Runtime : {key.Runtime}" +
                $"Rating : {key.Rating} , Votese : {key.Votes} , Revenue : {key.Revenue} , Metascore : {key.Metascore}";
            return output;
        }

        // Q4 :
        public static string BryanSingerFilms(this IEnumerable<IMDBData> data)
        {
            string output = "";
            string[] salesAmount = data.Where(x => x.Director == "Bryan Singer").OrderByDescending(x => x.Revenue).Select(x => x.Revenue).ToArray();
            string[] title = data.Where(x => x.Director == "Bryan Singer").OrderByDescending(x => x.Revenue).Select(x => x.Title).ToArray();
            for(int i=0; i<salesAmount.Length; i++)
            {
                output += salesAmount[i] + " " + title[i] + " , ";
            }
            output = output.Remove(output.Length - 2);
            return output;
        }

        // Q5 :
        public static double TotalSalesOfAllFilmsReleasedIn2016(this IEnumerable<IMDBData> data)
        {
            double total = 0.00;
            string[] sales = data.Where(x => x.Year == 2011).Select(x => x.Revenue).ToArray();
            for(int i =0; i<sales.Length; i++)
            {
                total += double.Parse(sales[i]);
            }
            return total;
        }

        // Q6 :
        public static string TenMostVotedActionFilms(this IEnumerable<IMDBData> data)
        {
            string output = "";
            string[] Action = data.Where(x => x.Genre == "Action" && x.Runtime > 120).OrderBy(x => x.Revenue).Select(x => x.Title).ToArray();
            for (int i = 0; i < 10; i++)
            {
                output += Action[i] + " , ";
            }
            output = output.Remove(output.Length - 2);
            return output;
        }

        // Q7 :
        public static string MoviesThatHaveNumbersInTheirName(this IEnumerable<IMDBData> data)
        {
            string output = "";
            string[] numbers = data.Where(x => x.Title.Contains('0') || x.Title.Contains('1') || x.Title.Contains('2') ||
            x.Title.Contains('3') || x.Title.Contains('4') || x.Title.Contains('5') || x.Title.Contains('6') || x.Title.Contains('7') ||
            x.Title.Contains('8') || x.Title.Contains('8')).Select(x => x.Title).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                output += numbers[i] + " , ";
            }
            output = output.Remove(output.Length - 2);
            return output;
        }

        //Q8 :
        public static string JenniferLawrenceAndAnneHathaway(this IEnumerable<IMDBData> data)
        {
            string output1= "Jennifer Lawrence : ", output2= "Anne Hathaway : ";
            string[] Jennifer = data.Where(x => x.Actor1.Contains("Jennifer Lawrence") || x.Actor2.Contains("Jennifer Lawrence")
            || x.Actor3.Contains("Jennifer Lawrence") || x.Actor4.Contains("Jennifer Lawrence")).OrderBy(x => x.Year).ThenByDescending(x => x.Rating)
            .Select(x => x.Title).ToArray();
            string[] Anne = data.Where(x => x.Actor1.Contains("Anne Hathaway") || x.Actor2.Contains("Anne Hathaway")
            || x.Actor3.Contains("Anne Hathaway") || x.Actor4.Contains("Anne Hathaway")).OrderBy(x => x.Year).OrderByDescending(x => x.Rating)
            .Select(x => x.Title).ToArray();
            for (int i = 0; i < Jennifer.Length; i++)
            {
                output1 += Jennifer[i] + " , ";
            }
            output1 = output1.Remove(output1.Length - 2);
            for (int i = 0; i < Anne.Length; i++)
            {
                output2 += Anne[i] + " , ";
            }
            output2 = output2.Remove(output2.Length - 2);
            return "\n" + output1 + "\n" + output2;
        }

        // Q9 :
        public static string DramaAndComedyRating(this IEnumerable<IMDBData> data)
        {
            double total1 = 0.00, total2 = 0.00;
            string[] drama = data.Where(x => x.Genre == "Drama").Select(x => x.Rating).ToArray();
            for (int i = 0; i < drama.Length; i++)
            {
                total1 += double.Parse(drama[i]);
            }
            string[] comedy = data.Where(x => x.Genre == "Comedy").Select(x => x.Rating).ToArray();
            for (int i = 0; i < comedy.Length; i++)
            {
                total2 += double.Parse(comedy[i]);
            }
            return $"Drama rating : {total1} , Comedy rating : {total2}";
        }

        // Q10 :
        public static string BadActor(this IEnumerable<IMDBData> data)
        {
            int k = 0 , count1 = 0 , count2 = 0;
            string[] actor = new string[900] ;
            string[] allRates = data.Select(x => x.Rating).ToArray();
            for(int i=0; i<allRates.Length; i++)
            {
                if(double.Parse(allRates[i]) < 7.0)
                {
                    actor[k] = data.Where(x => x.Rating == allRates[i]).Select(x => x.Actor1).ToString();
                    k++;
                    actor[k] = data.Where(x => x.Rating == allRates[i]).Select(x => x.Actor2).ToString();
                    k++;
                    actor[k] = data.Where(x => x.Rating == allRates[i]).Select(x => x.Actor3).ToString();
                    k++;
                    actor[k] = data.Where(x => x.Rating == allRates[i]).Select(x => x.Actor4).ToString();
                    k++;
                }
            }
            string bad = actor[0];
            for(int i=1; i< actor.Length; i++)
            {
                for(int j=0; j< actor.Length; j++)
                {
                    if(bad == actor[i])
                    {
                        count1++;
                    }
                }
                if (count1 > count2)
                {
                    bad = actor[i];
                    count2 = count1;
                }
            }
            return bad;
        }
        public static IMDBData ExtensionMethodPlaceHolder(this IEnumerable<IMDBData> data)
            => data.First();

    }



    public class IMDBData
    {
        public IMDBData(string line)
        {
            var toks = line.Split(',');
            Rank = int.Parse(toks[0]);
            Title = toks[1];
            Genre = toks[2];
            Director = toks[3];
            Actor1 = toks[4];
            Actor2 = toks[5];
            Actor3 = toks[6];
            Actor4 = toks[7];
            Year = int.Parse(toks[8]);
            Runtime = int.Parse(toks[9]);
            Rating = (toks[10]);
            Votes = int.Parse(toks[11]);
            Revenue = toks[12].ParseStringOrNull();
            Metascore = toks[13].ParseIntOrNull();
        }
        public int Rank;
        public string Title;
        public string Genre;
        public string Director;
        public string Actor1;
        public string Actor2;
        public string Actor3;
        public string Actor4;
        public int Year;
        public int Runtime;
        public string Rating;
        public int Votes;
        public string Revenue;
        public Nullable<int> Metascore;
    }
}
