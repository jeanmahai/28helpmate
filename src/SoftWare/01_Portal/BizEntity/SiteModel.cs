using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Helpmate.BizEntity.Enum;
using System.Windows.Forms;

namespace Helpmate.BizEntity
{
    [Serializable]
    public class SiteModel
    {
        public string Text { get; set; }

        public UserControl PageCtrl { get; set; }
    }
}
