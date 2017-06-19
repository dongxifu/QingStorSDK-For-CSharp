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
    class Vxnets
    {
        private String zone;
        private EvnContext evnContext;

        public Vxnets(EvnContext evnContext) 
        {
            this.evnContext = evnContext;
            this.zone = QSConstant.STOR_DEFAULT_ZONE;
        }   
     
        public Vxnets(EvnContext evnContext, String zone) 
        {
            this.evnContext = evnContext;
            this.zone = zone;
        }

        public class DescribeVxnetsInput:RequestInputModel
        {
            private String[] vxnets;
            [Param(paramType = "header", paramName = "Vxnets")]
            public String[] getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String[] vxnets)
            {
                this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
            }

            private int vxnet_type;
            [Param(paramType = "header", paramName = "Vxnet_type")]
            public int getVxnet_type()
            {
                return this.vxnet_type;
            }

            public void setvxnet_type(int vxnet_type)
            {
                this.vxnet_type = vxnet_type;
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
                this.tags = new String[tags.Length];
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

        public class DescribeVxnetsOutput:OutputModel
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

            private String vxnet_set;
            [Param(paramType = "query", paramName = "Vxnet_set")]
            public String getVxnet_set()
            {
                return this.vxnet_set;
            }
            public void setVxnet_set(String vxnet_set)
            {
                this.vxnet_set = vxnet_set;
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

            private String vxnet_id;
            [Param(paramType = "query", paramName = "Vxnet_id")]
            public String getVxnet_id()
            {
                return this.vxnet_id;
            }
            public void setVxnet_id(String vxnet_id)
            {
                this.vxnet_id = vxnet_id;
            }

            private String vxnet_name;
            [Param(paramType = "query", paramName = "vxnet_name")]
            public String getVxnet_name()
            {
                return this.vxnet_name;
            }
            public void setVxnet_name(String vxnet_name)
            {
                this.vxnet_name = vxnet_name;
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

            private String instance_ids;
            [Param(paramType = "query", paramName = "Instance_ids")]
            public String getInstance_ids()
            {
                return this.instance_ids;
            }
            public void setInstance_ids(String instance_ids)
            {
                this.instance_ids = instance_ids;
            }
            private Dictionary<object, object> router;
            [Param(paramType = "query", paramName = "Router")]
            public Dictionary<object, object> getRouter()
            {
                return this.router;
            }
            public void setRouter(Dictionary<object, object> router)
            {
                this.router = router;
            }
        }

        public DescribeVxnetsOutput DescribeVxnets(DescribeVxnetsInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DescribeVxnets");
            context.Add("APIName", "DescribeVxnets");
            context.Add("ServiceName", "Describe Vxnets");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeVxnetsOutput));
            if (backModel != null)
            {
                return (DescribeVxnetsOutput)backModel;
            }
            return null;
        }

        public class CreateVxnetsInput:RequestInputModel
        {
            private String vxnet_name;
            [Param(paramType = "header", paramName = "Vxnet_name")]
            public String getVxnet_name()
            {
                return this.vxnet_name;
            }
            public void setVxnet_name(String vxnet_name)
            {
                this.vxnet_name = vxnet_name;
            }

            private int vxnet_type;
            [Param(paramType = "header", paramName = "Vxnet_type")]
            public int getVxnet_type()
            {
                return this.vxnet_type;
            }
            public void setVxnet_type(int vxnet_type)
            {
                this.vxnet_type = vxnet_type;
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

        public class CreateVxnetsOutput:OutputModel
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

            private String vxnets;
            [Param(paramType = "query", paramName = "Vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }
            public void setVxnets(String vxnets)
            {
                this.vxnets = vxnets;
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

        public CreateVxnetsOutput CreateVxnets(CreateVxnetsInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "CreateVxnets");
            context.Add("APIName", "CreateVxnets");
            context.Add("ServiceName", "Create Vxnets");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(CreateVxnetsOutput));
            if (backModel != null)
            {
                return (CreateVxnetsOutput)backModel;
            }
            return null;
        }

        public class DeleteVxnetsInput:RequestInputModel
        {
            private String[] vxnets;
            [Param(paramType = "header", paramName = "Vxnets")]
            public String[] getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String[] vxnets)
            {
                this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
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

        public class DeleteVxnetsOutput:OutputModel
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

            private String vxnets;
            [Param(paramType = "query", paramName = "Vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }
            public void setVxnets(String vxnets)
            {
                this.vxnets = vxnets;
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

        public DeleteVxnetsOutput DeleteVxnets(DeleteVxnetsInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DeleteVxnets");
            context.Add("APIName", "DeleteVxnets");
            context.Add("ServiceName", "Delete Vxnets");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DeleteVxnetsOutput));
            if (backModel != null)
            {
                return (DeleteVxnetsOutput)backModel;
            }
            return null;
        }

        public class JoinVxnetInput:RequestInputModel
        {
            private String vxnets;
            [Param(paramType = "header", paramName = "Vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String vxnets)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
            }

            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = new String[instances.Length];
                this.instances = instances;
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

        public class JoinVxnetOutput:OutputModel
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

        public JoinVxnetOutput DeleteVxnets(JoinVxnetInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "JoinVxnet");
            context.Add("APIName", "JoinVxnet");
            context.Add("ServiceName", "Join Vxnet");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(JoinVxnetOutput));
            if (backModel != null)
            {
                return (JoinVxnetOutput)backModel;
            }
            return null;
        }

        public class LeaveVxnetInput:RequestInputModel
        {
            private String vxnets;
            [Param(paramType = "header", paramName = "Vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String vxnets)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
            }

            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = new String[instances.Length];
                this.instances = instances;
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

        public class LeaveVxnetOutput:OutputModel
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

        public LeaveVxnetOutput LeaveVxnet(LeaveVxnetInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "LeaveVxnet");
            context.Add("APIName", "LeaveVxnet");
            context.Add("ServiceName", "Leave Vxnet");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(LeaveVxnetOutput));
            if (backModel != null)
            {
                return (LeaveVxnetOutput)backModel;
            }
            return null;
        }

        public class ModifyVxnetAttributesInput:RequestInputModel
        {
            private String vxnets;
            [Param(paramType = "header", paramName = "Vxnets")]
            public String getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String vxnets)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnets = vxnets;
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

            private String vxnet_name;
            [Param(paramType = "header", paramName = "Vxnet_name")]
            public String getVxnet_name()
            {
                return this.vxnet_name;
            }

            public void setVxnet_name(String vxnet_name)
            {

                this.vxnet_name = vxnet_name;
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

        public class ModifyVxnetAttributesOutput:OutputModel
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

        public ModifyVxnetAttributesOutput ModifyVxnetAttributes(ModifyVxnetAttributesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "ModifyVxnetAttributes");
            context.Add("APIName", "ModifyVxnetAttributes");
            context.Add("ServiceName", "Modify Vxnet Attributes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ModifyVxnetAttributesOutput));
            if (backModel != null)
            {
                return (ModifyVxnetAttributesOutput)backModel;
            }
            return null;
        }

        public class DescribeVxnetInstancesInput:RequestInputModel
        {
            private String vxnet;
            [Param(paramType = "header", paramName = "Vxnet")]
            public String getVxnet()
            {
                return this.vxnet;
            }

            public void setVxnet(String vxnet)
            {
                //this.vxnets = new String[vxnets.Length];
                this.vxnet = vxnet;
            }

            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = new String[instances.Length];
                this.instances = instances;
            }

            private String instance_type;
            [Param(paramType = "header", paramName = "Instance_type")]
            public String getInstance_type()
            {
                return this.instance_type;
            }

            public void setInstance_type(String instance_type)
            {
                //this.vxnets = new String[vxnets.Length];
                this.instance_type = instance_type;
            }

            private String status;
            [Param(paramType = "header", paramName = "Status")]
            public String getStatus()
            {
                return this.status;
            }

            public void setStatus(String status)
            {
                //this.vxnets = new String[vxnets.Length];
                this.status = status;
            }

            private String image;
            [Param(paramType = "header", paramName = "Image")]
            public String getImage()
            {
                return this.image;
            }

            public void setImage(String image)
            {
                //this.vxnets = new String[vxnets.Length];
                this.image = image;
            }

            private int offset;
            [Param(paramType = "header", paramName = "Offset")]
            public int getOffset()
            {
                return this.offset;
            }

            public void setOffset(int offset)
            {
                //this.vxnets = new String[vxnets.Length];
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
                //this.vxnets = new String[vxnets.Length];
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
                //this.vxnets = new String[vxnets.Length];
                this.zone = zone;
            }
            public override String validateParam()
            {

                return null;
            }
        }

        public class DescribeVxnetInstancesOutput:OutputModel
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

            private String instance_set;
            [Param(paramType = "query", paramName = "Instance_set")]
            public String getInstance_set()
            {
                return this.instance_set;
            }
            public void setInstance_set(String instance_set)
            {
                this.instance_set = instance_set;
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

            private String vxnet_id;
            [Param(paramType = "query", paramName = "Vxnet_id")]
            public String getVxnet_id()
            {
                return this.vxnet_id;
            }
            public void setVxnet_id(String vxnet_id)
            {
                this.vxnet_id = vxnet_id;
            }

            private String instance_name;
            [Param(paramType = "query", paramName = "Instance_name")]
            public String getInstance_name()
            {
                return this.instance_name;
            }
            public void setInstance_name(String instance_name)
            {
                this.instance_name = instance_name;
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

            private String instance_type;
            [Param(paramType = "query", paramName = "Instance_type")]
            public String getInstance_type()
            {
                return this.instance_type;
            }
            public void setInstance_type(String instance_type)
            {
                this.instance_type = instance_type;
            }

            private int vcpus_current;
            [Param(paramType = "query", paramName = "Vcpus_current")]
            public int getVcpus_current()
            {
                return this.vcpus_current;
            }
            public void setVcpus_current(int vcpus_current)
            {
                this.vcpus_current = vcpus_current;
            }

            private int memory_current;
            [Param(paramType = "query", paramName = "Memory_current")]
            public int getMemory_current()
            {
                return this.memory_current;
            }
            public void setMemory_current(int memory_current)
            {
                this.memory_current = memory_current;
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

            private String image_id;
            [Param(paramType = "query", paramName = "Image_id")]
            public String getImage_id()
            {
                return this.image_id;
            }
            public void setImage_id(String image_id)
            {
                this.image_id = image_id;
            }

            private Dictionary<object,object> dhcp_options;
            [Param(paramType = "query", paramName = "Dhcp_options")]
            public Dictionary<object, object> getDhcp_options()
            {
                return this.dhcp_options;
            }
            public void setDhcp_options(Dictionary<object, object> dhcp_options)
            {
                this.dhcp_options = dhcp_options;
            }

            private String private_ip;
            [Param(paramType = "query", paramName = "Private_ip")]
            public String getPrivate_ip()
            {
                return this.private_ip;
            }
            public void setPrivate_ip(String private_ip)
            {
                this.private_ip = private_ip;
            }
        }

        public DescribeVxnetInstancesOutput DescribeVxnetInstances(DescribeVxnetInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DescribeVxnetInstances");
            context.Add("APIName", "DescribeVxnetInstances");
            context.Add("ServiceName", "Describe Vxnet Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeVxnetInstancesOutput));
            if (backModel != null)
            {
                return (DescribeVxnetInstancesOutput)backModel;
            }
            return null;
        }

    }
}
