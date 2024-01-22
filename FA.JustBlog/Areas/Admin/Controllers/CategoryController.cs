using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Core;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin/Category
        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_categoryService.GetAll());
        }

        // GET: Admin/Category/Details/5
        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("/{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Category/Create
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,UrlSlug,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Add(category);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpGet("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost("edit/{id?}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,UrlSlug,Description")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.Update(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpGet("delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.Find(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpPost("delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //if (_context.Categories == null)
            //{
            //    return Problem("Entity set 'JustBlogContext.Categories'  is null.");
            //}
            var category = _categoryService.Find(id);
            if (category != null)
            {
                _categoryService.Remove(category);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _categoryService.Find(id) != null;
        }
    }
}
