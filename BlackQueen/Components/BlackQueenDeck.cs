using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCards;
namespace BlackQueen.Components
{
    public class BlackQueenDeck : Deck
    {
        /// <summary>
        /// Deals the default deck of cards into number of players
        /// </summary>
        /// <param name="NumberOfPlayers"></param>
        /// <returns>a dictionary with player and the cards it holds</returns>
        public override Dictionary<int, List<Card>> DealCards(int NumberOfPlayers)
        {
            Dictionary<int, List<Card>> DealtCards = new Dictionary<int, List<Card>>();
            for(int i=0;i<ShuffledCards.Count(); i++)
            {
                int PlayerNumber = i % NumberOfPlayers;
                if (!DealtCards.ContainsKey(PlayerNumber))
                {
                    DealtCards.Add((PlayerNumber), new List<Card>());
                }
                DealtCards[PlayerNumber].Add(ShuffledCards[i]);
            }
            return DealtCards;
        }
        /// <summary>
        /// Shuffle the deck of cards using The Knuth Fisher-Yates algorithm
        /// </summary>
        public override void Shuffle()
        {
            ShuffledCards = new List<Card>(Cards);
            Random rnd = new Random();
            for(int i = 0; i< 1000;i++)
            {
                int location1 = rnd.Next(0, Cards.Count() - 1);
                int location2 = rnd.Next(0, Cards.Count() - 1);
                Card temp = ShuffledCards[location1];
                ShuffledCards[location1] = ShuffledCards[location2];
                ShuffledCards[location2] = temp;
            }
        }
    }
}
