using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenders.Core.Enums
{
    public enum ErrorCodeEnum
    {
        Undefined = 0,

        IncorrectModel = 400,
        Forbidden = 403,
        NotFound = 404,
        Unmodifiable = 406,
        AlreadyExists = 409,
        ResourceLocked = 423,

        FieldIsEmpty = 701,
        UndefinedValue = 702,
        InvalidValue = 703,
        InvalidDataFormat = 704,
        InappropriateFieldLength = 705,
        InvalidState = 709,
    }
}
