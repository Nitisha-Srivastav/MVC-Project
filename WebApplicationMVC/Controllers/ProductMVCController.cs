using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductDataAccess;

namespace WebApplicationMVC.Controllers
{
    public class ProductMVCController : Controller
    {
        Operation operations = new Operation();
        [HttpGet]
        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewProduct(Models.Product productLocal)
        {
                string fileName = Path.GetFileNameWithoutExtension(productLocal.ImageFile.FileName);
                string extension = Path.GetExtension(productLocal.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                productLocal.ProductImg = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                productLocal.ImageFile.SaveAs(fileName);
            

            PRODUCT prodDal = new PRODUCT();
            prodDal.ProductName = productLocal.ProductName;
            prodDal.ProductDescription = productLocal.ProductDescription;
            prodDal.ProductPrice = productLocal.ProductPrice;
            prodDal.ProductImg = productLocal.ProductImg;
            if (operations.AddNewProduct(prodDal))
            {
                ViewBag.prodMessage = "Product details added successfully";
            }
            else
            {
                ViewBag.prodMessage = "Failed to add product details";
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult ListAllProduct()
        {
            var lstProd = operations.GetAllProduct();
            List<Models.Product> prodListLocal = new List<Models.Product>();
            foreach (var prod in lstProd)
            {
                Models.Product prodModel = new Models.Product();
                prodModel.Id = prod.Id;
                prodModel.ProductName = prod.ProductName;
                prodModel.ProductDescription = prod.ProductDescription;
                prodModel.ProductPrice = prod.ProductPrice;
                if (prod.ProductImg != null)
                {
                    prodModel.ProductImg = prod.ProductImg;
                }
                prodListLocal.Add(prodModel);
            }
            return View(prodListLocal);

        }

        [HttpGet]
        public ActionResult ShowProductDetails()
        {
            var prod = operations.GetProdById(Request.QueryString["pID"]);
            Models.Product prodModel = new Models.Product();
            prodModel.Id = prod.Id;
            prodModel.ProductName = prod.ProductName;
            prodModel.ProductDescription = prod.ProductDescription;
            prodModel.ProductPrice = prod.ProductPrice;
            prodModel.ProductImg = prod.ProductImg;
            return View(prodModel);
        }

        [HttpGet]
        public ActionResult DeleteProduct()
        {
            var prod = operations.GetProdById(Request.QueryString["pID"]);
            Models.Product prodModel = new Models.Product();
            prodModel.ProductName = prod.ProductName;
            prodModel.ProductDescription = prod.ProductDescription;
            prodModel.ProductPrice = prod.ProductPrice;
            prodModel.ProductImg = prod.ProductImg;
            return View(prodModel);
        }

        [HttpPost]
        [ActionName("DeleteProduct")] //this is required when post and get method names are different
        public ActionResult DeleteProductConfirm()
        {
            operations.DeleteProductByID(Request.QueryString["pid"]);
            return RedirectToAction("ListAllProduct");

        }
    }
}

