using DeckOfCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackQueen.Components
{
    public class Game
    {
        private static Game CurrentGame =null;
        public static List<Card> PlayedCards = new List<Card>();

        protected Game()
        {

        }
        public static Game GetGame()
        {
            if(CurrentGame == null)
            {
                CurrentGame = new Game();
            }
            return CurrentGame;
        }
        
        public void Begin()
        {
            BlackQueenDeck Deck = new BlackQueenDeck();
            List<Player> Players = new List<Player>(new Player[4]);
            Deal(Deck, ref Players);
            BeginRound(Players);
        }

        private static void Deal(BlackQueenDeck DeckOfCards, ref List<Player> Players)
        {
            DeckOfCards.Shuffle();
            var DealtCards = DeckOfCards.DealCards(Players.Count());
            for(int i=0;i<Players.Count(); i++)
            {
                Player player = new Player()
                {
                    CardsInHand = DealtCards[i]
                };                
                Players[i] = player;
            }
        }

        private static void BeginRound(List<Player> Players)
        {
            foreach(Player player in Players)
            {
                PlayedCards.Add(player.PlayCard());
            }
            Card WinnerCard = WinnerOfRound();
        }

        private static Card WinnerOfRound()
        {
            Card max = null;
            var PlayedSuits = PlayedCards.Select(x => x.Suit);
            if(PlayedSuits.Distinct().Count() ==1)
            {
                Console.WriteLine("All players played  same suit");
                //Get values
                List<int> PlayedRank = PlayedCards.Select(x => Enum.Parse(typeof(Rank),x.Rank.ToString())).Cast<int>().ToList();
                max = PlayedCards[PlayedRank.IndexOf(PlayedRank.Max())];
            }
            return max;
        } 
    }
}
