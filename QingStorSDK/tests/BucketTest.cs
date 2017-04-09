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
    class BucketTest
    {
        private static Bucket Bucket;
	    private static String bucketName="";

	    private static Bucket.PutBucketOutput putBucketOutput;
	    private static Bucket.PutBucketOutput putBucketOutput2;
	    private static Bucket.ListObjectsOutput listObjectsOutput;
	    private static Bucket.HeadBucketOutput headBucketOutput;
	    private static Bucket.DeleteBucketOutput deleteBucketOutput;
	    private static Bucket.GetBucketStatisticsOutput getBucketStatisticsOutput;
	    private static Bucket.DeleteMultipleObjectsOutput deleteMultipleObjectsOutput;


	    public void initialize_the_bucket()
        {
		    // Write code here that turns the phrase above into concrete actions
		    bucketName = "java-test";
		    EvnContext evnContext = TestUtil.getEvnContext();
		    Bucket = new Bucket(evnContext, bucketName);

	    }


	    public void the_bucket_is_initialized()
        {
		    // Write code here that turns the phrase above into concrete actions
		    TestUtil.assertNotNull(Bucket);
	    }

	
	    public void put_bucket()
        {
		    // Write code here that turns the phrase above into concrete actions

		    //Bucket.PutBucketInput input = new Bucket.PutBucketInput();

		    putBucketOutput = Bucket.put();
	    }

	
	    public void put_bucket_status_code_is(int arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    TestUtil.assertEqual(putBucketOutput.getStatueCode(), arg1);
	    }

	
	    public void put_same_bucket_again()
        {
		    // Write code here that turns the phrase above into concrete actions

		    //Bucket.PutBucketInput input = new Bucket.PutBucketInput();

		    putBucketOutput2 = Bucket.put();
	    }

	
	    public void put_same_bucket_again_status_code_is(int arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    TestUtil.assertEqual(putBucketOutput2.getStatueCode(), arg1);
	    }

	
	    public void initialize_the_bucket_without_zone() 
        {
		    // Write code here that turns the phrase above into concrete actions
		    // throw new PendingException();
	    }

	
	    public void list_objects()
        {
		    // Write code here that turns the phrase above into concrete actions
		    Bucket.ListObjectsInput input = new Bucket.ListObjectsInput();
		    input.setLimit(20);
		    listObjectsOutput = Bucket.listObjects(input);
	    }
	    public void list_objects_status_code_is()
        {
		    // Write code here that turns the phrase above into concrete actions
            Console.WriteLine(bucketName + "list_objects:" + listObjectsOutput.getMessage());
	    }

	
	    public void list_objects_keys_count_is()
        {
		    // Write code here that turns the phrase above into concrete actions
		    Console.WriteLine("list_objects_keys_count_msg:" + listObjectsOutput.getPrefix());
	    }

	
	    public void head_bucket()
        {
		    // Write code here that turns the phrase above into concrete actions
		    headBucketOutput = Bucket.head();
	    }

	
	    public void head_bucket_status_code_is(int arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    TestUtil.assertEqual(headBucketOutput.getStatueCode(), arg1);
	    }

	
	    public void delete_bucket()
        {
		    // Write code here that turns the phrase above into concrete actions
		    deleteBucketOutput = Bucket.delete();
	    }

	
	    public void delete_bucket_status_code_is(int arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    Console.WriteLine("delete_bucket_message:" + deleteBucketOutput.getMessage());
		    TestUtil.assertEqual(deleteBucketOutput.getStatueCode(), arg1);
	    }

	
	    public void delete_multiple_objects(String arg1)
        {
		    // Write code here that turns the phrase above into concrete actions

		    Bucket.DeleteMultipleObjectsInput input = new Bucket.DeleteMultipleObjectsInput();
		    input.setBodyInput(arg1);
		    // arg1.raw().get(1)
		    //input.setBodyInput("{\"quiet\":false,\"objects\":[{\"key\":\"object_0\"},{\"key\":\"object_1\"},{\"key\":\"object_2\"}]}");
		    //input.setContentMD5("1UK03AxvZpSNLmYR2oz4qg==");
		    deleteMultipleObjectsOutput = Bucket
				.deleteMultipleObjects(input);
		    // throw new PendingException();
	    }


	    public void delete_multiple_objects_code_is(int arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    // throw new PendingException();
		    Console.WriteLine("delete_multiple_objects:" + deleteMultipleObjectsOutput.getMessage());
		    TestUtil.assertEqual(deleteMultipleObjectsOutput.getStatueCode(), arg1);
	    }


	    public void get_bucket_statistics()
        {
		    // Write code here that turns the phrase above into concrete actions

		    getBucketStatisticsOutput = Bucket
				.getStatistics();
	    }


	    public void get_bucket_statistics_status_code_is(int arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    Console.WriteLine("bucket_statistics:"+getBucketStatisticsOutput.getMessage());
		    TestUtil.assertEqual(getBucketStatisticsOutput.getStatueCode(), arg1);
	    }

	
	    public void get_bucket_statistics_status_is(String arg1)
        {
		    // Write code here that turns the phrase above into concrete actions
		    Console.WriteLine("get_bucket_statistics_status_msg:" + getBucketStatisticsOutput.getStatus());

	    }
    }
}
