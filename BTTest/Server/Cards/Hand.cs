using System.Collections.Generic;
using System.Linq;

namespace BTTest.Server.Cards
{
    public class Hand
    {
        public IReadOnlyCollection<Card> Cards { get; init; }

        public Hand(IEnumerable<Card> cards) { Cards = cards.ToList().AsReadOnly(); }

        public static ExecutionResult<Hand> Build(string s)
        {
            List<Card> cards = new();

            // Try to build the full hand of cards
            IEnumerable<string> inputs = s
                .Split(",")
                .Select(s => s.Trim());
            foreach (string input in inputs)
            {
                ExecutionResult<Card> result = Card.Build(input);
                if (result.IsError())
                    return ExecutionResult<Hand>.BuildNegative(result.ErrorMessage);
                cards.Add(result.Result);
            }

            // This could be done in a simpler way, such:
            // IEnumerable<ExecutionResult<Card>> cardsResult = s
            //    .Split(",")
            //    .Select(s => s.Trim())
            //    .Select(s => Card.Build(s))
            //    .ToList();
            // But probably we want to stop at the first error, although it could be interesting to collect all errors...

            // Check for too many jokers
            if (cards.Count(c => c.IsSpecialCard()) > 2) // Simplification: for the moment, the special cards can only be jokers
            {
                return ExecutionResult<Hand>.BuildNegative("A hand cannot contain more than two Jokers");
            }

            // Check for duplicates (excluding jokers)
            var cardsReps = cards
                    .Select(c => c.ToString())
                    .Where(s => s != "JR")
                    .ToList();
            if (cardsReps.Count != cardsReps.Distinct().Count())
            {
                return ExecutionResult<Hand>.BuildNegative("Cards cannot be duplicated");
            }

            return ExecutionResult<Hand>.BuildPositive(new(cards));
        }

        public int GetValue()
        {
            int result = Cards.Sum(c => c.CalculateValue());
            int jokers = Cards.Count(c => c.IsSpecialCard()); // Simplification: for the moment, the special cards can only be jokers
            if (jokers > 0)
            {
                result *= 2 * jokers;
            }
            return result;
        }
    }
}
