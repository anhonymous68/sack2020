using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Sack.Models;
using System.Data.SqlClient;

namespace Sack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private string _connectionString = "Data Source=therapist.database.windows.net,1433;Initial Catalog=therapist;User Id=sac;Password=Hack2020;";

        [HttpGet]
        public ActionResult<IEnumerable<UserOutput>> Get()
        {
            List<UserOutput> result = new List<UserOutput>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                List<Therapist> userQueried = sqlConnection.Query<Therapist>("Select * from dbo.therapist").ToList();

                foreach (Therapist x in userQueried)
                {
                    UserOutput a = new UserOutput();
                    a.id = x.id;
                    a.name = x.name;
                    List<DateTime> dates = sqlConnection.Query<DateTime>("Select time from dbo.therapistTimeMap where id = " + a.id).ToList();
                    List<string> illness = sqlConnection.Query<string>("Select specialtyId from dbo.therapistIllnessMap where therapistId =" + a.id).ToList();
                    a.illnesses = illness;
                    a.timeAvailable = dates;
                    result.Add(a);
                }


            }
            return result;
        }
    }
}
