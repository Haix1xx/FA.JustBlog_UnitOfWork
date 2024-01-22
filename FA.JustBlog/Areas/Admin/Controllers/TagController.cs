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
    [Route("admin/tag")]
    public class TagController : Controller
    {
        //private readonly JustBlogContext _context;
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [Authorize(Roles = "Contributor,Blog Owner,User")]
        // GET: Admin/Tag
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewData["Title"] = "All Tags";
            return View(_tagService.GetAll());
        }

        // GET: Admin/Tag/Details/5
        [Authorize(Roles = "Contributor,Blog Owner,User")]
        [HttpGet("{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _tagService.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Admin/Tag/Create
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,UrlSlug,Description,Count")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _tagService.Add(tag);
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: Admin/Tag/Edit/5
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpGet("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _tagService.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        // POST: Admin/Tag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Contributor,Blog Owner")]
        [HttpPost("edit/{id?}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,UrlSlug,Description,Count")] Tag tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _tagService.Update(tag);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.Id))
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
            return View(tag);
        }

        // GET: Admin/Tag/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpGet("delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _tagService.Find(id.Value);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Admin/Tag/Delete/5
        [Authorize(Roles = "Blog Owner")]
        [HttpPost("delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            //if (_context.Tags == null)
            //{
            //    return Problem("Entity set 'JustBlogContext.Tags'  is null.");
            //}
            var tag = _tagService.Find(id);
            if (tag != null)
            {
                _tagService.Remove(tag);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return _tagService.Find(id) != null;
        }
    }
}
