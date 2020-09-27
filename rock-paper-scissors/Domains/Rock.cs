using rock_paper_scissors.Interfaces;

namespace rock_paper_scissors.Domains
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