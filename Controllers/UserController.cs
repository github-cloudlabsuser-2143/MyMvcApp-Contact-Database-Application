using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers;

public class UserController : Controller
{
    //    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
    public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>
    {
        new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
        new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
    };
    // GET: User
    public ActionResult Index(string name)
    {
        // // Return the list of users to the Index view
        // return View(userlist);
        // If a search term is provided, filter the user list
        var filteredUsers = string.IsNullOrEmpty(name)
            ? userlist
            : userlist.Where(u => u.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        return View(filteredUsers); // Pass the filtered list to the view
    }

    // GET: User/Details/5
    public ActionResult Details(int id)
    {
        // Find the user by ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return 404 if user not found
        }
        return View(user); // Pass the user to the Details view
    }

    // GET: User/Create
    public ActionResult Create()
    {
        // Return the Create view
        return View();
    }

    // POST: User/Create
    [HttpPost]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            // Generate a unique ID for the new user
            user.Id = userlist.Count > 0 ? userlist.Max(u => u.Id) + 1 : 1;

            // Add the new user to the list
            userlist.Add(user);
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }
        return View(user); // Return the Create view with validation errors
    }

    // GET: User/Edit/5
    public ActionResult Edit(int id)
    {
        // Find the user by ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return 404 if user not found
        }
        return View(user); // Pass the user to the Edit view
    }

    // POST: User/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, User user)
    {
        if (ModelState.IsValid)
        {
            // Find the existing user by ID
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound(); // Return 404 if user not found
            }

            // Update the user's properties
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
        }
        return View(user); // Return the Edit view with validation errors
    }

    // GET: User/Delete/5
    public ActionResult Delete(int id)
    {
        // Find the user by ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return 404 if user not found
        }
        return View(user); // Pass the user to the Delete view
    }

    // POST: User/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        // Find the user by ID
        var user = userlist.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(); // Return 404 if user not found
        }

        // Remove the user from the list
        userlist.Remove(user);

        return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
    }
}
