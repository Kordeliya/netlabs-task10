using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Mapper
    {
        public DBTableObject TableMapper<Tentity>(Type entiry)
        {
            DBTableObject obj = null;




            foreach (var attr in attributes)
            {
                if (attr is TableAttribute)
                {
                    var args = attr.ConstructorArguments;
                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            if (arg is String)
                            {
                            }
                        }
                    }
                }
            }



            return obj;
        }

        public DBFieldObject FieldMapper<Tentity>(Tentity entiry)
        {
            DBFieldObject obj = null;
            return obj;
        }


    }
}
