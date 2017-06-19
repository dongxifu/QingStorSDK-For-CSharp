using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.utils;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.model;

namespace QingStorSDK.tests
{
    class QingStorTest
    {
        private QingStor storSerivce;
	    private QingStor.ListBucketsOutput listOutput;
	

        public void initService()
        {
    	    EvnContext evnContext = TestUtil.getEvnContext(); 
    	    storSerivce = new QingStor(evnContext);
    	    Console.WriteLine("test : initService");
        }
    
   
        public void initialize_QingStor_service()
        {
            // Write code here that turns the phrase above into concrete actions
    	    EvnContext evnContext = TestUtil.getEvnContext(); 
    	    storSerivce = new QingStor(evnContext);
    	    Console.WriteLine("test : initService");
        }
    
   
        public void initialized_QingStor_service()
        {
            // Write code here that turns the phrase above into concrete actions
    	    if(this.storSerivce == null)
            {
    		    throw new Exception("not initialized");
    	    }
        }

   
        public void list_buckets()
        {
            // Write code here that turns the phrase above into concrete actions
        	EvnContext evnContext = TestUtil.getEvnContext(); 
    	    storSerivce = new QingStor(evnContext);
    	    listOutput = storSerivce.listBuckets(new QingStor.ListBucketsInput());
        }

    
        public void list_buckets_status_code_is(int arg1)
        {
            // Write code here that turns the phrase above into concrete actions
    	    TestUtil.assertNotNull(this.listOutput.getStatueCode());
    	    TestUtil.assertEqual(arg1, this.listOutput.getStatueCode());
        }
    }
}
