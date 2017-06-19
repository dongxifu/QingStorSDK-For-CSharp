using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QingStorIaasSDK.com.qingstor.sdk.Attribute;
using QingStorIaasSDK.com.qingstor.sdk.model;
using QingStorIaasSDK.com.qingstor.sdk.utils;


namespace QingStorIaasSDK.com.qingstor.sdk.service
{
    class Types
    {
         public class ACLModel :RequestInputModel {
         private GranteeModel grantee;

        public void setGrantee(GranteeModel grantee) {
            this.grantee = grantee;
        }

       [Param(paramType = "query", paramName = "grantee")]
        public GranteeModel getGrantee() {
            return this.grantee;
        } // Permission for this grantee
        // Permission's available values: READ, WRITE, FULL_CONTROL
        // Required

        private String permission;

        public void setPermission(String permission) {
            this.permission = permission;
        }

       [Param(paramType =  "query", paramName = "permission")]
        public String getPermission() {
            return this.permission;
        }


       public override String validateParam()
       {

            if (this.getGrantee() != null) {
                String vValidate = this.getGrantee().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }
            if (this.getGrantee() == null) {
                return QSStringUtil.getParameterRequired("Grantee", "ACL");
            }
            if (QSStringUtil.isEmpty(this.getPermission())) {
                return QSStringUtil.getParameterRequired("Permission", "ACL");
            }
            String[] permissionValidValues = {"READ", "WRITE", "FULL_CONTROL"};

            Boolean permissionIsValid = false;
            int i=0;
            for (i=0;i<permissionValidValues.Length;i++) 
            {
                String v=permissionValidValues[i];
                if (v.Equals(this.getPermission())) {
                    permissionIsValid = true;
                }
            }

            if (!permissionIsValid) {
                return QSStringUtil.getParameterValueNotAllowedError(
                        "Permission", this.getPermission() + "", permissionValidValues);
            }
            return null;
        }
    }

    public class BucketModel:RequestInputModel {

        // Created time of the bucket

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
        } // URL to access the bucket

        private String uRL;

        public void setURL(String uRL) {
            this.uRL = uRL;
        }

       [Param(paramType = "query", paramName = "url")]
        public String getURL() {
            return this.uRL;
        }


       public override String validateParam()
       {

            return null;
        }
    }

    public class ConditionModel:RequestInputModel {

        private IPAddressModel iPAddress;

        public void setIPAddress(IPAddressModel iPAddress) {
            this.iPAddress = iPAddress;
        }

       [Param(paramType = "query", paramName = "ip_address")]
        public IPAddressModel getIPAddress() {
            return this.iPAddress;
        }

        private IsNullModel isNull;

        public void setIsNull(IsNullModel isNull) {
            this.isNull = isNull;
        }

       [Param(paramType = "query", paramName = "is_null")]
        public IsNullModel getIsNull() {
            return this.isNull;
        }

        private NotIPAddressModel notIPAddress;

        public void setNotIPAddress(NotIPAddressModel notIPAddress) {
            this.notIPAddress = notIPAddress;
        }

       [Param(paramType = "query", paramName = "not_ip_address")]
        public NotIPAddressModel getNotIPAddress() {
            return this.notIPAddress;
        }

        private StringLikeModel stringLike;

        public void setStringLike(StringLikeModel stringLike) {
            this.stringLike = stringLike;
        }

       [Param(paramType = "query", paramName = "string_like")]
        public StringLikeModel getStringLike() {
            return this.stringLike;
        }

        private StringNotLikeModel stringNotLike;

        public void setStringNotLike(StringNotLikeModel stringNotLike) {
            this.stringNotLike = stringNotLike;
        }

        [Param(paramType = "query", paramName = "string_not_like")]
        public StringNotLikeModel getStringNotLike() {
            return this.stringNotLike;
        }


        public override String validateParam()
        {

            if (this.getIPAddress() != null) {
                String vValidate = this.getIPAddress().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }

            if (this.getIsNull() != null) {
                String vValidate = this.getIsNull().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }

            if (this.getNotIPAddress() != null) {
                String vValidate = this.getNotIPAddress().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }

            if (this.getStringLike() != null) {
                String vValidate = this.getStringLike().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }

            if (this.getStringNotLike() != null) {
                String vValidate = this.getStringNotLike().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }

            return null;
        }
    }

    public class CORSRuleModel:RequestInputModel {

        // Allowed headers

        private List<String> allowedHeaders;

        public void setAllowedHeaders(List<String> allowedHeaders) {
            this.allowedHeaders = allowedHeaders;
        }

       [Param(paramType = "query", paramName = "allowed_headers")]
        public List<String> getAllowedHeaders() {
            return this.allowedHeaders;
        } // Allowed methods
        // Required

        private List<String> allowedMethods;

        public void setAllowedMethods(List<String> allowedMethods) {
            this.allowedMethods = allowedMethods;
        }

        [Param(paramType = "query", paramName = "allowed_methods")]
        public List<String> getAllowedMethods() {
            return this.allowedMethods;
        } // Allowed origin
        // Required

        private String allowedOrigin;

        public void setAllowedOrigin(String allowedOrigin) {
            this.allowedOrigin = allowedOrigin;
        }

       [Param(paramType = "query", paramName = "allowed_origin")]
        public String getAllowedOrigin() {
            return this.allowedOrigin;
        } // Expose headers

        private List<String> exposeHeaders;

        public void setExposeHeaders(List<String> exposeHeaders) {
            this.exposeHeaders = exposeHeaders;
        }

       [Param(paramType = "query", paramName = "expose_headers")]
        public List<String> getExposeHeaders() {
            return this.exposeHeaders;
        } // Max age seconds

        private int maxAgeSeconds;

        public void setMaxAgeSeconds(int maxAgeSeconds) {
            this.maxAgeSeconds = maxAgeSeconds;
        }

       [Param(paramType = "query", paramName = "max_age_seconds")]
        public int getMaxAgeSeconds() {
            return this.maxAgeSeconds;
        }


       public override String validateParam()
       {

            if (QSStringUtil.isEmpty(this.getAllowedOrigin())) {
                return QSStringUtil.getParameterRequired("AllowedOrigin", "CORSRule");
            }
            return null;
        }
    }

    public class GranteeModel: RequestInputModel {

        // Grantee user ID

        private String iD;

        public void setID(String iD) {
            this.iD = iD;
        }

       [Param(paramType = "query", paramName = "id")]
        public String getID() {
            return this.iD;
        } // Grantee group name

        private String name;

        public void setName(String name) {
            this.name = name;
        }

       [Param(paramType = "query", paramName = "name")]
        public String getName() {
            return this.name;
        } // Grantee type
        // Type's available values: user, group
        // Required

        private String type;

        public void setType(String type) {
            this.type = type;
        }

       [Param(paramType = "query", paramName = "type")]
        public String getType() {
            return this.type;
        }


       public override String validateParam()
       {

            if (QSStringUtil.isEmpty(this.getType())) {
                return QSStringUtil.getParameterRequired("Type", "Grantee");
            }
            String[] typeValidValues = {"user", "group"};

            Boolean typeIsValid = false;
            int i=0;
            for (i=0;i<typeValidValues.Length;i++) {
                String v=typeValidValues[i];
                if (v.Equals(this.getType())) {
                    typeIsValid = true;
                }
            }

            if (!typeIsValid) {
                return QSStringUtil.getParameterValueNotAllowedError(
                        "Type", this.getType() + "", typeValidValues);
            }
            return null;
        }
    }

    public class IPAddressModel :RequestInputModel {

        // Source IP

        private List<String> sourceIP;

        public void setSourceIP(List<String> sourceIP) {
            this.sourceIP = sourceIP;
        }

       [Param(paramType = "query", paramName = "source_ip")]
        public List<String> getSourceIP() {
            return this.sourceIP;
        }


       public override String validateParam()
       {

            return null;
        }
    }

    public class IsNullModel : RequestInputModel {

        // Refer url

        private Boolean referer;

        public void setReferer(Boolean referer) {
            this.referer = referer;
        }

       [Param(paramType = "query", paramName = "Referer")]
        public Boolean getReferer() {
            return this.referer;
        }


       public override String validateParam()
       {

            return null;
        }
    }

    public class KeyModel : RequestInputModel {

        // Object created time

        private String created;

        public void setCreated(String created) {
            this.created = created;
        }

       [Param(paramType = "query", paramName = "created")]
        public String getCreated() {
            return this.created;
        } // MD5sum of the object

        private String etag;

        public void setEtag(String etag) {
            this.etag = etag;
        }

        [Param(paramType = "query", paramName = "etag")]
        public String getEtag() {
            return this.etag;
        } // Object key

        private String key;

        public void setKey(String key) {
            this.key = key;
        }

        [Param(paramType = "query", paramName =  "key")]
        public String getKey() {
            return this.key;
        } // MIME type of the object

        private String mimeType;

        public void setMimeType(String mimeType) {
            this.mimeType = mimeType;
        }

        [Param(paramType = "query", paramName = "mime_type")]
        public String getMimeType() {
            return this.mimeType;
        } // Last modified time in unix time format

        private int modified;

        public void setModified(int modified) {
            this.modified = modified;
        }

        [Param(paramType = "query", paramName =  "modified")]
        public int getModified() {
            return this.modified;
        } // Object content size

        private int size;

        public void setSize(int size) {
            this.size = size;
        }

       [Param(paramType = "query", paramName = "size")]
        public int getSize() {
            return this.size;
        }


       public override String validateParam()
       {

            return null;
        }
    }

    public class KeyDeleteErrorModel:RequestInputModel {

        // Error code

        private String code;

        public void setCode(String code) {
            this.code = code;
        }

        [Param(paramType = "query", paramName =  "code")]
        public String getCode() {
            return this.code;
        } // Object key

        private String key;

        public void setKey(String key) {
            this.key = key;
        }

        [Param(paramType = "query", paramName = "key")]
        public String getKey() {
            return this.key;
        } // Error message

        private String message;

        public void setMessage(String message) {
            this.message = message;
        }

        [Param(paramType = "query", paramName = "message")]
        public String getMessage() {
            return this.message;
        }


        public override String validateParam()
        {

            return null;
        }
    }

    public  class NotIPAddressModel : RequestInputModel {

        // Source IP

        private List<String> sourceIP;

        public void setSourceIP(List<String> sourceIP) {
            this.sourceIP = sourceIP;
        }

       [Param(paramType = "query", paramName = "source_ip")]
        public List<String> getSourceIP() {
            return this.sourceIP;
        }


       public override String validateParam()
       {

            return null;
        }
    }

    public  class ObjectPartModel : RequestInputModel {

        // Object part created time

        private String created;

        public void setCreated(String created) {
            this.created = created;
        }

       [Param(paramType = "query", paramName = "created")]
        public String getCreated() {
            return this.created;
        } // MD5sum of the object part

        private String etag;

        public void setEtag(String etag) {
            this.etag = etag;
        }

        [Param(paramType = "query", paramName =  "etag")]
        public String getEtag() {
            return this.etag;
        } // Object part number
        // Required

        private int partNumber;

        public void setPartNumber(int partNumber) {
            this.partNumber = partNumber;
        }

        [Param(paramType = "query", paramName = "part_number")]
        public int getPartNumber() {
            return this.partNumber;
        } // Object part size

        private int size;

        public void setSize(int size) {
            this.size = size;
        }

        [Param(paramType = "query", paramName =  "size")]
        public int getSize() {
            return this.size;
        }


        public override String validateParam()
        {

            if (this.getPartNumber() < 0) {
                return QSStringUtil.getParameterRequired("PartNumber", "ObjectPart");
            }
            return null;
        }
    }

    public  class OwnerModel : RequestInputModel {

        // User ID

        private String iD;

        public void setID(String iD) {
            this.iD = iD;
        }

       [Param(paramType = "query", paramName = "id")]
        public String getID() {
            return this.iD;
        } // Username

        private String name;

        public void setName(String name) {
            this.name = name;
        }

       [Param(paramType = "query", paramName = "name")]
        public String getName() {
            return this.name;
        }


       public override String validateParam()
       {

            return null;
        }
    }

    public class StatementModel : RequestInputModel {

        // QingStor API methods
        // Required

        private List<String> action;

        public void setAction(List<String> action) {
            this.action = action;
        }

        [Param(paramType = "query", paramName =  "action")]
        public List<String> getAction() {
            return this.action;
        }

        private ConditionModel condition;

        public void setCondition(ConditionModel condition) {
            this.condition = condition;
        }

        [Param(paramType = "query", paramName = "condition")]
        public ConditionModel getCondition() {
            return this.condition;
        } // Statement effect
        // Effect's available values: allow, deny
        // Required

        private String effect;

        public void setEffect(String effect) {
            this.effect = effect;
        }

        [Param(paramType = "query", paramName = "effect")]
        public String getEffect() {
            return this.effect;
        } // Bucket policy id, must be unique
        // Required

        private String iD;

        public void setID(String iD) {
            this.iD = iD;
        }

       [Param(paramType = "query", paramName = "id")]
        public String getID() {
            return this.iD;
        } // The resources to apply bucket policy
        // Required

        private List<String> resource;

        public void setResource(List<String> resource) {
            this.resource = resource;
        }

        [Param(paramType = "query", paramName = "resource")]
        public List<String> getResource() {
            return this.resource;
        } // The user to apply bucket policy
        // Required

        private List<String> user;

        public void setUser(List<String> user) {
            this.user = user;
        }

        [Param(paramType = "query", paramName = "user")]
        public List<String> getUser() {
            return this.user;
        }

        
        public override String validateParam() {

            if (this.getCondition() != null) {
                String vValidate = this.getCondition().validateParam();
                if (!QSStringUtil.isEmpty(vValidate)) {
                    return vValidate;
                }
            }

            if (QSStringUtil.isEmpty(this.getEffect())) {
                return QSStringUtil.getParameterRequired("Effect", "Statement");
            }
            String[] effectValidValues = {"allow", "deny"};

            Boolean effectIsValid = false;
            int i=0;
            for (i=9;i<effectValidValues.Length;i++) {
                String v = effectValidValues[i];
                if (v.Equals(this.getEffect())) {
                    effectIsValid = true;
                }
            }

            if (!effectIsValid) {
                return QSStringUtil.getParameterValueNotAllowedError(
                        "Effect", this.getEffect() + "", effectValidValues);
            }
            if (QSStringUtil.isEmpty(this.getID())) {
                return QSStringUtil.getParameterRequired("ID", "Statement");
            }
            return null;
        }
    }

    public  class StringLikeModel : RequestInputModel {

        // Refer url

        private List<String> referer;

        public void setReferer(List<String> referer) {
            this.referer = referer;
        }

       [Param(paramType = "query", paramName = "Referer")]
        public List<String> getReferer() {
            return this.referer;
        }

        
        public override String validateParam() {

            return null;
        }
    }

    public  class StringNotLikeModel :RequestInputModel {

        // Refer url

        private List<String> referer;

        public void setReferer(List<String> referer) {
            this.referer = referer;
        }

       [Param(paramType = "query", paramName = "Referer")]
        public List<String> getReferer() {
            return this.referer;
        }

        
        public override String validateParam() {

            return null;
        }
    }

    }
}
