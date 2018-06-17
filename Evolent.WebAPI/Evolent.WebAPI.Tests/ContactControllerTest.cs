using Evolent.DataAccess.UnitOfWork;
using Evolent.Entities.DTOs;
using Evolent.Services.Interface;
using Evolent.WebAPI.Controllers;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace Evolent.WebAPI.Tests
{
    [TestFixture]
    public class ContactControllerTest
    {
        #region Variables

        private readonly string _ContactAPIURL;
        private string sURL;
        private static ContactDTO _contactDTO;
        private static string _webApiURL = "http://localhost:55551/api";
        private static string _contactUrl = "Contact/";
        private static string _GetContactList = "GetContactList";
        private static string _AddContactDetails = "AddContactDetails";
        private static string _UpdateContactDetails = "UpdateContactDetails";
        private static HttpWebRequest _request;
        private static HttpWebResponse _response;
        private static StreamWriter _streamWriter;
        private static StreamReader _streamReader;
        public ContactControllerTest()
        {
            _ContactAPIURL = string.Format("{0}/{1}", _webApiURL, _contactUrl);
        }
        #endregion



        [Test]
        public void GetAllProductsTest()
        {
            sURL = _ContactAPIURL + _GetContactList;
            _request = (HttpWebRequest)WebRequest.Create(sURL);
            _request.Method = "GET";
            _request.ContentType = "application/json";
            _request.Accept = "application/json";
            using (_response = _request.GetResponse() as HttpWebResponse)
            {
                Stream ResponseStream = null;
                ResponseStream = _response.GetResponseStream();
                int responseCode = (int)_response.StatusCode;
                string responseBody = ((new StreamReader(ResponseStream)).ReadToEnd());


                ContactDTO[] responseResult = JsonConvert.DeserializeObject<ContactDTO[]>(responseBody);
                Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);  // Checking successful Response.
                Assert.AreEqual(responseResult.Any(), true); // Checking for any data coming in response.
                Assert.AreEqual(responseResult.FirstOrDefault(x => x.Id.Equals(5)).FirstName, "Amaze");// Checking result with first name of individual.
                Assert.AreNotEqual(responseResult.Select(x => x.Id = 100), true); // Cheking 100 id in system which is not available right now, in this case expected and actual are not equal.
            }
        }


        [Test]
        public void AddNewProductsTest()
        {
            _contactDTO = new ContactDTO();
            sURL = _ContactAPIURL + _AddContactDetails;

            _contactDTO.FirstName = "Test";
            _contactDTO.LastName = "Run";
            _contactDTO.Email = "TestRun@NUnit.com";
            _contactDTO.PhoneNumber = "9890989098";
            _contactDTO.IsActive = true;

            var requestJson = JsonConvert.SerializeObject(_contactDTO);

            _request = (HttpWebRequest)WebRequest.Create(sURL);
            _request.Headers.Clear();
            _request.Method = "POST";
            _request.ContentType = "application/json";
            _request.Accept = "application/json";
            using (_streamWriter = new StreamWriter(_request.GetRequestStream()))
            {
                _streamWriter.Write(requestJson);
                _streamWriter.Flush();
                _streamWriter.Close();
            }
            _response = (HttpWebResponse)_request.GetResponse();
            using (_streamReader = new StreamReader(_response.GetResponseStream()))
            {
                var responseBody = _streamReader.ReadToEnd();
                ResponseDTO responseResult = JsonConvert.DeserializeObject<ResponseDTO>(responseBody);
                Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);  // Checking successful Response.
                Assert.AreEqual(responseResult.IsSuccess, true); // Checking is request completed successfully or not.

            }
        }

        [Test]
        public void UpdateProductsByIdTest()
        {
            _contactDTO = new ContactDTO();
            sURL = _ContactAPIURL + _UpdateContactDetails;

            _contactDTO.Id = 3;
            _contactDTO.FirstName = "TestUpdate";
            _contactDTO.LastName = "RunUpdate";
            _contactDTO.Email = "TestRun@NUnit.com";
            _contactDTO.PhoneNumber = "9191919191";
            _contactDTO.IsActive = true;

            var requestJson = JsonConvert.SerializeObject(_contactDTO);

            _request = (HttpWebRequest)WebRequest.Create(sURL);
            _request.Headers.Clear();
            _request.Method = "PUT";
            _request.ContentType = "application/json";
            _request.Accept = "application/json";
            using (_streamWriter = new StreamWriter(_request.GetRequestStream()))
            {
                _streamWriter.Write(requestJson);
                _streamWriter.Flush();
                _streamWriter.Close();
            }
            _response = (HttpWebResponse)_request.GetResponse();
            using (var _streamReader = new StreamReader(_response.GetResponseStream()))
            {
                var responseBody = _streamReader.ReadToEnd();
                ResponseDTO responseResult = JsonConvert.DeserializeObject<ResponseDTO>(responseBody);
                Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);  // Checking successful Response.
                Assert.AreEqual(responseResult.IsSuccess, true); // Checking is request completed successfully or not.
            }
        }

        [Test]
        public void UpdateProductsByInvalidInputTest()
        {
            _contactDTO = new ContactDTO();
            sURL = _ContactAPIURL + _UpdateContactDetails;

            _contactDTO.Id = 3;
            _contactDTO.Email = "TestRun@NUnit.com";
            _contactDTO.PhoneNumber = "9191919191";
            _contactDTO.IsActive = true;

            var requestJson = JsonConvert.SerializeObject(_contactDTO);

            _request = (HttpWebRequest)WebRequest.Create(sURL);
            _request.Headers.Clear();
            _request.Method = "PUT";
            _request.ContentType = "application/json";
            _request.Accept = "application/json";
            using (_streamWriter = new StreamWriter(_request.GetRequestStream()))
            {
                _streamWriter.Write(requestJson);
                _streamWriter.Flush();
                _streamWriter.Close();
            }
            _response = (HttpWebResponse)_request.GetResponse();
            using (var _streamReader = new StreamReader(_response.GetResponseStream()))
            {
                var responseBody = _streamReader.ReadToEnd();
                ResponseDTO responseResult = JsonConvert.DeserializeObject<ResponseDTO>(responseBody);
                Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);  // Checking successful Response.
                Assert.AreNotEqual(responseResult.IsSuccess, true); // Checking is request completed with false status.
            }
        }
    }
}
