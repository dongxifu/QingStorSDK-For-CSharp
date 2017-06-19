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
    class Volume
    {
        private String zone;
        private EvnContext evnContext;

        public Volume(EvnContext evnContext) 
        {
            this.evnContext = evnContext;
            this.zone = QSConstant.STOR_DEFAULT_ZONE;
        }   
     
        public Volume(EvnContext evnContext, String zone) 
        {
            this.evnContext = evnContext;
            this.zone = zone;
        }

        public class DescribeVolumesInput : RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "Volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                this.volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private int volume_type;
            [Param(paramType = "header", paramName = "Volume_type")]
            public int getVolume_type()
            {
                return this.volume_type;
            }

            public void setVolume_type(int volume_type)
            {
                this.volume_type = volume_type;
            }

            private String[] status;
            [Param(paramType = "header", paramName = "Status")]
            public String[] getStatus()
            {
                return this.status;
            }

            public void setStatus(String[] status)
            {
                this.status = status;
            }

            private String search_word;
            [Param(paramType = "header", paramName = "Search_word")]
            public String getSearch_word()
            {
                return this.search_word;
            }

            public void setSearch_word(String search_word)
            {
                this.search_word = search_word;
            }

            private String[] tags;
            [Param(paramType = "header", paramName = "Tags")]
            public String[] getTags()
            {
                return this.tags;
            }

            public void setTags(String[] tags)
            {
                this.tags = tags;
            }

            private int verbose;
            [Param(paramType = "header", paramName = "Verbose")]
            public int getVerbose()
            {
                return this.verbose;
            }

            public void setVerbose(int verbose)
            {
                this.verbose = verbose;
            }

            private int offset;
            [Param(paramType = "header", paramName = "Offset")]
            public int getOffset()
            {
                return this.offset;
            }

            public void setOffset(int offset)
            {
                this.offset = offset;
            }

            private int limit;
            [Param(paramType = "header", paramName = "Limit")]
            public int getLimit()
            {
                return this.limit;
            }

            public void setLimit(int limit)
            {
                this.limit = limit;
            }

            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class DescribeVolumesOutput : OutputModel
        {
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

            private String volume_set;
            [Param(paramType = "query", paramName = "Volume_set")]
            public String getVolume_set()
            {
                return this.volume_set;
            }
            public void setVolume_set(String volume_set)
            {
                this.volume_set = volume_set;
            }

            private int total_count;
            [Param(paramType = "query", paramName = "Total_count")]
            public int getTotal_count()
            {
                return this.total_count;
            }
            public void setTotal_count(int total_count)
            {
                this.total_count = total_count;
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

            private String volume_id;
            [Param(paramType = "query", paramName = "Volume_id")]
            public String getVolume_id()
            {
                return this.volume_id;
            }
            public void setVolume_id(String volume_id)
            {
                this.volume_id = volume_id;
            }

            private String volume_name;
            [Param(paramType = "query", paramName = "Volume_name")]
            public String getVolume_name()
            {
                return this.volume_name;
            }
            public void setVolume_name(String volume_name)
            {
                this.volume_name = volume_name;
            }

            private String description;
            [Param(paramType = "query", paramName = "Description")]
            public String getDescription()
            {
                return this.description;
            }
            public void setDescription(String description)
            {
                this.description = description;
            }

            private String size;
            [Param(paramType = "query", paramName = "Size")]
            public String getSize()
            {
                return this.size;
            }
            public void setSize(String size)
            {
                this.size = size;
            }

            private String status;
            [Param(paramType = "query", paramName = "Status")]
            public String getStatus()
            {
                return this.status;
            }
            public void setStatus(String status)
            {
                this.status = status;
            }

            private String transition_status;
            [Param(paramType = "query", paramName = "Transition_status")]
            public String getTransition_status()
            {
                return this.transition_status;
            }
            public void setTransition_status(String transition_status)
            {
                this.transition_status = transition_status;
            }

            private DateTime create_time;
            [Param(paramType = "query", paramName = "Create_time")]
            public DateTime getCreate_time()
            {
                return this.create_time;
            }
            public void setCreate_time(DateTime create_time)
            {
                this.create_time = create_time;
            }

            private DateTime status_time;
            [Param(paramType = "query", paramName = "Status_time")]
            public DateTime getStatus_time()
            {
                return this.status_time;
            }
            public void setStatus_time(DateTime status_time)
            {
                this.status_time = status_time;
            }

            private Dictionary<object,object> instance;
            [Param(paramType = "query", paramName = "Instance")]
            public Dictionary<object, object> getInstance()
            {
                return this.instance;
            }
            public void setInstance(Dictionary<object, object> instance)
            {
                this.instance = instance;
            }
        }

        public DescribeVolumesOutput DescribeVolumes(DescribeVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DescribeVolumes");
            context.Add("APIName", "DescribeVolumes");
            context.Add("ServiceName", "Describe Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeVolumesOutput));
            if (backModel != null)
            {
                return (DescribeVolumesOutput)backModel;
            }
            return null;
        }

        public class CreateVolumesInput:RequestInputModel
        {
            private int size;
            [Param(paramType = "header", paramName = "Size")]
            public int getSize()
            {
                return this.size;
            }

            public void setSize(int size)
            {
                this.size = size;
            }

            private String volume_name;
            [Param(paramType = "header", paramName = "Volume_name")]
            public String getVolume_name()
            {
                return this.volume_name;
            }

            public void setVolume_name(String volume_name)
            {
                this.volume_name = volume_name;
            }

            private int volume_type;
            [Param(paramType = "header", paramName = "Volume_type")]
            public int getVolume_type()
            {
                return this.volume_type;
            }

            public void setVolume_type(int volume_type)
            {
                this.volume_type = volume_type;
            }

            private int count;
            [Param(paramType = "header", paramName = "Count")]
            public int getCount()
            {
                return this.count;
            }

            public void setCount(int count)
            {
                this.count = count;
            }

            private String target_user;
            [Param(paramType = "header", paramName = "Target_user")]
            public String getTarget_user()
            {
                return this.target_user;
            }

            public void setTarget_user(String target_user)
            {
                this.target_user = target_user;
            }

            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class CreateVolumesOutput:OutputModel
        {
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

            private String job_id;
            [Param(paramType = "query", paramName = "Job_id")]
            public String getJob_id()
            {
                return this.job_id;
            }
            public void setJob_id(String job_id)
            {
                this.job_id = job_id;
            }

            private String volumes;
            [Param(paramType = "query", paramName = "Volumes")]
            public String getVolumes()
            {
                return this.volumes;
            }
            public void setVolumes(String volumes)
            {
                this.volumes = volumes;
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

        public CreateVolumesOutput CreateVolumes(CreateVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "CreateVolumes");
            context.Add("APIName", "CreateVolumes");
            context.Add("ServiceName", "Create Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(CreateVolumesOutput));
            if (backModel != null)
            {
                return (CreateVolumesOutput)backModel;
            }
            return null;
        }

        public class DeleteVolumesInput :RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "Volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class DeleteVolumesOutput : OutputModel
        {
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

            private String job_id;
            [Param(paramType = "query", paramName = "Job_id")]
            public String getJob_id()
            {
                return this.job_id;
            }
            public void setJob_id(String job_id)
            {
                this.job_id = job_id;
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

        public DeleteVolumesOutput DeleteVolumes(DeleteVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DeleteVolumes");
            context.Add("APIName", "DeleteVolumes");
            context.Add("ServiceName", "Delete Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DeleteVolumesOutput));
            if (backModel != null)
            {
                return (DeleteVolumesOutput)backModel;
            }
            return null;
        }
        
        public class AttachVolumesInput:RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "Volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private String instance;
            [Param(paramType = "header", paramName = "Instance")]
            public String getInstance()
            {
                return this.instance;
            }

            public void setInstance(String instance)
            {
                this.instance = instance;
            }

            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class AttachVolumesOutput:OutputModel
        {
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

            private String job_id;
            [Param(paramType = "query", paramName = "Job_id")]
            public String getJob_id()
            {
                return this.job_id;
            }
            public void setJob_id(String job_id)
            {
                this.job_id = job_id;
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

        public AttachVolumesOutput AttachVolumes(AttachVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "AttachVolumes");
            context.Add("APIName", "AttachVolumes");
            context.Add("ServiceName", "Attach Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(AttachVolumesOutput));
            if (backModel != null)
            {
                return (AttachVolumesOutput)backModel;
            }
            return null;
        }

        public class DetachVolumesInput :RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "Volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private String instance;
            [Param(paramType = "header", paramName = "Instance")]
            public String getInstance()
            {
                return this.instance;
            }

            public void setInstance(String instance)
            {
                this.instance = instance;
            }

            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class DetachVolumesOutput :OutputModel
        {
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

            private String job_id;
            [Param(paramType = "query", paramName = "Job_id")]
            public String getJob_id()
            {
                return this.job_id;
            }
            public void setJob_id(String job_id)
            {
                this.job_id = job_id;
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

        public DetachVolumesOutput DetachVolumes(DetachVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DetachVolumes");
            context.Add("APIName", "DetachVolumes");
            context.Add("ServiceName", "Detach Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DetachVolumesOutput));
            if (backModel != null)
            {
                return (DetachVolumesOutput)backModel;
            }
            return null;
        }

        public class ResizeVolumesInput:RequestInputModel
        {
            private String[] volumes;
            [Param(paramType = "header", paramName = "Volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setVolumes(String[] volumes)
            {
                volumes = new String[volumes.Length];
                this.volumes = volumes;
            }

            private int size;
            [Param(paramType = "header", paramName = "Size")]
            public int getSize()
            {
                return this.size;
            }

            public void setSize(int size)
            {
                this.size = size;
            }

            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class ResizeVolumesOutput:OutputModel
        {
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

            private String job_id;
            [Param(paramType = "query", paramName = "Job_id")]
            public String getJob_id()
            {
                return this.job_id;
            }
            public void setJob_id(String job_id)
            {
                this.job_id = job_id;
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

        public ResizeVolumesOutput ResizeVolumes(ResizeVolumesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "ResizeVolumes");
            context.Add("APIName", "ResizeVolumes");
            context.Add("ServiceName", "Resize Volumes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ResizeVolumesOutput));
            if (backModel != null)
            {
                return (ResizeVolumesOutput)backModel;
            }
            return null;
        }

        public class ModifyVolumeAttributesInput : RequestInputModel
        {
            private String volume;
            [Param(paramType = "header", paramName = "Volume")]
            public String getVolume()
            {
                return this.volume;
            }

            public void setVolume(String volume)
            {
                this.volume = volume;
            }

            private String volume_name;
            [Param(paramType = "header", paramName = "Volume_name")]
            public String getVolume_name()
            {
                return this.volume_name;
            }

            public void setVolume_name(String volume_name)
            {
                this.volume_name = volume_name;
            }

            private String description;
            [Param(paramType = "header", paramName = "Description")]
            public String getDescription()
            {
                return this.description;
            }

            public void setDescription(String description)
            {
                this.description = description;
            }



            private String zone;
            [Param(paramType = "header", paramName = "Zone")]
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

        public class ModifyVolumeAttributesOutput:OutputModel
        {
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

        public ModifyVolumeAttributesOutput ResizeVolumes(ModifyVolumeAttributesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "ModifyVolumeAttributes");
            context.Add("APIName", "ModifyVolumeAttributes");
            context.Add("ServiceName", "Modify Volume Attributes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ModifyVolumeAttributesOutput));
            if (backModel != null)
            {
                return (ModifyVolumeAttributesOutput)backModel;
            }
            return null;
        }

        
    }
}
