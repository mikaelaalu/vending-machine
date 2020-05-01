using System.Reflection.Metadata;

namespace AwesomeProject
{
    public class Bank
    {
        public int money { get; set; }
        
        public Bank( int money)
        {
            this.money = money;
        }
        public int CheckAccount()
        {
            return money;
        }
        
        public bool Withdrawal( int wantToTakeOut)
        {
            if (wantToTakeOut > money)
            {
                return false;
            }

            money = money - wantToTakeOut;
             return true;
        }
    }
}