using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.DataAccess.Repositories
{
    internal class DBConstant
    {
        public const string SP_GetContactList = "ev_usp_GetContactList";
        public const string SP_AddContactDetails = "ev_usp_AddContactDetails";
        public const string SP_UpdateContactDetails = "ev_usp_UpdateContactDetails";
        public const string SP_DeleteContactDetails = "ev_usp_DeleteContactRecord";
    }
}
