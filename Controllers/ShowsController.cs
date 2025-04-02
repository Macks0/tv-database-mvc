using Microsoft.AspNetCore.Mvc;
using TV_Show_Database.Models; // For AddShowViewModel
using TV_Show_Database.Data; // For ApplicationDbContext
using TV_Show_Database.Models.Entities;
using Microsoft.EntityFrameworkCore; // For Show entity
namespace TV_Show_Database.Controllers
{
    public class ShowsController : Controller
    {

        private readonly ApplicationDbContext dbContext;
        public ShowsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddShowViewModel viewModel)
        {
            var show = new Show
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                ReleaseYear = viewModel.ReleaseYear,
                Rating = viewModel.Rating,
                Recommend = viewModel.Recommend
            };

            await dbContext.Shows.AddAsync(show);
            await dbContext.SaveChangesAsync(); // Save changes to the database

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var shows = await dbContext.Shows.ToListAsync();
            return View(shows);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var show = await dbContext.Shows.FindAsync(id); // Find the show by id

            return View(show);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Show viewModel)
        {
            var show = await dbContext.Shows.FindAsync(viewModel.Id); // Find the show by id
            if (show is not null)
            {
                show.Title = viewModel.Title;
                show.Genre = viewModel.Genre;
                show.ReleaseYear = viewModel.ReleaseYear;
                show.Title = viewModel.Title;
                show.Rating = viewModel.Rating;
                show.Recommend = viewModel.Recommend;
                await dbContext.SaveChangesAsync(); // Save changes to the database
            }
            return RedirectToAction("List", "Shows"); // Redirect to the list of shows after editing
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Show viewModel)
        {
            var student = await dbContext.Shows
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id); // Find the student by id
            if (student is not null)
            {
                dbContext.Shows.Remove(viewModel);
                dbContext.SaveChangesAsync(); // Save changes to the database
            }
            return RedirectToAction("List", "Shows"); // Redirect to the list of shows after deleting
        }

    }
}
