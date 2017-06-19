using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.Attribute;
using QingStorSDK.test.CSharp.com.qingstor.sdk.utils;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class ParamTestModel
    {
        private String action;

        private List<String> instances;

        public void setInstances(List<String> instances) 
        {
            this.instances = instances;
        }

        [Param(paramType = "query", paramName = "instances")]
        public List<String> getInstances() 
        {
            return this.instances;
        }

        public void setAction(String action) 
        {
            this.action = action;
        }

        private List<String> imageID;

        public void setImageID(List<String> imageID) 
        {
            this.imageID = imageID;
        }

        [Param(paramType = "query", paramName = "image_id")]
        public List<String> getImageID() 
        {
            return this.imageID;
        } // InstanceClass's available values: 0, 1

        [Param(paramType = "query", paramName = "action")]
        public String getAction() 
        {
            return this.action;
        }

        private List<ParamTypeModel> instanceSet;

        public void setInstanceSet(List<ParamTypeModel> instanceSet) 
        {
            this.instanceSet = instanceSet;
        }

        [Param(paramType = "query", paramName = "instance_set")]
        public List<ParamTypeModel> getInstanceSet() 
        {
            return this.instanceSet;
        }

        private int retCode;

        public void setRetCode(int retCode) 
        {
            this.retCode = retCode;
        }

        private int totalCount;

        public void setTotalCount(int totalCount) 
        {
            this.totalCount = totalCount;
        }
    }
}
