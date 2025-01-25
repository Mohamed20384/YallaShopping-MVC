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

    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork,IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
           
            List<Product> products = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();

            return View(products);
        }

        [HttpGet]
        public IActionResult Create_Update(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll()
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Id.ToString()
                    }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product = _unitOfWork.Product.Get(p=>p.Id==id,includeProperties:"ProductImages");
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Create_Update(ProductVM productVM, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                if (productVM.Product.Id == 0)
                {
                    if (_unitOfWork.Product.Get(p => p.Title == productVM.Product.Title) != null)
                    {
                        ModelState.AddModelError("Product.Title", $"The Product Name '{productVM.Product.Title}' is already taken");
                    }

                    _unitOfWork.Product.Add(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Created Successfully";
                }
                else
                {
                    if (_unitOfWork.Product.Get(p => p.Title == productVM.Product.Title && p.Id != productVM.Product.Id) != null)
                    {
                        ModelState.AddModelError("Product.Title", $"The Product Name '{productVM.Product.Title}' is already taken");
                    }
                    _unitOfWork.Product.Update(productVM.Product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product Updated Successfully";
                }
                string wwwRootPath =_webHostEnvironment.WebRootPath;
                if (files != null) 
                {
                    foreach(IFormFile file in files)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string productPath = @"images\products\product-" + productVM.Product.Id;
                        string finalPath = Path.Combine(wwwRootPath, productPath);

                        if(!Directory.Exists(finalPath))
                            Directory.CreateDirectory(finalPath);

                        using (var fileStream = new FileStream(Path.Combine(finalPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        ProductImage productImage = new()
                        {
                            ImageUrl = @"\" + productPath + @"\" + fileName,
                            ProductId = productVM.Product.Id,
                        };

                        if(productVM.Product.ProductImages==null)
                            productVM.Product.ProductImages = new List<ProductImage>();

                        productVM.Product.ProductImages.Add(productImage);
                    }

                    _unitOfWork.Product.Update(productVM.Product);
                    _unitOfWork.Save();
                }

                return RedirectToAction("Index");
                
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll()
                    .Select(l => new SelectListItem
                    {
                        Text = l.Name,
                        Value = l.Id.ToString()
                    });
                return View(productVM);

            }

        }

        public IActionResult DeleteImage(int imageId)
        {
            var imageToBeDeleted=_unitOfWork.ProductImage.Get(i=>i.Id== imageId);
            if(imageToBeDeleted != null)
            {
                if (!string.IsNullOrEmpty(imageToBeDeleted.ImageUrl))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, imageToBeDeleted.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                _unitOfWork.ProductImage.Remove(imageToBeDeleted);
                _unitOfWork.Save();
                TempData["success"] = "Image Deleted Successfully";

            }
            return RedirectToAction(nameof(Create_Update), new {id=imageToBeDeleted.ProductId});
        }

        #region NewEdit
        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    ProductVM productVM = new()
        //    {
        //        CategoryList = _unitOfWork.Category.GetAll()
        //            .Select(l => new SelectListItem
        //            {
        //                Text = l.Name,
        //                Value = l.Id.ToString()
        //            }),
        //        Product = _unitOfWork.Product.Get(p => p.Id == id)
        //    };

        //    if (productVM.Product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productVM);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(ProductVM productVM)
        //{
        //    if (productVM.Product == null || productVM.Product.Id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var originalProduct = _unitOfWork.Product.Get(p => p.Id == productVM.Product.Id);

        //    if (originalProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    var productWithSameName = _unitOfWork.Product.Get(p => p.Title == productVM.Product.Title && p.Id != productVM.Product.Id);

        //    if (productWithSameName != null)
        //    {
        //        ModelState.AddModelError("Product.Title", $"The Product Name '{productVM.Product.Title}' is already taken");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Update(productVM.Product);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product Updated Successfully";
        //        return RedirectToAction("Index");
        //    }

        //    // Re-populate CategoryList if ModelState is not valid
        //    productVM.CategoryList = _unitOfWork.Category.GetAll()
        //        .Select(l => new SelectListItem
        //        {
        //            Text = l.Name,
        //            Value = l.Id.ToString()
        //        });

        //    return View(productVM);
        //}
        #endregion
        #region OldEdit
        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();


        //    ProductVM productVM = new()
        //    {
        //        CategoryList = _unitOfWork.Category.GetAll()
        //           .Select(l => new SelectListItem
        //           {
        //               Text = l.Name,
        //               Value = l.Id.ToString()
        //           }),
        //        Product = _unitOfWork.Product.Get(p => p.Id == id)
        //    };
        //    if (productVM.Product == null)
        //        return NotFound();
        //    return View(productVM);
        //}
        //[HttpPost]
        //public IActionResult Edit(ProductVM product)
        //{
        //    Product? originalProduct = _unitOfWork.Product.Get(p => p.Id == product.Product.Id);

        //    if (originalProduct == null)
        //        return NotFound();

        //    if (_unitOfWork.Product.Get(p => p.Title == product.Product.Title) != null)
        //    {
        //        ModelState.AddModelError("Product.Title", $"The Product Name '{product.Product.Title}' is already taken");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Update(product.Product);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product Updated Successfully";
        //        return RedirectToAction("Index");
        //    }

        //    return View("Edit", product);
        //}
        #endregion
        #region Delete
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();
        //    Product? selectedProduct = _unitOfWork.Product.Get(p => p.Id == id);
        //    if (selectedProduct == null)
        //        return NotFound();
        //    return View(selectedProduct);
        //}

        //[HttpPost]
        //public IActionResult DeletePost(Product? product)
        //{
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Product.Remove(product);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Product Deleted Successfully";
        //    return RedirectToAction("Index");
        //}
        #endregion
        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = products });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(p=>p.Id==id);
            if(productToBeDeleted == null)
            {
                return Json(new {success=false,message="Error while deleting"});
            }

            string productPath = @"images\products\product-" +id;
            string finalPath = Path.Combine(_webHostEnvironment.WebRootPath, productPath);

            if (Directory.Exists(finalPath))
            {
                string[] filePaths=Directory.GetFiles(finalPath);
                foreach (string filePath in filePaths)
                {
                    System.IO.File.Delete(filePath);
                }
                Directory.CreateDirectory(finalPath);
            }
                

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });


        }
        #endregion
    }
}
