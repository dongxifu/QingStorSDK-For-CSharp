using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.utils;
using QingStorSDK.com.qingstor.sdk.config;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class QSSignatureUtilTest
    {
        public void testSignature() 
        {
            ParamTestModel instancesInput = new ParamTestModel();
            instancesInput.setAction("TestAction");
            List<String> imgs = new List<String>();
            imgs.Add("test-0001");
            imgs.Add("test-0002");
            instancesInput.setImageID(imgs);

            Dictionary<object,object> queryParam =
                QSParamInvokeUtil.getRequestParams(instancesInput, QSConstant.PARAM_TYPE_QUERY);

            /*https://api.qc.dev/iaas?access_key_id=QYACCESSKEYIDEXAMPLE&image_id.0=test-0001&image_id.1=test-0002&
            // search_word=serch_word_test&signature_method=HmacSHA256&signature_version=1&
            // time_stamp=2016-12-02T13%3A07%3A16Z&version=1&signature=r%2FR9TmmnZQWhkEi1gQy5qV9wEPjoJYi9QHSKzliq2eg%3D
            */
            String d = QSSignatureUtil.formatGmtDate(DateTime.Now);
            String url =
                QSSignatureUtil.getAuth(
                        "QYACCESSKEYIDEXAMPLE",
                        "wudajefiLSJDWIFJLSD",
                        "GET",
                        "objectTest",
                        queryParam,
                        null);

            Assert.AreEqual(url.IndexOf("QS QYACCESSKEYIDEXAMPLE:") >= 0, true);
        }
        public void testEncodeString() 
        {
            String req1 = null;
            String req2 = null;
            try 
            {
                req1 = QSSignatureUtil.percentEncode("test/obj+.txt");
                req2 = QSSignatureUtil.percentEncode("test/在obj.txt");
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreNotEqual(req1, "test/obj+.txt");

            Assert.AreNotEqual(req2, "test/在obj.txt");
        }

        public void testExpireString() 
        {
            EvnContext evnContext = new EvnContext("testkey", "test_asss");

            String req1 = null;
            try 
            {
                req1 =
                    QSSignatureUtil.getObjectAuthRequestUrl(
                            evnContext, "testzone", "bucketName", "objectName/dd.txt", 1000);
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreEqual(
                req1.IndexOf("https://bucketName.testzone.qingstor.com/objectName/dd.txt?") == -1,
                true);
        }
    }
}
