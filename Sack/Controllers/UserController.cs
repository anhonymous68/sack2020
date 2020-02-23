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

                List<User> userQueried = sqlConnection.Query<User>("Select * from dbo.users").ToList();

                foreach (User x in userQueried)
                {
                    UserOutput a = new UserOutput();
                    a.id = x.id;
                    a.name = x.name;
                    List<DateTime> dates = sqlConnection.Query<DateTime>("Select time from dbo.userTimeMap where id = " + a.id).ToList();
                    List<string> illness = sqlConnection.Query<string>("Select illnessId from dbo.userIllnessMap where userId =" + a.id).ToList();
                    a.illnesses = illness;
                    a.timeAvailable = dates;
                    result.Add(a);
                }


            }
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<UserOutput> GetUserById(int id)
        {
            UserOutput result = new UserOutput();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {

                User x = sqlConnection.Query<User>("Select * from dbo.users where id ="+id).ToList().FirstOrDefault();

                
                    UserOutput a = new UserOutput();
                    a.id = x.id;
                    a.name = x.name;
                    List<DateTime> dates = sqlConnection.Query<DateTime>("Select time from dbo.userTimeMap where id = " + a.id).ToList();
                    List<string> illness = sqlConnection.Query<string>("Select illnessId from dbo.userIllnessMap where userId =" + a.id).ToList();
                    a.illnesses = illness;
                    a.timeAvailable = dates;
                    return a;
                


            }
            return result;
        }
    }
}