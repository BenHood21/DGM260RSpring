using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class InheritancePracticeScript : MonoBehaviour
{
    class MainClass
    {
        class Hero
        {
            public string name;
            public string weapon;
            public float goal;

            public void PrintBaseValues()
            {
                Console.WriteLine("Name: " + name);
                Console.WriteLine("Weapon: " + weapon);
                Console.WriteLine("Goal: " + goal);
            }
        }

        class Archer : Hero
        {
            public int arrowCount;

            public void Attack()
            {
                Console.WriteLine("Fire");
            }
        }

        class Warrior : Hero
        {
            public Color hairColor;

            public void WarCry()
            {
                Console.WriteLine("AHHHHHH");
            }
        }

        public void Main(string[] args)
        {
            Warrior Tank = new Warrior();
            Tank.name = "Martty";
            Tank.weapon = "Axe";
            Tank.goal = 50f;
            Tank.hairColor = Color.gray;
            Tank.PrintBaseValues();
            Tank.WarCry();
        }
    }
}


