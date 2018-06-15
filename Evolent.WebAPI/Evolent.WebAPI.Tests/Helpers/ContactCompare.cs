using Evolent.Entities.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolent.WebAPI.Tests.Helpers
{
    class ContactCompare : IComparer, IComparer<ContactDTO>
    {
        public int Compare(object expected, object actual)
    {
        var lhs = expected as ContactDTO;
        var rhs = actual as ContactDTO;
        if (lhs == null || rhs == null) throw new InvalidOperationException();
        return Compare(lhs, rhs);
    }

    public int Compare(ContactDTO expected, ContactDTO actual)
    {
        int temp;
        return (temp = expected.Id.CompareTo(actual.Id)) != 0 ? temp : expected.FirstName.CompareTo(actual.FirstName);
    }
}
    }
