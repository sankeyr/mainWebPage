using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SankeyMainPageWebApp.Models
{
    public class HomeTeamAwayTeamStats
    {
        public string HomeTeamWins { get; set; }
        public string AwayTeamWins { get; set; }
        public string HomeTeamLoses { get; set; }
        public string AwayTeamLoses { get; set; }
        public string HomeTeamOt { get; set; }
        public string AwayTeamOt { get; set; }
        public int HomeTeamPoints { get; set; }
        public int AwayTeamPoints { get; set; }
        public int HomePowerPlayPercentage { get; set; }
        public int AwayPowerPlayPercentage { get; set; }
        public int HomePowerPlayGoals { get; set; }
        public int AwayPowerPlayGoals { get; set; }
        public int HomePowerPlayGoalsAgainst { get; set; }
        public int AwayPowerPlayGoalsAgainst { get; set; }
        public int HomeShotsPerGame { get; set; }
        public int AwayShotsPerGame { get; set; }
        public int HomeWinScoreFirst { get; set; }
        public int AwayWinScoreFirst { get; set; }
        public int HomeWinLeadFirstPer { get; set; }
        public int AwayWinLeadFirstPer { get; set; }
        public int HomeWinLeadSecondPer { get; set; }
        public int AwayWinLeadSecondPer { get; set; }
        public int HomeFaceOffsWon { get; set; }
        public int AwayFaceOffsWon { get; set; }
        public int HomeDivisionRank { get; set; }
        public int HomeConferenceRank { get; set; }
        public int HomeLeagueRank { get; set; }

        public int AwayDivisionRank { get; set; }
        public int AwayConferenceRank { get; set; }
        public int AwayLeagueRank { get; set; }

        public string HomePowerPlayPercentageStr { get; set; }
        public string AwayPowerPlayPercentageStr { get; set; }
        public string HomePowerPlayGoalsStr { get; set; }
        public string AwayPowerPlayGoalsStr { get; set; }
        public string HomePowerPlayGoalsAgainstStr { get; set; }
        public string AwayPowerPlayGoalsAgainstStr { get; set; }
        public string HomeShotsPerGameStr { get; set; }
        public string AwayShotsPerGameStr { get; set; }
        public string HomeWinScoreFirstStr { get; set; }
        public string AwayWinScoreFirstStr { get; set; }
        public string HomeWinLeadFirstPerStr { get; set; }
        public string AwayWinLeadFirstPerStr { get; set; }
        public string HomeWinLeadSecondPerStr { get; set; }
        public string AwayWinLeadSecondPerStr { get; set; }
        public string HomeFaceOffsWonStr { get; set; }
        public string AwayFaceOffsWonStr { get; set; }
        public string DivisionRankStr { get; set; }
        public string ConferenceRankStr { get; set; }
        public string LeagueRankStr { get; set; }
    }
}