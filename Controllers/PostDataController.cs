using App_mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App_mobile.Controllers
{
    public class PostDataController : ApiController
    {
        API_MOBILEEntities1 api = new API_MOBILEEntities1();


        //da hoc
        [HttpPost]
       public IHttpActionResult postLearned([FromBody] learn data)
        {
           
                learn learn = new learn();
                learn.id_word = data.id_word;
                learn.id_user = data.id_user;
                api.learns.Add(learn);
                api.SaveChanges();
                return Ok(learn);
         

        }


        // kiem tra xem ton tai chua

        [HttpPost]
        public ApiResponse<Boolean>testFavourites([FromBody] favourite data)
        {
            if(api.favourites.Where(m=>m.id_word== data.id_word).Any())
            {
                return new ApiResponse<Boolean> { error = 0, message = "Da ton tai", data = true };
            }
            else
            {
                return new ApiResponse<Boolean> { error = 1, message = "chua ton tai", data = false };

            }
        }

        //them tu yeu thich
        [HttpPost]
        public IHttpActionResult getFavourites([FromBody] favourite data)
        {
            favourite fav = new favourite();
            fav.id_word = data.id_word;
            fav.id_user = data.id_user;
            api.favourites.Add(fav);
            api.SaveChanges();
            return Ok(fav);
        }

        //del tu yeu thich
        [HttpPost]
        public IHttpActionResult delFavourites([FromBody] favourite data)
        {
            api.favourites.Remove(api.favourites.Where(m => m.id==data.id && m.id_user== data.id_user).FirstOrDefault());
            api.SaveChanges();
            return Ok();
        }

        //lay du lieu ra test
        [HttpGet]
        public IHttpActionResult getId(String user)
        {
            var id = api.logins.Where(m => m.user_name == user).Select(m => m.id).ToList();
            if(id != null)
            {
                return Ok(id);
            }
            return NotFound();
        }
    } 
}