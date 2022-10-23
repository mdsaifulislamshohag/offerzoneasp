using System;
using System.Collections.Generic;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OfferZoneAsp.Models;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Tables;
using System.Data;
using Syncfusion.HtmlConverter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace OfferZoneAsp.Controllers
{

    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly ILogger<HomeController> _logger;
        private readonly OfferContext _context;
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, RoleManager<ApplicationRole> _roleManager, IWebHostEnvironment _hostingEnvironment, OfferContext context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            hostingEnvironment = _hostingEnvironment;
            _context = context;
            _logger = logger;
        }
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            //var admin = roleManager.FindByNameAsync("admin").Result;

            if (!signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
               
                dynamic mymodel = new ExpandoObject();
                mymodel.Offers = await _context.Offers.ToListAsync();
                mymodel.Categories = await _context.Categories.ToListAsync();
                mymodel.Ratings = await _context.Ratings .ToListAsync();
                mymodel.ApplicationUsers = await _context.ApplicationUsers.ToListAsync();
                mymodel.recentThreeOffers = _context.Offers.OrderByDescending(x => x.CreatedAt).Take(3);
                return View(mymodel);
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GenerateReport()
        {
            //var myOffers = await _context.Offers.ToListAsync();
            //var myCategories = await _context.Categories.ToListAsync();
            //var myRatings = await _context.Ratings.ToListAsync();
            //var myApplicationUsers = await _context.ApplicationUsers.ToListAsync();
            //var myRecentThreeOffers = _context.Offers.OrderByDescending(x => x.CreatedAt).Take(3);
            ////Create a new PDF document
            //PdfDocument doc = new PdfDocument();

            ////Add a page to the document
            //PdfPage page = doc.Pages.Add();

            //PdfGrid pdfGrid = new PdfGrid();
            ////Add values to list
            //List<object> data = new List<object>();
            //var row1 = new { Total_Users = myApplicationUsers.Count };
            //var row2 = new { Total_Ratings = myRatings.Count };
            //var row3 = new { Total_Offers = myApplicationUsers.Count };
            //var row4 = new { Total_Categories = myApplicationUsers.Count };
            //data.Add(row1);
            //data.Add(row2);
            //data.Add(row3);
            //data.Add(row4);
            ////Add list to IEnumerable
            //IEnumerable<object> dataTable = data;
            ////Assign data source.
            //pdfGrid.DataSource = dataTable;
            ////Draw grid to the page of PDF document.
            //pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 10));
            ////Save the PDF document to stream
            //MemoryStream stream = new MemoryStream();
            //doc.Save(stream);
            ////If the position is not set to '0' then the PDF will be empty.
            //stream.Position = 0;
            ////Close the document.
            //doc.Close(true);
            ////Defining the ContentType for pdf file.
            //string contentType = "application/pdf";
            ////Define the file name.
            //string fileName = "Output.pdf";
            ////Creates a FileContentResult object by using the file contents, content type, and file name.
            //return File(stream, contentType, fileName);
            //Initialize the HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();

            WebKitConverterSettings settings = new WebKitConverterSettings();

            //Set WebKit path
            settings.WebKitPath = @"\QtBinariesDotNetCore\";

            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;

            //Convert URL to PDF
            PdfDocument document = htmlConverter.Convert("https://localhost:5001/home");

            FileStream fileStream = new FileStream("Sample.pdf", FileMode.CreateNew, FileAccess.ReadWrite);

            //Save and close the PDF document 
            document.Save(fileStream);
            document.Close(true);
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}