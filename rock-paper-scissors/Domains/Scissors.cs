using rock_paper_scissors.Interfaces;

namespace rock_paper_scissors.Domains
{
    public class Scissors : Сompetitor
    {

        public override bool HitResult(Сompetitor competitor)
        {
            switch (competitor)
            {
                case Paper paper:
                    paper.IsAlive = false;
                    return true;
                case Scissors scissors:
                    return false;
                case Rock rock:
                    IsAlive = false;
                    return false;
            };
            return false;
        }
        
        public override string ToString()
        {
            return "Scissors";
        }
    }
}
