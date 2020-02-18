using Newtonsoft.Json;
using SankeyMainPageWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SankeyMainPageWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeTeamAwayTeam htat = GetHomeAndAwayTeamId();
            string htId = htat.HomeTeamId;
            string atId = htat.AwayTeamId;
            HomeTeamAwayTeamStats htats = new HomeTeamAwayTeamStats();

            TeamStanding.Rootobject teamStanding = GetTeamStanding();

            //HOME TEAM

            string teamStatsUrl = "https://statsapi.web.nhl.com/api/v1/teams/" + htId + "/stats";
            Uri address = new Uri(teamStatsUrl);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            // Create the web request 
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST 
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output 
                string strOutputJson = FormatJson(reader.ReadToEnd());
                strOutputJson.Trim('{');
                strOutputJson.Trim('}');

                var data = JsonConvert.DeserializeObject<TeamStatsFull.Rootobject>(strOutputJson);

                
                htats.HomeTeamWins = data.stats[0].splits[0].stat.wins.ToString();
                htats.HomeTeamLoses = data.stats[0].splits[0].stat.losses.ToString();
                htats.HomeTeamOt = data.stats[0].splits[0].stat.ot.ToString();
                htats.HomeTeamPoints = Convert.ToInt32(data.stats[0].splits[0].stat.pts);

                char[] MyChar = { 't', 'h', 's', 'n', 'd', 'r'};
                htats.HomePowerPlayPercentage = Convert.ToInt32(data.stats[1].splits[0].stat.powerPlayPercentage.ToString().TrimEnd(MyChar));
                htats.HomePowerPlayGoals = Convert.ToInt32(data.stats[1].splits[0].stat.powerPlayGoals.ToString().TrimEnd(MyChar));
                htats.HomePowerPlayGoalsAgainst = Convert.ToInt32(data.stats[1].splits[0].stat.powerPlayGoalsAgainst.ToString().TrimEnd(MyChar));
                htats.HomeShotsPerGame = Convert.ToInt32(data.stats[1].splits[0].stat.shotsPerGame.ToString().TrimEnd(MyChar));
                htats.HomeWinScoreFirst = Convert.ToInt32(data.stats[1].splits[0].stat.winScoreFirst.ToString().TrimEnd(MyChar));
                htats.HomeWinLeadFirstPer = Convert.ToInt32(data.stats[1].splits[0].stat.winLeadFirstPer.ToString().TrimEnd(MyChar));
                htats.HomeWinLeadSecondPer = Convert.ToInt32(data.stats[1].splits[0].stat.winLeadSecondPer.ToString().TrimEnd(MyChar));
                htats.HomeFaceOffsWon = Convert.ToInt32(data.stats[1].splits[0].stat.faceOffsWon.ToString().TrimEnd(MyChar));

                htats.HomePowerPlayPercentageStr = data.stats[1].splits[0].stat.powerPlayPercentage;
                htats.HomePowerPlayGoalsStr = data.stats[1].splits[0].stat.powerPlayGoals.ToString();
                htats.HomePowerPlayGoalsAgainstStr = data.stats[1].splits[0].stat.powerPlayGoalsAgainst.ToString();
                htats.HomeShotsPerGameStr = data.stats[1].splits[0].stat.shotsPerGame.ToString();
                htats.HomeWinScoreFirstStr = data.stats[1].splits[0].stat.winScoreFirst.ToString();
                htats.HomeWinLeadFirstPerStr = data.stats[1].splits[0].stat.winLeadFirstPer.ToString();
                htats.HomeWinLeadSecondPerStr = data.stats[1].splits[0].stat.winLeadSecondPer.ToString();
                htats.HomeFaceOffsWonStr = data.stats[1].splits[0].stat.faceOffsWon.ToString();

                foreach (var tr in teamStanding.records.SelectMany(div => div.teamRecords.Where(tr => tr.team.id.ToString() == htId)))
                {
                    //create string versions
                    htats.HomeDivisionRank = Convert.ToInt32(tr.divisionRank);
                    htats.HomeConferenceRank = Convert.ToInt32(tr.conferenceRank);
                    htats.HomeLeagueRank = Convert.ToInt32(tr.leagueRank);
                }
            }


            //AWAY TEAM

            teamStatsUrl = "https://statsapi.web.nhl.com/api/v1/teams/" + atId + "/stats";
            address = new Uri(teamStatsUrl);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            // Create the web request 
            request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST 
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output 
                string strOutputJson = FormatJson(reader.ReadToEnd());
                strOutputJson.Trim('{');
                strOutputJson.Trim('}');

                var data = JsonConvert.DeserializeObject<TeamStatsFull.Rootobject>(strOutputJson);


                htats.AwayTeamWins = data.stats[0].splits[0].stat.wins.ToString();
                htats.AwayTeamLoses = data.stats[0].splits[0].stat.losses.ToString();
                htats.AwayTeamOt = data.stats[0].splits[0].stat.ot.ToString();
                htats.AwayTeamPoints = Convert.ToInt32(data.stats[0].splits[0].stat.pts);

                char[] MyChar = { 't', 'h', 's', 'n', 'd', 'r' };
                htats.AwayPowerPlayPercentage = Convert.ToInt32(data.stats[1].splits[0].stat.powerPlayPercentage.ToString().TrimEnd(MyChar));
                htats.AwayPowerPlayGoals = Convert.ToInt32(data.stats[1].splits[0].stat.powerPlayGoals.ToString().TrimEnd(MyChar));
                htats.AwayPowerPlayGoalsAgainst = Convert.ToInt32(data.stats[1].splits[0].stat.powerPlayGoalsAgainst.ToString().TrimEnd(MyChar));
                htats.AwayShotsPerGame = Convert.ToInt32(data.stats[1].splits[0].stat.shotsPerGame.ToString().TrimEnd(MyChar));
                htats.AwayWinScoreFirst = Convert.ToInt32(data.stats[1].splits[0].stat.winScoreFirst.ToString().TrimEnd(MyChar));
                htats.AwayWinLeadFirstPer = Convert.ToInt32(data.stats[1].splits[0].stat.winLeadFirstPer.ToString().TrimEnd(MyChar));
                htats.AwayWinLeadSecondPer = Convert.ToInt32(data.stats[1].splits[0].stat.winLeadSecondPer.ToString().TrimEnd(MyChar));
                htats.AwayFaceOffsWon = Convert.ToInt32(data.stats[1].splits[0].stat.faceOffsWon.ToString().TrimEnd(MyChar));

                htats.AwayPowerPlayPercentageStr = data.stats[1].splits[0].stat.powerPlayPercentage;
                htats.AwayPowerPlayGoalsStr = data.stats[1].splits[0].stat.powerPlayGoals.ToString();
                htats.AwayPowerPlayGoalsAgainstStr = data.stats[1].splits[0].stat.powerPlayGoalsAgainst.ToString();
                htats.AwayShotsPerGameStr = data.stats[1].splits[0].stat.shotsPerGame.ToString();
                htats.AwayWinScoreFirstStr = data.stats[1].splits[0].stat.winScoreFirst.ToString();
                htats.AwayWinLeadFirstPerStr = data.stats[1].splits[0].stat.winLeadFirstPer.ToString();
                htats.AwayWinLeadSecondPerStr = data.stats[1].splits[0].stat.winLeadSecondPer.ToString();
                htats.AwayFaceOffsWonStr = data.stats[1].splits[0].stat.faceOffsWon.ToString();

                foreach (var tr in teamStanding.records.SelectMany(div => div.teamRecords.Where(tr => tr.team.id.ToString() == atId)))
                {
                    //create string versions
                    htats.AwayDivisionRank = Convert.ToInt32(tr.divisionRank);
                    htats.AwayConferenceRank = Convert.ToInt32(tr.conferenceRank);
                    htats.AwayLeagueRank = Convert.ToInt32(tr.leagueRank);
                }

                
            }

            return View(htats);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected static string FormatJson(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        public string GetAvsScheduleInfo()
        {
            string AvsInfoUrl = "https://statsapi.web.nhl.com/api/v1/teams/21?expand=team.schedule.next";
            string nextGameDate = string.Empty;
            AvsGameInfo avsGameInfo = new AvsGameInfo();
            var homeTeamLogoUrl = string.Empty;
            var awayTeamLogoUrl = string.Empty;
            var homeTeamId = 0;
            var awayTeamId = 0;
            var awayTeamScore = string.Empty;
            var homeTeamScore = string.Empty;
            var liveSteamId = string.Empty;

            Uri address = new Uri(AvsInfoUrl);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            // Create the web request 
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST 
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output 
                string strOutputJson = FormatJson(reader.ReadToEnd());
                strOutputJson.Trim('{');
                strOutputJson.Trim('}');

                var data = JsonConvert.DeserializeObject<AvsScheduleInfo.RootObject>(strOutputJson);
                //Mon Feb 17 2020 20:56:12 GMT-0700 (Mountain Standard Time)
                nextGameDate = data.teams[0].nextGameSchedule.dates[0].games[0].gameDate.ToLocalTime().ToString("ddd MMM dd yyy HH:mm:ss 'GMT-0700'");
                homeTeamId = data.teams[0].nextGameSchedule.dates[0].games[0].teams.home.team.id;
                awayTeamId = data.teams[0].nextGameSchedule.dates[0].games[0].teams.away.team.id;
                homeTeamScore = data.teams[0].nextGameSchedule.dates[0].games[0].teams.home.score.ToString();
                awayTeamScore = data.teams[0].nextGameSchedule.dates[0].games[0].teams.away.score.ToString();
                liveSteamId = data.teams[0].nextGameSchedule.dates[0].games[0].gamePk.ToString();


            }

            NhlLogos.Rootobject nhlLogo = getTeamLogoUrl();
            homeTeamLogoUrl = nhlLogo.data.Where(x => x.mostRecentTeamId == homeTeamId).FirstOrDefault().teams[0].logos.LastOrDefault().secureUrl;
            awayTeamLogoUrl = nhlLogo.data.Where(x => x.mostRecentTeamId == awayTeamId).FirstOrDefault().teams[0].logos.LastOrDefault().secureUrl;

            HomeTeamAwayTeamSog htatSog = GetHomeTeamAwayTeamSog(liveSteamId);

            

            avsGameInfo.GameTimeStart = nextGameDate;
            avsGameInfo.AwayLogoUrl = awayTeamLogoUrl;
            avsGameInfo.HomeLogoUrl = homeTeamLogoUrl;
            avsGameInfo.HomeScore = homeTeamScore;
            avsGameInfo.AwayScore = awayTeamScore;
            avsGameInfo.AwaySog = htatSog.AwayTeamSog;
            avsGameInfo.HomeSog = htatSog.HomeTeamSog;

            return JsonConvert.SerializeObject(avsGameInfo);
        }

        public HomeTeamAwayTeamSog GetHomeTeamAwayTeamSog(string liveFeedId)
        {
            var urlInfo = "https://statsapi.web.nhl.com/api/v1/game/" + liveFeedId + "/linescore"; 

            Uri address = new Uri(urlInfo);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            // Create the web request 
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST 
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output 
                string strOutputJson = FormatJson(reader.ReadToEnd());
                strOutputJson.Trim('{');
                strOutputJson.Trim('}');

                var data = JsonConvert.DeserializeObject<HomeTeamAwayTeamLinescore.Rootobject>(strOutputJson);

                HomeTeamAwayTeamSog htatSog = new HomeTeamAwayTeamSog();
                htatSog.AwayTeamSog = data.teams.away.shotsOnGoal.ToString();
                htatSog.HomeTeamSog = data.teams.home.shotsOnGoal.ToString();
                return htatSog;
            }
            
        }

        public TeamStanding.Rootobject GetTeamStanding()
        {
            string AvsInfoUrl = "https://statsapi.web.nhl.com/api/v1/standings";

            Uri address = new Uri(AvsInfoUrl);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            // Create the web request 
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST 
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output 
                string strOutputJson = FormatJson(reader.ReadToEnd());
                strOutputJson.Trim('{');
                strOutputJson.Trim('}');

                var data = JsonConvert.DeserializeObject<TeamStanding.Rootobject>(strOutputJson);

                return data;
            }
        }
        public NhlLogos.Rootobject getTeamLogoUrl()
        {
            //string NhlLogoUrl = "https://records.nhl.com/site/api/franchise?include=teams.id&include=teams.logos;

            //Uri address = new Uri(NhlLogoUrl);

            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
            //       | SecurityProtocolType.Tls11
            //       | SecurityProtocolType.Tls12
            //       | SecurityProtocolType.Ssl3;
            //// Create the web request 
            //HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            //// Set type to POST 
            //request.Method = "GET";
            //request.ContentType = "text/xml";

            //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            //{
            //    // Get the response stream 
            //    StreamReader reader = new StreamReader(response.GetResponseStream());

            //    // Console application output 
            //    string strOutputJson = FormatJson(reader.ReadToEnd());
            //    strOutputJson.Trim('{');
            //    strOutputJson.Trim('}');


            //    //dynamic jsonObj = JsonConvert.DeserializeObject(strOutputJson);
            //    var data = JsonConvert.DeserializeObject<NhlLogos.Rootobject>(strOutputJson);

            //    return data;
            //}

            string subfoldername = "Content";
            string filename = "NhlLogos.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, subfoldername, filename);

            using (StreamReader r = new StreamReader(filePath))
            {
                var json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<NhlLogos.Rootobject>(json);

                return data;
            }
        }

        public HomeTeamAwayTeam GetHomeAndAwayTeamId()
        {
            string AvsInfoUrl = "https://statsapi.web.nhl.com/api/v1/teams/21?expand=team.schedule.next";

            Uri address = new Uri(AvsInfoUrl);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            // Create the web request 
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST 
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream 
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output 
                string strOutputJson = FormatJson(reader.ReadToEnd());
                strOutputJson.Trim('{');
                strOutputJson.Trim('}');

                var data = JsonConvert.DeserializeObject<AvsScheduleInfo.RootObject>(strOutputJson);

                HomeTeamAwayTeam homeTeamAwayTeam = new HomeTeamAwayTeam();
                homeTeamAwayTeam.HomeTeamId = data.teams[0].nextGameSchedule.dates[0].games[0].teams.home.team.id.ToString();
                homeTeamAwayTeam.AwayTeamId = data.teams[0].nextGameSchedule.dates[0].games[0].teams.away.team.id.ToString();

                return homeTeamAwayTeam;
            }
        }
    }
}