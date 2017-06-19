using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using QingStorSDK.com.qingstor.sdk.service;
using QingStorSDK.com.qingstor.sdk.Attribute;
using QingStorSDK.com.qingstor.sdk.config;
using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.exception;
using QingStorSDK.com.qingstor.sdk.model;
using QingStorSDK.com.qingstor.sdk.request;
using QingStorSDK.com.qingstor.sdk.utils;


namespace QingStorSDK.com.qingstor.sdk.service
{
    class Bucket
    {
        private String zone;
        private String bucketName;
        private EvnContext evnContext;

    public Bucket(EvnContext evnContext, String bucketName) {
        this.evnContext = evnContext;
        this.zone = QSConstant.STOR_DEFAULT_ZONE;
        this.bucketName = bucketName; 
    }
    public Bucket(String bucketName)
    {
        this.bucketName = bucketName;
    }
    public Bucket(EvnContext evnContext, String zone, String bucketName) {
        this.evnContext = evnContext;
        this.zone = zone;
        this.bucketName = bucketName;
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/delete.html
     */
    public DeleteBucketOutput delete()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucket");
        context.Add("APIName", "DeleteBucket");
        context.Add("ServiceName", "DELETE Bucket");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(DeleteBucketOutput));
        if (backModel != null) {
            return  (DeleteBucketOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/delete.html
     */
    public void deleteAsync(ResponseCallBack callback)  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucket");
        context.Add("APIName", "DeleteBucket");
        context.Add("ServiceName", "DELETE Bucket");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class DeleteBucketOutput : OutputModel {}

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/cors/delete_cors.html
     */
    public DeleteBucketCORSOutput deleteCORS()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucketCORS");
        context.Add("APIName", "DeleteBucketCORS");
        context.Add("ServiceName", "DELETE Bucket CORS");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>?cors");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(DeleteBucketCORSOutput));
        if (backModel != null) {
            return (DeleteBucketCORSOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/cors/delete_cors.html
     */
    public void deleteCORSAsync(ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucketCORS");
        context.Add("APIName", "DeleteBucketCORS");
        context.Add("ServiceName", "DELETE Bucket CORS");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>?cors");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class DeleteBucketCORSOutput : OutputModel {}

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/external_mirror/delete_external_mirror.html
     */
    public DeleteBucketExternalMirrorOutput deleteExternalMirror()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucketExternalMirror");
        context.Add("APIName", "DeleteBucketExternalMirror");
        context.Add("ServiceName", "DELETE Bucket External Mirror");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>?mirror");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(DeleteBucketExternalMirrorOutput));
        if (backModel != null) {
            return (DeleteBucketExternalMirrorOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/external_mirror/delete_external_mirror.html
     */
    public void deleteExternalMirrorAsync(
            ResponseCallBack callback)  {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucketExternalMirror");
        context.Add("APIName", "DeleteBucketExternalMirror");
        context.Add("ServiceName", "DELETE Bucket External Mirror");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>?mirror");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public  class DeleteBucketExternalMirrorOutput : OutputModel {}

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/policy/delete_policy.html
     */
    public DeleteBucketPolicyOutput deletePolicy()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucketPolicy");
        context.Add("APIName", "DeleteBucketPolicy");
        context.Add("ServiceName", "DELETE Bucket Policy");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>?policy");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(DeleteBucketPolicyOutput));
        if (backModel != null) {
            return (DeleteBucketPolicyOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/policy/delete_policy.html
     */
    public void deletePolicyAsync(ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteBucketPolicy");
        context.Add("APIName", "DeleteBucketPolicy");
        context.Add("ServiceName", "DELETE Bucket Policy");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>?policy");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class DeleteBucketPolicyOutput: OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/delete_multiple.html
     */
    public DeleteMultipleObjectsOutput deleteMultipleObjects(DeleteMultipleObjectsInput input)
             {

        if (input == null) {
            input = new DeleteMultipleObjectsInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteMultipleObjects");
        context.Add("APIName", "DeleteMultipleObjects");
        context.Add("ServiceName", "Delete Multiple Objects");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>?delete");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(DeleteMultipleObjectsOutput));
        if (backModel != null) {
            return (DeleteMultipleObjectsOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/delete_multiple.html
     */
    public void deleteMultipleObjectsAsync(
            DeleteMultipleObjectsInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new DeleteMultipleObjectsInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteMultipleObjects");
        context.Add("APIName", "DeleteMultipleObjects");
        context.Add("ServiceName", "Delete Multiple Objects");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>?delete");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class DeleteMultipleObjectsInput:RequestInputModel {


        // The request body
        private String bodyInput;

        [Param(paramType = "body", paramName = "BodyInput")]
        public String getBodyInput() {
            return bodyInput;
        }
        //Object json string
        public void setBodyInput(String bodyInput) {
            this.bodyInput = bodyInput;
        } // A list of keys to delete
        // Required
        
        private List<Types.KeyModel> objects;

        public void setObjects(List<Types.KeyModel> objects) {
            this.objects = objects;
        }


        [Param(paramType = "body", paramName = "objects")]
        public List<Types.KeyModel> getObjects() {
            return this.objects;
        } // Whether to return the list of deleted objects

        private Boolean quiet;

        public void setQuiet(Boolean quiet) {
            this.quiet = quiet;
        }

       [Param(paramType = "body", paramName = "quiet")]
        public Boolean getQuiet() {
            return this.quiet;
        }
       public override String validateParam()
       {

            if (this.getObjects() != null && this.getObjects().Count > 0) {
                for (int i = 0; i < this.getObjects().Count; i++) {
                    String vValidate = this.getObjects()[i].validateParam();
                    if (!QSStringUtil.isEmpty(vValidate)) {
                        return vValidate;
                    }
                }
            }

            return null;
        }
    }

    public class DeleteMultipleObjectsOutput : OutputModel {

        // List of deleted objects

        private List<Types.KeyModel> deleted;

        public void setDeleted(List<Types.KeyModel> deleted) {
            this.deleted = deleted;
        }

        [Param(paramType = "query", paramName = "deleted")]
        public List<Types.KeyModel> getDeleted() {
            return this.deleted;
        } // Error messages

        private List<Types.KeyDeleteErrorModel> errors;

        public void setErrors(List<Types.KeyDeleteErrorModel> errors) {
            this.errors = errors;
        }

        [Param(paramType = "query", paramName =  "errors")]
        public List<Types.KeyDeleteErrorModel> getErrors() {
            return this.errors;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/get_acl.html
     */
    public GetBucketACLOutput getACL()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketACL");
        context.Add("APIName", "GetBucketACL");
        context.Add("ServiceName", "GET Bucket ACL");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?acl");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(GetBucketACLOutput));
        if (backModel != null) {
            return (GetBucketACLOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/get_acl.html
     */
    public void getACLAsync(ResponseCallBack callback)  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketACL");
        context.Add("APIName", "GetBucketACL");
        context.Add("ServiceName", "GET Bucket ACL");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?acl");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class GetBucketACLOutput:OutputModel {

        // Bucket ACL rules

        private List<Types.ACLModel> aCL;

        public void setACL(List<Types.ACLModel> aCL) {
            this.aCL = aCL;
        }

        [Param(paramType = "query", paramName = "acl")]
        public List<Types.ACLModel> getACL() {
            return this.aCL;
        } // Bucket owner

        private Types.OwnerModel owner;

        public void setOwner(Types.OwnerModel owner) {
            this.owner = owner;
        }

        [Param(paramType = "query", paramName = "owner")]
        public Types.OwnerModel getOwner() {
            return this.owner;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/cors/get_cors.html
     */
    public GetBucketCORSOutput getCORS()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketCORS");
        context.Add("APIName", "GetBucketCORS");
        context.Add("ServiceName", "GET Bucket CORS");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?cors");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(GetBucketCORSOutput));
        if (backModel != null) {
            return (GetBucketCORSOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/cors/get_cors.html
     */
    public void getCORSAsync(ResponseCallBack callback)  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketCORS");
        context.Add("APIName", "GetBucketCORS");
        context.Add("ServiceName", "GET Bucket CORS");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?cors");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class GetBucketCORSOutput : OutputModel {

        // Bucket CORS rules

        private List<Types.CORSRuleModel> cORSRules;

        public void setCORSRules(List<Types.CORSRuleModel> cORSRules) {
            this.cORSRules = cORSRules;
        }

        [Param(paramType = "query", paramName = "cors_rules")]
        public List<Types.CORSRuleModel> getCORSRules() {
            return this.cORSRules;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/external_mirror/get_external_mirror.html
     */
    public GetBucketExternalMirrorOutput getExternalMirror()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketExternalMirror");
        context.Add("APIName", "GetBucketExternalMirror");
        context.Add("ServiceName", "GET Bucket External Mirror");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?mirror");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(GetBucketExternalMirrorOutput));
        if (backModel != null) {
            return (GetBucketExternalMirrorOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/external_mirror/get_external_mirror.html
     */
    public void getExternalMirrorAsync(ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketExternalMirror");
        context.Add("APIName", "GetBucketExternalMirror");
        context.Add("ServiceName", "GET Bucket External Mirror");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?mirror");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class GetBucketExternalMirrorOutput :OutputModel {

        // Source site url

        private String sourceSite;

        public void setSourceSite(String sourceSite) {
            this.sourceSite = sourceSite;
        }

        [Param(paramType = "query", paramName = "source_site")]
        public String getSourceSite() {
            return this.sourceSite;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://https://docs.qingcloud.com/qingstor/api/bucket/policy/get_policy.html
     */
    public GetBucketPolicyOutput getPolicy()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketPolicy");
        context.Add("APIName", "GetBucketPolicy");
        context.Add("ServiceName", "GET Bucket Policy");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?policy");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(GetBucketPolicyOutput));
        if (backModel != null) {
            return (GetBucketPolicyOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://https://docs.qingcloud.com/qingstor/api/bucket/policy/get_policy.html
     */
    public void getPolicyAsync(ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketPolicy");
        context.Add("APIName", "GetBucketPolicy");
        context.Add("ServiceName", "GET Bucket Policy");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?policy");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class GetBucketPolicyOutput: OutputModel {

        // Bucket policy statement

        private List<Types.StatementModel> statement;

        public void setStatement(List<Types.StatementModel> statement) {
            this.statement = statement;
        }

        [Param(paramType = "query", paramName = "statement")]
        public List<Types.StatementModel> getStatement() {
            return this.statement;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/get_stats.html
     */
    public GetBucketStatisticsOutput getStatistics()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketStatistics");
        context.Add("APIName", "GetBucketStatistics");
        context.Add("ServiceName", "GET Bucket Statistics");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?stats");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(GetBucketStatisticsOutput));
        if (backModel != null) {
            return (GetBucketStatisticsOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/get_stats.html
     */

    public void getStatisticsAsync(ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetBucketStatistics");
        context.Add("APIName", "GetBucketStatistics");
        context.Add("ServiceName", "GET Bucket Statistics");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>?stats");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class GetBucketStatisticsOutput: OutputModel {

        // Objects count in the bucket

        private int count;

        public void setCount(int count) {
            this.count = count;
        }

        [Param(paramType = "query", paramName = "count")]
        public int getCount() {
            return this.count;
        } // Bucket created time

        private String created;

        public void setCreated(String created) {
            this.created = created;
        }

        [Param(paramType = "query", paramName = "created")]
        public String getCreated() {
            return this.created;
        } // QingCloud Zone ID

        private String location;

        public void setLocation(String location) {
            this.location = location;
        }

        [Param(paramType = "query", paramName = "location")]
        public String getLocation() {
            return this.location;
        } // Bucket name

        private String name;

        public void setName(String name) {
            this.name = name;
        }

        [Param(paramType = "query", paramName = "name")]
        public String getName() {
            return this.name;
        } // Bucket storage size

        private int size;

        public void setSize(int size) {
            this.size = size;
        }

        [Param(paramType = "query", paramName = "size")]
        public int getSize() {
            return this.size;
        } // Bucket status
        // Status's available values: active, suspended

        private String status;

        public void setStatus(String status) {
            this.status = status;
        }

        [Param(paramType = "query", paramName = "status")]
        public String getStatus() {
            return this.status;
        } // URL to access the bucket

        private String uRL;

        public void setURL(String uRL) {
            this.uRL = uRL;
        }

        [Param(paramType = "query", paramName = "url")]
        public String getURL() {
            return this.uRL;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/head.html
     */
    public HeadBucketOutput head()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "HeadBucket");
        context.Add("APIName", "HeadBucket");
        context.Add("ServiceName", "HEAD Bucket");
        context.Add("RequestMethod", "HEAD");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(HeadBucketOutput));
        if (backModel != null) {
            return (HeadBucketOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/head.html
     */
   
    public void headAsync(ResponseCallBack callback)  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "HeadBucket");
        context.Add("APIName", "HeadBucket");
        context.Add("ServiceName", "HEAD Bucket");
        context.Add("RequestMethod", "HEAD");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class HeadBucketOutput:OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/get.html
     */
    public ListObjectsOutput listObjects(ListObjectsInput input)  {

        if (input == null) {
            input = new ListObjectsInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "ListObjects");
        context.Add("APIName", "ListObjects");
        context.Add("ServiceName", "GET Bucket (List Objects)");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(ListObjectsOutput));
        if (backModel != null) {
            return (ListObjectsOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/get.html
     */
    public void listObjectsAsync(
            ListObjectsInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new ListObjectsInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "ListObjects");
        context.Add("APIName", "ListObjects");
        context.Add("ServiceName", "GET Bucket (List Objects)");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class ListObjectsInput:RequestInputModel {
        // Put all keys that share a common prefix into a list

        private String delimiter;

        public void setDelimiter(String delimiter) {
            this.delimiter = delimiter;
        }

        [Param(paramType = "query", paramName = "delimiter")]
        public String getDelimiter() {
            return this.delimiter;
        } // Results count limit

        private int limit;

        public void setLimit(int limit) {
            this.limit = limit;
        }

        [Param(paramType = "query", paramName = "limit")]
        public int getLimit() {
            return this.limit;
        } // Limit results to keys that start at this marker

        private String marker;

        public void setMarker(String marker) {
            this.marker = marker;
        }

        [Param(paramType = "query", paramName = "marker")]
        public String getMarker() {
            return this.marker;
        } // Limits results to keys that begin with the prefix

        private String prefix;

        public void setPrefix(String prefix) {
            this.prefix = prefix;
        }

       [Param(paramType = "query", paramName ="prefix")]
        public String getPrefix() {
            return this.prefix;
        }

       public override String validateParam()
       {

            return null;
        }
    }

    public class ListObjectsOutput:OutputModel {

        // Other object keys that share common prefixes

        private List<String> commonPrefixes;

        public void setCommonPrefixes(List<String> commonPrefixes) {
            this.commonPrefixes = commonPrefixes;
        }

        [Param(paramType = "query", paramName = "common_prefixes")]
        public List<String> getCommonPrefixes() {
            return this.commonPrefixes;
        } // Delimiter that specified in request parameters

        private String delimiter;

        public void setDelimiter(String delimiter) {
            this.delimiter = delimiter;
        }

        [Param(paramType = "query", paramName = "delimiter")]
        public String getDelimiter() {
            return this.delimiter;
        } // Object keys

        private List<Types.KeyModel> keys;

        public void setKeys(List<Types.KeyModel> keys) {
            this.keys = keys;
        }

        [Param(paramType = "query", paramName ="keys")]
        public List<Types.KeyModel> getKeys() {
            return this.keys;
        } // Limit that specified in request parameters

        private int limit;

        public void setLimit(int limit) {
            this.limit = limit;
        }

        [Param(paramType = "query", paramName = "limit")]
        public int getLimit() {
            return this.limit;
        } // Marker that specified in request parameters

        private String marker;

        public void setMarker(String marker) {
            this.marker = marker;
        }

        [Param(paramType = "query", paramName = "marker")]
        public String getMarker() {
            return this.marker;
        } // Bucket name

        private String name;

        public void setName(String name) {
            this.name = name;
        }

        [Param(paramType = "query", paramName ="name")]
        public String getName() {
            return this.name;
        } // The last key in keys list

        private String nextMarker;

        public void setNextMarker(String nextMarker) {
            this.nextMarker = nextMarker;
        }

        [Param(paramType = "query", paramName =  "next_marker")]
        public String getNextMarker() {
            return this.nextMarker;
        } // Bucket owner

        private Types.OwnerModel owner;

        public void setOwner(Types.OwnerModel owner) {
            this.owner = owner;
        }

        [Param(paramType = "query", paramName = "owner")]
        public Types.OwnerModel getOwner() {
            return this.owner;
        } // Prefix that specified in request parameters

        private String prefix;

        public void setPrefix(String prefix) {
            this.prefix = prefix;
        }

        [Param(paramType = "query", paramName = "prefix")]
        public String getPrefix() {
            return this.prefix;
        }
    }

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/put.html
     */
    public PutBucketOutput put()  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucket");
        context.Add("APIName", "PutBucket");
        context.Add("ServiceName", "PUT Bucket");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(PutBucketOutput));
        if (backModel != null) {
            return (PutBucketOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/put.html
     */
    public void putAsync(ResponseCallBack callback)  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucket");
        context.Add("APIName", "PutBucket");
        context.Add("ServiceName", "PUT Bucket");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class PutBucketOutput :OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/put_acl.html
     */
    public PutBucketACLOutput putACL(PutBucketACLInput input)  {

        if (input == null) {
            input = new PutBucketACLInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketACL");
        context.Add("APIName", "PutBucketACL");
        context.Add("ServiceName", "PUT Bucket ACL");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?acl");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(PutBucketACLOutput));
        if (backModel != null) {
            return (PutBucketACLOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/put_acl.html
     */
    public void putACLAsync(PutBucketACLInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new PutBucketACLInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketACL");
        context.Add("APIName", "PutBucketACL");
        context.Add("ServiceName", "PUT Bucket ACL");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?acl");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class PutBucketACLInput :RequestInputModel {

        // The request body
        private String bodyInput;

        [Param(paramType = "body", paramName = "BodyInput")]
        public String getBodyInput() {
            return bodyInput;
        }
        //Object json string
        public void setBodyInput(String bodyInput) {
            this.bodyInput = bodyInput;
        } // Bucket ACL rules
        // Required

        private List<Types.ACLModel> aCL;

        public void setACL(List<Types.ACLModel> aCL) {
            this.aCL = aCL;
        }

        [Param(paramType = "body", paramName = "acl")]
        public List<Types.ACLModel> getACL() {
            return this.aCL;
        }

        public override String validateParam()
        {

            if (this.getACL() != null && this.getACL().Count > 0) {
                for (int i = 0; i < this.getACL().Count; i++) {
                    String vValidate = this.getACL()[i].validateParam();
                    if (!QSStringUtil.isEmpty(vValidate)) {
                        return vValidate;
                    }
                }
            }

            return null;
        }
    }

    public class PutBucketACLOutput: OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/cors/put_cors.html
     */
    public PutBucketCORSOutput putCORS(PutBucketCORSInput input)  {

        if (input == null) {
            input = new PutBucketCORSInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketCORS");
        context.Add("APIName", "PutBucketCORS");
        context.Add("ServiceName", "PUT Bucket CORS");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?cors");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(PutBucketCORSOutput));
        if (backModel != null) {
            return (PutBucketCORSOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/cors/put_cors.html
     */
    public void putCORSAsync(
            PutBucketCORSInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new PutBucketCORSInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketCORS");
        context.Add("APIName", "PutBucketCORS");
        context.Add("ServiceName", "PUT Bucket CORS");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?cors");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class PutBucketCORSInput : RequestInputModel {

        // The request body
        private String bodyInput;

        [Param(paramType = "body", paramName = "BodyInput")]
        public String getBodyInput() {
            return bodyInput;
        }
        //Object json string
        public void setBodyInput(String bodyInput) {
            this.bodyInput = bodyInput;
        } // Bucket CORS rules
        // Required

        private List<Types.CORSRuleModel> cORSRules;

        public void setCORSRules(List<Types.CORSRuleModel> cORSRules) {
            this.cORSRules = cORSRules;
        }

        [Param(paramType = "body", paramName =  "cors_rules")]
        public List<Types.CORSRuleModel> getCORSRules() {
            return this.cORSRules;
        }

        public override String validateParam()
        {

            if (this.getCORSRules() != null && this.getCORSRules().Count > 0) {
                for (int i = 0; i < this.getCORSRules().Count; i++) {
                    String vValidate = this.getCORSRules()[i].validateParam();
                    if (!QSStringUtil.isEmpty(vValidate)) {
                        return vValidate;
                    }
                }
            }

            return null;
        }
    }

    public class PutBucketCORSOutput : OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/external_mirror/put_external_mirror.html
     */
    public PutBucketExternalMirrorOutput putExternalMirror(PutBucketExternalMirrorInput input)
             {

        if (input == null) {
            input = new PutBucketExternalMirrorInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketExternalMirror");
        context.Add("APIName", "PutBucketExternalMirror");
        context.Add("ServiceName", "PUT Bucket External Mirror");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?mirror");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(PutBucketExternalMirrorOutput));
        if (backModel != null) {
            return (PutBucketExternalMirrorOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/external_mirror/put_external_mirror.html
     */
  
    public void putExternalMirrorAsync(
            PutBucketExternalMirrorInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new PutBucketExternalMirrorInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketExternalMirror");
        context.Add("APIName", "PutBucketExternalMirror");
        context.Add("ServiceName", "PUT Bucket External Mirror");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?mirror");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class PutBucketExternalMirrorInput: RequestInputModel {

        // The request body
        private String bodyInput;

        [Param(paramType = "body", paramName = "BodyInput")]
        public String getBodyInput() {
            return bodyInput;
        }
        //Object json string
        public void setBodyInput(String bodyInput) {
            this.bodyInput = bodyInput;
        } // Source site url
        // Required

        private String sourceSite;

        public void setSourceSite(String sourceSite) {
            this.sourceSite = sourceSite;
        }

        [Param(paramType = "body", paramName ="source_site")]
        public String getSourceSite() {
            return this.sourceSite;
        }


        public override String validateParam()
        {

            if (QSStringUtil.isEmpty(this.getSourceSite())) {
                return QSStringUtil.getParameterRequired(
                        "SourceSite", "PutBucketExternalMirrorInput");
            }

            return null;
        }
    }

    public class PutBucketExternalMirrorOutput:OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/policy/put_policy.html
     */
    public PutBucketPolicyOutput putPolicy(PutBucketPolicyInput input)  {

        if (input == null) {
            input = new PutBucketPolicyInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketPolicy");
        context.Add("APIName", "PutBucketPolicy");
        context.Add("ServiceName", "PUT Bucket Policy");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?policy");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(PutBucketPolicyOutput));
        if (backModel != null) {
            return (PutBucketPolicyOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/bucket/policy/put_policy.html
     */
    public void putPolicyAsync(
            PutBucketPolicyInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new PutBucketPolicyInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutBucketPolicy");
        context.Add("APIName", "PutBucketPolicy");
        context.Add("ServiceName", "PUT Bucket Policy");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>?policy");
        context.Add("bucketNameInput", this.bucketName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class PutBucketPolicyInput: RequestInputModel {

        // The request body
        private String bodyInput;

        [Param(paramType = "body", paramName = "BodyInput")]
        public String getBodyInput() {
            return bodyInput;
        }
        //Object json string
        public void setBodyInput(String bodyInput) {
            this.bodyInput = bodyInput;
        } // Bucket policy statement
        // Required

        private List<Types.StatementModel> statement;

        public void setStatement(List<Types.StatementModel> statement) {
            this.statement = statement;
        }

        [Param(paramType = "body", paramName = "statement")]
        public List<Types.StatementModel> getStatement() {
            return this.statement;
        }


        public override String validateParam()
        {

            if (this.getStatement() != null && this.getStatement().Count > 0) {
                for (int i = 0; i < this.getStatement().Count; i++) {
                    String vValidate = this.getStatement()[i].validateParam();
                    if (!QSStringUtil.isEmpty(vValidate)) {
                        return vValidate;
                    }
                }
            }

            return null;
        }
    }

    public class PutBucketPolicyOutput : OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/abort_multipart_upload.html
     */
    public AbortMultipartUploadOutput abortMultipartUpload(
            String objectName, AbortMultipartUploadInput input)  {

        if (input == null) {
            input = new AbortMultipartUploadInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "AbortMultipartUpload");
        context.Add("APIName", "AbortMultipartUpload");
        context.Add("ServiceName", "Abort Multipart Upload");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(AbortMultipartUploadOutput));
        if (backModel != null) {
            return (AbortMultipartUploadOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/abort_multipart_upload.html
     */
    public void abortMultipartUploadAsync(
            String objectName,
            AbortMultipartUploadInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new AbortMultipartUploadInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "AbortMultipartUpload");
        context.Add("APIName", "AbortMultipartUpload");
        context.Add("ServiceName", "Abort Multipart Upload");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class AbortMultipartUploadInput : RequestInputModel {
        // Object multipart upload ID
        // Required

        private String uploadID;

        public void setUploadID(String uploadID) {
            this.uploadID = uploadID;
        }

        [Param(paramType = "query", paramName = "upload_id")]
        public String getUploadID() {
            return this.uploadID;
        }
        public override String validateParam()
        {

            if (QSStringUtil.isEmpty(this.getUploadID())) {
                return QSStringUtil.getParameterRequired("UploadID", "AbortMultipartUploadInput");
            }

            return null;
        }
    }

    public class AbortMultipartUploadOutput :OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/complete_multipart_upload.html
     */
    public CompleteMultipartUploadOutput completeMultipartUpload(
            String objectName, CompleteMultipartUploadInput input)  {

        if (input == null) {
            input = new CompleteMultipartUploadInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "CompleteMultipartUpload");
        context.Add("APIName", "CompleteMultipartUpload");
        context.Add("ServiceName", "Complete multipart upload");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(CompleteMultipartUploadOutput));
        if (backModel != null) {
            return (CompleteMultipartUploadOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/complete_multipart_upload.html
     */
    public void completeMultipartUploadAsync(
            String objectName,
            CompleteMultipartUploadInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new CompleteMultipartUploadInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "CompleteMultipartUpload");
        context.Add("APIName", "CompleteMultipartUpload");
        context.Add("ServiceName", "Complete multipart upload");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class CompleteMultipartUploadInput : RequestInputModel {
        // Object multipart upload ID
        // Required

        private String uploadID;

        public void setUploadID(String uploadID) {
            this.uploadID = uploadID;
        }

        [Param(paramType = "query", paramName = "upload_id")]
        public String getUploadID() {
            return this.uploadID;
        }

        // MD5sum of the object part

        private String eTag;

        public void setETag(String eTag) {
            this.eTag = eTag;
        }

        [Param(paramType = "header", paramName = "ETag")]
        public String getETag() {
            return this.eTag;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSEncryptionCustomerKey;

        public void setXQSEncryptionCustomerKey(String xQSEncryptionCustomerKey) {
            this.xQSEncryptionCustomerKey = xQSEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key")]
        public String getXQSEncryptionCustomerKey() {
            return this.xQSEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSEncryptionCustomerKeyMD5;

        public void setXQSEncryptionCustomerKeyMD5(String xQSEncryptionCustomerKeyMD5) {
            this.xQSEncryptionCustomerKeyMD5 = xQSEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName =  "X-QS-Encryption-Customer-Key-MD5")]
        public String getXQSEncryptionCustomerKeyMD5() {
            return this.xQSEncryptionCustomerKeyMD5;
        }

        private String bodyInput;

        [Param(paramType = "body", paramName = "BodyInput")]
        public String getBodyInput() {
            return bodyInput;
        }
        //Object json string
        public void setBodyInput(String bodyInput) {
            this.bodyInput = bodyInput;
        } // Object parts

        private List<Types.ObjectPartModel> objectParts;

        public void setObjectParts(List<Types.ObjectPartModel> objectParts) {
            this.objectParts = objectParts;
        }

       [Param(paramType = "body", paramName ="object_parts")]
        public List<Types.ObjectPartModel> getObjectParts() {
            return this.objectParts;
        }


       public override String validateParam()
       {

            if (QSStringUtil.isEmpty(this.getUploadID())) {
                return QSStringUtil.getParameterRequired(
                        "UploadID", "CompleteMultipartUploadInput");
            }

            if (this.getObjectParts() != null && this.getObjectParts().Count > 0) {
                for (int i = 0; i < this.getObjectParts().Count; i++) {
                    String vValidate = this.getObjectParts()[i].validateParam();
                    if (!QSStringUtil.isEmpty(vValidate)) {
                        return vValidate;
                    }
                }
            }

            return null;
        }
    }

    public class CompleteMultipartUploadOutput :OutputModel {}

    /*
     *
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/delete.html
     */
    public DeleteObjectOutput deleteObject(String objectName)  {

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteObject");
        context.Add("APIName", "DeleteObject");
        context.Add("ServiceName", "DELETE Object");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, null, typeof(DeleteObjectOutput));
        if (backModel != null) {
            return (DeleteObjectOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/delete.html
     */
    public void deleteObjectAsync(String objectName, ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "DeleteObject");
        context.Add("APIName", "DeleteObject");
        context.Add("ServiceName", "DELETE Object");
        context.Add("RequestMethod", "DELETE");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, null, callback);
    }

    public class DeleteObjectOutput : OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/get.html
     */
    public GetObjectOutput getObject(String objectName, GetObjectInput input)  {

        if (input == null) {
            input = new GetObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetObject");
        context.Add("APIName", "GetObject");
        context.Add("ServiceName", "GET Object");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(GetObjectOutput));
        if (backModel != null) {
            return (GetObjectOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/get.html
     */
   
    public void getObjectAsync(
            String objectName, GetObjectInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new GetObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetObject");
        context.Add("APIName", "GetObject");
        context.Add("ServiceName", "GET Object");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class GetObjectInput :RequestInputModel {
        // Specified the Cache-Control response header

        private String responseCacheControl;

        public void setResponseCacheControl(String responseCacheControl) {
            this.responseCacheControl = responseCacheControl;
        }

        [Param(paramType = "query", paramName = "response-cache-control")]
        public String getResponseCacheControl() {
            return this.responseCacheControl;
        } // Specified the Content-Disposition response header

        private String responseContentDisposition;

        public void setResponseContentDisposition(String responseContentDisposition) {
            this.responseContentDisposition = responseContentDisposition;
        }

        [Param(paramType = "query", paramName = "response-content-disposition")]
        public String getResponseContentDisposition() {
            return this.responseContentDisposition;
        } // Specified the Content-Encoding response header

        private String responseContentEncoding;

        public void setResponseContentEncoding(String responseContentEncoding) {
            this.responseContentEncoding = responseContentEncoding;
        }

        [Param(paramType = "query", paramName = "response-content-encoding")]
        public String getResponseContentEncoding() {
            return this.responseContentEncoding;
        } // Specified the Content-Language response header

        private String responseContentLanguage;

        public void setResponseContentLanguage(String responseContentLanguage) {
            this.responseContentLanguage = responseContentLanguage;
        }

        [Param(paramType = "query", paramName = "response-content-language")]
        public String getResponseContentLanguage() {
            return this.responseContentLanguage;
        } // Specified the Content-Type response header

        private String responseContentType;

        public void setResponseContentType(String responseContentType) {
            this.responseContentType = responseContentType;
        }

        [Param(paramType = "query", paramName = "response-content-type")]
        public String getResponseContentType() {
            return this.responseContentType;
        } // Specified the Expires response header

        private String responseExpires;

        public void setResponseExpires(String responseExpires) {
            this.responseExpires = responseExpires;
        }

        [Param(paramType = "query", paramName =  "response-expires")]
        public String getResponseExpires() {
            return this.responseExpires;
        }

        // Check whether the ETag matches

        private String ifMatch;

        public void setIfMatch(String ifMatch) {
            this.ifMatch = ifMatch;
        }

        [Param(paramType = "header", paramName = "If-Match")]
        public String getIfMatch() {
            return this.ifMatch;
        } // Check whether the object has been modified

        private String ifModifiedSince;

        public void setIfModifiedSince(String ifModifiedSince) {
            this.ifModifiedSince = ifModifiedSince;
        }

        [Param(paramType = "header", paramName = "If-Modified-Since")]
        public String getIfModifiedSince() {
            return this.ifModifiedSince;
        } // Check whether the ETag does not match

        private String ifNoneMatch;

        public void setIfNoneMatch(String ifNoneMatch) {
            this.ifNoneMatch = ifNoneMatch;
        }

        [Param(paramType = "header", paramName = "If-None-Match")]
        public String getIfNoneMatch() {
            return this.ifNoneMatch;
        } // Check whether the object has not been modified

        private String ifUnmodifiedSince;

        public void setIfUnmodifiedSince(String ifUnmodifiedSince) {
            this.ifUnmodifiedSince = ifUnmodifiedSince;
        }

        [Param(paramType = "header", paramName = "If-Unmodified-Since")]
        public String getIfUnmodifiedSince() {
            return this.ifUnmodifiedSince;
        } // Specified range of the object

        private String range;

        public void setRange(String range) {
            this.range = range;
        }

        [Param(paramType = "header", paramName = "Range")]
        public String getRange() {
            return this.range;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSEncryptionCustomerKey;

        public void setXQSEncryptionCustomerKey(String xQSEncryptionCustomerKey) {
            this.xQSEncryptionCustomerKey = xQSEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName =  "X-QS-Encryption-Customer-Key")]
        public String getXQSEncryptionCustomerKey() {
            return this.xQSEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSEncryptionCustomerKeyMD5;

        public void setXQSEncryptionCustomerKeyMD5(String xQSEncryptionCustomerKeyMD5) {
            this.xQSEncryptionCustomerKeyMD5 = xQSEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key-MD5")]
        public String getXQSEncryptionCustomerKeyMD5() {
            return this.xQSEncryptionCustomerKeyMD5;
        }


        public override String validateParam()
        {

            return null;
        }
    }

    public class GetObjectOutput : OutputModel {

        // The response body
        private StreamReader bodyInputStream;

        [Param(paramType = "body", paramName = "BodyInputStream")]
        public StreamReader getBodyInputStream() {
            return bodyInputStream;
        }

        public void setBodyInputStream(StreamReader bodyInputStream) {
            this.bodyInputStream = bodyInputStream;
        }

        // Range of response data content

        private String contentRange;

        public void setContentRange(String contentRange) {
            this.contentRange = contentRange;
        }

        [Param(paramType = "header", paramName = "Content-Range")]
        public String getContentRange() {
            return this.contentRange;
        } // MD5sum of the object

        // Specified the Cache-Control response header

        private String responseCacheControl;

        public void setResponseCacheControl(String responseCacheControl) {
            this.responseCacheControl = responseCacheControl;
        }

        [Param(paramType = "header", paramName = "Cache-Control")]
        public String getResponseCacheControl() {
            return this.responseCacheControl;
        } // Specified the Content-Disposition response header

        private String responseContentDisposition;

        public void setResponseContentDisposition(String responseContentDisposition) {
            this.responseContentDisposition = responseContentDisposition;
        }

        [Param(paramType = "header", paramName = "Content-Disposition")]
        public String getResponseContentDisposition() {
            return this.responseContentDisposition;
        } // Specified the Content-Encoding response header

        private String responseContentEncoding;

        public void setResponseContentEncoding(String responseContentEncoding) {
            this.responseContentEncoding = responseContentEncoding;
        }

        [Param(paramType = "header", paramName = "Content-Encoding")]
        public String getResponseContentEncoding() {
            return this.responseContentEncoding;
        } // Specified the Content-Language response header

        private String responseContentLanguage;

        public void setResponseContentLanguage(String responseContentLanguage) {
            this.responseContentLanguage = responseContentLanguage;
        }

        [Param(paramType = "header", paramName = "Content-Language")]
        public String getResponseContentLanguage() {
            return this.responseContentLanguage;
        } // Specified the Content-Type response header

        private String responseContentType;

        public void setResponseContentType(String responseContentType) {
            this.responseContentType = responseContentType;
        }

        [Param(paramType = "header", paramName =  "Content-Type")]
        public String getResponseContentType() {
            return this.responseContentType;
        } // Specified the Expires response header

        private String responseExpires;

        public void setResponseExpires(String responseExpires) {
            this.responseExpires = responseExpires;
        }

        [Param(paramType = "header", paramName = "Expires")]
        public String getResponseExpires() {
            return this.responseExpires;
        }


        
        private String eTag;

        public void setETag(String eTag) {
            this.eTag = eTag;
        }

        [Param(paramType = "header", paramName = "ETag")]
        public String getETag() {
            return this.eTag;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        }
    }

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/head.html
     */
   
    public HeadObjectOutput headObject(String objectName, HeadObjectInput input)
             {

        if (input == null) {
            input = new HeadObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "HeadObject");
        context.Add("APIName", "HeadObject");
        context.Add("ServiceName", "HEAD Object");
        context.Add("RequestMethod", "HEAD");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(HeadObjectOutput));
        if (backModel != null) {
            return (HeadObjectOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/head.html
     */
    public void headObjectAsync(
            String objectName, HeadObjectInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new HeadObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "HeadObject");
        context.Add("APIName", "HeadObject");
        context.Add("ServiceName", "HEAD Object");
        context.Add("RequestMethod", "HEAD");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class HeadObjectInput : RequestInputModel {

        // Check whether the ETag matches

        private String ifMatch;

        public void setIfMatch(String ifMatch) {
            this.ifMatch = ifMatch;
        }

        [Param(paramType = "header", paramName = "If-Match")]
        public String getIfMatch() {
            return this.ifMatch;
        } // Check whether the object has been modified

        private String ifModifiedSince;

        public void setIfModifiedSince(String ifModifiedSince) {
            this.ifModifiedSince = ifModifiedSince;
        }

        [Param(paramType = "header", paramName = "If-Modified-Since")]
        public String getIfModifiedSince() {
            return this.ifModifiedSince;
        } // Check whether the ETag does not match

        private String ifNoneMatch;

        public void setIfNoneMatch(String ifNoneMatch) {
            this.ifNoneMatch = ifNoneMatch;
        }

        [Param(paramType = "header", paramName = "If-None-Match")]
        public String getIfNoneMatch() {
            return this.ifNoneMatch;
        } // Check whether the object has not been modified

        private String ifUnmodifiedSince;

        public void setIfUnmodifiedSince(String ifUnmodifiedSince) {
            this.ifUnmodifiedSince = ifUnmodifiedSince;
        }

        [Param(paramType = "header", paramName = "If-Unmodified-Since")]
        public String getIfUnmodifiedSince() {
            return this.ifUnmodifiedSince;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSEncryptionCustomerKey;

        public void setXQSEncryptionCustomerKey(String xQSEncryptionCustomerKey) {
            this.xQSEncryptionCustomerKey = xQSEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key")]
        public String getXQSEncryptionCustomerKey() {
            return this.xQSEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSEncryptionCustomerKeyMD5;

        public void setXQSEncryptionCustomerKeyMD5(String xQSEncryptionCustomerKeyMD5) {
            this.xQSEncryptionCustomerKeyMD5 = xQSEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key-MD5")]
        public String getXQSEncryptionCustomerKeyMD5() {
            return this.xQSEncryptionCustomerKeyMD5;
        }


        public override String validateParam()
        {

            return null;
        }
    }

    public class HeadObjectOutput :OutputModel {

        // Object content length

        private int contentLength;

        public void setContentLength(int contentLength) {
            this.contentLength = contentLength;
        }

        [Param(paramType = "header", paramName = "Content-Length")]
        public int getContentLength() {
            return this.contentLength;
        } // Object content type

        private String contentType;

        public void setContentType(String contentType) {
            this.contentType = contentType;
        }

        [Param(paramType = "header", paramName = "Content-Type")]
        public String getContentType() {
            return this.contentType;
        } // MD5sum of the object

        private String eTag;

        public void setETag(String eTag) {
            this.eTag = eTag;
        }

        [Param(paramType = "header", paramName = "ETag")]
        public String getETag() {
            return this.eTag;
        }

        private String lastModified;

        public void setLastModified(String lastModified) {
            this.lastModified = lastModified;
        }

        [Param(paramType = "header", paramName = "Last-Modified")]
        public String getLastModified() {
            return this.lastModified;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        }
    }

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/initiate_multipart_upload.html
     */

    public InitiateMultipartUploadOutput initiateMultipartUpload(
            String objectName, InitiateMultipartUploadInput input)  {

        if (input == null) {
            input = new InitiateMultipartUploadInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "InitiateMultipartUpload");
        context.Add("APIName", "InitiateMultipartUpload");
        context.Add("ServiceName", "Initiate Multipart Upload");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>/<object-key>?uploads");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(InitiateMultipartUploadOutput));
        if (backModel != null) {
            return (InitiateMultipartUploadOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/initiate_multipart_upload.html
     */

    public void initiateMultipartUploadAsync(
            String objectName,
            InitiateMultipartUploadInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new InitiateMultipartUploadInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "InitiateMultipartUpload");
        context.Add("APIName", "InitiateMultipartUpload");
        context.Add("ServiceName", "Initiate Multipart Upload");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>/<object-key>?uploads");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class InitiateMultipartUploadInput : RequestInputModel {

        // Object content type

        private String contentType;

        public void setContentType(String contentType) {
            this.contentType = contentType;
        }

        [Param(paramType = "header", paramName = "Content-Type")]
        public String getContentType() {
            return this.contentType;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName =  "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSEncryptionCustomerKey;

        public void setXQSEncryptionCustomerKey(String xQSEncryptionCustomerKey) {
            this.xQSEncryptionCustomerKey = xQSEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key")]
        public String getXQSEncryptionCustomerKey() {
            return this.xQSEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSEncryptionCustomerKeyMD5;

        public void setXQSEncryptionCustomerKeyMD5(String xQSEncryptionCustomerKeyMD5) {
            this.xQSEncryptionCustomerKeyMD5 = xQSEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName =  "X-QS-Encryption-Customer-Key-MD5")]
        public String getXQSEncryptionCustomerKeyMD5() {
            return this.xQSEncryptionCustomerKeyMD5;
        }


        public override String validateParam()
        {

            return null;
        }
    }

    public class InitiateMultipartUploadOutput :OutputModel {

        // Bucket name

        private String bucket;

        public void setBucket(String bucket) {
            this.bucket = bucket;
        }

        [Param(paramType = "query", paramName = "bucket")]
        public String getBucket() {
            return this.bucket;
        } // Object key

        private String key;

        public void setKey(String key) {
            this.key = key;
        }

        [Param(paramType = "query", paramName = "key")]
        public String getKey() {
            return this.key;
        } // Object multipart upload ID

        private String uploadID;

        public void setUploadID(String uploadID) {
            this.uploadID = uploadID;
        }

        [Param(paramType = "query", paramName ="upload_id")]
        public String getUploadID() {
            return this.uploadID;
        }

        // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        }
    }

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/list_multipart.html
     */
    
    public ListMultipartOutput listMultipart(String objectName, ListMultipartInput input)
             {

        if (input == null) {
            input = new ListMultipartInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "ListMultipart");
        context.Add("APIName", "ListMultipart");
        context.Add("ServiceName", "List Multipart");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(ListMultipartOutput));
        if (backModel != null) {
            return (ListMultipartOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/list_multipart.html
     */
  
    public void listMultipartAsync(
            String objectName,
            ListMultipartInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new ListMultipartInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "ListMultipart");
        context.Add("APIName", "ListMultipart");
        context.Add("ServiceName", "List Multipart");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class ListMultipartInput : RequestInputModel {
        // Limit results count

        private int limit;

        public void setLimit(int limit) {
            this.limit = limit;
        }

        [Param(paramType = "query", paramName = "limit")]
        public int getLimit() {
            return this.limit;
        } // Object multipart upload part number

        private int partNumberMarker;

        public void setPartNumberMarker(int partNumberMarker) {
            this.partNumberMarker = partNumberMarker;
        }

        [Param(paramType = "query", paramName = "part_number_marker")]
        public int getPartNumberMarker() {
            return this.partNumberMarker;
        } // Object multipart upload ID
        // Required

        private String uploadID;

        public void setUploadID(String uploadID) {
            this.uploadID = uploadID;
        }

        [Param(paramType = "query", paramName = "upload_id")]
        public String getUploadID() {
            return this.uploadID;
        }


        public override String validateParam()
        {

            if (QSStringUtil.isEmpty(this.getUploadID())) {
                return QSStringUtil.getParameterRequired("UploadID", "ListMultipartInput");
            }

            return null;
        }
    }

    public class ListMultipartOutput : OutputModel {

        // Object multipart count

        private int count;

        public void setCount(int count) {
            this.count = count;
        }

        [Param(paramType = "query", paramName = "count")]
        public int getCount() {
            return this.count;
        } // Object parts

        private List<Types.ObjectPartModel> objectParts;

        public void setObjectParts(List<Types.ObjectPartModel> objectParts)
        {
            this.objectParts = objectParts;
        }

        [Param(paramType = "query", paramName ="object_parts")]
        public List<Types.ObjectPartModel> getObjectParts()
        {
            return this.objectParts;
        }
    }

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/options.html
     */
    
    public OptionsObjectOutput optionsObject(String objectName, OptionsObjectInput input)
             {

        if (input == null) {
            input = new OptionsObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "OptionsObject");
        context.Add("APIName", "OptionsObject");
        context.Add("ServiceName", "OPTIONS Object");
        context.Add("RequestMethod", "OPTIONS");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(OptionsObjectOutput));
        if (backModel != null) {
            return (OptionsObjectOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/options.html
     */
 
    public void optionsObjectAsync(
            String objectName,
            OptionsObjectInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new OptionsObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "OptionsObject");
        context.Add("APIName", "OptionsObject");
        context.Add("ServiceName", "OPTIONS Object");
        context.Add("RequestMethod", "OPTIONS");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class OptionsObjectInput : RequestInputModel {

        // Request headers

        private String accessControlRequestHeaders;

        public void setAccessControlRequestHeaders(String accessControlRequestHeaders) {
            this.accessControlRequestHeaders = accessControlRequestHeaders;
        }

        [Param(paramType = "header", paramName = "Access-Control-Request-Headers")]
        public String getAccessControlRequestHeaders() {
            return this.accessControlRequestHeaders;
        } // Request method
        // Required

        private String accessControlRequestMethod;

        public void setAccessControlRequestMethod(String accessControlRequestMethod) {
            this.accessControlRequestMethod = accessControlRequestMethod;
        }

        [Param(paramType = "header", paramName = "Access-Control-Request-Method")]
        public String getAccessControlRequestMethod() {
            return this.accessControlRequestMethod;
        } // Request origin
        // Required

        private String origin;

        public void setOrigin(String origin) {
            this.origin = origin;
        }

        [Param(paramType = "header", paramName = "Origin")]
        public String getOrigin() {
            return this.origin;
        }

        public override String validateParam()
        {

            if (QSStringUtil.isEmpty(this.getAccessControlRequestMethod())) {
                return QSStringUtil.getParameterRequired(
                        "AccessControlRequestMethod", "OptionsObjectInput");
            }
            if (QSStringUtil.isEmpty(this.getOrigin())) {
                return QSStringUtil.getParameterRequired("Origin", "OptionsObjectInput");
            }

            return null;
        }
    }

    public class OptionsObjectOutput : OutputModel {

        // Allowed headers

        private String accessControlAllowHeaders;

        public void setAccessControlAllowHeaders(String accessControlAllowHeaders) {
            this.accessControlAllowHeaders = accessControlAllowHeaders;
        }

        [Param(paramType = "header", paramName = "Access-Control-Allow-Headers")]
        public String getAccessControlAllowHeaders() {
            return this.accessControlAllowHeaders;
        } // Allowed methods

        private String accessControlAllowMethods;

        public void setAccessControlAllowMethods(String accessControlAllowMethods) {
            this.accessControlAllowMethods = accessControlAllowMethods;
        }

        [Param(paramType = "header", paramName =  "Access-Control-Allow-Methods")]
        public String getAccessControlAllowMethods() {
            return this.accessControlAllowMethods;
        } // Allowed origin

        private String accessControlAllowOrigin;

        public void setAccessControlAllowOrigin(String accessControlAllowOrigin) {
            this.accessControlAllowOrigin = accessControlAllowOrigin;
        }

        [Param(paramType = "header", paramName = "Access-Control-Allow-Origin")]
        public String getAccessControlAllowOrigin() {
            return this.accessControlAllowOrigin;
        } // Expose headers

        private String accessControlExposeHeaders;

        public void setAccessControlExposeHeaders(String accessControlExposeHeaders) {
            this.accessControlExposeHeaders = accessControlExposeHeaders;
        }

        [Param(paramType = "header", paramName = "Access-Control-Expose-Headers")]
        public String getAccessControlExposeHeaders() {
            return this.accessControlExposeHeaders;
        } // Max age

        private String accessControlMaxAge;

        public void setAccessControlMaxAge(String accessControlMaxAge) {
            this.accessControlMaxAge = accessControlMaxAge;
        }

        [Param(paramType = "header", paramName = "Access-Control-Max-Age")]
        public String getAccessControlMaxAge() {
            return this.accessControlMaxAge;
        }
    }

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/put.html
     */
   
    public PutObjectOutput putObject(String objectName, PutObjectInput input)  {

        if (input == null) {
            input = new PutObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutObject");
        context.Add("APIName", "PutObject");
        context.Add("ServiceName", "PUT Object");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(PutObjectOutput));
        if (backModel != null) {
            return (PutObjectOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/put.html
     */
   
    public void putObjectAsync(
            String objectName, PutObjectInput input, ResponseCallBack callback)
             {
        if (input == null) {
            input = new PutObjectInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "PutObject");
        context.Add("APIName", "PutObject");
        context.Add("ServiceName", "PUT Object");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class PutObjectInput : RequestInputModel {

        // Object content size
        // Required

        private int contentLength;

        public void setContentLength(int contentLength) {
            this.contentLength = contentLength;
        }

       [Param(paramType = "header", paramName =  "Content-Length")]
        public int getContentLength() {
            return this.contentLength;
        } // Object MD5sum

        private String contentMD5;

        public void setContentMD5(String contentMD5) {
            this.contentMD5 = contentMD5;
        }

        [Param(paramType = "header", paramName = "Content-MD5")]
        public String getContentMD5() {
            return this.contentMD5;
        } // Object content type

        private String contentType;

        public void setContentType(String contentType) {
            this.contentType = contentType;
        }

        [Param(paramType = "header", paramName =  "Content-Type")]
        public String getContentType() {
            return this.contentType;
        } // Used to indicate that particular server behaviors are required by the client

        private String expect;

        public void setExpect(String expect) {
            this.expect = expect;
        }

        [Param(paramType = "header", paramName = "Expect")]
        public String getExpect() {
            return this.expect;
        } // Copy source, format (/<bucket-name>/<object-key>)

        private String xQSCopySource;

        public void setXQSCopySource(String xQSCopySource) {
            this.xQSCopySource = xQSCopySource;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source")]
        public String getXQSCopySource() {
            return this.xQSCopySource;
        } // Encryption algorithm of the object

        private String xQSCopySourceEncryptionCustomerAlgorithm;

        public void setXQSCopySourceEncryptionCustomerAlgorithm(
                String xQSCopySourceEncryptionCustomerAlgorithm) {
            this.xQSCopySourceEncryptionCustomerAlgorithm =
                    xQSCopySourceEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source-Encryption-Customer-Algorithm")]
        public String getXQSCopySourceEncryptionCustomerAlgorithm() {
            return this.xQSCopySourceEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSCopySourceEncryptionCustomerKey;

        public void setXQSCopySourceEncryptionCustomerKey(
                String xQSCopySourceEncryptionCustomerKey) {
            this.xQSCopySourceEncryptionCustomerKey = xQSCopySourceEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source-Encryption-Customer-Key")]
        
        public String getXQSCopySourceEncryptionCustomerKey() {
            return this.xQSCopySourceEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSCopySourceEncryptionCustomerKeyMD5;

        public void setXQSCopySourceEncryptionCustomerKeyMD5(
                String xQSCopySourceEncryptionCustomerKeyMD5) {
            this.xQSCopySourceEncryptionCustomerKeyMD5 = xQSCopySourceEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source-Encryption-Customer-Key-MD5")]
        
        public String getXQSCopySourceEncryptionCustomerKeyMD5() {
            return this.xQSCopySourceEncryptionCustomerKeyMD5;
        } // Check whether the copy source matches

        private String xQSCopySourceIfMatch;

        public void setXQSCopySourceIfMatch(String xQSCopySourceIfMatch) {
            this.xQSCopySourceIfMatch = xQSCopySourceIfMatch;
        }

        [Param(paramType = "header", paramName =  "X-QS-Copy-Source-If-Match")]
        public String getXQSCopySourceIfMatch() {
            return this.xQSCopySourceIfMatch;
        } // Check whether the copy source has been modified

        private String xQSCopySourceIfModifiedSince;

        public void setXQSCopySourceIfModifiedSince(String xQSCopySourceIfModifiedSince) {
            this.xQSCopySourceIfModifiedSince = xQSCopySourceIfModifiedSince;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source-If-Modified-Since")]
        public String getXQSCopySourceIfModifiedSince() {
            return this.xQSCopySourceIfModifiedSince;
        } // Check whether the copy source does not match

        private String xQSCopySourceIfNoneMatch;

        public void setXQSCopySourceIfNoneMatch(String xQSCopySourceIfNoneMatch) {
            this.xQSCopySourceIfNoneMatch = xQSCopySourceIfNoneMatch;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source-If-None-Match")]
        public String getXQSCopySourceIfNoneMatch() {
            return this.xQSCopySourceIfNoneMatch;
        } // Check whether the copy source has not been modified

        private String xQSCopySourceIfUnmodifiedSince;

        public void setXQSCopySourceIfUnmodifiedSince(String xQSCopySourceIfUnmodifiedSince) {
            this.xQSCopySourceIfUnmodifiedSince = xQSCopySourceIfUnmodifiedSince;
        }

        [Param(paramType = "header", paramName = "X-QS-Copy-Source-If-Unmodified-Since")]
        public String getXQSCopySourceIfUnmodifiedSince() {
            return this.xQSCopySourceIfUnmodifiedSince;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSEncryptionCustomerKey;

        public void setXQSEncryptionCustomerKey(String xQSEncryptionCustomerKey) {
            this.xQSEncryptionCustomerKey = xQSEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key")]
        public String getXQSEncryptionCustomerKey() {
            return this.xQSEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSEncryptionCustomerKeyMD5;

        public void setXQSEncryptionCustomerKeyMD5(String xQSEncryptionCustomerKeyMD5) {
            this.xQSEncryptionCustomerKeyMD5 = xQSEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key-MD5")]
        public String getXQSEncryptionCustomerKeyMD5() {
            return this.xQSEncryptionCustomerKeyMD5;
        } // Check whether fetch target object has not been modified

        private String xQSFetchIfUnmodifiedSince;

        public void setXQSFetchIfUnmodifiedSince(String xQSFetchIfUnmodifiedSince) {
            this.xQSFetchIfUnmodifiedSince = xQSFetchIfUnmodifiedSince;
        }

        [Param(paramType = "header", paramName =  "X-QS-Fetch-If-Unmodified-Since")]
        public String getXQSFetchIfUnmodifiedSince() {
            return this.xQSFetchIfUnmodifiedSince;
        } // Fetch source, should be a valid url

        private String xQSFetchSource;

        public void setXQSFetchSource(String xQSFetchSource) {
            this.xQSFetchSource = xQSFetchSource;
        }

        [Param(paramType = "header", paramName = "X-QS-Fetch-Source")]
        public String getXQSFetchSource() {
            return this.xQSFetchSource;
        } // Move source, format (/<bucket-name>/<object-key>)

        private String xQSMoveSource;

        public void setXQSMoveSource(String xQSMoveSource) {
            this.xQSMoveSource = xQSMoveSource;
        }

        [Param(paramType = "header", paramName = "X-QS-Move-Source")]
        public String getXQSMoveSource() {
            return this.xQSMoveSource;
        }

        // The request body
        private FileStream bodyInputFile;

        [Param(paramType = "body", paramName = "BodyInputFile")]
        public FileStream getBodyInputFile() {
            return bodyInputFile;
        }
        //
        public void setBodyInputFile(FileStream bodyInputFile) {
            this.bodyInputFile = bodyInputFile;
        }

        private StreamReader bodyInputStream;

        [Param(paramType = "body", paramName = "BodyInputStream")]
        public StreamReader getBodyInputStream() {
            return bodyInputStream;
        }

        public void setBodyInputStream(StreamReader bodyInputStream) {
            this.bodyInputStream = bodyInputStream;
        }
        public override String validateParam()
        {

            return null;
        }
    }

    public class PutObjectOutput :OutputModel {}

    /*
     *
     * @param input
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/multipart/upload_multipart.html
     */
 
    public UploadMultipartOutput uploadMultipart(String objectName, UploadMultipartInput input)
             {

        if (input == null) {
            input = new UploadMultipartInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "UploadMultipart");
        context.Add("APIName", "UploadMultipart");
        context.Add("ServiceName", "Upload Multipart");
        context.Add("RequestMethod", "PUT");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        OutputModel backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(context, input, typeof(UploadMultipartOutput));
        if (backModel != null) {
            return (UploadMultipartOutput) backModel;
        }
        return null;
    }

    /*
     *
     * @param input
     * @param callback
     * @
     *
     * Documentation URL: https://docs.qingcloud.com/qingstor/api/object/multipart/upload_multipart.html
     */
  
    public void uploadMultipartAsync(
            String objectName,
            UploadMultipartInput input,
            ResponseCallBack callback)
             {
        if (input == null) {
            input = new UploadMultipartInput();
        }

        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "UploadMultipart");
        context.Add("APIName", "UploadMultipart");
        context.Add("ServiceName", "Upload Multipart");
        context.Add("RequestMethod", "POST");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");
        context.Add("bucketNameInput", this.bucketName);
        context.Add("objectNameInput", objectName);

        if (QSStringUtil.isEmpty(bucketName)) {
            throw new QSException("bucketName can't be empty!");
        }
        if (QSStringUtil.isEmpty(objectName)) {
            throw new QSException("objectName can't be empty!");
        }

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest().sendApiRequestAsync(context, input, callback);
    }

    public class UploadMultipartInput : RequestInputModel {
        // Object multipart upload part number
        // Required

        private int partNumber;

        public void setPartNumber(int partNumber) {
            this.partNumber = partNumber;
        }

        [Param(paramType = "query", paramName = "part_number")]
        public int getPartNumber() {
            return this.partNumber;
        } // Object multipart upload ID
        // Required

        private String uploadID;

        public void setUploadID(String uploadID) {
            this.uploadID = uploadID;
        }

        [Param(paramType = "query", paramName = "upload_id")]
        public String getUploadID() {
            return this.uploadID;
        }

        // Object multipart content length

        private int contentLength;

        public void setContentLength(int contentLength) {
            this.contentLength = contentLength;
        }

        [Param(paramType = "header", paramName = "Content-Length")]
        public int getContentLength() {
            return this.contentLength;
        } // Object multipart content MD5sum

        private String contentMD5;

        public void setContentMD5(String contentMD5) {
            this.contentMD5 = contentMD5;
        }

        [Param(paramType = "header", paramName = "Content-MD5")]
        public String getContentMD5() {
            return this.contentMD5;
        } // Encryption algorithm of the object

        private String xQSEncryptionCustomerAlgorithm;

        public void setXQSEncryptionCustomerAlgorithm(String xQSEncryptionCustomerAlgorithm) {
            this.xQSEncryptionCustomerAlgorithm = xQSEncryptionCustomerAlgorithm;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Algorithm")]
        public String getXQSEncryptionCustomerAlgorithm() {
            return this.xQSEncryptionCustomerAlgorithm;
        } // Encryption key of the object

        private String xQSEncryptionCustomerKey;

        public void setXQSEncryptionCustomerKey(String xQSEncryptionCustomerKey) {
            this.xQSEncryptionCustomerKey = xQSEncryptionCustomerKey;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key")]
        public String getXQSEncryptionCustomerKey() {
            return this.xQSEncryptionCustomerKey;
        } // MD5sum of encryption key

        private String xQSEncryptionCustomerKeyMD5;

        public void setXQSEncryptionCustomerKeyMD5(String xQSEncryptionCustomerKeyMD5) {
            this.xQSEncryptionCustomerKeyMD5 = xQSEncryptionCustomerKeyMD5;
        }

        [Param(paramType = "header", paramName = "X-QS-Encryption-Customer-Key-MD5")]
        public String getXQSEncryptionCustomerKeyMD5() {
            return this.xQSEncryptionCustomerKeyMD5;
        }

        // The request body
        private FileStream bodyInputFile;

        [Param(paramType = "body", paramName = "BodyInputFile")]
        public FileStream getBodyInputFile() {
            
            return bodyInputFile;
        }
        //
        public void setBodyInputFile(FileStream bodyInputFile) {
            this.bodyInputFile = bodyInputFile;
        }

        private StreamReader bodyInputStream;

        [Param(paramType = "body", paramName = "BodyInputStream")]
        public StreamReader getBodyInputStream() {
            return bodyInputStream;
        }

        public void setBodyInputStream(StreamReader bodyInputStream) {
            this.bodyInputStream = bodyInputStream;
        }

        
        public override String validateParam() {

            if (this.getPartNumber() < 0) {
                return QSStringUtil.getParameterRequired("PartNumber", "UploadMultipartInput");
            }
            if (QSStringUtil.isEmpty(this.getUploadID())) {
                return QSStringUtil.getParameterRequired("UploadID", "UploadMultipartInput");
            }

            return null;
        }
    }

    public class UploadMultipartOutput : OutputModel {}

    /**
     * @param objectName
     * @param expiresSecond Relative current time，the second when this quert sign expires
     * @return
     * @
     */
    public String GetObjectSignatureUrl(String objectName, int expiresSecond)  {
        return QSSignatureUtil.getObjectAuthRequestUrl(
                this.evnContext, this.zone, bucketName, objectName, expiresSecond);
    }

    /**
     * @param signaturedRequest
     * @return
     * @
     */
   
    public GetObjectOutput GetObjectBySignatureUrl(String signaturedRequest)  {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetObject");
        context.Add("APIName", "GetObject");
        context.Add("ServiceName", "QingStor");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");

        Object backModel =
                ResourceRequestFactory.getResourceRequest()
                        .sendApiRequest(signaturedRequest, context, typeof(GetObjectOutput));
        if (backModel != null) {
            return (GetObjectOutput) backModel;
        }
        return null;
    }

    /**
     * @param signaturedRequest
     * @param callback
     * @
     */
  
    public void GetObjectBySignatureUrlAsync(
            String signaturedRequest, ResponseCallBack callback)
             {
        Dictionary<object,object> context=new Dictionary<object,object>();
        context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
        context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
        context.Add("OperationName", "GetObject");
        context.Add("APIName", "GetObject");
        context.Add("ServiceName", "QingStor");
        context.Add("RequestMethod", "GET");
        context.Add("RequestURI", "/<bucket-name>/<object-key>");

        if (callback == null) {
            throw new QSException("callback can't be null");
        }

        ResourceRequestFactory.getResourceRequest()
                .sendApiRequestAsync(signaturedRequest, context, callback);
    }

    }
}
