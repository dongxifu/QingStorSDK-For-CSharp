using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.utils;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.model;

namespace QingStorSDK.tests
{
    class MultiObjectTemplateUnitTest
    {
        public static String QC_STOR_CONTENT_TEXT = "text/plain; charset=utf-8";
        public static String QC_STOR_CONTENT_JSON = "application/json";
        public static String QC_STOR_CONTENT_MULTI = "multipart/form-data;";


     
        public void qcstorHeadBucketObject()
        {

            EvnContext evn = EvnContext.loadFromFile(System.Environment.CurrentDirectory + "/tmp/test_key.csv");
            String bucketName = "java-bucket";
            Bucket ss = new Bucket(evn,bucketName);
            String objectName = "2.txt";

            Bucket.HeadObjectInput bb = new Bucket.HeadObjectInput();
            //bb.setIfMatch("cda0a741aac6541c730ed6be6c6f5bcc");
            OutputModel dd = ss.headObject(objectName,bb);

            Console.WriteLine(dd+"");

        }

  
        public void qcstorDeleteBucketObject()
        {

            EvnContext evn = EvnContext.loadFromFile(System.Environment.CurrentDirectory + "/tmp/test_key.csv");
            String bucketName = "java-bucket";
            Bucket ss = new Bucket(evn,bucketName);
            String objectName = "2.txt";


            //bb.setIfMatch("cda0a741aac6541c730ed6be6c6f5bcc");
            OutputModel dd = ss.deleteObject(objectName);

            Console.WriteLine(dd+"");

        }

   
   
        public void qcstorGetObject()
        {

            EvnContext evn = EvnContext.loadFromFile(System.Environment.CurrentDirectory + "/tmp/test_key.csv");
            String bucketName = "java-bucket";
            Bucket ss = new Bucket(evn,bucketName);
            String objectName = "2.txt";

            Bucket.GetObjectInput bb = new Bucket.GetObjectInput();

            //bb.setIfMatch("cda0a741aac6541c730ed6be6c6f5bcc");
            Bucket.GetObjectOutput dd = ss.getObject(objectName,bb);
            Console.WriteLine(dd+"");

            if(dd != null && dd.getBodyInputStream() != null)
            {
                FileStream ff = new FileStream("D:\\5.txt",FileMode.OpenOrCreate);
                StreamWriter os = new StreamWriter(ff);
                string buffer;
                while ((buffer=dd.getBodyInputStream().ReadLine())!=null) 
                {
                    os.WriteLine(buffer);
                    
                }
                os.Flush();
                os.Close();
                ff.Close();
                dd.getBodyInputStream().Close();
            }

        }
    }
}
