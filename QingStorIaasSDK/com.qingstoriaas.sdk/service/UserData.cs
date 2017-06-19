using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorIaasSDK.com.qingstor.sdk.service;
using QingStorIaasSDK.com.qingstor.sdk.Attribute;
using QingStorIaasSDK.com.qingstor.sdk.config;
using QingStorIaasSDK.com.qingstor.sdk.constants;
using QingStorIaasSDK.com.qingstor.sdk.exception;
using QingStorIaasSDK.com.qingstor.sdk.model;
using QingStorIaasSDK.com.qingstor.sdk.request;
using QingStorIaasSDK.com.qingstor.sdk.utils;

namespace QingStorIaasSDK.com.qingstor.sdk.service
{
    class UserData
    {
        private String zone;
        private EvnContext evnContext;

        public UserData(EvnContext evnContext) 
        {
            this.evnContext = evnContext;
            this.zone = QSConstant.STOR_DEFAULT_ZONE;
        }

        public UserData(EvnContext evnContext, String zone) 
        {
            this.evnContext = evnContext;
            this.zone = zone;
        }

        public class UploadUserDataAttachmentInput:RequestInputModel
        {
            private String attachment_content;
            [Param(paramType = "body", paramName = "Attachment_content")]
            public String getAttachment_content()
            {
                return this.attachment_content;
            }

            public void setAttachment_content(String attachment_content)
            {
                this.attachment_content = attachment_content;
            }

            private String attachment_name;
            [Param(paramType = "body", paramName = "Attachment_name")]
            public String getAttachment_name()
            {
                return this.attachment_name;
            }

            public void setAttachment_name(String attachment_name)
            {
                this.attachment_name = attachment_name;
            }

            private String zone;
            [Param(paramType = "body", paramName = "Zone")]
            public String getZone()
            {
                return this.zone;
            }

            public void setZone(String zone)
            {
                this.zone = zone;
            }

            public override String validateParam()
            {

                return null;
            }
        }

        public class UploadUserDataAttachmentOutput:OutputModel
        {
            private String attachment_id;
            [Param(paramType = "query", paramName = "Attachment_id")]
            public String getAttachment_id()
            {
                return this.action;
            }
            public void setAttachment_id(String attachment_id)
            {
                this.attachment_id = attachment_id;
            }

            private String action;
            [Param(paramType = "query", paramName = "Action")]
            public String getAction()
            {
                return this.action;
            }
            public void setAction(String action)
            {
                this.action = action;
            }

            private int ret_code;
            [Param(paramType = "query", paramName = "Ret_code")]
            public int getRet_code()
            {
                return this.ret_code;
            }
            public void setRet_code(int ret_code)
            {
                this.ret_code = ret_code;
            }
        }

        public UploadUserDataAttachmentOutput UploadUserDataAttachment(UploadUserDataAttachmentInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DescribeInstances");
            context.Add("APIName", "DescribeInstances");
            context.Add("ServiceName", "Describe Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(UploadUserDataAttachmentOutput));
            if (backModel != null)
            {
                return (UploadUserDataAttachmentOutput)backModel;
            }
            return null;
        }
    }
}
