using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.Attribute;

namespace QingStorSDK.test.CSharp.com.qingstor.sdk.utils
{
    class ParamTypeModel
    {
        private String alarmStatus;

        public void setAlarmStatus(String alarmStatus) 
        {
            this.alarmStatus = alarmStatus;
        }

        [Param(paramType = "query", paramName = "alarm_status")]
        public String getAlarmStatus() 
        {
            return this.alarmStatus;
        }

        private String cPUTopology;

        public void setCPUTopology(String cPUTopology) 
        {
            this.cPUTopology = cPUTopology;
        }      

        [Param(paramType = "query", paramName = "cpu_topology")]
        public String getCPUTopology() 
        {
            return this.cPUTopology;
        }

        private String createTime;

        public void setCreateTime(String createTime) 
        {
            this.createTime = createTime;
        }

        [Param(paramType = "query", paramName = "create_time")]
        public String getCreateTime() 
        {
            return this.createTime;
        }

        private String description;

        public void setDescription(String description) 
        {
            this.description = description;
        }

        [Param(paramType = "query", paramName = "description")]
        public String getDescription() 
        {
            return this.description;
        }

        private String device;

        public void setDevice(String device) 
        {
            this.device = device;
        }

        [Param(paramType = "query", paramName = "device")]
        public String getDevice() 
        {
            return this.device;
        }

        private String graphicsPasswd;

        public void setGraphicsPasswd(String graphicsPasswd) 
        {
            this.graphicsPasswd = graphicsPasswd;
        }

        [Param(paramType = "query", paramName = "graphics_passwd")]
        public String getGraphicsPasswd() 
        {
            return this.graphicsPasswd;
        }

        private String graphicsProtocol;

        public void setGraphicsProtocol(String graphicsProtocol) 
        {
            this.graphicsProtocol = graphicsProtocol;
        }

        [Param(paramType = "query", paramName = "graphics_protocol")]
        public String getGraphicsProtocol() 
        {
            return this.graphicsProtocol;
        }

        private String imageID;

        public void setImageID(String imageID) 
        {
            this.imageID = imageID;
        }

        [Param(paramType = "query", paramName = "image_id")]
        public String getImageID() 
        {
            return this.imageID;
        }

        private int instanceClass;

        public void setInstanceClass(int instanceClass) 
        {
            this.instanceClass = instanceClass;
        }

        [Param(paramType = "query", paramName = "instance_class")]
        public int getInstanceClass() 
        {
            return this.instanceClass;
        }

        private String instanceID;

        public void setInstanceID(String instanceID) 
        {
            this.instanceID = instanceID;
        }

        [Param(paramType = "query", paramName = "instance_id")]
        public String getInstanceID() 
        {
            return this.instanceID;
        }

        private String instanceName;

        public void setInstanceName(String instanceName) 
        {
            this.instanceName = instanceName;
        }

        [Param(paramType = "query", paramName = "instance_name")]
        public String getInstanceName() 
        {
            return this.instanceName;
        }

        private String instanceType;

        public void setInstanceType(String instanceType) 
        {
            this.instanceType = instanceType;
        }

        [Param(paramType = "query", paramName = "instance_type")]
        public String getInstanceType() 
        {
            return this.instanceType;
        }

        private List<String> keyPairIDs;

        public void setKeyPairIDs(List<String> keyPairIDs) 
        {
            this.keyPairIDs = keyPairIDs;
        }

        [Param(paramType = "query", paramName = "keypair_ids")]
        public List<String> getKeyPairIDs() 
        {
            return this.keyPairIDs;
        }

        private int memoryCurrent;

        public void setMemoryCurrent(int memoryCurrent) 
        {
            this.memoryCurrent = memoryCurrent;
        }

        [Param(paramType = "query", paramName = "memory_current")]
        public int getMemoryCurrent() 
        {
            return this.memoryCurrent;
        }

        private String privateIP;

        public void setPrivateIP(String privateIP) 
        {
            this.privateIP = privateIP;
        }

        [Param(paramType = "query", paramName = "private_ip")]
        public String getPrivateIP() 
        {
            return this.privateIP;
        }

        private String status;

        public void setStatus(String status) 
        {
            this.status = status;
        }

        [Param(paramType = "query", paramName = "status")]
        public String getStatus() 
        {
            return this.status;
        }

        private String statusTime;

        public void setStatusTime(String statusTime) 
        {
            this.statusTime = statusTime;
        }

        [Param(paramType = "query", paramName = "status_time")]
        public String getStatusTime() 
        {
            return this.statusTime;
        }

        private int subCode;

        public void setSubCode(int subCode) 
        {
            this.subCode = subCode;
        }

        [Param(paramType = "query", paramName = "sub_code")]
        public int getSubCode() 
        {
            return this.subCode;
        }

        private String transitionStatus;

        public void setTransitionStatus(String transitionStatus) 
        {
            this.transitionStatus = transitionStatus;
        }

        [Param(paramType = "query", paramName = "transition_status")]
        public String getTransitionStatus() 
        {
            return this.transitionStatus;
        }

        private int vCPUsCurrent;

        public void setVCPUsCurrent(int vCPUsCurrent) 
        {
            this.vCPUsCurrent = vCPUsCurrent;
        }

        [Param(paramType = "query", paramName = "vcpus_current")]
        public int getVCPUsCurrent() 
        {
            return this.vCPUsCurrent;
        }

        private List<String> volumeIDs;

        public void setVolumeIDs(List<String> volumeIDs) 
        {
            this.volumeIDs = volumeIDs;
        }

        [Param(paramType = "query", paramName = "volume_ids")]
        public List<String> getVolumeIDs() 
        {
            return this.volumeIDs;
        }
    }
}
