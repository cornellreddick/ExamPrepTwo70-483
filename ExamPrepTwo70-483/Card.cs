using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepTwo70_483
{
    class Card
    {
        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }
    }
    class Deck
    {
        private int _maximumNumberOfCards;

        public List<Card> Cards {get; set; }

        public Deck(int _maximumNumberOfCards)
        {
            _maximumNumberOfCards = maximumNumberOfCards;
            Cards = new List<Card>();
        }



    }
}
