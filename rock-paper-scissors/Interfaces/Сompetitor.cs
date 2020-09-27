using System.Reflection.Metadata.Ecma335;

namespace rock_paper_scissors.Interfaces
{
    public abstract class Сompetitor
    {
        private bool _isAlive = true;
        public bool IsAlive { get => _isAlive; set => _isAlive = value; }
        public abstract bool HitResult(Сompetitor competitor);
    }
}