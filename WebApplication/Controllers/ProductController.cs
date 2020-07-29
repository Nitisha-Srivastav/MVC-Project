using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ProductDataAccess;

namespace WebApplication.Controllers
{
    public class ProductController : ApiController
    {
        Operation operations = new Operation();

        //[Route("Product/GetAddProduct")]
        //public JsonResult<List<Models.Product>> GetAllProduct()
        //{

        //    var lstProd = operations.GetAllProduct();
        //    Models.Product prodModel = new Models.Product();
        //    foreach (var prod in lstProd)
        //    {
                
        //        prodModel.ProductName = prod.ProductName;
        //        prodModel.ProductDescription = prod.ProductDescription;
        //        prodModel.ProductPrice = prod.ProductPrice;
        //        prodModel.ProductImg = prod.ProductImg;
        //       // prodListLocal.Add(prodModel);
        //    }

        //    var jsonRes = (Json)prodModel;
        //    return jsonRes;
        //}

    }
}
