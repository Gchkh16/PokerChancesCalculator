﻿using System;
using static PokerChancesCalculator.Data;

namespace PokerChancesCalculator
{
    /// <summary>
    /// The straight flush combination
    /// </summary>
    public class StraightFlush : Combination
    {
        #region CONSTRUCTOR
        public StraightFlush(Card[] cards) : base(CombinationType.StraightFlush, cards) { }
        #endregion


        /// <summary>
        /// checks if 7 cards array contains StraightFlush
        /// </summary>
        /// <param name="cards">
        /// 7 cards array
        /// </param>
        /// <returns>
        /// Cards in StraightFlush combination if exits otherwise null
        /// </returns>
        public override Combination Check(Card[] cards)
        {
            return Check(cards, true);
        }

        public Combination Check(Card[] cards, bool alreadyChecked)
        {
            if (alreadyChecked)
            {
                if (Combinations[CombinationType.StraightFlush] == null) return null;
                return new Combination(Type, Combinations[CombinationType.StraightFlush]);
            }


            Combination flush = new FLush(null).Check(cards, false);
            if (flush == null)
            {
                Combinations[CombinationType.Flush] = null;
                return null;
            }

            Card[] flushCards = flush.Cards;
            Combinations[CombinationType.Flush] = flushCards;
            var comb = new Straight(null).Check(flushCards);
            if (comb == null) return null;
            return new Combination(CombinationType.StraightFlush, flushCards);
        }
    }
}
