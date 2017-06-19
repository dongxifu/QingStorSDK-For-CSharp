using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using QingStorSDK.com.qingstor.sdk.utils;
using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.constants;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class QSParamInvokeUtilTest
    {
        public void testParamInvokeCapitalize() 
        {
            String capitalize = QSParamInvokeUtil.capitalize("tttTtest");
            Assert.AreEqual(capitalize, "TttTtest");
        }
        public void testClassToModel() 
        {
            Object outmodel = null;
            try 
            {
                outmodel = QSParamInvokeUtil.getOutputModel(typeof(Bucket.PutBucketACLOutput));
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreEqual(outmodel.GetType().Name, typeof(Bucket.PutBucketACLOutput).Name);
        }
        public void testOutputModel() 
        {
            Bucket.PutBucketACLOutput outmodel = null;
            try 
            {
                outmodel =
                    (Bucket.PutBucketACLOutput)
                            QSParamInvokeUtil.getOutputModel(typeof(Bucket.PutBucketACLOutput));
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            Assert.AreEqual(outmodel.GetType().Name, typeof(Bucket.PutBucketACLOutput).Name);
        }

        public void testParam() 
        {
            ParamTestModel instancesInput = new ParamTestModel();
            List<String> imgs = new List<String>();
            imgs.Add("test-0001");
            imgs.Add("test-0002");
            
            instancesInput.setImageID(imgs);
            instancesInput.setAction("serch_word_test");
            Dictionary<Object,Object> queryParam =
                QSParamInvokeUtil.getRequestParams(instancesInput, QSConstant.PARAM_TYPE_QUERY);
            Dictionary<Object,Object> bodyParam =
                QSParamInvokeUtil.getRequestParams(
                        instancesInput, QSConstant.PARAM_TYPE_BODYINPUTSTREAM);

            Assert.AreEqual(queryParam["action"], "serch_word_test");
            Assert.AreEqual(((List<String>)queryParam["image_id"])[1], "test-0002");
            Assert.AreEqual(queryParam.Count, 2);
            Assert.AreEqual(bodyParam.Count, 0);
        }
    }
}
