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
    public class BloodDonorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Registration(BloodDonorViewModel model)
        {
            if (model == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotAcceptable, message = "Please provide required data!", isSuccess = false });

            if (BloodDonorDataAccess.CheckDonorExist(model.RegNo))
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.Ambiguous, message = "Please provide unique registration number!", isSuccess = false });


            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    id = BloodDonorDataAccess.RegisterBloodDonor(model)
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        public IHttpActionResult GetActiveBloodDonors()
        {
            var bloodDonors = BloodDonorDataAccess.GetActiveBloodDonorsList();
            if (bloodDonors == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor list not found!", isSuccess = false });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    blooddonors = bloodDonors
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        public IHttpActionResult GetBloodDonors()
        {
            var bloodDonors = BloodDonorDataAccess.GetBloodDonorsList();
            if (bloodDonors == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor list not found!", isSuccess = false });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    blooddonors = bloodDonors
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        public IHttpActionResult GetBloodDonor(string username)
        {
            BloodDonorViewModel bloodDonor = BloodDonorDataAccess.GetBloodDonor(username);
            if (bloodDonor == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor list not found!", isSuccess = false });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    bloodDonor = bloodDonor
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        [HttpPost]
        public IHttpActionResult UpdateBloodDonor(BloodDonorViewModel model)
        {
            BloodDonorViewModel bloodDonor = BloodDonorDataAccess.UpdateBloodDonor(model);
            if (bloodDonor == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor not found!", isSuccess = false });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    blooddonor = bloodDonor
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        [HttpPost]
        public IHttpActionResult Approve(BloodDonor model)
        {
            BloodDonor bloodDonor = BloodDonorDataAccess.ApproveDonor(model.Id);
            if (bloodDonor == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor not found!", isSuccess = false });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    blooddonor = bloodDonor
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        public IHttpActionResult UpdateDonationDate(int id, DateTime date)
        {
            BloodDonor bloodDonor = BloodDonorDataAccess.LastDonationDateUpdate(id,date);
            if (bloodDonor == null)
                return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor not found!", isSuccess = false });

            return Content(HttpStatusCode.OK, new
            {
                data = new
                {
                    blooddonor = bloodDonor
                },
                code = HttpStatusCode.OK,
                message = "success",
                isSuccess = true
            });
        }

        //public IHttpActionResult App()
        //{
        //    var bloodDonors = BloodDonorDataAccess.GetBloodDonorsList();
        //    if (bloodDonors == null)
        //        return Content(HttpStatusCode.OK, new { data = new { }, code = HttpStatusCode.NotFound, message = "Donor not found!", isSuccess = false });

        //    return Content(HttpStatusCode.OK, new
        //    {
        //        data = new
        //        {
        //            blooddonors = BloodDonorDataAccess.GetBloodDonorsList()
        //        },
        //        code = HttpStatusCode.OK,
        //        message = "success",
        //        isSuccess = true
        //    });
        //}
    }
}
