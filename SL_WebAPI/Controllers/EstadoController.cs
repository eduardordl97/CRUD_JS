using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{
    public class EstadoController : ApiController
    {
        // GET: api/Estado
        [Route("api/estado")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Estado.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }



        // POST: api/Estado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Estado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Estado/5
        public void Delete(int id)
        {
        }
    }
}
