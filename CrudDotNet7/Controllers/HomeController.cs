using AutoMapper;
using CrudDotNet7.Models;
using CrudDotNet7.Models.Entities;
using CrudDotNet7.Models.ViewModels;
using CrudDotNet7.Profiles;
using CrudDotNet7.Repository.Interfacess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudDotNet7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, IUserRepository user, IMapper mapper)
        {
            _logger = logger;
            _userRepository = user;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var user = _mapper.Map<List<UserListViewModel>>(users);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] User id)
        {
            var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id.ToString());
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = "asa";
            // Update other properties as needed

            return NoContent();
        }

        //public async Task<IActionResult> Edit()
        //{
        //    var users = await _userRepository.GetAll();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}