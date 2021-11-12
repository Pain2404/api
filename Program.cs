using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            void Print1()
            {
                Console.WriteLine("To get back press 1");
            }
            //GetAllFilmography getAllFilmography = new GetAllFilmography();
            //getAllFilmography.AllMovieByActor("nm0001667");

            //GetBIO getBio = new GetBIO();
            //getBio.GetBioByActor("nm0001667");

            //GetVersionsByTitle getVersionsByTitle = new GetVersionsByTitle();
            //getVersionsByTitle.GetAllVersions("tt0944947");

            //Translator translator = new Translator();
            //translator.Translate();

            //GetWeather getWeather = new GetWeather();
            //getWeather.GetWeatherForToday("kyiv");

            //GetAllLeagues leagues = new GetAllLeagues();
            //leagues.AllLeagues();

            //GetAllTeams getAllTeams = new GetAllTeams();
            //getAllTeams.GetTeams("333","2019");
            //getAllTeams.GetTeamByName("Arsenal");


            Print print = new Print();
            GetAllLeagues leagues_response = new GetAllLeagues();
            GetAllTeams team_response = new GetAllTeams();
            Console.WriteLine("Hello \n Welcome to our program");
            print.Print_();
            string option = Console.ReadLine();
            switch (option)
            {
                case "0":

                    print.Print_();
                    if (Console.ReadLine() == "1")
                    {
                        goto case "1";
                    }
                    else if (Console.ReadLine() == "2")
                    {
                        goto case "2";
                    }
                    else
                    {
                        break;
                    }

                case "1":

                    leagues_response.AllLeagues();
                    Print1();
                    Console.WriteLine("To remember League id press 2");
                    string asd = Console.ReadLine();
                    Print1();
                    if (asd == "1")
                    {
                        goto case "0";
                    }
                    else if (asd == "2")
                    {
                        Console.WriteLine("Input league id");
                        IdRemember idRemember = new IdRemember();
                        idRemember.id = Console.ReadLine();
                        goto case "0";
                    }
                    else
                    {
                        break;
                    }

                case "2":

                    Console.WriteLine("Id:");
                    string id = Console.ReadLine();
                    Console.WriteLine("Year");
                    string year = Console.ReadLine();
                    team_response.GetTeams(id, year);
                    Print1();
                    if (Console.ReadLine() == "1")
                    {
                        goto case "0";
                    }
                    else
                    {
                        break;
                    }

                case "3":

                    Console.WriteLine("Input team name");
                    team_response.GetTeamByName(Console.ReadLine());
                    Print1();
                    if (Console.ReadLine() == "1")
                    {
                        goto case "0";
                    }
                    else
                    {
                        break;
                    }

                case "4":
                    Console.WriteLine("Input team name");
                    team_response.GetTeamByName(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("Option doesnt exist");
                    break;
            }


            //GetPlayer getPlayer = new GetPlayer();
            //getPlayer.GetPlayersByTeamId("2015", "33");
            //getPlayer.GetPlayersByPlayerName("2019","Ronaldo");
        }
    }
}