using CrystalDecisions.CrystalReports.Engine;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Lecture_Claims_System_Web_Application.Controllers
{
    public class HRController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IActionResult Report()
        {
            // Load the report
            ReportDocument reportDocument = new ReportDocument();

            // Get the path of the Crystal Report file
            string reportPath = System.IO.Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "ClaimReport.rpt");
            reportDocument.Load(reportPath);

            //  pass data from your claim repository to the report
            var acceptedClaims = ClaimRepository.Instance.AllClaims
                .Where(c => c.Status == "Accepted")
                .ToList();

            reportDocument.SetDataSource(acceptedClaims);

            // Export to a temporary file (PDF for demonstration)
            var stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            // Return the report as a PDF file
            return File(stream, "application/pdf", "AcceptedClaimsReport.pdf");
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
