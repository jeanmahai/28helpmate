using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.BizEntity;

namespace Helpmate.UI.Forms.Models
{
    public interface IPage
    {
        List<SiteModel> GetSiteModelList();

        void QueryData(int? pageIndex = null);

    }
}
