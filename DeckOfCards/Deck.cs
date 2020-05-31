using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    /// <summary>
    /// Abstract class that intializes a deck of 52 cards
    /// </summary>
    public abstract class Deck
    {
        readonly static int DeckSize = 52;
        public List<Card> Cards = new List<Card>();
        public List<Card> ShuffledCards;
        /// <summary>
        /// Default constructor. Initializes a deck of 52 cards.
        /// </summary>
        public Deck()
        {
            var Rank = Enum.GetValues(typeof(Rank));
            var Suit = Enum.GetValues(typeof(Suit));
           
            foreach (Suit suit in Suit)
            {
                foreach(Rank rank in Rank)
                {
                    Card c = new Card(rank, suit);
                    //Console.WriteLine(c.ToString());
                    Cards.Add(c);
                }   
            }
        }
       
        public abstract void Shuffle();
        
        public abstract Dictionary<int,List<Card>> DealCards(int NumberOfPlayers);
    }
}
