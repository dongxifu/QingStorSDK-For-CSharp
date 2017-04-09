using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.config;

namespace QingStorSDK.tests
{
    class BucketCORTest
    {
        public  String bucketName = TestUtil.getBucketName();
        private Bucket Bucket;

        private Bucket.PutBucketCORSOutput putBucketCORSOutput;
        private Bucket.GetBucketCORSOutput getBucketCORSOutput;
        private Bucket.DeleteBucketCORSOutput deleteBucketCORSOutput;

 
        public void initialize_the_bucket_CORS()
        {
        // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
        }


        public void the_bucket_CORS_is_initialized()
        {
        // Write code here that turns the phrase above into concrete actions
            TestUtil.assertNotNull(this.Bucket);
        }

        public void put_bucket_CORS(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            Bucket.PutBucketCORSInput input = new Bucket.PutBucketCORSInput();
            List<Object> cors = new List<Object>();

            input.setBodyInput(arg1);
            putBucketCORSOutput = Bucket.putCORS(input);
        }


        public void put_bucket_CORS_status_code_is(int arg1)
        {
        // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("put_bucket_CORS_status_code_msg:"+this.putBucketCORSOutput.getMessage());
            TestUtil.assertEqual(this.putBucketCORSOutput.getStatueCode(),arg1);
        }

 
        public void get_bucket_CORS()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            getBucketCORSOutput = Bucket.getCORS();
        }

  
        public void get_bucket_CORS_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(getBucketCORSOutput.getStatueCode(),arg1);
        }

   
        public void get_bucket_CORS_should_have_allowed_origin(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine ("get_bucket_CORS_should_have_allowed_origin_msg:"+this.getBucketCORSOutput.getMessage());
    }

   
        public void delete_bucket_CORS()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            deleteBucketCORSOutput = Bucket.deleteCORS();
        }


   
        public void delete_bucket_CORS_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(deleteBucketCORSOutput.getStatueCode(),arg1);
        }
    }
}
