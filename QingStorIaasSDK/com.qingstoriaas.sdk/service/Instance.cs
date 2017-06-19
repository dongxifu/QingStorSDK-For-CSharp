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
    class Instance
    {
        private String zone;
        private EvnContext evnContext;

        public Instance(EvnContext evnContext) 
        {
            this.evnContext = evnContext;
            this.zone = QSConstant.STOR_DEFAULT_ZONE;
        }   
     
        public Instance(EvnContext evnContext, String zone) 
        {
            this.evnContext = evnContext;
            this.zone = zone;
        }
        public class DescribeInstancesInput : RequestInputModel
        {
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

            private String[] image_id;
            [Param(paramType = "header", paramName = "Image_id")]
            public String[] getImage_id()
            {
                return this.image_id;
            }

            public void setImage_id(String[] image_id)
            {
                this.image_id = new String[image_id.Length];
                this.image_id = image_id;
            }

            private String[] instance_type;
            [Param(paramType = "header", paramName = "Instance_type")]
            public String[] getInstance_type()
            {
                return this.instance_type;
            }

            public void setInstance_type(String[] instance_type)
            {
                this.instance_type = new String[instance_type.Length];
                this.instance_type = instance_type;
            }

            private String instance_class;
            [Param(paramType = "header", paramName = "Instance_class")]
            public String getInstance_class()
            {
                return this.instance_class;
            }

            public void setInstance_class(String instance_class)
            {
                this.instance_class = instance_class;
            }

            private String status;
            [Param(paramType = "header", paramName = "Status")]
            public String getStatus()
            {
                return this.status;
            }

            public void setStatus(String status)
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

            private String tags;
            [Param(paramType = "header", paramName = "tags")]
            public String getTags()
            {
                return this.tags;
            }

            public void setTags(String tags)
            {
                this.tags = tags;
            }

            private String owner;
            [Param(paramType = "header", paramName = "owner")]
            public String getOwner()
            {
                return this.owner;
            }

            public void setOwner(String owner)
            {
                this.owner = owner;
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
            [Param(paramType = "header", paramName = "limit")]
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

        public class DescribeInstancesOutput : OutputModel 
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

            private String total_count;
            [Param(paramType = "query", paramName = "Total_count")]
            public String getTotal_count()
            {
                return this.total_count;
            }
            public void setTotal_count(String total_count)
            {
                this.total_count = total_count;
            }

            private String instance_id;
            [Param(paramType = "query", paramName = "Instance_id")]
            public String getInstance_id()
            {
                return this.instance_id;
            }
            public void setInstance_id(String instance_id)
            {
                this.instance_id = instance_id;
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

            private Dictionary<object,object> image;
            [Param(paramType = "query", paramName = "Image")]
            public Dictionary<object, object> getImage()
            {
                return this.image;
            }
            public void setImage(Dictionary<object, object> image)
            {
                this.image = image;
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

            private Dictionary<object,object> eip;
            [Param(paramType = "query", paramName = "Eip")]
            public Dictionary<object,object> getEip()
            {
                return this.eip;
            }
            public void setEip(Dictionary<object,object> eip)
            {
                this.eip = eip;
            }

            private Dictionary<object,object> security_group;
            [Param(paramType = "query", paramName = "Security_group")]
            public Dictionary<object,object> getkeypair_ids()
            {
                return this.security_group;
            }
            public void setSecurity_group(Dictionary<object,object> security_group)
            {
                this.security_group = security_group;
            }

            private String volume_ids;
            [Param(paramType = "query", paramName = "Volume_ids")]
            public String getVolume_ids()
            {
                return this.volume_ids;
            }
            public void setVolume_ids(String volume_ids)
            {
                this.volume_ids = volume_ids;
            }

            private String keypair_ids;
            [Param(paramType = "query", paramName = "Keypair_ids")]
            public String getKeypair_ids()
            {
                return this.keypair_ids;
            }
            public void setKeypair_ids(String keypair_ids)
            {
                this.keypair_ids = keypair_ids;
            }

            private String graphics_protocol;
            [Param(paramType = "query", paramName = "Graphics_protocol")]
            public String getGraphics_protocol()
            {
                return this.graphics_protocol;
            }
            public void setGraphics_protocol(String graphics_protocol)
            {
                this.graphics_protocol = graphics_protocol;
            }

            private String graphics_password;
            [Param(paramType = "query", paramName = "Graphics_password")]
            public String getGraphics_password()
            {
                return this.graphics_password;
            }
            public void setGraphics_password(String graphics_password)
            {
                this.graphics_password = graphics_password;
            }
        }


        public DescribeInstancesOutput DescribeInstances(DescribeInstancesInput input)
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
                            .sendApiRequest(context, input, typeof(DescribeInstancesOutput));
            if (backModel != null)
            {
                return (DescribeInstancesOutput)backModel;
            }
            return null;
        }
        
        public class RunInstancesInput : RequestInputModel
        {
            private String image_id;
            [Param(paramType = "header", paramName = "Image_id")]
            public String getImage_id()
            {
                return this.image_id;
            }

            public void setImage_id(String image_id)
            {
                this.image_id = image_id;
            }
            
            private int cpu;
            [Param(paramType = "header", paramName = "Cpu")]
            public int getCpu()
            {
                return this.cpu;
            }

            public void setCpu(int cpu)
            {
                this.cpu = cpu;
            }
            
            private int memory;
            [Param(paramType = "header", paramName = "Memory")]
            public int getMemory()
            {
                return this.memory;
            }

            public void setMemory(int memory)
            {
                this.memory = memory;
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

            private String instance_name;
            [Param(paramType = "header", paramName = "Instance_name")]
            public String getInstance_name()
            {
                return this.instance_name;
            }

            public void setInstance_name(String instance_name)
            {
                this.instance_name = instance_name;
            }

            private String login_mode;
            [Param(paramType = "header", paramName = "Login_mode")]
            public String getLogin_mode()
            {
                return this.login_mode;
            }

            public void setLogin_mode(String login_mode)
            {
                this.login_mode = login_mode;
            }

            private String login_keypair;
            [Param(paramType = "header", paramName = "Login_keypair")]
            public String getLogin_keypair()
            {
                return this.login_keypair;
            }

            public void setLogin_keypair(String login_keypair)
            {
                this.login_keypair = login_keypair;
            }

            private String login_password;
            [Param(paramType = "header", paramName = "Login_password")]
            public String getLogin_password()
            {
                return this.login_password;
            }

            public void setLogin_password(String login_password)
            {
                this.login_password = login_password;
            }

            private String[] vxnets;
            [Param(paramType = "header", paramName = "Vxnets")]
            public String[] getVxnets()
            {
                return this.vxnets;
            }

            public void setVxnets(String[] vxnets)
            {
                this.vxnets = vxnets;
            }

            private String security_group;
            [Param(paramType = "header", paramName = "Security_group")]
            public String getSecurity_group()
            {
                return this.security_group;
            }

            public void setSecurity_group(String security_group)
            {
                this.security_group = security_group;
            }

            private String[] volumes;
            [Param(paramType = "header", paramName = "Volumes")]
            public String[] getVolumes()
            {
                return this.volumes;
            }

            public void setimage_id(String[] volumes)
            {
                this.volumes = volumes;
            }

            private String hostname;
            [Param(paramType = "header", paramName = "Hostname")]
            public String getHostname()
            {
                return this.hostname;
            }

            public void setHostname(String hostname)
            {
                this.hostname = hostname;
            }

            private int need_newsid;
            [Param(paramType = "header", paramName = "Need_newsid")]
            public int getNeed_newsid()
            {
                return this.need_newsid;
            }

            public void setNeed_newsid(int need_newsid)
            {
                this.need_newsid = need_newsid;
            }

            private int need_userdata;
            [Param(paramType = "header", paramName = "Need_userdata")]
            public int getNeed_userdata()
            {
                return this.need_userdata;
            }

            public void setNeed_userdata(int need_userdata)
            {
                this.need_userdata = need_userdata;
            }

            private String userdata_type;
            [Param(paramType = "header", paramName = "Userdata_type")]
            public String getUserdata_type()
            {
                return this.userdata_type;
            }

            public void setUserdata_type(String userdata_type)
            {
                this.userdata_type = userdata_type;
            }

            private String userdata_value;
            [Param(paramType = "header", paramName = "Userdata_value")]
            public String getUserdata_value()
            {
                return this.userdata_value;
            }

            public void setUserdata_value(String userdata_value)
            {
                this.userdata_value = userdata_value;
            }

            private String instance_class;
            [Param(paramType = "header", paramName = "Instance_class")]
            public String getInstance_class()
            {
                return this.instance_class;
            }

            public void setInstance_class(String instance_class)
            {
                this.instance_class = instance_class;
            }

            private String cpu_model;
            [Param(paramType = "header", paramName = "Cpu_model")]
            public String getCpu_model()
            {
                return this.cpu_model;
            }

            public void setCpu_model(String cpu_model)
            {
                this.cpu_model = cpu_model;
            }

            private String cpu_topology;
            [Param(paramType = "header", paramName = "Cpu_topology")]
            public String getCpu_topology()
            {
                return this.cpu_topology;
            }

            public void setCpu_topology(String cpu_topology)
            {
                this.cpu_topology = cpu_topology;
            }

            private int nic_mqueue;
            [Param(paramType = "header", paramName = "Nic_mqueue")]
            public int getNic_mqueue()
            {
                return this.nic_mqueue;
            }

            public void setNic_mqueue(int nic_mqueue)
            {
                this.nic_mqueue = nic_mqueue;
            }

            private String userdata_path;
            [Param(paramType = "header", paramName = "Userdata_path")]
            public String getUserdata_path()
            {
                return this.userdata_path;
            }

            public void setUserdata_path(String userdata_path)
            {
                this.userdata_path = userdata_path;
            }

            private String userdata_file;
            [Param(paramType = "header", paramName = "Userdata_file")]
            public String getUserdata_file()
            {
                return this.userdata_file;
            }

            public void setUserdata_file(String userdata_file)
            {
                this.userdata_file = userdata_file;
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

        public class RunInstancesOutput: OutputModel
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

            private String instances;
            [Param(paramType = "query", paramName = "Instances")]
            public String getInstances()
            {
                return this.instances;
            }

            public void setInstances(String instances)
            {
                this.instances = instances;
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

        public RunInstancesOutput RunInstances(RunInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "RunInstances");
            context.Add("APIName", "RunInstances");
            context.Add("ServiceName", "Run Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(RunInstancesOutput));
            if (backModel != null)
            {
                return (RunInstancesOutput)backModel;
            }
            return null;
        }

        public class TerminateInstancesInput : RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = instances;
            }

            private String zone;
            [Param(paramType = "header", paramName = "zone")]
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

        public class TerminateInstancesOutput : OutputModel
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

        public TerminateInstancesOutput TerminateInstances(TerminateInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "TerminateInstances");
            context.Add("APIName", "TerminateInstances");
            context.Add("ServiceName", "Terminate Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(TerminateInstancesOutput));
            if (backModel != null)
            {
                return (TerminateInstancesOutput)backModel;
            }
            return null;
        }

        public class StartInstancesInput:RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = instances;
            }

            private String zone;
            [Param(paramType = "header", paramName = "zone")]
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

        public class StartInstancesOutput : OutputModel
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

        public StartInstancesOutput StartInstances(StartInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "StartInstances");
            context.Add("APIName", "StartInstances");
            context.Add("ServiceName", "Start Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(StartInstancesOutput));
            if (backModel != null)
            {
                return (StartInstancesOutput)backModel;
            }
            return null;
        }

        public class StopInstancesInput :　RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = instances;
            }

            private int force;
            [Param(paramType = "header", paramName = "Force")]
            public int getForce()
            {
                return this.force;
            }

            public void setForce(int force)
            {

                this.force = force;
            }

            private String zone;
            [Param(paramType = "header", paramName = "zone")]
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

        public class StopInstancesOutput :OutputModel
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

        public StopInstancesOutput StartInstances(StopInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "StopInstances");
            context.Add("APIName", "StopInstances");
            context.Add("ServiceName", "Stop Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(StopInstancesOutput));
            if (backModel != null)
            {
                return (StopInstancesOutput)backModel;
            }
            return null;
        }

        public class RestartInstancesInput :RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {
                this.instances = instances;
            }

            private String zone;
            [Param(paramType = "header", paramName = "zone")]
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

        public class RestartInstancesOutput :OutputModel
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

        public RestartInstancesOutput RestartInstances(RestartInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "RestartInstances");
            context.Add("APIName", "RestartInstances");
            context.Add("ServiceName", "Restart Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(RestartInstancesOutput));
            if (backModel != null)
            {
                return (RestartInstancesOutput)backModel;
            }
            return null;
        }

        public class ResetInstancesInput : RequestInputModel
        {
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

            
            private String login_mode;
            [Param(paramType = "header", paramName = "Login_mode")]
            public String getLogin_mode()
            {
                return this.login_mode;
            }

            public void setLogin_mode(String login_mode)
            {
                this.login_mode = login_mode;
            }

            private String login_keypair;
            [Param(paramType = "header", paramName = "Login_keypair")]
            public String getLogin_keypair()
            {
                return this.login_keypair;
            }

            public void setLogin_keypair(String login_keypair)
            {
                this.login_keypair = login_keypair;
            }

            private String login_password;
            [Param(paramType = "header", paramName = "Login_password")]
            public String getLogin_password()
            {
                return this.login_password;
            }

            public void setLogin_password(String login_password)
            {
                this.login_password = login_password;
            }

            private String login_newsid;
            [Param(paramType = "header", paramName = "Login_newsid")]
            public String getLogin_newsid()
            {
                return this.login_newsid;
            }

            public void setLogin_newsid(String login_newsid)
            {
                this.login_newsid = login_newsid;
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

        public class ResetInstancesOutput : OutputModel
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

        public ResetInstancesOutput ResetInstances(ResetInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "ResetInstances");
            context.Add("APIName", "ResetInstances");
            context.Add("ServiceName", "Reset Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ResetInstancesOutput));
            if (backModel != null)
            {
                return (ResetInstancesOutput)backModel;
            }
            return null;
        }

        public class ResizeInstancesInput : RequestInputModel
        {
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
               
                this.instance_type = instance_type;
            }

            private int cpu;
            [Param(paramType = "header", paramName = "Cpu")]
            public int getCpu()
            {
                return this.cpu;
            }

            public void setCpu(int cpu)
            {

                this.cpu = cpu;
            }

            private String memory;
            [Param(paramType = "header", paramName = "Memory")]
            public String getMemory()
            {
                return this.memory;
            }

            public void setMemory(String memory)
            {

                this.memory = memory;
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

        public class ResizeInstancesOutput:OutputModel
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
        
        public ResizeInstancesOutput ResizeInstances(ResizeInstancesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "ResizeInstances");
            context.Add("APIName", "ResizeInstances");
            context.Add("ServiceName", "Resize Instances");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ResizeInstancesOutput));
            if (backModel != null)
            {
                return (ResizeInstancesOutput)backModel;
            }
            return null;
        }

        public class ModifyInstanceAttributesInput:RequestInputModel
        {
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

            private String instance_name;
            [Param(paramType = "header", paramName = "Instance_name")]
            public String getInstance_name()
            {
                return this.instance_name;
            }

            public void setInstance_name(String instance_name)
            {

                this.instance_name = instance_name;
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

            private int nic_mqueue;
            [Param(paramType = "header", paramName = "Nic_mqueue")]
            public int getNic_mqueue()
            {
                return this.nic_mqueue;
            }

            public void setNic_mqueue(int nic_mqueue)
            {

                this.nic_mqueue = nic_mqueue;
            }

            public override String validateParam()
            {

                return null;
            }
        }

        public class ModifyInstanceAttributesOutput:OutputModel
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

        public ModifyInstanceAttributesOutput ModifyInstanceAttributes(ModifyInstanceAttributesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "ModifyInstanceAttributes");
            context.Add("APIName", "ModifyInstanceAttributes");
            context.Add("ServiceName", "Modify Instance Attributes");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(ModifyInstanceAttributesOutput));
            if (backModel != null)
            {
                return (ModifyInstanceAttributesOutput)backModel;
            }
            return null;
        }

        public class DescribeInstanceTypesInput : RequestInputModel
        {
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

            private String instance_types;
            [Param(paramType = "header", paramName = "Instance_types")]
            public String getInstance_types()
            {
                return this.instance_types;
            }

            public void setInstance_types(String instance_types)
            {

                this.instance_types = instance_types;
            }

            public override String validateParam()
            {

                return null;
            }
        }

        public class DescribeInstanceTypesOutput:OutputModel
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

            private String instance_type_set;
            [Param(paramType = "query", paramName = "Instance_type_set")]
            public String getInstance_type_set()
            {
                return this.instance_type_set;
            }
            public void setInstance_type_set(String instance_type_set)
            {
                this.instance_type_set = instance_type_set;
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

            private String instance_type_id;
            [Param(paramType = "query", paramName = "Instance_type_id")]
            public String getInstance_type_id()
            {
                return this.instance_type_id;
            }
            public void setInstance_type_id(String instance_type_id)
            {
                this.instance_type_id = instance_type_id;
            }

            private String instance_type_name;
            [Param(paramType = "query", paramName = "Instance_type_name")]
            public String getInstance_type_name()
            {
                return this.instance_type_name;
            }
            public void setInstance_type_name(String instance_type_name)
            {
                this.instance_type_name = instance_type_name;
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
        }

        public DescribeInstanceTypesOutput DescribeInstanceTypes(DescribeInstanceTypesInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DescribeInstanceTypes");
            context.Add("APIName", "DescribeInstanceTypes");
            context.Add("ServiceName", "Describe Instance Types");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DescribeInstanceTypesOutput));
            if (backModel != null)
            {
                return (DescribeInstanceTypesOutput)backModel;
            }
            return null;
        }

        public class CreateBrokersInput : RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {

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

        public class CreateBrokersOutput : OutputModel
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

            private String brokers;
            [Param(paramType = "query", paramName = "Brokers")]
            public String getBrokers()
            {
                return this.brokers;
            }
            public void setBrokers(String brokers)
            {
                this.brokers = brokers;
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

            private String instance_id;
            [Param(paramType = "query", paramName = "Instance_id")]
            public String getInstance_id()
            {
                return this.instance_id;
            }
            public void setInstance_id(String instance_id)
            {
                this.instance_id = instance_id;
            }

            private String broker_host;
            [Param(paramType = "query", paramName = "Broker_host")]
            public String getBroker_host()
            {
                return this.broker_host;
            }
            public void setBroker_host(String broker_host)
            {
                this.broker_host = broker_host;
            }

            private int broker_port;
            [Param(paramType = "query", paramName = "Broker_port")]
            public int getBroker_port()
            {
                return this.broker_port;
            }
            public void setBroker_port(int broker_port)
            {
                this.broker_port = broker_port;
            }
        }

        public CreateBrokersOutput CreateBrokers(CreateBrokersInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "CreateBrokers");
            context.Add("APIName", "CreateBrokers");
            context.Add("ServiceName", "Create Brokers");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(CreateBrokersOutput));
            if (backModel != null)
            {
                return (CreateBrokersOutput)backModel;
            }
            return null;
        }

        public class DeleteBrokersInput : RequestInputModel
        {
            private String[] instances;
            [Param(paramType = "header", paramName = "Instances")]
            public String[] getInstances()
            {
                return this.instances;
            }

            public void setInstances(String[] instances)
            {

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

        public class DeleteBrokersOutput : OutputModel
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

            private String brokers;
            [Param(paramType = "query", paramName = "Brokers")]
            public String getBrokers()
            {
                return this.brokers;
            }
            public void setBrokers(String brokers)
            {
                this.brokers = brokers;
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

        public DeleteBrokersOutput DeleteBrokers(DeleteBrokersInput input)
        {
            Dictionary<object, object> context = new Dictionary<object, object>();
            context.Add(QSConstant.PARAM_KEY_REQUEST_ZONE, this.zone);
            context.Add(QSConstant.EVN_CONTEXT_KEY, this.evnContext);
            context.Add("action", "DeleteBrokers");
            context.Add("APIName", "DeleteBrokers");
            context.Add("ServiceName", "Delete Brokers");
            context.Add("RequestMethod", "GET");
            //context.Add("RequestURI", "/<>");
            //context.Add("instanceNameInput", this.instance_name);

            if (QSStringUtil.isEmpty(zone))
            {
                throw new QSException("zone can't be empty!");
            }

            OutputModel backModel =
                    ResourceRequestFactory.getResourceRequest()
                            .sendApiRequest(context, input, typeof(DeleteBrokersOutput));
            if (backModel != null)
            {
                return (DeleteBrokersOutput)backModel;
            }
            return null;
        }
    }
}
