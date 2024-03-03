using TextRpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextRpg
{
    class Program
    {
        public static Random rand = new Random();
        public static bool newPlayer = true;
        public static bool mainGamePlay = false;
        public static Player currentPlayer = new Player();
        public static string filePath = Environment.CurrentDirectory + @"\" + "Save.json";
        static void Main()
        {
            if (File.Exists(filePath))
            {
                currentPlayer = LoadPlayer();
                mainGamePlay = true;
            }
            else
            {
                while (newPlayer)
                {
                    string? name;
                    Console.WriteLine("Enter your name: ");
                    name = Console.ReadLine();
                    currentPlayer.init();
                    currentPlayer.name = name!;
                    SavePlayer();
                    newPlayer = false;
                    mainGamePlay = true;
                }
            }
            while (mainGamePlay)
            {
                Encounter.GetRandEncounter();
            }
        }

        public static Player StartNewPlayer()
        {
            Player p = new Player();
            p.init();

            return p;
        }

        public static void SavePlayer()
        {
            string json = JsonSerializer.Serialize(currentPlayer);
            File.WriteAllText(filePath, json);
        }

        public static Player LoadPlayer()
        {
            string loadedJson = File.ReadAllText(filePath);
            Console.WriteLine(loadedJson);
            Player? loadedPlayer = JsonSerializer.Deserialize<Player>(loadedJson);
            return loadedPlayer!;
        }

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < dif)
                    Console.Write(fillerChar);
                else
                    Console.Write(backgroundChar);
            }
        }
    }
}