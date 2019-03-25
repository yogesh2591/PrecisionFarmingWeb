using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrecisionFarmingWeb.Models;
using System.Security.Cryptography;
using System.Text;
namespace PrecisionFarmingWeb.Controllers
{
    
    public class UsersController : Controller
    {
        string key = "FairEarth";
        [HttpPost]
        [Route("api/Users/Authenticate")]
        public ActionResult Authenticate([FromBody]Users ClientUser)
        {
            try
            {
                using (var context = new DatabaseContext())
                {

                    var userEntity = (from user in context.USERS
                                      where ClientUser.USER_EMAIL.ToLower().Trim() == user.USER_EMAIL.ToLower().Trim()

                                      select new
                                      {
                                          user.USER_EMAIL,
                                          user.USER_PASSWORD
                                      }
                                    ).FirstOrDefault();

                    if (userEntity != null)
                    {
                        if (Decryptword(userEntity.USER_PASSWORD) == ClientUser.USER_PASSWORD)
                        {
                            return Ok("Login Success");
                        }
                        else
                        {
                            return UnprocessableEntity("Password Incorrect");
                        }
                    }
                    else
                    {
                        return NotFound("No User Found with Email : " + ClientUser.USER_EMAIL);
                    }
                }


            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }

        }

        [HttpPost]
        [Route("api/Users/CreateUser")]
        public ActionResult CreateUser([FromBody]Users ClientUser) {
            try
            {
                using (var context = new DatabaseContext())
                {

                    var userEntity = context.USERS.FirstOrDefault(U => U.USER_EMAIL == ClientUser.USER_EMAIL);
                    if (userEntity == null)
                    {
                        ClientUser.USER_PASSWORD = Encryptword(ClientUser.USER_PASSWORD);
                        context.USERS.Add(ClientUser);
                        context.SaveChanges();
                        return Created(ClientUser.USER_EMAIL, "User Created");
                    }
                    else {
                        return UnprocessableEntity("User Already Exist");
                    }
                }


            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        private string Encryptword(string Encryptval)

        {

            byte[] SrctArray;

            byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(Encryptval);

            SrctArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();

            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();

            SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            objcrpt.Clear();

            objt.Key = SrctArray;

            objt.Mode = CipherMode.ECB;

            objt.Padding = PaddingMode.PKCS7;

            ICryptoTransform crptotrns = objt.CreateEncryptor();

            byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);

            objt.Clear();

            return Convert.ToBase64String(resArray, 0, resArray.Length);

        }

        private string Decryptword(string DecryptText)

        {

            byte[] SrctArray;

            byte[] DrctArray = Convert.FromBase64String(DecryptText);

            SrctArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();

            MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();

            SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

            objmdcript.Clear();

            objt.Key = SrctArray;

            objt.Mode = CipherMode.ECB;

            objt.Padding = PaddingMode.PKCS7;

            ICryptoTransform crptotrns = objt.CreateDecryptor();

            byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);

            objt.Clear();

            return UTF8Encoding.UTF8.GetString(resArray);

        }
    }
}