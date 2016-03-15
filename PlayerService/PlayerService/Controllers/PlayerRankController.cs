using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using PlayerService.DataObjects;
using PlayerService.Models;
using System;

namespace PlayerService.Controllers
{
    public class PlayerRankController : TableController<PlayerRank>
    {
        MobileServiceContext context = new MobileServiceContext();

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);            
            DomainManager = new EntityDomainManager<PlayerRank>(context, Request, Services);
        }

        // GET tables/PlayerRank
        public IQueryable<PlayerRankDto> GetAllPlayerRank()
        {
            return Query().Select( x =>new PlayerRankDto()
            {
                Id = x.Id,
                PlayerName = x.Player.Name,
                Rank = x.Rank,
                Score = x.Score
            }); 
        }

        // GET tables/PlayerRank/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PlayerRankDto> GetPlayerRank(string id)
        {
            var result = Lookup(id).Queryable.Select(x => new PlayerRankDto()
            {
                Id = x.Id,
                PlayerName = x.Player.Name,
                Rank = x.Rank,
                Score = x.Score
            });
            return SingleResult<PlayerRankDto>.Create(result);
        }

        [Route("api/score")]
        public async Task<IHttpActionResult> PostPlayerScore(PlayerScore score)
        {
            // Does this player exist?
            var count = context.Players.Where(x => x.Id == score.PlayerId).Count();
            if (count < 1)
            {
                return BadRequest();
            }

            // Try to find the PlayerRank entity for this player. If not found, create a new one.
            PlayerRank rank = await context.PlayerRanks.FindAsync(score.PlayerId);
            if (rank == null)
            {
                rank = new PlayerRank { Id = score.PlayerId };
                rank.Score = score.Score;
                context.PlayerRanks.Add(rank);
            }
            else
            {
                rank.Score = score.Score;
            }

            await context.SaveChangesAsync();

            // Update rankings
            // See http://stackoverflow.com/a/575799
            const string updateCommand =
                "UPDATE r SET Rank = ((SELECT COUNT(*)+1 from {0}.PlayerRanks " +
                "where Score > (select score from {0}.PlayerRanks where Id = r.Id)))" +
                "FROM {0}.PlayerRanks as r";

            string command = String.Format(updateCommand, ServiceSettingsDictionary.GetSchemaName());
            await context.Database.ExecuteSqlCommandAsync(command);

            return Ok();
        }



    }
}