using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using QingStorSDK.com.qingstor.sdk.utils;
using QingStorSDK.com.qingstor.sdk.constants;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class QSStringUtilTest
    {
        public void testReqString() 
        {
            String req = QSStringUtil.getParameterRequired("key", "colume");
            Assert.AreEqual(req, "key is required in colume");
        }

  
        public void testNotAllowedString() 
        {
            String[] values = {"2", "3"};
            String req = QSStringUtil.getParameterValueNotAllowedError("colume", "key", values);
            Assert.AreEqual(req, "colume value key is not allowed, should be one of 2,3");
        }
        public void testUserAgentString() 
        {
            String req = QSStringUtil.getUserAgent();
            Assert.AreEqual(req.IndexOf(QSConstant.SDK_VERSION) >= 0, true);
            Assert.AreEqual(req.IndexOf(QSConstant.SDK_NAME) >= 0, true);
        }
    
   
	    public void mapJsonStringTest() 
        {

		    Dictionary<object,object> m = new Dictionary<object,object>();
		    m.Add("testString","didididi");
		    m.Add("testInt",100);
		    m.Add("testInt2","100");
		    m.Add("testBoolean","true");
		    ParamTestModel model = new ParamTestModel();
		    model.setAction("testAction");
		    ParamTypeModel typeModel = new ParamTypeModel();
		    typeModel.setAlarmStatus("status");
		    typeModel.setInstanceClass(10);
		    m.Add("testObject",typeModel);

		    String d = QSStringUtil.getDictionaryToJson(m);
		    Console.WriteLine(d);
		    Object o = QSJSONUtil.convertJSONObject(d);
		    Assert.IsNotNull(o);
            Dictionary<String, Object> dic = QSJSONUtil.JsonToDictionary(d);
		    Assert.AreEqual(dic["testString"],"didididi");
		    Assert.AreEqual(Convert.ToInt32(dic["testInt2"]),100);
	}
        public void testChineseCharactersEncoding() 
        {
            String req;
		    try 
            {
			    req = QSStringUtil.chineseCharactersEncoding("中文编码测试/{}-==辛苦、");
			    Console.WriteLine(req);
			    Assert.AreEqual(req.IndexOf("{}") > 0, true);
	            Assert.AreEqual(req.IndexOf("中文编码") == -1, true);
		    } 
            catch (Exception e) 
            {
			// TODO Auto-generated catch block
                Console.WriteLine(e.Message);
		    }
        
        }
    }
}
