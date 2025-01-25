using Microsoft.AspNetCore.Mvc;
using YallaShopping.DataAccess.Repository;
using YallaShopping.DataAccess.Repository.IRepository;
using YallaShopping.Models;
using PagedList;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using YallaShopping.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using YallaShopping.Utility;

namespace YallaShopping_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> companies = _unitOfWork.Company.GetAll().ToList();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create_Update(int? id)
        {
           
            if (id == null || id == 0)
            {
                //Create
                return View(new Company());
            }
            else
            {
                //Update
                Company company = _unitOfWork.Company.Get(p=>p.Id==id);
                return View(company);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create_Update(Company company)
        {
            if (ModelState.IsValid)
            {
               
                if (company.Id == 0)
                {
                    _unitOfWork.Company.Add(company);
                }
                else
                {
                    _unitOfWork.Company.Update(company);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company Updated Successfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(company);
            }

            
        }
        #region NewEdit
        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    CompanyVM CompanyVM = new()
        //    {
        //        CategoryList = _unitOfWork.Category.GetAll()
        //            .Select(l => new SelectListItem
        //            {
        //                Text = l.Name,
        //                Value = l.Id.ToString()
        //            }),
        //        Company = _unitOfWork.Company.Get(p => p.Id == id)
        //    };

        //    if (CompanyVM.Company == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(CompanyVM);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(CompanyVM CompanyVM)
        //{
        //    if (CompanyVM.Company == null || CompanyVM.Company.Id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var originalCompany = _unitOfWork.Company.Get(p => p.Id == CompanyVM.Company.Id);

        //    if (originalCompany == null)
        //    {
        //        return NotFound();
        //    }

        //    var CompanyWithSameName = _unitOfWork.Company.Get(p => p.Title == CompanyVM.Company.Title && p.Id != CompanyVM.Company.Id);

        //    if (CompanyWithSameName != null)
        //    {
        //        ModelState.AddModelError("Company.Title", $"The Company Name '{CompanyVM.Company.Title}' is already taken");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Company.Update(CompanyVM.Company);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company Updated Successfully";
        //        return RedirectToAction("Index");
        //    }

        //    // Re-populate CategoryList if ModelState is not valid
        //    CompanyVM.CategoryList = _unitOfWork.Category.GetAll()
        //        .Select(l => new SelectListItem
        //        {
        //            Text = l.Name,
        //            Value = l.Id.ToString()
        //        });

        //    return View(CompanyVM);
        //}
        #endregion
        #region OldEdit
        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();


        //    CompanyVM CompanyVM = new()
        //    {
        //        CategoryList = _unitOfWork.Category.GetAll()
        //           .Select(l => new SelectListItem
        //           {
        //               Text = l.Name,
        //               Value = l.Id.ToString()
        //           }),
        //        Company = _unitOfWork.Company.Get(p => p.Id == id)
        //    };
        //    if (CompanyVM.Company == null)
        //        return NotFound();
        //    return View(CompanyVM);
        //}
        //[HttpPost]
        //public IActionResult Edit(CompanyVM Company)
        //{
        //    Company? originalCompany = _unitOfWork.Company.Get(p => p.Id == Company.Company.Id);

        //    if (originalCompany == null)
        //        return NotFound();

        //    if (_unitOfWork.Company.Get(p => p.Title == Company.Company.Title) != null)
        //    {
        //        ModelState.AddModelError("Company.Title", $"The Company Name '{Company.Company.Title}' is already taken");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Company.Update(Company.Company);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Company Updated Successfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View("Edit", Company);
        //}
        #endregion
        #region Delete
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();
        //    Company? selectedCompany = _unitOfWork.Company.Get(p => p.Id == id);
        //    if (selectedCompany == null)
        //        return NotFound();
        //    return View(selectedCompany);
        //}

        //[HttpPost]
        //public IActionResult DeletePost(Company? Company)
        //{
        //    if (Company == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Company.Remove(Company);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Company Deleted Successfully";
        //    return RedirectToAction("Index");
        //}
        #endregion
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> Companyies = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = Companyies });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted = _unitOfWork.Company.Get(p=>p.Id==id);
            if(CompanyToBeDeleted == null)
            {
                return Json(new {success=false,message="Error while deleting"});
            }

          

            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });


        }
        #endregion
    }
}
