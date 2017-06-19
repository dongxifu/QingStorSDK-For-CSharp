using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.tests;

namespace QingStorSDK.tests
{
    class BucketACLTest
    {
        private Bucket Bucket;
        public static String bucketName = TestUtil.getBucketName();

        private Bucket.PutBucketACLOutput putBucketACLOutput;
        private Bucket.GetBucketACLOutput getBucketACLOutput;

   
        public void initialize_the_bucket_ACL()
        {
        // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext(); 
        		//TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
        }

 
        public void the_bucket_ACL_is_initialized()
        {
        // Write code here that turns the phrase above into concrete actions
            TestUtil.assertNotNull(Bucket);
        }

    
        public void put_bucket_ACL()
        {
            // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            Bucket.PutBucketACLInput input = new Bucket.PutBucketACLInput();
            Types.ACLModel acl = new Types.ACLModel();
            acl.setPermission("FULL_CONTROL");
            Types.GranteeModel gm = new Types.GranteeModel();
            gm.setName("QS_ALL_USERS");
            gm.setType("group");
            acl.setGrantee(gm);
            List<Types.ACLModel> aa = new List<Types.ACLModel>();
            aa.Add(acl);
            input.setACL(aa);
            putBucketACLOutput = Bucket.putACL(input);
        }


        public void put_bucket_ACL_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("put_bucket_ACL_status_code_msg:"+this.putBucketACLOutput.getMessage());
            TestUtil.assertEqual(this.putBucketACLOutput.getStatueCode(),arg1);
        }
        public void get_bucket_ACL()
        {
        // Write code here that turns the phrase above into concrete actions
            EvnContext evnContext = TestUtil.getEvnContext();
            Bucket = new Bucket(evnContext,bucketName);
            getBucketACLOutput = Bucket.getACL();
        }

    
        public void get_bucket_ACL_status_code_is(int arg1)
        {
        // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("get_bucket_ACL_status_code_msg:"+this.getBucketACLOutput.getMessage());
            TestUtil.assertEqual(this.getBucketACLOutput.getStatueCode(),arg1);
        }


        public void get_bucket_ACL_shoud_have_grantee_name(String arg1)
        {
        // Write code here that turns the phrase above into concrete actions
            Console.WriteLine("get_bucket_ACL_shoud_have_grantee_name:"+this.getBucketACLOutput.getACL());
        }
    }
}
