using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ShopBridg.Models;

namespace ShopBridg.Controllers
{
    public class ProductInfoController : ApiController
    {
        // POST: api/ProductInfo/PostAdd
       
        [HttpPost]
        [Route("api/ProductInfo/PostAdd")]
        public HttpResponseMessage Insert([FromBody]Product obj)
        {
            
            
            try
            {
                
                 Dbopration objDB = new Dbopration();
                 objDB.AddProduct(obj);
                 var msg1 = "Record Added Successfully";
                 var msg = Request.CreateResponse(HttpStatusCode.OK, msg1);
              
                return msg;
            }
            catch (Exception objEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, objEx);
            }

            
        }
       // GET: api/ProductInfo

        [HttpGet]
        [Route("api/ProductInfo/Get")]
        public List<Product> Get()
        {
            Dbopration objDB = new Dbopration();

            return objDB.getAllInfo();

        }

        [HttpPut]
        [Route("api/ProductInfo/Update")]
        public HttpResponseMessage Update([FromBody]Product obj)
        {
            try
            {
                Dbopration objDB = new Dbopration();
                objDB.UpdateProduct(obj);
                var msg1 = "Record Updated Successfully";
                var msg = Request.CreateResponse(HttpStatusCode.OK, msg1);
                return msg;
            }
            catch (Exception objEx)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, objEx);
            }

           
        }



        [HttpDelete]
        [Route("api/ProductInfo/Delete")]
        public string Delete([FromBody]int id)
        {
            try
            {
                Dbopration objDB = new Dbopration();
                objDB.DeleteProduct(id);
                
            }
            catch (Exception objEx)
            {
                //
            }
            return "true";
            
        }


    }
}
