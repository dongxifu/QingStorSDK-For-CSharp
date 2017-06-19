using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.config;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.config
{
    class EvnContextTest
    {
        public void testDefault() 
        {
            EvnContext evnContext = new EvnContext("testkey", "test_asss");
            
            Assert.AreEqual(evnContext.getAccessKey(), "testkey");
            Assert.AreEqual(evnContext.getAccessSecret(), "test_asss");
            Assert.AreEqual(evnContext.getRequestUrl(), "https://qingstor.com");
            Assert.AreEqual(evnContext.getLog_level(), QSConstant.LOGGER_ERROR);
        }


        public void testConfig() 
        {
            String config =
                "access_key: 'testkey'\n"
                        + "access_secret: 'test_asss'\n"
                        + "host: qingcloud.com\n"
                        + "port: 443\n"
                        + "protocol: https\n";
            FileStream f = new FileStream(System.Environment.CurrentDirectory + "/tmp/key.csv", FileMode.Open);
            Boolean bConf = false;
            try 
            {
                StreamReader output = new StreamReader(f);
                output.ReadToEnd();
                output.Close();
                f.Close();
                bConf = true;
            } 
            catch (Exception e) 
            {
                System.Console.Write(e.Message);
            } 
          
            if (bConf) 
            {

                EvnContext evnContext = EvnContext.loadFromFile(System.Environment.CurrentDirectory + "/tmp/key.csv");
                Assert.AreEqual(evnContext.getAccessKey(), "testkey");
                Assert.AreEqual(evnContext.getAccessSecret(), "testaccess");
                Assert.AreEqual(evnContext.getRequestUrl(), "https://qingcloud.com:443");
            }
        }
    }
}
