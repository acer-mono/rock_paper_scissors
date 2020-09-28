namespace rock_paper_scissors.Domain
{
    public abstract class Сompetitor
    {
        public bool IsAlive { get; set; } = true;
        public abstract bool HitResult(Сompetitor competitor);
    }
}