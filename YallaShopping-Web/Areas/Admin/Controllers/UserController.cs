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
using YallaShopping.DataAccess.Data;
using Microsoft.AspNetCore.Identity;

namespace YallaShopping_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = StaticDetails.Role_Admin)]

    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork=unitOfWork;
            _userManager = userManager;
            _roleManager=roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleManagement(string userId)
        { 

            RoleManagementVM RoleVM = new RoleManagementVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId,includeProperties:"Company"),
                RoleList = _roleManager.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList=_unitOfWork.Company.GetAll().Select(i=>new SelectListItem
                {
                    Text = i.Name,
                    Value=i.Id.ToString()
                }),
            };
            RoleVM.ApplicationUser.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.
                Get(u=>u.Id==userId)).GetAwaiter().GetResult().FirstOrDefault();
            return View(RoleVM);
        }

        [HttpPost]
        public IActionResult RoleManagement(RoleManagementVM roleManagementVM)
        {

           
            string oldRole = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.
                Get(u => u.Id == roleManagementVM.ApplicationUser.Id)).GetAwaiter().GetResult().FirstOrDefault();
            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == roleManagementVM.ApplicationUser.Id);

            if (!(roleManagementVM.ApplicationUser.Role == oldRole))
            {
                if (roleManagementVM.ApplicationUser.Role == StaticDetails.Role_Company)
                {
                    applicationUser.CompanyId = roleManagementVM.ApplicationUser.CompanyId;
                }
                if (oldRole == StaticDetails.Role_Company)
                {
                    applicationUser.CompanyId = null;
                }
                _unitOfWork.ApplicationUser.Update(applicationUser);
                _unitOfWork.Save();

                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagementVM.ApplicationUser.Role).GetAwaiter().GetResult();

            }
            else
            {
                if(oldRole== StaticDetails.Role_Company&&applicationUser.CompanyId!=roleManagementVM.ApplicationUser.CompanyId)
                {
                    applicationUser.CompanyId=roleManagementVM.ApplicationUser.CompanyId;
                    _unitOfWork.ApplicationUser.Update(applicationUser);
                    _unitOfWork.Save();
                }
            }

            return RedirectToAction("Index");
        }
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> userList = _unitOfWork.ApplicationUser.GetAll(includeProperties:"Company").ToList();
           
            foreach (var user in userList) 
            {
                user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

                if (user.Company == null)
                {
                    user.Company = new()
                    {
                        Name = "",
                    };
                }
            }
            return Json(new { data = userList });
        }
        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb=_unitOfWork.ApplicationUser.Get(u=>u.Id == id);
            if (objFromDb == null)
            {
                return Json(new {success = false,message="Enter while Locking/Unlocking"});
            }
            if(objFromDb.LockoutEnd!=null && objFromDb.LockoutEnd > DateTime.Now)
            {
                objFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDb.LockoutEnd= DateTime.Now.AddYears(1000);
            }
            _unitOfWork.ApplicationUser.Update(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }
       
        #endregion
    }
}
