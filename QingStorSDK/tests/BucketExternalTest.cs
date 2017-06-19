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
    class BucketExternalTest
    {
        private Bucket Bucket;
        public  String bucketName = TestUtil.getBucketName();

        private Bucket.PutBucketExternalMirrorOutput putBucketExternalMirrorOutput;
        private Bucket.GetBucketExternalMirrorOutput getBucketExternalMirrorOutput;
        private Bucket.DeleteBucketExternalMirrorOutput deleteBucketExternalMirrorOutput;


  
        public void initialize_the_bucket_external_mirror()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
        }


        public void the_bucket_external_mirror_is_initialized()
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertNotNull(Bucket);
        }



        public void put_bucket_external_mirror(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            Bucket.PutBucketExternalMirrorInput input = new Bucket.PutBucketExternalMirrorInput();
            string obj = QSJSONUtil.convertJSONObject(arg1);
            input.setSourceSite(QSJSONUtil.toString(obj, "source_site"));
            putBucketExternalMirrorOutput  = Bucket.putExternalMirror(input);
        }

  
        public void put_bucket_external_mirror_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(putBucketExternalMirrorOutput.getStatueCode(),arg1);
        }

  
        public void get_bucket_external_mirror()
        {
            // Write code here that turns the phrase above into concrete actions

            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            getBucketExternalMirrorOutput = Bucket.getExternalMirror();
        }


        public void get_bucket_external_mirror_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(getBucketExternalMirrorOutput.getStatueCode(),arg1);
        }


        public void get_bucket_external_mirror_should_have_source_site(String arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("get_bucket_external_mirror_should_have_source_site:"+getBucketExternalMirrorOutput.getSourceSite());
        }

   
        public void delete_bucket_external_mirror()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);

            deleteBucketExternalMirrorOutput = Bucket.deleteExternalMirror();

        }

 
        public void delete_bucket_external_mirror_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            TestUtil.assertEqual(deleteBucketExternalMirrorOutput.getStatueCode(),arg1);
        }
    }
}
