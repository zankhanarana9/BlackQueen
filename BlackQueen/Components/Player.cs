using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeckOfCards;
namespace BlackQueen.Components
{
    public class Player
    {
        public List<Card> CardsInHand = new List<Card>();

        public Card PlayCard()
        {
            int PlayCardIndex = int.Parse(Console.ReadLine());
            return CardsInHand[PlayCardIndex];
        }

        public void ArrangeCardsInHand()
        {

        }
    }
}
