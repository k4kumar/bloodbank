using bloodbank.DataAccess;
using bloodbank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bloodbank.Controllers
{
    public class DonationPostController : ApiController
    {
        [HttpPost]
        public IHttpActionResult AddDonationPost(DonationPost model)
        {
            if (model == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotAcceptable, message = "Please provide required data!", isSuccess = false });


            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    donationPost = DonationPostDataAccess.AddDonationPost(model)
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        public IHttpActionResult GetDonationPosts()
        {
            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    donationPosts = DonationPostDataAccess.GetDonationPosts()
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }
    }
}
