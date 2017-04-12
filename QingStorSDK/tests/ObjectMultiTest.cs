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
    class ObjectMultiTest
    {
        private static Bucket Bucket;
        private static String bucketName = TestUtil.getBucketName();
        //private String multiObjectName = "test";
        private static String apkContentType = "application/vnd.android.package-archive";
        private static Bucket.UploadMultipartOutput uploadMultipartOutput1;
        private static Bucket.UploadMultipartOutput uploadMultipartOutput2;
        private static Bucket.UploadMultipartOutput uploadMultipartOutput3;
        private static Bucket.ListMultipartOutput listMultipartOutput;
        private static Bucket.CompleteMultipartUploadOutput completeMultipartUploadOutput;
        private static Bucket.AbortMultipartUploadOutput abortMultipartUploadOutput;
        private static Bucket.DeleteObjectOutput deleteObjectOutput;

        private static Bucket.InitiateMultipartUploadOutput initOutput;

        private static String multipart_upload_name = "";
        private static String multipart_upload_id = "";
   
        public void initiate_multipart_upload_with_key(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);

            Bucket.InitiateMultipartUploadInput input = new Bucket.InitiateMultipartUploadInput();
            //input.setContentType(apkContentType);

            initOutput = Bucket.initiateMultipartUpload(arg1,input);
            multipart_upload_name = arg1;
            multipart_upload_id = initOutput.getUploadID();
        }



    
        public void the_object_multipart_upload_is_initialized()
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertNotNull(initOutput);
            Console.WriteLine("the_object_multipart_upload_is_initialized:"+initOutput.getUploadID());
            multipart_upload_id = initOutput.getUploadID();
        }

 
        public void initiate_multipart_upload()
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException(); 03ce946f30943afa97b7cd82a11cd45d
        }

  
        public void initiate_multipart_upload_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            TestUtil.assertEqual(initOutput.getStatueCode(),arg1);
        }

  
        public void upload_the_first_part()
        {
            // Write code here that turns the phrase above into concrete actions
            //inputI.setContentType(apkContentType);

           
           

            int part_number = 0;
            FileStream f = new FileStream(System.Environment.CurrentDirectory + "/tmp/test_1",FileMode.Open);
            Bucket.UploadMultipartInput input = new Bucket.UploadMultipartInput();
            input.setContentLength((int) f.Length);
            input.setBodyInputFile(f);
            input.setPartNumber(part_number);
            input.setUploadID(multipart_upload_id);
            uploadMultipartOutput1 = Bucket.uploadMultipart(multipart_upload_name,input);

        }

   
        public void upload_the_first_part_status_code_is(int arg1) 
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("upload_the_first_part_status_code_msg"+uploadMultipartOutput1.getMessage());
            TestUtil.assertEqual(uploadMultipartOutput1.getStatueCode(),arg1);
        }


        public void upload_the_second_part()
        {
            // Write code here that turns the phrase above into concrete actions
           
            int part_number = 0;
            FileStream f = new FileStream(System.Environment.CurrentDirectory + "/tmp/test_2",FileMode.Open);
            Bucket.UploadMultipartInput input = new Bucket.UploadMultipartInput();
            input.setContentLength((int) f.Length);
            input.setBodyInputFile(f);
            input.setPartNumber(part_number);
            input.setUploadID(multipart_upload_id);
            uploadMultipartOutput2 = Bucket.uploadMultipart(multipart_upload_name,input);
        }

  
        public void upload_the_second_part_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("upload_the_first_part_status_code_is2"+uploadMultipartOutput2.getMessage());
            TestUtil.assertEqual(uploadMultipartOutput2.getStatueCode(),arg1);
        }

        public void upload_the_third_part()
        {
            // Write code here that turns the phrase above into concrete actions
           

            int part_number = 0;
            FileStream f = new FileStream(System.Environment.CurrentDirectory + "/tmp/test_3",FileMode.Open);
            Bucket.UploadMultipartInput input = new Bucket.UploadMultipartInput();
            input.setContentLength((int) f.Length);
            input.setBodyInputFile(f);
            input.setPartNumber(part_number);
            input.setUploadID(multipart_upload_id);
            uploadMultipartOutput3 = Bucket.uploadMultipart(multipart_upload_name,input);
        }

   
        public void upload_the_third_part_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(uploadMultipartOutput3.getStatueCode(),arg1);
        }

   
        public void list_multipart()
        {
            // Write code here that turns the phrase above into concrete actions


            Bucket.ListMultipartInput input = new Bucket.ListMultipartInput();
            input.setUploadID(initOutput.getUploadID());
            input.setLimit(10);
            listMultipartOutput = Bucket.listMultipart(multipart_upload_name,input);
        }


        public void list_multipart_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("list_multipart_status_code_msg"+listMultipartOutput.getMessage());
            TestUtil.assertEqual(listMultipartOutput.getStatueCode(),arg1);
        }

    
        public void list_multipart_object_parts_count_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("list_multipart_object_parts_count_is:"+listMultipartOutput.getCount());
        }

    
        public void complete_multipart_upload()
        {
            // Write code here that turns the phrase above into concrete actions
            Bucket.CompleteMultipartUploadInput input = new Bucket.CompleteMultipartUploadInput();
            //inputI.setContentType(apkContentType);



            input.setUploadID(initOutput.getUploadID());
            String content = "{\n" +
                "    \"object_parts\": [\n" +
                "        {\"part_number\": 0},\n" +
                "        {\"part_number\": 1},\n" +
                "        {\"part_number\": 2}\n" +
                "    ]\n" +
                "}";
            input.setBodyInput(content);

            completeMultipartUploadOutput = Bucket.completeMultipartUpload(multipart_upload_name,input);
        }

    
        public void complete_multipart_upload_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("complete_multipart_upload_status_code_msg"+completeMultipartUploadOutput.getMessage());
            TestUtil.assertEqual(completeMultipartUploadOutput.getStatueCode(),arg1);
        }


        public void abort_multipart_upload()
        {
            // Write code here that turns the phrase above into concrete actions
            Bucket.AbortMultipartUploadInput input = new Bucket.AbortMultipartUploadInput();
            //inputI.setContentType(apkContentType);


            input.setUploadID(initOutput.getUploadID());
            abortMultipartUploadOutput = Bucket.abortMultipartUpload(multipart_upload_name,input);

        }

  
        public void abort_multipart_upload_status_code_is(int arg1) 
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(abortMultipartUploadOutput.getStatueCode(),arg1);
        }

  
        public void delete_the_multipart_object()
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();

            deleteObjectOutput = Bucket.deleteObject(multipart_upload_name);

        }

  
        public void delete_the_multipart_object_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            //throw new PendingException();
            TestUtil.assertEqual(deleteObjectOutput.getStatueCode(), arg1);
        }
    }
}
