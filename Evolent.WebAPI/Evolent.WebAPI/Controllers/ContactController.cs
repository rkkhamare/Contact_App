using Evolent.Entities.DTOs;
using Evolent.Services.Interface;
using Evolent.WebAPI.App_Start;
using Evolent.WebAPI.Logging;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Evolent.WebAPI.Controllers
{
    public class ContactController : ApiController
    {
        private IContact _objContact;
        private readonly ILogAdapter _logger;
        public ContactController(IContact objContact)
        {
            _objContact = objContact;
            _logger = LoggerFactory.GetLogger();
        }

        /// <summary>
        /// Gets List of all user.
        /// </summary>
        /// <returns></returns>

        [ActionName("GetContactList")]
        [HttpGet]
        
        public List<ContactDTO> GetContactList()
        {
            try
            {
                return _objContact.GetContactList();
            }
            catch (Exception ex)
            {
                _logger.WriteMessage("ContactController:GetContactList", NLogAdapter.LogLevel.ERROR, ex);
                return new List<ContactDTO>();
            }


        }


        /// <summary>
        /// Add new Contact Details.
        /// </summary>
        /// <returns></returns>
        [Route("api/Contact/AddContactDetails")]
        [HttpPost]
        public ResponseDTO AddContactDetails(ContactDTO contactDTO)
        {
            try
            {
                return _objContact.AddContactDetails(contactDTO);
            }
            catch (Exception ex)
            {
                _logger.WriteMessage("ContactController:AddContactDetails", NLogAdapter.LogLevel.ERROR, ex);
                return new ResponseDTO { IsSuccess = false };

            }

        }


        /// <summary>
        /// Update Contact Details.
        /// </summary>
        /// <returns></returns>
        [Route("api/Contact/UpdateContactDetails")]
        [HttpPut]
        public ResponseDTO UpdateContactDetails(ContactDTO contactDTO)
        {
            try
            {
                return _objContact.UpdateContactDetails(contactDTO);
            }
            catch (Exception ex)
            {
                _logger.WriteMessage("ContactController:UpdateContactDetails", NLogAdapter.LogLevel.ERROR, ex);
                return new ResponseDTO { IsSuccess = false };

            }

        }


        /// <summary>
        /// Delete Contact Details.
        /// </summary>
        /// <returns></returns>
        [Route("api/Contact/DeleteContactDetails")]
        [HttpPut]
        public ResponseDTO DeleteContactDetails(ContactDTO contactDTO)
        {
            try
            {
                return _objContact.DeleteContactDetails(contactDTO);
            }
            catch (Exception ex)
            {
                _logger.WriteMessage("ContactController:DeleteContactDetails", NLogAdapter.LogLevel.ERROR, ex);
                return new ResponseDTO { IsSuccess = false };

            }

        }
    }
}
