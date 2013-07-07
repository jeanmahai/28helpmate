using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpmate.Facades.LotteryWebService;

namespace Helpmate.Facades
{
    public class CommonFacede
    {

        public bool Login()
        {



            var serviceInstance = new LotteryWebServiceSoapClient();

            //var WebserviceInstance = new localhost.Service();
            //    //通过实例化的webservice对象来调用Webservice暴露的方法
            //var c = WebserviceInstance.addition(double.Parse(Num1.Text), double.Parse(Num2.Text)).ToString();
            return true;
        }


    }
}
