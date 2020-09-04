using NUnit.Framework.Constraints;
using PokemonClasses;
using PokemonTypesNamespace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Features
{
    public class Pokemon
    {
        public bool IsShiny { get; private set; }
        public int IVsHP { get; private set; }
        public int IVsAttack { get; private set; }
        public int IVsDefense { get; private set; }
        public int IVsSpAttack { get; private set; }
        public int IVsSpDefense { get; private set; }
        public int IVsSpeed { get; private set; }
        public int EVsHP { get; private set; }
        public int EVsAttack { get; private set; }
        public int EVsDefense { get; private set; }
        public int EVsSpAttack { get; private set; }
        public int EVsSpDefense { get; private set; }
        public int EVsSpeed { get; private set; }
        public bool HasPrimaryAbility { get; private set; }
        public bool HasSecondaryAbility { get; private set; }
        public bool HasHiddenAbility { get; private set; }
        public bool HasPokeRus { get; private set; }
        public bool PokeRusIsCured { get; private set; }
        public int Number { get; private set; }
        public string Name { get; private set; }
        public List<PokemonTypes> PokemonTypes { get; private set; }
        public List<PokemonAbility> PokemonAbilities { get; private set; }
        public int BaseHP { get; private set; }
        public int BaseAttack { get; private set; }
        public int BaseDefense { get; private set; }
        public int BaseSpecialAttack { get; private set; }
        public int BaseSpecialDefense { get; private set; }
        public int BaseSpeed { get; private set; }



        public Pokemon(string name)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = false;
            SetHPIVs(0);
            SetAttackIVs(0);
            SetDefenseIVs(0);
            SetSpecialAttackIVs(0);
            SetSpecialDefenseIVs(0);
            SetSpeedIVs(0);
            AssignAbility(true, false, false);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }


        public Pokemon(string name, bool shiny)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = shiny;
            SetHPIVs(0);
            SetAttackIVs(0);
            SetDefenseIVs(0);
            SetSpecialAttackIVs(0);
            SetSpecialDefenseIVs(0);
            SetSpeedIVs(0);
            AssignAbility(true, false, false);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }


        public Pokemon(string name, bool primary, bool secondary, bool hidden)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = false;
            SetHPIVs(0);
            SetAttackIVs(0);
            SetDefenseIVs(0);
            SetSpecialAttackIVs(0);
            SetSpecialDefenseIVs(0);
            SetSpeedIVs(0);
            AssignAbility(primary, secondary, hidden);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }

        public Pokemon(string name, bool shiny, bool primary, bool secondary, bool hidden)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = shiny;
            SetHPIVs(0);
            SetAttackIVs(0);
            SetDefenseIVs(0);
            SetSpecialAttackIVs(0);
            SetSpecialDefenseIVs(0);
            SetSpeedIVs(0);
            AssignAbility(primary, secondary, hidden);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }


        public Pokemon(string name, int hp, int attack, int def, int spatt, int spdef, int spe)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = false;
            SetHPIVs(hp);
            SetAttackIVs(attack);
            SetDefenseIVs(def);
            SetSpecialAttackIVs(spatt);
            SetSpecialDefenseIVs(spdef);
            SetSpeedIVs(spe);
            AssignAbility(true, false, false);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }

        public Pokemon(string name, int hp, int attack, int def, int spatt, int spdef, int spe, bool primary, bool secondary, bool hidden)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = false;
            SetHPIVs(hp);
            SetAttackIVs(attack);
            SetDefenseIVs(def);
            SetSpecialAttackIVs(spatt);
            SetSpecialDefenseIVs(spdef);
            SetSpeedIVs(spe);
            AssignAbility(primary, secondary, hidden);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }

        public Pokemon(string name, bool shiny, int hp, int attack, int def, int spatt, int spdef, int spe)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = shiny;
            SetHPIVs(hp);
            SetAttackIVs(attack);
            SetDefenseIVs(def);
            SetSpecialAttackIVs(spatt);
            SetSpecialDefenseIVs(spdef);
            SetSpeedIVs(spe);
            AssignAbility(true, false, false);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }

        public Pokemon(string name, bool shiny, int hp, int attack, int def, int spatt, int spdef, int spe, bool primary, bool secondary, bool hidden)
        {
            PokemonFactory pkf = new PokemonFactory(name);
            SetBuildsData(pkf);
            IsShiny = shiny;
            SetHPIVs(hp);
            SetAttackIVs(attack);
            SetDefenseIVs(def);
            SetSpecialAttackIVs(spatt);
            SetSpecialDefenseIVs(spdef);
            SetSpeedIVs(spe);
            AssignAbility(primary, secondary, hidden);
            HasPokeRus = false;
            PokeRusIsCured = false;
        }

        private void SetBuildsData(PokemonFactory pkf)
        {
            Name = pkf.Name;
            Number = pkf.Number;
            PokemonTypes = pkf.PokemonTypes;
            PokemonAbilities = pkf.PokemonAbilities;
            BaseHP = pkf.BaseHP;
            BaseAttack = pkf.BaseAttack;
            BaseDefense = pkf.BaseDefense;
            BaseSpecialAttack = pkf.BaseSpecialAttack;
            BaseSpecialDefense = pkf.BaseSpecialDefense;
            BaseSpeed = pkf.BaseSpeed;
        }


        public void HyperTrainHP()
        {
            if (IVsHP < 31)
            {
                IVsHP = 31;
            }
        }

        public void HyperTrainAttack()
        {
            if (IVsHP < 31)
            {
                IVsHP = 31;
            }
        }

        public void HyperTrainDefense()
        {
            if (IVsAttack < 31)
            {
                IVsAttack = 31;
            }
        }

        public void HyperTrainSpecialAttack()
        {
            if (EVsSpAttack < 31)
            {
                EVsSpAttack = 31;
            }
        }

        public void HyperTrainSpecialDefense()
        {
            if (EVsSpDefense < 31)
            {
                EVsSpDefense = 31;
            }
        }

        public void HyperTrainSpeed()
        {
            if (IVsSpeed < 31)
            {
                IVsSpeed = 31;
            }
        }

        private void SetHPIVs(int ivs)
        {
            if (ivs < 0)
            {
                IVsHP = 0;

            }
            else if (ivs > 31)
            {
                IVsHP = 31;
            }
            else
            {
                IVsHP = ivs;
            }
        }

        private void SetAttackIVs(int ivs)
        {
            if (ivs < 0)
            {
                IVsAttack = 0;

            }
            else if (ivs > 31)
            {
                IVsAttack = 31;
            }
            else
            {
                IVsAttack = ivs;
            }
        }

        private void SetDefenseIVs(int ivs)
        {
            if (ivs < 0)
            {
                IVsDefense = 0;

            }
            else if (ivs > 31)
            {
                IVsDefense = 31;
            }
            else
            {
                IVsDefense = ivs;
            }
        }


        private void SetSpecialAttackIVs(int ivs)
        {
            if (ivs < 0)
            {
                IVsSpAttack = 0;

            }
            else if (ivs > 31)
            {
                IVsSpAttack = 31;
            }
            else
            {
                IVsSpAttack = ivs;
            }
        }

        private void SetSpecialDefenseIVs(int ivs)
        {
            if (ivs < 0)
            {
                IVsSpDefense = 0;

            }
            else if (ivs > 31)
            {
                IVsSpDefense = 31;
            }
            else
            {
                IVsSpDefense = ivs;
            }
        }

        private void SetSpeedIVs(int ivs)
        {
            if (ivs < 0)
            {
                IVsSpeed = 0;

            }
            else if (ivs > 31)
            {
                IVsSpeed = 31;
            }
            else
            {
                IVsSpeed = ivs;
            }
        }

        public void PrintIVs()
        {
            Console.WriteLine("HP IVS: " + IVsHP.ToString());
            Console.WriteLine("Attack IVS: " + IVsAttack.ToString());
            Console.WriteLine("Defense IVS: " + IVsDefense.ToString());
            Console.WriteLine("Special Attack IVS: " + IVsSpAttack.ToString());
            Console.WriteLine("Special Defense IVS: " + IVsSpDefense.ToString());
            Console.WriteLine("Speed IVS: " + IVsSpeed.ToString());
        }


        private void AssignAbility(bool primary, bool secondary, bool hidden)
        {
            if (hidden)
            {
                HasPrimaryAbility = false;
                HasSecondaryAbility = false;
                HasHiddenAbility = hidden;
            }
            else 
            {
                if (secondary)
                {
                    HasPrimaryAbility = false;
                    HasSecondaryAbility = secondary;
                    HasHiddenAbility = false;
                }
                else
                {
                    HasPrimaryAbility = true;
                    HasSecondaryAbility = false;
                    HasHiddenAbility = false;
                }
            }
        }

        public void AbilityCapsule()
        {
            if (!HasHiddenAbility)
            {
                if (HasPrimaryAbility)
                {
                    HasPrimaryAbility = false;
                    HasSecondaryAbility = true;
                }
                else
                {
                    HasPrimaryAbility = true;
                    HasSecondaryAbility = false;
                }
            }
        }

        public void InfectPokeRus()
        {
            if (HasPokeRus == false)
            {
                HasPokeRus = true;
                PokeRusIsCured = false;
            }
        }

        public void CurePokeRus()
        {
            if (HasPokeRus == true && PokeRusIsCured == false)
            {
                PokeRusIsCured = true;
            }
        }

        public void ResetEVs()
        {
            EVsHP = 0;
            EVsAttack = 0;
            EVsDefense = 0;
            EVsSpAttack = 0;
            EVsSpDefense = 0;
            EVsSpeed = 0;
        }


        public void PrintEVs()
        {
            Console.WriteLine("HP EVS: "+ EVsHP.ToString());
            Console.WriteLine("Attack EVS: " + EVsAttack.ToString());
            Console.WriteLine("Defense EVS: " + EVsDefense.ToString());
            Console.WriteLine("Special Attack EVS: " + EVsSpAttack.ToString());
            Console.WriteLine("Special Defense EVS: " + EVsSpDefense.ToString());
            Console.WriteLine("Speed EVS: " + EVsSpeed.ToString());
        }

        public void AddEVPointsToHP(int evs)
        {
            int Total = EVsHP + EVsAttack + EVsDefense + EVsSpAttack + EVsSpDefense + EVsSpeed;
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = EVsHP + evs;
                    if (TotalStatus <= 252)
                    {
                        EVsHP = TotalStatus;
                    }
                }
            }
        }

        public void AddEVPointsToAttack(int evs)
        {
            int Total = EVsHP + EVsAttack + EVsDefense + EVsSpAttack + EVsSpDefense + EVsSpeed;
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = EVsAttack + evs;
                    if (TotalStatus <= 252)
                    {
                        EVsAttack = TotalStatus;
                    }
                }
            }
        }

        public void AddEVPointsToDefense(int evs)
        {
            int Total = EVsHP + EVsAttack + EVsDefense + EVsSpAttack + EVsSpDefense + EVsSpeed;
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = EVsDefense + evs;
                    if (TotalStatus <= 252)
                    {
                        EVsDefense = TotalStatus;
                    }
                }
            }
        }


        public void AddEVPointsToSpecialAttack(int evs)
        {
            int Total = EVsHP + EVsAttack + EVsDefense + EVsSpAttack + EVsSpDefense + EVsSpeed;
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = EVsSpAttack + evs;
                    if (TotalStatus <= 252)
                    {
                        EVsSpAttack = TotalStatus;
                    }
                }
            }
        }


        public void AddEVPointsToSpecialDefense(int evs)
        {
            int Total = EVsHP + EVsAttack + EVsDefense + EVsSpAttack + EVsSpDefense + EVsSpeed;
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = EVsSpDefense + evs;
                    if (TotalStatus <= 252)
                    {
                        EVsSpDefense = TotalStatus;
                    }
                }
            }
        }


        public void AddEVPointsToSpeed(int evs)
        {
            int Total = EVsHP + EVsAttack + EVsDefense + EVsSpAttack + EVsSpDefense + EVsSpeed;
            if (Total <= 510)
            {
                int TotalEVs = Total + evs;
                if (TotalEVs <= 510)
                {
                    int TotalStatus = EVsSpeed + evs;
                    if (TotalStatus <= 252)
                    {
                        EVsSpeed = TotalStatus;
                    }
                }
            }
        }

    }
}
