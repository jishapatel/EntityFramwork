using EntityFramwork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EntityFramwork.Controllers
{
    public class MovieController : ApiController
    {
        //Model -> EmpModel.edmx -> EmpModel.Context.tt -> EmpModel.Context.cs create object
        MovieDBEntities db = new MovieDBEntities();

        //insert a data Model -> EmpModel.edmx -> EmpModel.tt -> Movie_Master
        //in postman Post method https://localhost:44367/api/movie Body -> Row -> last option in drop down JSON
        /*{
            "movie_id":1,
            "movie_name":"YDLJ",
            "movie_cast":"alia"
        }*/
    public IHttpActionResult PostData(Movie_Master movie)
        {
            try
            {
                if (movie != null)
                {
                    db.Movie_Master.Add(movie);
                    db.SaveChanges();
                    return Ok("Inserted Data Successfully!");
                }
                else
                {
                    return BadRequest("Provide Proper Data!");
                }
            }
            catch(Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, "Enter Proper data!");
            }
        }


        //Display All the Data Get method https://localhost:44367/api/movie
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Movie_Master> data= db.Movie_Master.ToList();
                if(data.Count > 0)
                {
                    return Content(HttpStatusCode.OK, data);//Ok(data);
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, "No Data Found!");
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please Try Again!");
            }
        }

        //Display a perticullar movie by id using Get method https://localhost:44367/api/movie?movie_id=2
        public IHttpActionResult GetMovie(int movie_id)
        {
            try
            {
                Movie_Master movie = db.Movie_Master.Find(movie_id);
                if (movie != null)
                {
                    return Content(HttpStatusCode.OK, movie);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "There is no Data available with Movie_Id '"+movie_id+"'");
                }
                
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please Try Again!");
            }
        }

        //Update a data Post method https://localhost:44367/api/movie?movie_id=2
        //Body -> x-www-form-urlencoded 
        //movie_name    Raabta
        //movie_cast    kriti
        public IHttpActionResult UpdateData(int movie_id,Movie_Master movie)
        {
            try
            {
                Movie_Master movie1 = db.Movie_Master.Find(movie_id);
                if (movie1 != null)
                {
                    movie1.Movie_Name = movie.Movie_Name;
                    movie1.Movie_Cast = movie.Movie_Cast;
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data updated successfully!");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "There is no Data available with Movie_Id '" + movie_id + "'");
                }

            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please Try Again!");
            }
        }

        //Display a perticullar movie by id using Get method https://localhost:44367/api/movie?movie_id=2
        public IHttpActionResult DeleteMovie(int movie_id)
        {
            try
            {
                Movie_Master movie = db.Movie_Master.Find(movie_id);
                if (movie != null)
                {
                    return Content(HttpStatusCode.OK, movie);
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "There is no Data available with Movie_Id '" + movie_id + "'");
                }

            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Please Try Again!");
            }
        }

    }
}
