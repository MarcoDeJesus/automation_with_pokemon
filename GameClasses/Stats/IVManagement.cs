﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StatsManagement
{
    public class IVManagement
    {
        public int hp { get; private set; }
        public int attack { get; private set; }
        public int defense { get; private set; }
        public int specialAttack { get; private set; }
        public int specialDefense { get; private set; }
        public int speed { get; private set; }

        public IVManagement()
        {
            hp = GenerateRandomIVValue();
            attack = GenerateRandomIVValue();
            defense = GenerateRandomIVValue();
            specialAttack = GenerateRandomIVValue();
            specialDefense = GenerateRandomIVValue();
            speed = GenerateRandomIVValue();
        }


        public IVManagement(bool _hp, bool _attack, bool _defense, bool _specialA, bool _specialDef, bool _speed, List<int> values)
        {
            if (ValidateInputArray(values))
            {
                if (_hp)
                {
                    hp = values[0];
                }
                else
                {
                    hp = GenerateRandomIVValue();
                }
                if (_attack)
                {
                    attack = values[1];
                }
                else
                {
                    attack = GenerateRandomIVValue();
                }
                if (_defense)
                {
                    defense = values[2];
                }
                else
                {
                    defense = GenerateRandomIVValue();
                }
                if (_specialA)
                {
                    specialAttack = values[3];
                }
                else
                {
                    specialAttack = GenerateRandomIVValue();
                }
                if (_specialDef)
                {
                    specialDefense = values[4];
                }
                else
                {
                    specialDefense = GenerateRandomIVValue();
                }
                if (_speed)
                {
                    speed = values[5];
                }
                else
                {
                    speed = GenerateRandomIVValue();
                }
            }
            else
            {
                hp = GenerateRandomIVValue();
                attack = GenerateRandomIVValue();
                defense = GenerateRandomIVValue();
                specialAttack = GenerateRandomIVValue();
                specialDefense = GenerateRandomIVValue();
                speed = GenerateRandomIVValue();
            }

        }


        public IVManagement(List<int> values)
        {
            if (ValidateInputArray(values))
            {
                hp = values[0];
                attack = values[1];
                defense = values[2];
                specialAttack = values[3];
                specialDefense = values[4];
                speed = values[5];
            }
            else {
                hp = GenerateRandomIVValue();
                attack = GenerateRandomIVValue();
                defense = GenerateRandomIVValue();
                specialAttack = GenerateRandomIVValue();
                specialDefense = GenerateRandomIVValue();
                speed = GenerateRandomIVValue();
            }
        }


        private int GenerateRandomIVValue()
        {
            Thread.Sleep(2);
            Random r = new Random(DateTime.Now.Millisecond);
            int rInt = r.Next(31);
            return rInt;
        }

        private bool ValidateInputArray(List<int> values)
        {
            bool results = false;
            if (values.Count == 6)
            {
                foreach (int i in values)
                {
                    if (i >= 0 || i <= 31)
                    {
                        results = true;
                    }
                    else 
                    {
                        results = false;
                        break;
                    }
                }
            }
            return results;
        }
    }
}
