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
    class ObjectTest
    {
        private static Bucket subService;
        private static String bucketName = TestUtil.getBucketName();
        private static String chinesePrefix = "中文测试/";
        private static String chineseSuffix = "/中文test";
        private static String test_object = "";
        private static String test_object_copy = "";
        private static String test_object_move = "";


        private static Bucket.PutObjectOutput objectOutput;
        private static Bucket.PutObjectOutput copyOutput;
        private static Bucket.PutObjectOutput moveOutput;
        private static Bucket.GetObjectOutput getContentTypeOutput;

        private static Bucket.PutObjectOutput putObjectOutput;
        private static Bucket.GetObjectOutput getObjectOutput;
        private static Bucket.HeadObjectOutput headObjectOutput;
        private static Bucket.OptionsObjectOutput optionObjectOutput;
        private static Bucket.DeleteObjectOutput deleteObjectOutput;
        private static Bucket.DeleteObjectOutput deleteObjectOutput2;


        public void initialize_the_object_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            subService = new Bucket(evnContext,bucketName);
            evnContext.setLog_level(QSConstant.LOGGER_INFO);
            Bucket.PutObjectInput input = new Bucket.PutObjectInput();
            //objectOutput = subService.PutObject(arg1,input);
            test_object =arg1;

        }

    
        public void the_object_is_initialized()
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertNotNull(subService);
        }

   
        public void initialize_the_copy_object_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Bucket.PutObjectInput input = new Bucket.PutObjectInput();
            copyOutput = subService.putObject(arg1,input);
            test_object_copy = arg1;
        }


        public void the_copy_object_is_initialized()
        {
            // Write code here that turns the phrase above into concrete actions
            //TestUtil.assertEqual(copyOutput.getStatueCode(),);
            Console.WriteLine("the_copy_object_is_initialized:"+test_object_copy);
        }

   
        public void initialize_the_move_object_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Bucket.PutObjectInput input = new Bucket.PutObjectInput();
            moveOutput = subService.putObject(arg1,input);
            test_object_move = arg1;
        }


        public void the_move_object_is_initialized()
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            Console.WriteLine("the_move_object_is_initialized:"+test_object_move);
        }


        public void put_object_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            evnContext.setLog_level(QSConstant.LOGGER_INFO);
            subService = new Bucket(evnContext,bucketName);
            Bucket.PutObjectInput input = new Bucket.PutObjectInput();
            FileStream f = new FileStream("D:\\2.txt",FileMode.Open);
            input.setBodyInputFileStream(f);
            input.setContentLength((int) f.Length);
            test_object = chinesePrefix+arg1+chineseSuffix;
            putObjectOutput = subService.putObject(test_object,input);
        }

    
        public void put_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("put_object_status_code_msg:"+putObjectOutput.getMessage()+test_object);
            TestUtil.assertEqual(putObjectOutput.getStatueCode(),arg1);
        }

   
        public void copy_object_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            Bucket.PutObjectInput input = new Bucket.PutObjectInput();
            input.setXQSCopySource("/" + bucketName + "/" + test_object);
            test_object_copy = arg1;
            copyOutput = subService.putObject(test_object_copy,input);
        }


        public void copy_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            Console.WriteLine("put_the_copy_object_status_code_message:"+copyOutput.getMessage());
            TestUtil.assertEqual(copyOutput.getStatueCode(),arg1);
        }

    
        public void move_object_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            Bucket.PutObjectInput input = new Bucket.PutObjectInput();
            test_object_move=arg1;
            input.setXQSMoveSource("/" + bucketName + "/" + test_object_copy);
            moveOutput = subService.putObject(test_object_move,input);
        }

    
        public void move_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            Console.WriteLine("put_the_move_object_status_code_message:"+copyOutput.getMessage());
            TestUtil.assertEqual(moveOutput.getStatueCode(),arg1);
        }


        public void get_object()
        {
            // Write code here that turns the phrase above into concrete actions
    	    Bucket.GetObjectInput input = new Bucket.GetObjectInput();
            getObjectOutput = subService.getObject(test_object,input);
        }

 
        public void get_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(getObjectOutput.getStatueCode(),arg1);
        }

   
        public void get_object_content_length_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
          
            if(getObjectOutput != null && getObjectOutput.getBodyInputStream() != null)
            {
                FileStream ff = new FileStream("D:\\5.txt",FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(ff);
                string buffer;
                while ((buffer=getObjectOutput.getBodyInputStream().ReadLine()) != null)
                {
                    sw.Write(buffer);
                }
                sw.Close();
                getObjectOutput.getBodyInputStream().Close();
            }
            //TestUtil.assertEqual(iLength,arg1);
        }


  
        public void get_object_with_query_signature()
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            String reqUrl = subService.GetObjectSignatureUrl(test_object,1000);
            getObjectOutput = subService.GetObjectBySignatureUrl(reqUrl);

        }

  
        public void get_object_with_query_signature_content_length_is(int arg1) 
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            Console.WriteLine("get_object_with_query_signature_statue:"+getObjectOutput.getStatueCode());
            int iLength = 0;
            if(getObjectOutput != null && getObjectOutput.getBodyInputStream() != null)
            {
                string buffer=getObjectOutput.getBodyInputStream().ReadToEnd();
                iLength = buffer.Length;
                Console.WriteLine("get_object_with_query_signature_length:"+iLength);
            }   
        
        }
    

        public void get_object_with_content_type(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
    	    Bucket.GetObjectInput input = new Bucket.GetObjectInput();
    	    input.setResponseContentType(arg1);
    	    getContentTypeOutput = subService.getObject(test_object, input);
        }


        public void get_object_content_type_is(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
    	    TestUtil.assertEqual(arg1,getContentTypeOutput.getResponseContentType());
        }
    

    
        public void head_object()
        {
            // Write code here that turns the phrase above into concrete actions
            Bucket.HeadObjectInput input = new Bucket.HeadObjectInput();
                
            headObjectOutput = subService.headObject(test_object,input);
        }

  
        public void head_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(headObjectOutput.getStatueCode(),arg1);
        }

  
        public void options_object_with_method_and_origin(String arg1, String arg2)
        {
            // Write code here that turns the phrase above into concrete actions
            Bucket.OptionsObjectInput input = new Bucket.OptionsObjectInput();
            input.setAccessControlRequestMethod(arg1);
            input.setOrigin(arg2);
            optionObjectOutput = subService.optionsObject(test_object_move,input);
        }

   
        public void options_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(optionObjectOutput.getStatueCode(),arg1);
        }

   
        public void delete_object()
        {
            // Write code here that turns the phrase above into concrete actions
            //Bucket.DeleteObjectInput input = new Bucket.DeleteObjectInput();
            deleteObjectOutput = subService.deleteObject(test_object);
        }

    
        public void delete_object_status_code_is(int arg1) 
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(deleteObjectOutput.getStatueCode(),arg1);
        }


        public void delete_the_move_object()
        {
            // Write code here that turns the phrase above into concrete actions
            //Bucket.DeleteObjectInput input = new Bucket.DeleteObjectInput();
            deleteObjectOutput2 = subService.deleteObject(test_object_move);
        }

        public void delete_the_move_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(deleteObjectOutput2.getStatueCode(),arg1);
        }
    }
}
