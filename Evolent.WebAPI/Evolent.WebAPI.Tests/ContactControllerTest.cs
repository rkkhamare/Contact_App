using Evolent.DataAccess.UnitOfWork;
using Evolent.Entities.DTOs;
using Evolent.Services.Interface;
using Evolent.WebAPI.Controllers;
using Evolent.WebAPI.Tests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        private readonly Helper helper;
        public ContactControllerTest()
        {
            helper = new Helper();
        }
        private IContact _contactService;
        private IUnitOfWork _unitOfWork;
        private List<ContactDTO> _contacts;
        private HttpClient _client;

        private HttpResponseMessage _response;
        private const string ServiceBaseURL = "http://localhost:55551/";
        #endregion



        [Test]
        public void GetAllProductsTest()
        {
            _contacts = helper.GetContactList();

            var responseResult = JsonConvert.DeserializeObject<ContactDTO>(_response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(_response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Id, true);
        }
    }
}
