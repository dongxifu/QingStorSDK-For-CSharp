using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using QingStorSDK.com.qingstor.sdk.config;

namespace QingStorSDK.tests
{
    class TestUtil
    {
        public static void assertNotNull(Object o)
        {
            if(o == null)
            {
                throw new Exception("is null");
            }
        }


        public static void assertEqual(int i,int j)
        {
            if(i != j)
            {
                throw new Exception(i + " is not equal "+j);
            }
        }

        public static void assertEqual(String i,String j)
        {
            if(!i.Equals(j))
            {
                throw new Exception(i + " is not equal "+j);
            }
        }
    
        public static EvnContext getEvnContext()
        {
            return EvnContext.loadFromFile(System.Environment.CurrentDirectory + "/tmp/test_key.csv");
        }

        public static String getZone()
        {
    	    return getFileConfig("zone");
        }

        public static String getBucketName()
        {
    	    return getFileConfig("bucket_name");
        }

        private static String getFileConfig(String key)
        {
            FileStream f = new FileStream(System.Environment.CurrentDirectory + "/tmp/test_key.csv",FileMode.Open);
            if (File.Exists(System.Environment.CurrentDirectory + "/tmp/test_key.csv"))
            {
                StreamReader br = null;
                Dictionary<String,String> confParams = new Dictionary<String,String>();
                try 
                {
                    br = new StreamReader(f);
                    String strConf = null;

                    while ((strConf = br.ReadLine()) != null)
                    {
                        String[] str = strConf.Split(':');
                        if(str.Length > 1)
                        {
                            confParams.Add(str[0].Trim(),str[1].Trim());
                        }
                    }
                } 
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
                finally 
                {
                    if(br != null)
                    {
                        try 
                        {
                            br.Close();
                        } 
                        catch (IOException e) 
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                return confParams[key];
            }
            return "";
        }
    }
}
