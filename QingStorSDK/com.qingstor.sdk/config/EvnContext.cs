using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.utils;

namespace QingStorSDK.com.qingstor.sdk.config
{
    class EvnContext
    {
        public static string qingcloudIaasHost = "api.qingcloud.com";

        public static string qingcloudStorHost = "qingstor.com";
        public static string default_protocal = "https";
        public static string default_iaas_uri = "/iaas";
        
        private string accessKey;

        private string accessSecret;

        private string host;
        private string port;
        private string protocol = default_protocal;
        private string uri;
        private string log_level = QSConstant.LOGGER_ERROR;

        private bool safeOkHttp = true;

        public bool isSafeOkHttp() 
        {
            return safeOkHttp;
        }

        public void setSafeOkHttp(bool SafeOkHttp) 
        {
            this.safeOkHttp = SafeOkHttp;
        }

        public string getAccessKey() {
            return accessKey;
        }

        public void setAccessKey(string AccessKey) 
        {
            this.accessKey = AccessKey;
        }

        public string getAccessSecret() 
        {
            return accessSecret;
        }

        public void setAccessSecret(string AccessSecret) 
        {
            this.accessSecret = AccessSecret;
        }

        public string getHost() 
        {
            return host;
        }

    /** @param host example: qingstor.com */
        public void setHost(string Host) 
        {
            this.host = Host;
        }

        public string getPort() 
        {
            return port;
        }

    /** @param port example: 8080 */
        public void setPort(string Port) 
        {
            this.port = Port;
        }

        public string getProtocol() 
        {
            return protocol;
        }

    /** @param protocol example: https or http */
        public void setProtocol(string Protocol) 
        {
            this.protocol = Protocol;
        }

        public string getUri() 
        {
            return uri;
        }

    public string getRequestUrl() 
    {
        string joinUrl = this.getProtocol() + "://" + this.getHost();
        if (this.getPort() != null) {
            joinUrl += ":" + this.getPort();
        }
        if (this.getUri() != null) {
            joinUrl += this.getUri();
        }
        return joinUrl;
    }

    /** @param uri example: /iaas */
    public void setUri(string Uri) {
        this.uri = Uri;
        //QSConstant.FINNAL_URL = Uri;
    }

    private EvnContext() {}

    public EvnContext(string accessKey, string accessSecret) {
        this.setAccessKey(accessKey);
        this.setAccessSecret(accessSecret);
        this.setHost(qingcloudStorHost);
        QSConstant.LOGGER_LEVEL = this.getLog_level();
    }

    public static EvnContext loadFromFile(string filePathName) {
        EvnContext evn = new EvnContext();
        FileStream f = new FileStream(filePathName,FileMode.OpenOrCreate);
        if (f!=null) 
        {
            StreamReader sr = null;
            Dictionary <String, String> confParams = new Dictionary<String, String>();
            try 
            {
                sr = new StreamReader(f);
                string strConf = null;

                while ((strConf = sr.ReadLine()) != null) 
                {
                    string[] str = strConf.Split(':');
                    if (str.Length > 1) 
                    {
                        confParams.Add(str[0].Trim(), str[1].Replace("'","").Trim());
                    }
                }
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e);
            }
            finally 
            {
                if (sr!= null) 
                {
                    try 
                    {
                        sr.Close();
                    } 
                    catch (IOException e) 
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            evn.setAccessKey(confParams["qy_access_key_id"]);
            evn.setAccessSecret(confParams["qy_secret_access_key"]);
            evn.setProtocol("https");
            evn.setHost("qingstor.com");
            evn.setPort("443");
            evn.setLog_level(QSConstant.LOGGER_ERROR);
        }
        return evn;
    }
    

    public String getLog_level() {
		return log_level;
	}

	public void setLog_level(String log_level) {
		if(!QSStringUtil.isEmpty(log_level)){
        	QSConstant.LOGGER_LEVEL = log_level;
        }
		this.log_level = log_level;
	}
    public String validateParam() {
        if (QSStringUtil.isEmpty(getAccessKey())) {
            return QSStringUtil.getParameterRequired("AccessKey", "EvnContext");
        }
        if (QSStringUtil.isEmpty(getAccessSecret())) {
            return QSStringUtil.getParameterRequired("AccessSecret", "EvnContext");
        }
        if (QSStringUtil.isEmpty(getRequestUrl())) {
            return QSStringUtil.getParameterRequired("host", "EvnContext");
        }
        return null;
    }
    }
}
