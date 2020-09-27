using System;
using System.Collections.Generic;
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
            if (_competitors.Count == 1 || _competitors.Count <= 0)
            {
                return false;
            }
            
            var sum = _competitors.Count(c => c != null);
            foreach (var type in Types)
            {
                if (_competitors.Count(c => c != null && c.GetType() == type) == sum)
                {
                    return false;
                }
            }

            _first = FindAliveComponent(_first + 1);
            _second = FindAliveComponent(_first + 1);
            
            var result = _competitors[_first].HitResult(_competitors[_second]);
            Console.WriteLine($"{_competitors[_first]} hits {_competitors[_second]}. \n" +
                              $"Is alive {_competitors[_first]}: {_competitors[_first].IsAlive} \n" +
                              $"Is alive {_competitors[_second]}: {_competitors[_second].IsAlive} \n");

            if (_competitors[_first].ToString() == _competitors[_second].ToString())
            {
                return true;
            }
            
            if (result)
            {
                _competitors[_second] = null;
            }
            else
            {
                _competitors[_first] = null;
            }
            
            return true;
        }

        public IEnumerable<string> Result() => _competitors.Select(c => c == null ? "DEAD" : c.ToString()).ToList();

        private int FindAliveComponent(int index)
        {
            if (index > _competitors.Count - 1)
                index = 0;
            
            while (_competitors[index] == null)
            {
                index++;
                if (index > _competitors.Count - 1)
                    index = 0;
            }

            return index;
        }
    }
}