using System;
using System.Collections.Generic;
using System.IO;

namespace Frozen
{
    class Program
    {
        class Frozen
        {
            string character;
            string wish;

            public Frozen(string _character, string _wish)
            {
                character = _character;
                wish = _wish;
            }

            public string Character { get { return character; } }
            public string Wish { get { return wish; } }
        }

        class CharacterList
        {
            List<Frozen> characters;

            public CharacterList()
            {
                characters = new List<Frozen>();
            }

            public void AddCharactersToList(string character, string wish)
            {
                Frozen newChar = new Frozen(character, wish);
                characters.Add(newChar);
            }

            public void PrintAllCharacters()
            {
                foreach (Frozen frozen in characters)
                {
                    Console.WriteLine($"{frozen.Character} wants {frozen.Wish} for christmas");
                }
            }
        }



        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"frozen.txt";
            string fullFilePath = Path.Combine(filePath, fileName);

            //create an arrray of records from file
            string[] linesFromFile = File.ReadAllLines(fullFilePath);

            CharacterList myCharacters = new CharacterList();

            foreach (string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string characterName = tempArray[0];
                string characterWish = tempArray[1];

                myCharacters.AddCharactersToList(characterName, characterWish);
            }

            myCharacters.PrintAllCharacters();
        }
    }
}
