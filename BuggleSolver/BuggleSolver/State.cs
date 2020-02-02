using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace BuggleSolver
{
    class State
    {

        private List<State> childState;
        private State parentState;
        private char letter;
        private string word;
        private bool visited;

        public char getLetter()
        {
            return letter;
        }

        public String getWord()
        {
            return word;
        }

        public void setWord(String word)
        {
            this.word = word;
        }

        public State getParentState() { return parentState; }


        public State(char letter)
        {
            childState = new List<State>();
            parentState = this;
            this.letter = letter;
        }

        public State(char letter, State parent)
        {
            childState = new List<State>();
            parentState = parent;
            word = string.Empty; //until last node, not a word
            this.letter = letter;
        }

        public void addChild(State newState)
        {
            childState.Add(newState);
        }

       
        //fait seulement que ecrire une list de mots....
        /*
        public List<String> wordList (List<String> list)
        {
            if(this.getWord() != null)
            {
                list.Add(this.getWord());
            }
            for(int i = 0; i < this.childState.Count; i++)
            {
                childState[i].wordList(list);
            }

            return list;
        }
        */


        public State nextState(char letter)
        {
            for (int i = 0; i < childState.Count; i++)
            {
                if (childState[i].getLetter() == letter)
                {
                    return childState[i];
                }
            }
            return this;
        }

        public bool hasNext(char letter)
        {
            for (int i = 0; i < childState.Count; i++)
            {
                if (childState[i].getLetter() == letter)
                {
                    return true;
                }
            }
            return false;
        }

    }

}
