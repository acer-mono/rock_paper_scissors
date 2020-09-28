using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using rock_paper_scissors.Interfaces;
using rock_paper_scissors.Domains;

namespace rock_paper_scissors
{
    public class Game
    {
        private static readonly Type[] Types = { typeof(Paper),  typeof(Scissors), typeof(Rock)};
        private readonly List<Сompetitor> _competitors;
        private int _first = -1;
        private int _second;
        
        public Game(int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidEnumArgumentException("The number of competitors must be a positive number");
            }
            
            _competitors = new List<Сompetitor>(amount);
            
            var rand = new Random();
            for (var i = 0; i < amount; i++)
            {
                var random = rand.Next() % 3;
                switch (random)
                {
                    case 0:
                        _competitors.Add(new Paper());
                        break;
                    case 1:
                        _competitors.Add(new Rock());
                        break;
                    case 2:
                        _competitors.Add(new Scissors());
                        break;
                }
            }
        }

        public bool Next()
        {
            var aliveCompetitors = _competitors.Count(c => c.IsAlive);
            foreach (var type in Types)
            {
                if (_competitors.Count(c => c.IsAlive && c.GetType() == type) == aliveCompetitors)
                {
                    return false;
                }
            }

            _first = FindAliveCompetitorIndex(_first + 1);
            _second = FindAliveCompetitorIndex(_first + 1);
            
            var result = _competitors[_first].HitResult(_competitors[_second]);
            Console.WriteLine($"{_competitors[_first]} hits {_competitors[_second]}. \n" +
                              $"Is alive {_competitors[_first]}: {_competitors[_first].IsAlive} \n" +
                              $"Is alive {_competitors[_second]}: {_competitors[_second].IsAlive} \n");
            return true;
        }

        public IEnumerable<string> Result() => _competitors.Select(c => !c.IsAlive ? "DEAD" : c.ToString()).ToList();

        private int FindAliveCompetitorIndex(int index)
        {
            if (index > _competitors.Count - 1)
                index = 0;
            
            while (!_competitors[index].IsAlive)
            {
                index++;
                if (index > _competitors.Count - 1)
                    index = 0;
            }

            return index;
        }
    }
}