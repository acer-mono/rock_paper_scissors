namespace rock_paper_scissors.Domain
{
    public class Paper : Сompetitor
    {
        public override bool HitResult(Сompetitor competitor)
        {
            switch (competitor)
            {
                case Paper paper:
                    return false;
                case Scissors scissors:
                    IsAlive = false;
                    return false;
                case Rock rock:
                    rock.IsAlive = false;
                    return true;
            };
            return false;
        }

        public override string ToString()
        {
            return "Paper";
        }
    }
}