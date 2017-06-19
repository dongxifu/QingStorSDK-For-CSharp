using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorSDK.com.qingstor.sdk.Attribute;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.exception;
using QingStorSDK.com.qingstor.sdk.model;

using QingStorSDK.com.qingstor.sdk.request;

using QingStorSDK.com.qingstor.sdk.service;

namespace QingStorSDK.com.qingstor.sdk.service
{
    class QingStor
    {
        private String zone;
    private EvnContext evnContext;
    private String bucketName;

    public QingStor(EvnContext evnContext) {
        
        this.evnContext = evnContext;
        this.zone = QSConstant.STOR_DEFAULT_ZONE;

    }

    public QingStor(EvnContext evnContext, String zone) {
        this.evnContext = evnContext;
        this.zone = zone;
    }

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/service/get.html
     */
    
    public ListBucketsOutput listBuckets(ListBucketsInput input)  {

        if (input == null) {
            input = new ListBucketsInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "ListBuckets");
        context.Add("APIName", "ListBuckets");
        context.Add("ServiceName", "Get Service");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/");
        context.Add("bucketNameInput", this.bucketName);

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(ListBucketsOutput));
        if (backModel != null) {
            return (ListBucketsOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/service/get.html
     */
    
    public void listBucketsAsync(
            ListBucketsInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new ListBucketsInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "ListBuckets");
        context.Add("APIName", "ListBuckets");
        context.Add("ServiceName", "Get Service");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/");
        context.Add("bucketNameInput", this.bucketName);

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class ListBucketsInput:RequestInputModel {

        // Limits results to buckets that in the location

        private String location;

        public void setLocation(String location) {
            this.location = location;
        }

        [Param(paramType = "header", paramName = "Location")]
        public String getLocation() {
            return this.location;
        }


        public override String validateParam()
        {

            return null;
        }
    }

    public class ListBucketsOutput: OutputModel {

        // Buckets information

        private List<Types.BucketModel> buckets;

        public void setBuckets(List<Types.BucketModel> buckets) {
            this.buckets = buckets;
        }

        [Param(paramType = "query", paramName = "buckets")]
        public List<Types.BucketModel> getBuckets() {
            return this.buckets;
        } // Bucket count

        private int count;

        public void setCount(int count) {
            this.count = count;
        }

        [Param(paramType = "query", paramName = "count")]
        public int getCount() {
            return this.count;
        }
    }

    public com.qingstor.sdk.service.Bucket getBucket(String bucketName) {
        return new com.qingstor.sdk.service.Bucket(this.evnContext, this.zone, bucketName);
    }

    public com.qingstor.sdk.service.Bucket getBucket(String bucketName, String zone) {
        return new com.qingstor.sdk.service.Bucket(this.evnContext, zone, bucketName);
    }

    }
}
