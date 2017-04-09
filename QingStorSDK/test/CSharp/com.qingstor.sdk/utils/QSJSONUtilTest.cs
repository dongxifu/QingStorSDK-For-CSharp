using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class QSJSONUtilTest
    {
        public void testJson() 
        {
            
            Dictionary<String, object> obj = new Dictionary<string, object>();
            obj.Add("testString", "test");
            obj.Add("testInt", 123);
            obj.Add("testList","[{'test':'test'}]");
            String convertObj =
                 QSJSONUtil.convertJSONObject(obj);
            Dictionary<String, Object> dic = QSJSONUtil.JsonToDictionary(convertObj);
            Assert.AreEqual(dic["testString"], "test");
            Assert.AreEqual(dic["testInt"], 123);
        }
    }
}
