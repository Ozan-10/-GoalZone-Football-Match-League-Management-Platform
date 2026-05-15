using Microsoft.AspNetCore.Mvc;
using Project5Day.WebApi.Context;
using Project5Day.WebApi.Dtos;
using Project5Day.WebApi.Entities;

namespace Project5Day.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchController(ApiContext context)
        {
            _context = context;
        }

        // 🔥 MAÇ EKLEME
        [HttpPost]
        public IActionResult CreateMatch(CreateMatchDto dto)
        {
            var match = new Match
            {
                HomeTeamId = dto.HomeTeamId,
                AwayTeamId = dto.AwayTeamId,
                MatchDate = dto.MatchDate,
                Stadium = dto.Stadium,
                Status = 2, // NotStarted
                HomeScore = 0,
                AwayScore = 0
            };

            _context.Matches.Add(match);
            _context.SaveChanges();

            return Ok("Maç eklendi");
        }

        // 🔥 MAÇ LİSTELE
        [HttpGet]
        public IActionResult GetMatches()
        {
            var values = _context.Matches
                .Select(x => new
                {
                    x.MatchId,

                    HomeTeam = x.HomeTeam.TeamName,
                    AwayTeam = x.AwayTeam.TeamName,

                    HomeLogo = x.HomeTeam.LogoUrl,
                    AwayLogo = x.AwayTeam.LogoUrl,

                    x.MatchDate,
                    x.Stadium,

                    x.HomeScore,
                    x.AwayScore,

                    x.Week
                })
                .ToList();

            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetMatchById(int id)
        {
            var value = _context.Matches
                .Where(x => x.MatchId == id)
                .Select(x => new
                {
                    x.MatchId,

                    HomeTeam = x.HomeTeam.TeamName,
                    AwayTeam = x.AwayTeam.TeamName,

                    HomeLogo = x.HomeTeam.LogoUrl,
                    AwayLogo = x.AwayTeam.LogoUrl,

                    x.HomeScore,
                    x.AwayScore,

                    x.Stadium,
                    x.MatchDate,

                    x.Week
                }).FirstOrDefault();

            return Ok(value);
        }
    }
}