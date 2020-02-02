using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BuggleSolver
{
    class Automate
    {

        
    
        private State initialState;
        private State currentState;
        private List<State> visitedWord = new List<State>();

        public Automate()
        {

            initialState = new State('0');
            currentState = initialState;

            try
            {

                
                string path = "test.txt";
                System.IO.StreamReader file = new System.IO.StreamReader("test.txt");

                string line;
                String currentString;

                while((line = file.ReadLine())!= null)
                {
                    currentString = line;

                    for (int j = 0; j < currentString.Length; j++)
                    {
                        if (!currentState.hasNext(currentString[j]))
                        {
                            currentState.addChild(new State(currentString[j], currentState));
                        }
                        currentState = currentState.nextState(currentString[j]);
                    }
                    currentState.setWord(currentString);
                    currentState = initialState;
                }
                file.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());

            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());

            }
        }
    
    }
}
