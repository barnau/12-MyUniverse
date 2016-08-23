using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUniverse
{
    class Program
    {
        static string[] potentialNames = new string[] { "Galaxian", "SemiQuest", "Babylon", "Shintiquaqua", "Camisatagon" };

        static void Main(string[] args)
        {

            Universe awesomeUniverse = new Universe("Awesome Universe");

            Random r = new Random();
            // Create 1000 Galaxies and add to Universe
            for (int i = 0; i < 1001; i++)
            {
                int numberOfWords = r.Next(1, 3);

                string name = string.Empty;

                for (int j = 0; j < numberOfWords; j++)
                {
                    name += potentialNames[r.Next(0, potentialNames.Length - 1)];
                }

                Galaxy galaxy = new Galaxy(name);
                Console.WriteLine(galaxy._name);

                awesomeUniverse.AddGalaxy(galaxy);
            }

            //for each Galaxy add 200 solar systems
            foreach (Galaxy gal in awesomeUniverse._galaxies)
            {
                for (int i = 0; i < 201; i++)
                {
                    SolarSystem solarSystem = new SolarSystem(i.ToString());

                    solarSystem.AddStar(new Star(i.ToString()));

                    for (int j = 0; j < 16; j++)
                    {
                        Planet planet = new Planet(j.ToString());

                        for (int k = 0; k < 10000; k++)
                        {
                            LifeForm lifeForm = new LifeForm(k.ToString(), i.ToString());
                            planet.AddLifeForm(lifeForm);
                        }
                        solarSystem.AddPlanet(planet);
                    }
                    gal.AddSolarSystem(solarSystem);

                    
                }
                

            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();


        }
    }

    public class Universe
    {
        public string _name { get; set; }
        public List<Galaxy> _galaxies = new List<Galaxy>();
        public void AddGalaxy(Galaxy galaxy)
        {
            _galaxies.Add(galaxy);
        }

        public Universe(string name)
        {
            _name = name;
        } 
    }

    public class Galaxy
    {

        public string _name { get; set; }
        public List<SolarSystem> _solarSystems = new List<SolarSystem>();
        public void AddSolarSystem(SolarSystem solarSystem)
        {
            _solarSystems.Add(solarSystem);
        }

        public Galaxy(string Name)
        {
            _name = Name;
        }
    }

    public class SolarSystem
    {
        public string _name { get; set; }
        public List<Star> _stars = new List<Star>();
        public List<Planet> _planets = new List<Planet>();
        public void AddStar(Star star)
        {
            _stars.Add(star);
        }
        public void AddPlanet(Planet planet)
        {
            _planets.Add(planet);
        }

        public SolarSystem(string name)
        {
            _name = name;
        }
    }

    public class Planet
    {
        public string _name { get; set; }
        public List<LifeForm> _lifeForms = new List<LifeForm>();
        public void AddLifeForm(LifeForm lifeForm)
        {
            _lifeForms.Add(lifeForm);
        } 

        public Planet(string name)
        {
            _name = name;
        }

    }

    public class Star
    {
        public string _name { get; set; }

        public Star(string name)
        {
            _name = name;
        }

  
    }

    public class LifeForm
    {
        public string _firstName { get; set; }
        public string _lastName { get; set; }

        public LifeForm(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}
