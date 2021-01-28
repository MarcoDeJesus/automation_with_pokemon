using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsManagement
{
    public class EVManagement
    {
        public int hp { get; private set; }
        public int attack { get; private set; }
        public int defense { get; private set; }
        public int specialAttack { get; private set; }
        public int specialDefense { get; private set; }
        public int speed { get; private set; }

        public EVManagement()
        {
            hp = 0;
            attack = 0;
            defense = 0;
            specialAttack = 0;
            specialDefense = 0;
            speed = 0;
        }

        public int GetTotalEVPoints()
        {
            int total = hp + attack + defense + specialAttack + specialDefense + speed;
            return total;
        }
        public void AddEVPointsToHP(int evs)
        {
            int Total = GetTotalEVPoints();
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = hp + evs;
                    if (TotalStatus <= 252)
                    {
                        hp = TotalStatus;
                    }
                }
            }
        }

        public void AddEVPointsToAttack(int evs)
        {
            int Total = GetTotalEVPoints();
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = attack + evs;
                    if (TotalStatus <= 252)
                    {
                        attack = TotalStatus;
                    }
                }
            }
        }

        public void AddEVPointsToDefense(int evs)
        {
            int Total = GetTotalEVPoints();
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = defense + evs;
                    if (TotalStatus <= 252)
                    {
                        defense = TotalStatus;
                    }
                }
            }
        }


        public void AddEVPointsToSpecialAttack(int evs)
        {
            int Total = GetTotalEVPoints();
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = specialAttack + evs;
                    if (TotalStatus <= 252)
                    {
                        specialAttack = TotalStatus;
                    }
                }
            }
        }


        public void AddEVPointsToSpecialDefense(int evs)
        {
            int Total = GetTotalEVPoints();
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = specialDefense + evs;
                    if (TotalStatus <= 252)
                    {
                        specialDefense = TotalStatus;
                    }
                }
            }
        }


        public void AddEVPointsToSpeed(int evs)
        {
            int Total = GetTotalEVPoints();
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = speed + evs;
                    if (TotalStatus <= 252)
                    {
                        speed = TotalStatus;
                    }
                }
            }
        }


    }
}
