using System;
using System.Collections.Generic;
using System.IO;

namespace BuggleSolver
{
    class Program
    {

       /* public void LoadJson()
        {
            using (StreamReader r = new StreamReader("words_dictionary.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
            }
        }
        */

        static int[] moveRow = { 0, 0, 1, 1, -1, 1, -1, -1 };
        static int[] moveCol = { 1, -1, -1, 1, 1, 0, 0, -1 };

        public static void findWord(char[,] board, bool[,] visited, int row, int col, string word, List<string> dictionnary)
        {
            //Console.WriteLine(word + " ------- (" + row + " , " + col + ") ");

            if (dictionnary.Contains(word))
            {
                Console.WriteLine(word);
            }

            for(int i = 0; i< moveRow.Length; i++)
            {
                int newRow = row + moveRow[i];
                int newCol = col + moveCol[i];
                if(isCoordValid(newRow, newCol, visited))
                { 
                    visited[newRow, newCol] = true;
                    findWord(board, visited, newRow, newCol, word + board[newRow, newCol], dictionnary);
                    visited[newRow, newCol] = false;
                }
            }
        }

        private static bool isCoordValid(int newRow, int newCol, bool[,] visited)
        {
            if((newRow >= 0)&&(newCol >= 0)&& (newRow < 3)&&(newCol <3)&&(!visited[newRow, newCol]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            Automate wordTree = new Automate();
            Console.WriteLine("My Boggle:");
            int h = 3;
            int l = 3;
            char[,] board = { {'c', 'a', 'm'},
                               {'b', 'g', 't'},
                               {'n', 'e', 'o'} };
            bool[,] visited = { {false, false, false },
                                {false, false, false },
                                {false, false, false }};

            string word = string.Empty;
            List<string> dictionnary = new List<string>{ "age", "hat", "toe", "cam", "tam", "ben", "gen", "cagot", "mtoen", "mton", "tbg"};

            for (int i = 0; i < h; i++)
            {
                for(int j = 0; j < l; j++)
                {
                    visited[i, j] = true;
                    findWord(board, visited, i, j, word + board[i, j], dictionnary);
                    visited[i, j] = false;
                }
                Console.WriteLine();
            }
        }


        
    }

}
