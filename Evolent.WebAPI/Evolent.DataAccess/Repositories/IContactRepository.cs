using Evolent.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.DataAccess.Repositories
{
    public interface IContactRepository
    {
        List<ContactDTO> GetContactList();
        
        ResponseDTO AddContactDetails(ContactDTO contactDTO);
        
        ResponseDTO UpdateContactDetails(ContactDTO contactDTO);
        
        ResponseDTO DeleteContactDetails(ContactDTO contactDTO);
    }
}
