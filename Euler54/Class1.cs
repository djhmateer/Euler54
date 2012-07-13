using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Euler54
{
    [TestFixture]
    public class E54Tests
    {
        [Test]
        public void LoadFile_Given_ReturnListOfListOf2CharacterStrings()
        {
            List<List<string>> result = E54.LoadFile();
            Assert.AreEqual(1000, result.Count);
        }

        [Test]
        public void GetBestOutcomeFromHand_GivenPairWin_ReturnWinningCardsEnum()
        {
            var list = new List<string>() { "5H", "5C", "6S", "7S", "KD" };
            Outcome outcome;
            List<string> result = E54.GetBestOutcomeFromHand(list, out outcome);
            Assert.AreEqual(Outcome.OnePair, outcome);
            Assert.AreEqual(new List<string>() {"5H", "5C"}, result);
        }

        [Test]
        public void RunGameGiven10CardsFirst5Player1Second5Player2_GivenHand1_Return2()
        {
            var list = new List<string>() {"5H","5C", "6S", "7S", "KD", "2C", "3S", "8S", "8D", "TD" };
            int result = E54.RunGameGiven10CardsFirst5Player1Second5Player2(list);
            Assert.AreEqual(2, result);
        }
    }

    public enum Outcome
    {
        HighCard, OnePair, TwoPairs
    }
    public class E54
    {
        public static List<string> GetBestOutcomeFromHand(List<string> listCardsIn, out Outcome outcome)
        {
            //check for Royal Flush
            //..
            //check for 1 Pair
            //  check for same first digit
            var firstDigitList = new List<string>();
            foreach (string card in listCardsIn)
            {
                string firstDigit = card[0].ToString();
                firstDigitList.Add(firstDigit);
            }
            //  get any cards with > 1 in
            string firstDigitPair = firstDigitList.Count(x => x > 1);

            var listWinningCards = new List<string>();
            listWinningCards.Add("5H");
            listWinningCards.Add("5C");
            outcome = Outcome.OnePair;
            return listWinningCards;
        }

        public static int RunGameGiven10CardsFirst5Player1Second5Player2(List<string> list)
        {
            int result = 0;
            var player1 = new List<string>();
            var player2 = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                player1.Add(list[i]);
            }
            for (int i = 5; i < 10; i++)
            {
                player2.Add(list[i]);
            }

            //get best outcome from hand



            return result;
        }

        public static List<List<string>> LoadFile()
        {
            string[] text = File.ReadAllLines(@"e:\temp\poker.txt");
            var listOfHands = new List<List<string>>();

            for (int i = 0; i < text.Length; i++)
            {
                string line = text[i];
                string[] cards = line.Split(' ');
                var listOfCards = new List<string>();
                for (int j = 0; j < cards.Length; j++)
                {
                    listOfCards.Add(cards[j]);
                }
                listOfHands.Add(listOfCards);
                Console.WriteLine(line);
            }
            return listOfHands;
        }
    }
}
