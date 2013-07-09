using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpmate.UI.Forms.Models
{
    public interface IPage
    {

        void QueryData(int? pageIndex = null);

    }
}
