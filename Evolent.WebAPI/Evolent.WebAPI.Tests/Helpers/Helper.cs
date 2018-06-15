using Evolent.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.WebAPI.Tests.Helpers
{
   public class Helper
    {
        private readonly string _ContactAPIURL;

        private static string _webApiURL = "http://localhost:55551/api";
        private static string _contactUrl = "Contact/";
        public Helper()
        {
            _ContactAPIURL = string.Format("{0}/{1}", _webApiURL, _contactUrl);
        }

        public List<ContactDTO> GetContactList()
        {
            List<ContactDTO> _outputList = new List<ContactDTO>();
            _outputList = ApiHandler.ExecuteGetAPIExtendedTime<List<ContactDTO>>(_ContactAPIURL, delegate { return _ContactAPIURL + "GetContactList"; });

            return _outputList;
        }
        public ResponseDTO CreateNewContact(ContactDTO contactDTO)
        {
            ResponseDTO _outputList = new ResponseDTO();
            int resultCode = 0;
            _outputList = ApiHandler.ExecutePostAPI<ResponseDTO, ContactDTO>(_ContactAPIURL, "AddContactDetails", contactDTO, out resultCode);

            return _outputList;
        }
        public ResponseDTO UpdateContact(ContactDTO contactDTO)
        {
            ResponseDTO _outputList = new ResponseDTO();
            int resultCode = 0;

            _outputList = ApiHandler.ExecutePutAPI<ResponseDTO, ContactDTO>(_ContactAPIURL, "UpdateContactDetails", contactDTO, out resultCode);

            return _outputList;
        }
        public ResponseDTO DeleteContactDetails(ContactDTO contactDTO)
        {
            ResponseDTO _outputList = new ResponseDTO();
            int resultCode = 0;
            _outputList = ApiHandler.ExecutePutAPI<ResponseDTO, ContactDTO>(_ContactAPIURL, "DeleteContactDetails", contactDTO, out resultCode);

            return _outputList;
        }
    }
}
