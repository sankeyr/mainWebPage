using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SankeyMainPageWebApp.Models
{
    public class HomeTeamAwayTeamLinescore
    {

        public class Rootobject
        {
            public string copyright { get; set; }
            public int currentPeriod { get; set; }
            public string currentPeriodOrdinal { get; set; }
            public string currentPeriodTimeRemaining { get; set; }
            public Period[] periods { get; set; }
            public Shootoutinfo shootoutInfo { get; set; }
            public Teams teams { get; set; }
            public string powerPlayStrength { get; set; }
            public bool hasShootout { get; set; }
            public Intermissioninfo intermissionInfo { get; set; }
            public Powerplayinfo powerPlayInfo { get; set; }
        }

        public class Shootoutinfo
        {
            public Away away { get; set; }
            public Home home { get; set; }
        }

        public class Away
        {
            public int scores { get; set; }
            public int attempts { get; set; }
        }

        public class Home
        {
            public int scores { get; set; }
            public int attempts { get; set; }
        }

        public class Teams
        {
            public Home1 home { get; set; }
            public Away1 away { get; set; }
        }

        public class Home1
        {
            public Team team { get; set; }
            public int goals { get; set; }
            public int shotsOnGoal { get; set; }
            public bool goaliePulled { get; set; }
            public int numSkaters { get; set; }
            public bool powerPlay { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Away1
        {
            public Team1 team { get; set; }
            public int goals { get; set; }
            public int shotsOnGoal { get; set; }
            public bool goaliePulled { get; set; }
            public int numSkaters { get; set; }
            public bool powerPlay { get; set; }
        }

        public class Team1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string link { get; set; }
        }

        public class Intermissioninfo
        {
            public int intermissionTimeRemaining { get; set; }
            public int intermissionTimeElapsed { get; set; }
            public bool inIntermission { get; set; }
        }

        public class Powerplayinfo
        {
            public int situationTimeRemaining { get; set; }
            public int situationTimeElapsed { get; set; }
            public bool inSituation { get; set; }
        }

        public class Period
        {
            public string periodType { get; set; }
            public DateTime startTime { get; set; }
            public DateTime endTime { get; set; }
            public int num { get; set; }
            public string ordinalNum { get; set; }
            public Home2 home { get; set; }
            public Away2 away { get; set; }
        }

        public class Home2
        {
            public int goals { get; set; }
            public int shotsOnGoal { get; set; }
            public string rinkSide { get; set; }
        }

        public class Away2
        {
            public int goals { get; set; }
            public int shotsOnGoal { get; set; }
            public string rinkSide { get; set; }
        }

    }
}