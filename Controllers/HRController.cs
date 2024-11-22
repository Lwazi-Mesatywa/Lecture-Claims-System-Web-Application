using CrystalDecisions.CrystalReports.Engine;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;

namespace Lecture_Claims_System_Web_Application.Controllers
{
    public class HRController : Controller
    {
        public IActionResult Report()
        {
            // Load the report
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(Server.MapPath("~/Reports/ClaimReport.rpt"));

            //  pass data from your claim repository to the report
            var acceptedClaims = ClaimRepository.Instance.AllClaims
                .Where(c => c.Status == "Accepted")
                .ToList();

            // setting data source for the report
            reportDocument.SetDataSource(acceptedClaims);

            //Create a Crystal Report viewer
            CrystalReportViewer reportViewer = new CrystalReportViewer
           {
               ReportSource = reportDocument
           };

            // Render the report on the view
            ViewBag.ReportViewer = reportViewer;

            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get all claims with the status of "Accepted"
            var acceptedClaims = ClaimRepository.Instance.AllClaims
                .Where(c => c.Status == "Accepted")
                .ToList();

            // Return the view with the accepted claims
            return View(acceptedClaims);
        }

        private class CrystalReportViewer
        {
        }
    }
}
