using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika10
{
    class Error: Field
    {
        public bool FindError()
        {
            for (int i = 0; i < 4; i++)
                if ((figure[1, i] >= widthField) || (figure[0, i] >= heightField) || (figure[1, i] < 0) || (figure[0, i] < 0) || (field[figure[1, i], figure[0, i]] == 1))
                    return true;

            return false;
        }
    }
}
