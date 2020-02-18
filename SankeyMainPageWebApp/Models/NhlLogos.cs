﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SankeyMainPageWebApp.Models
{
    public class NhlLogos
    {

        public class Rootobject
        {
            public Datum[] data { get; set; }
            public int total { get; set; }
        }

        public class Datum
        {
            public int id { get; set; }
            public int firstSeasonId { get; set; }
            public int? lastSeasonId { get; set; }
            public int mostRecentTeamId { get; set; }
            public string teamCommonName { get; set; }
            public string teamPlaceName { get; set; }
            public Team[] teams { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string active { get; set; }
            public string commonName { get; set; }
            public Conference conference { get; set; }
            public Division division { get; set; }
            public Franchiseteam[] franchiseTeam { get; set; }
            public string fullName { get; set; }
            public Logo[] logos { get; set; }
            public string placeName { get; set; }
            public string triCode { get; set; }
        }

        public class Conference
        {
            public string name { get; set; }
        }

        public class Division
        {
            public string name { get; set; }
        }

        public class Franchiseteam
        {
            public Firstseason firstSeason { get; set; }
            public Lastseason lastSeason { get; set; }
            public string teamCommonName { get; set; }
        }

        public class Firstseason
        {
            public int id { get; set; }
        }

        public class Lastseason
        {
            public int id { get; set; }
        }

        public class Logo
        {
            public int id { get; set; }
            public string background { get; set; }
            public int endSeason { get; set; }
            public string secureUrl { get; set; }
            public int startSeason { get; set; }
            public int teamId { get; set; }
            public string url { get; set; }
        }

    }
}