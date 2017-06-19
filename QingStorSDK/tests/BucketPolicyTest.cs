using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.com.qingstor.sdk.utils;

namespace QingStorSDK.tests
{
    class BucketPolicyTest
    {
        private String bucketName = TestUtil.getBucketName();

        private Bucket Bucket;

        private Bucket.PutBucketPolicyOutput putBucketPolicyOutput;
        private Bucket.GetBucketPolicyOutput getBucketPolicyOutput;
        private Bucket.DeleteBucketPolicyOutput deleteBucketPolicyOutput;

  
        public void initialize_the_bucket_policy()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
        }

    
        public void the_bucket_policy_is_initialized() 
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertNotNull(this.Bucket);
        }

  
        public void put_bucket_policy(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            Bucket.PutBucketPolicyInput input = new Bucket.PutBucketPolicyInput();
            input.setBodyInput(arg1);
            putBucketPolicyOutput = Bucket.putPolicy(input);
        }


        public void put_bucket_policy_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
    	    Console.WriteLine("put_bucket_policy_status_code_is:"+this.putBucketPolicyOutput.getMessage());
            TestUtil.assertEqual(this.putBucketPolicyOutput.getStatueCode(),arg1);
        }

   
        public void get_bucket_policy()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            getBucketPolicyOutput = Bucket.getPolicy();
        }

   
        public void get_bucket_policy_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(this.getBucketPolicyOutput.getStatueCode(),arg1);
        }

    
        public void get_bucket_policy_should_have_Referer(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("get_bucket_policy_should_have_Referer:\n"+this.getBucketPolicyOutput.getStatement());
        }

    
        public void delete_bucket_policy()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            deleteBucketPolicyOutput = Bucket.deletePolicy();
        }

    
        public void delete_bucket_policy_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(this.deleteBucketPolicyOutput.getStatueCode(),arg1);
        }
    }
}
