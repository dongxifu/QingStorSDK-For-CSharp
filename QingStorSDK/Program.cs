using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.request;
using System.IO;
using System.Net;
using QingStorSDK.test.CSharp.com.qingstor.sdk.config;
using QingStorSDK.test.CSharp.com.qingstor.sdk.utils;
using QingStorSDK.tests;
namespace QingStorSDK
{
    class Program
    {
        static void Main(string[] args)
        {
            //EvnContextTest
            /*EvnContextTest evncontexttest = new EvnContextTest();
            evncontexttest.testConfig();
            evncontexttest.testDefault();*/
            
            //Base64Test
            /*Base64Test test = new Base64Test();
            test.testBase();*/
            //QSJSONUtilTest
            /*QSJSONUtilTest test = new QSJSONUtilTest();
            test.testJson();*/

            //QSParamInvokeUtilTest
            /*QSParamInvokeUtilTest test = new QSParamInvokeUtilTest();
            test.testClassToModel();
            test.testOutputModel();
            test.testParam();
            test.testParamInvokeCapitalize();*/

            //QSSignatureUtilTest
            /*QSSignatureUtilTest test = new QSSignatureUtilTest();
            test.testEncodeString();
            test.testExpireString();
            test.testSignature();*/

            //QSStringUtilTest
            /*QSStringUtilTest test = new QSStringUtilTest();
            test.mapJsonStringTest();
            test.testChineseCharactersEncoding();
            test.testNotAllowedString();
            test.testReqString();
            test.testUserAgentString();*/

            //BucketACLTest
            /*BucketACLTest test = new BucketACLTest();
            test.put_bucket_ACL();*/

            //BucketTest
            /*BucketTest test = new BucketTest();
            test.initialize_the_bucket();
            test.put_bucket();
            test.list_objects();
            test.list_objects_status_code_is();
            test.list_objects_keys_count_is();*/

            //MultiObjectTemplateUnitTest
            MultiObjectTemplateUnitTest test = new MultiObjectTemplateUnitTest();
            test.qcstorHeadBucketObject();
            test.qcstorGetObject();
            //test.qcstorDeleteBucketObject();

            /*EvnContext evn = new EvnContext("MYCDQJFYCUKPENFIIZSM", "aYlWBEbAB2bIRFKImWUyyBbA0QnnFAJms2rOhhbc");//
            //evn.setUri("http://php-bucket.pek3a.qingstor.com/wordpress");
            evn.setProtocol("http");
            evn.setHost("qingstor.com");
            //evn.setHost("HTTP/1.1");
            //evn.setPort("443");
            string zoneName = "pek3a";
            QingStor storService = new QingStor(evn, zoneName);
            string bucketName = "java-bucket";
            Bucket bucket = storService.getBucket(bucketName);
            string objectName = "2.txt";
            Bucket.PutObjectInput input=new Bucket.PutObjectInput();
            FileStream f = new FileStream("D:\\2.txt",FileMode.Open);
            input.setBodyInputFileStream(f);
            input.setContentLength((int)f.Length);
            Bucket.PutObjectOutput output = bucket.putObject(objectName, input);
            f.Close();
            Console.WriteLine(output.getMessage());*/

            /*Bucket.InitiateMultipartUploadInput inputParam = new Bucket.InitiateMultipartUploadInput();
            Bucket.UploadMultipartInput input = new Bucket.UploadMultipartInput();
            //inputParam.setContentType("text/plain");
            
            Bucket.InitiateMultipartUploadOutput output = bucket.initiateMultipartUpload(objectName, inputParam);
            FileStream f = File.OpenRead("D:\\3.txt");
            //string text = System.IO.File.ReadAllText("D:\\1.iso");
            input.setContentLength(1024*1024*4);
            input.setBodyInputFileStream(f);
            input.setPartNumber(0);
            input.setUploadID(output.getUploadID());
            Bucket.UploadMultipartOutput uploadMultipartOutput3 = bucket.uploadMultipart(objectName, input);
            uploadMultipartOutput3.getMessage();*/
            System.Console.Read();
            
        }
    }
}
