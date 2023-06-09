using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qwe
{
    public enum TableName
    {
        cabinet,
        korpus,
        Role,
        status,
        typecabinet,
        User,
        UserCabinet
    }

    internal class AppData
    {
        public static rezervEntities2 db = new rezervEntities2();
    }
}
