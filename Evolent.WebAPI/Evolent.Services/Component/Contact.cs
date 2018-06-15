using Evolent.DataAccess.Repositories;
using Evolent.Entities.DTOs;
using Evolent.Services.Interface;
using System.Collections.Generic;

namespace Evolent.Services.Component
{
   public class Contact: IContact
    {
        private IContactRepository _objContact;
        public Contact(IContactRepository objContact)
        {
            _objContact = objContact;
        }

        public List<ContactDTO> GetContactList()
        {
            return _objContact.GetContactList();
        }
        public ResponseDTO AddContactDetails(ContactDTO contactDTO)
        {
            return _objContact.AddContactDetails(contactDTO);
        }
        public ResponseDTO UpdateContactDetails(ContactDTO contactDTO)
        {
            return _objContact.UpdateContactDetails(contactDTO);
        }
        public ResponseDTO DeleteContactDetails(ContactDTO contactDTO)
        {
            return _objContact.DeleteContactDetails(contactDTO);
        }
    }
}
