using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using QingStorSDK.com.qingstor.sdk.utils;
namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class Base64Test
    {
        public void testBase()
        {
            String testDecode = "tesidkslkdjiwefwe";
            byte[] de= new byte[Encoding.UTF8.GetBytes(testDecode).Length];
            de = Encoding.UTF8.GetBytes(testDecode);
            String encode = Base64.encode(de);
            byte[] decode = Base64.decode(encode);
            Assert.AreEqual(System.Text.Encoding.UTF8.GetString(decode), testDecode);
        }
    }
}
