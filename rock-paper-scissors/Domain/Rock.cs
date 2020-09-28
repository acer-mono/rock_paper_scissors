namespace rock_paper_scissors.Domain
{
    public class Rock : Сompetitor
    {
        public override bool HitResult(Сompetitor competitor)
        {
            switch (competitor)
            {
                case Paper paper:
                    IsAlive = false;
                    return false;
                case Scissors scissors:
                    scissors.IsAlive = false;
                    return true;
                case Rock rock:
                    return false;
            };
            return false;
        }
        
        public override string ToString()
        {
            return "Rock";
        }
    }
}