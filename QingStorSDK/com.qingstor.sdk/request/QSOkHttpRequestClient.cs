using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using QingStorSDK.com.qingstor.sdk.utils;
using QingStorSDK.com.qingstor.sdk.constants;
using QingStorSDK.com.qingstor.sdk.model;

using System.Net.Http;
using System.Net;
using System.Net.Mime;
using System.IO;

namespace QingStorSDK.com.qingstor.sdk.request
{
    class QSOkHttpRequestClient
    {
        private static ILog logger = QSLoggerUtil.setLoggerHanlder(typeof(QSOkHttpRequestClient).Name);
        private HttpClient client = null;
        private static QSOkHttpRequestClient ins;

        protected QSOkHttpRequestClient() 
        {
            intiOkHttpClient();
        }

        public void intiOkHttpClient() 
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromMilliseconds(QSConstant.HTTPCLIENT_CONNECTION_TIME_OUT*1000);
        }

        /*private static HttpClient getUnsafeOkHttpClient() 
        {
            try 
            {
            // Create a trust manager that does not validate certificate chains
                ServicePointManager.SecurityProtocol=SecurityProtocolType.Ssl3;
            // Install the all-trusting trust manager
                
                SSLContext sslContext = SSLContext.getInstance("SSL");
            sslContext.init(null, trustAllCerts, new java.security.SecureRandom());
            // Create an ssl socket factory with our all-trusting manager
            final SSLSocketFactory sslSocketFactory = sslContext.getSocketFactory();

            OkHttpClient.Builder builder =
                    new OkHttpClient.Builder()
                            .connectTimeout(
                                    QSConstant.HTTPCLIENT_CONNECTION_TIME_OUT, TimeUnit.SECONDS)
                            .readTimeout(QSConstant.HTTPCLIENT_READ_TIME_OUT, TimeUnit.SECONDS)
                            .writeTimeout(QSConstant.HTTPCLIENT_WRITE_TIME_OUT, TimeUnit.SECONDS);
            builder.sslSocketFactory(sslSocketFactory);
            builder.hostnameVerifier(
                    new HostnameVerifier() {
                        @Override
                        public boolean verify(String hostname, SSLSession session) {
                            return true;
                        }
                    });

            OkHttpClient okHttpClient = builder.build();
            return okHttpClient;
        } catch (Exception e) {
            logger.log(Level.SEVERE, e.getMessage());
            throw new RuntimeException(e);
        }
    }*/

        public static QSOkHttpRequestClient getInstance() 
        {
            if (ins == null) 
            {
                ins = new QSOkHttpRequestClient();
            }
            return ins;
        }
        

        /*private HttpWebResponse getRequestCall(Boolean bSafe,HttpWebRequest request) 
        {
            if (bSafe) 
            {
                return client
        } else {
            return this.unsafeClient.newCall(request);
        }
    }*/

        public OutputModel requestAction(HttpWebRequest request, Boolean bSafe, Type outputClass)
        {
            HttpWebResponse response = null;
            try 
            {
                OutputModel model = (OutputModel) QSParamInvokeUtil.getOutputModel(outputClass);
                response = (HttpWebResponse)request.GetResponse();
                fillResponseValue2Object(response, model);
                return model;
            } 
            catch (WebException e) 
            {
                logger.Fatal(e.Message);
                Stream stream = e.Response.GetResponseStream();
                StreamReader st = new StreamReader(stream);
                string str = st.ReadToEnd();
                System.Console.WriteLine(str);
            }
            return null;
        }

    /**
     * 
     * @param singedUrl with singed parameter url
     * @return
     */
        public HttpWebRequest buildUrlRequest(string singedUrl) 
        {
            TrustAllUnsafeConUtil.SetCertificatePolicy();
            HttpWebRequest request =(HttpWebRequest)HttpWebRequest.Create(singedUrl);
            return request;
        }

        private void fillResponseValue2Object(HttpWebResponse response, OutputModel target)
        {
            int code = Convert.ToInt32(response.StatusCode);
            Stream receviceStream = response.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream);
            string strHTML = readerOfStream.ReadToEnd();
            string body = strHTML;//.Replace("\"","");//System.Text.RegularExpressions.Regex.Replace(strHTML,"(?is)(?<=<body>).*(?=</body>)","");
            String st = QSJSONUtil.toJSONObject("");
            st = QSJSONUtil.putJsonData(st, QSConstant.PARAM_TYPE_BODYINPUTSTREAM,body);
            if (target!=null) 
            {
                if (!QSJSONUtil.jsonObjFillValue2Object(st, target)) 
                {
                    try 
                    {
                        string responseInfo = body;
                        // Deserialize HTTP response to concrete type.
                        if (!QSStringUtil.isEmpty(responseInfo)) 
                        {
                            QSJSONUtil.jsonFillValue2Object(responseInfo, target);
                        }
                    } 
                    catch (Exception e) 
                    {
                        throw new Exception(e.Message);
                    }
                }
                WebHeaderCollection responseHeaders = response.Headers;
                int iHeads = responseHeaders.Count;
                string headJson = QSJSONUtil.toJSONObject("");
                headJson = QSJSONUtil.putJsonData(headJson, QSConstant.QC_CODE_FIELD_NAME, code);
                for (int i = 0; i < iHeads; i++) 
                {
                    QSJSONUtil.putJsonData(headJson,responseHeaders.GetKey(i), responseHeaders.GetValues(i));
                }
                QSJSONUtil.jsonObjFillValue2Object(headJson, target);
            }
        }

        public static void fillResponseCallbackModel(int code, Object content, OutputModel model) 
        {
            string errorJson = "{'"+QSConstant.QC_CODE_FIELD_NAME+"':"+code +",'"+ QSConstant.QC_MESSAGE_FIELD_NAME +"':'"+content+"'}";
            QSJSONUtil.jsonFillValue2Object(errorJson, model);
        }
        private void onOkhttpFailure(String message, ResponseCallBack callBack) 
        {
            try 
            {
                if (callBack != null) 
                {
                    OutputModel m = QSParamInvokeUtil.getOutputModel(callBack);
                    fillResponseCallbackModel(QSConstant.REQUEST_ERROR_CODE, message, m);
                    callBack.onAPIResponse(m);
                }
            } 
            catch (Exception ee) 
            {
                logger.Fatal(ee.Message);
                throw new Exception(ee.Message);
            }
        }

         public delegate OutputModel Asyncdelegate(HttpWebRequest request, Boolean bSafe,ResponseCallBack callBack);  
  
        //异步调用完成时，执行回调方法  
        private void CallbackMethod(IAsyncResult ar)  
        {  
            Asyncdelegate dlgt = (Asyncdelegate)ar.AsyncState;  
            dlgt.EndInvoke(ar);  
        }  
  
        //异步调用方法  
        public virtual OutputModel RunrequestActionAsync(HttpWebRequest request, Boolean bSafe,ResponseCallBack callBack)  
        {  
            Asyncdelegate isgt = new Asyncdelegate(requestActionAsync);  
            IAsyncResult ar = isgt.BeginInvoke(request,bSafe,callBack,new AsyncCallback(CallbackMethod),isgt);
            return null;
        }  

        public virtual OutputModel requestActionAsync(HttpWebRequest request, Boolean bSafe,ResponseCallBack callBack)
        {
            HttpWebResponse response=(HttpWebResponse)request.GetResponse();
            try
            {
                if (callBack != null) 
                {
                    OutputModel m = QSParamInvokeUtil.getOutputModel(callBack);
                    fillResponseValue2Object(response, m);
                    callBack.onAPIResponse(m);
                }
            } 
            catch (Exception e) 
            {
                logger.Fatal(e.Message);
                onOkhttpFailure(e.Message, callBack);
            } 
            finally 
            {
                if (response != null) 
                {
                    response.Close();
                }
            }
            return null;
        }

        

    

    /**
     * 
     * @param method  request method name
     * @param bodyContent body params
     * @param signedUrl  with signed param url
     * @param headParams http head params
     * @return
     * @throws QSException
     */
        public object getBodyContent(Dictionary<object,object> bodyContent)
        {
            Dictionary<object, object>.Enumerator iterator = new Dictionary<object, object>.Enumerator();
    	    iterator = bodyContent.GetEnumerator();
            int i=0;
            for(i=0;i<bodyContent.Count;i++)
            {
                iterator.MoveNext();
                string key = iterator.Current.Key.ToString();
                Object bodyObj = bodyContent[key];
                if(QSConstant.PARAM_TYPE_BODYINPUTFILESTREAM.Equals(key) 
            		|| QSConstant.PARAM_TYPE_BODYINPUTSTREAM.Equals(key)
            		|| QSConstant.PARAM_TYPE_BODYINPUTSTRING.Equals(key))
                {
                    return iterator.Current.Value;
                }
                
            }
            object jsonStr = QSStringUtil.getDictionaryToJson(bodyContent);
            return jsonStr;
        }
        public HttpWebRequest buildStorRequest(
            string method,
            Dictionary<object,object> bodyContent,
            string signedUrlFirst,
            Dictionary<object,object> headParams)
        {
            String signedUrl = null;

            //System.Console.WriteLine(signedUrl);
            
            signedUrl = signedUrlFirst;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(signedUrl);
            //request.Headers.Add("qy_access_key_id",)
            request.Method = method;
            string[] sortedHeadersKeys=new string[200];
            int sortedHeadersKeysIndex=0;
            foreach(string temp in headParams.Keys)
            {
                sortedHeadersKeys[sortedHeadersKeysIndex]=temp;
                sortedHeadersKeysIndex++;
            }
            int index=0;
            for(index=0;index<sortedHeadersKeysIndex;index++) 
            {
                string key=sortedHeadersKeys[index];
                //System.Console.WriteLine(key);
                //System.Console.Read();
                if (key == "Referer")
                    request.Referer = headParams[key].ToString();
                else if (key == "Date")
                    request.Date = Convert.ToDateTime(headParams[key].ToString());
                else if (key == "Content-Length")
                    request.ContentLength = Convert.ToInt32(headParams[key].ToString());
                else if(key=="Content-Type")
                {
                    request.ContentType = headParams[key].ToString();
                    request.MediaType = headParams[key].ToString();
                 
                }
                else if (key != null && headParams != null)
                {
                    request.Headers.Add(key, headParams[key].ToString());

                }
            }
            if(!headParams.ContainsKey(QSConstant.PARAM_KEY_USER_AGENT)) 
            {
                request.UserAgent = QSStringUtil.getUserAgent();
                //request.Headers.Add(QSConstant.PARAM_KEY_USER_AGENT, );
            }
            if (!headParams.ContainsKey(QSConstant.HEADER_PARAM_KEY_CONTENTTYPE))
                request.ContentType = null;
            else
                request.ContentType = headParams[QSConstant.HEADER_PARAM_KEY_CONTENTTYPE].ToString();
            if (bodyContent != null && bodyContent.Count > 0) 
            {
                
                object bodyObj = getBodyContent(bodyContent);
                //Stream outstream = request.GetRequestStream();  
                Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
                byte[] data = null;
                if (bodyObj is string) 
                {
                    Stream outstream = request.GetRequestStream();
                    data = new byte[((string)bodyObj).ToString().Length];
                    data = encoding.GetBytes(bodyObj.ToString());  
                    outstream.Write(data,0,data.Length);
                    outstream.Close();
                } 
                else if (bodyObj is FileStream) 
                {
                    
                    //data = new byte[((FileStream)bodyObj).ToString().Length];
                    request.MediaType = headParams[QSConstant.HEADER_PARAM_KEY_CONTENTTYPE].ToString();
                    FileStream fs = (FileStream)bodyObj;
                    //request.Headers.Add(";filename=\""+fs.Name+"\"\r\n");
                    Stream outstream = request.GetRequestStream();
                    data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);
                    fs.Close();
                    outstream.Write(data,0,data.Length);
                    outstream.Close();
                } 
                else if (bodyObj is Stream) 
                {
                    
                    request.MediaType = headParams[QSConstant.HEADER_PARAM_KEY_CONTENTTYPE].ToString();
                    Stream stream = (Stream)bodyObj;
                    Stream outstream = request.GetRequestStream();
                    data= new byte[stream.Length];
                    stream.Read(data,0,data.Length);
                    stream.Close();
                    outstream.Write(data,0,data.Length);
                    outstream.Close();
                }
                //Console.WriteLine(signedUrl);
                //request = (HttpWebRequest)HttpWebRequest.Create(signedUrl);
            //connection.getOutputStream().write(bodyContent.getBytes()); 
            }
            return request;
        }
    
    
        /*private static class EmptyRequestBody extends RequestBody {

        private String contentType;

        private int contentLength=0;


        public EmptyRequestBody(String contentType) {
            this.contentType = contentType;
        }

        @Override
        public long contentLength() throws IOException {
            return this.contentLength;
        }

        @Override
        public void writeTo(BufferedSink sink) throws IOException {

        }

        @Override
        public MediaType contentType() {
            return MediaType.parse(this.contentType);
        }

    }*/

    
    /**
     * @param method
     * @param bodyContent
     * @param headParams
     * @param singedUrl
     * @throws QSException
     */
        public HttpWebRequest buildStorMultiUpload(
            string method,
            Dictionary<object,object> bodyContent,
            string singedUrl,
            Dictionary<object,object> headParams,
            Dictionary<object,object> queryParams)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(singedUrl);
            request.Method = method;
            //Request.Builder builder = new Request.Builder();
            int KeyIndex=0;
            string[] sortedHeadersKeys = new string[100];
            foreach(string key in headParams.Keys)
            {
                sortedHeadersKeys[KeyIndex]=key.ToString();
                KeyIndex++;
            }
            for(int i=0;i<KeyIndex;i++)
            {
                if (sortedHeadersKeys[i] == "Content-Length")
                    request.ContentLength = Convert.ToInt32(headParams[sortedHeadersKeys[i]]);
                else if (sortedHeadersKeys[i] == "Date")
                    request.Date = Convert.ToDateTime(headParams[sortedHeadersKeys[i]]);
                else if (sortedHeadersKeys[i] == "Content-Type")
                {
                    request.ContentType = headParams[sortedHeadersKeys[i]].ToString();
                    request.MediaType = headParams[sortedHeadersKeys[i]].ToString();

                }
                else
                    request.Headers.Add(sortedHeadersKeys[i], headParams[sortedHeadersKeys[i]].ToString());
            }
      
            if (!headParams.ContainsKey(QSConstant.PARAM_KEY_USER_AGENT)) 
            {
                request.UserAgent = QSStringUtil.getUserAgent();
                //request.Headers.Add(QSConstant.PARAM_KEY_USER_AGENT, QSStringUtil.getUserAgent());
            }
            if (bodyContent != null && bodyContent.Count > 0) 
            {

                if(headParams.ContainsKey(QSConstant.HEADER_PARAM_KEY_CONTENTTYPE))
                {
                    string contentType = headParams[QSConstant.HEADER_PARAM_KEY_CONTENTTYPE].ToString();
                    request.ContentType = contentType;
                }
                    

                Dictionary<object,object>.Enumerator iterator = bodyContent.GetEnumerator();
                int contentLength = Convert.ToInt32(headParams[QSConstant.PARAM_KEY_CONTENT_LENGTH]);
                int partNumber = Convert.ToInt32(queryParams[QSConstant.PARAM_KEY_PART_NUMBER]);

                for(int i=0;i<bodyContent.Count;i++) 
                {
                    iterator.MoveNext();
                    string key = (string) iterator.Current.Key;
                    object bodyObj = bodyContent[key];
                    //Stream outstream = request.GetRequestStream();  
                    Encoding encoding = System.Text.Encoding.GetEncoding("UTF-8");
                    byte[] data = null;
                    if (bodyObj is string) 
                    {
                        //request.MediaType = contentType;
                        Stream outstream = request.GetRequestStream();  
                        data = new byte[((String)bodyObj).Length];
                        data = encoding.GetBytes(bodyObj.ToString());  
                        outstream.Write(data,0,data.Length);
                        outstream.Close();
                    } 
                    else if (bodyObj is FileStream) 
                    {
                        FileStream fs = (FileStream)bodyObj;
                        data = new byte[4*1024*1024];
                        //request.Headers.Add(";filename=\""+fs.Name+"\"\r\n");
                        //request.MediaType = contentType;
                        try 
                        {
                            //
                            //fs.Seek(contentLength * partNumber,0);    
                            long contentLeft = ((FileStream)bodyObj).Length - contentLength * (partNumber+1);
                            long readContentLength =  contentLength;
                            if(contentLeft < 0)
                            {
                                readContentLength +=contentLeft;
                                readContentLength = readContentLength > 0 ? readContentLength : 0;
                            }
                            request.ContentLength = readContentLength;
                            Stream outstream = request.GetRequestStream();  
                            fs.Read(data, contentLength * partNumber, (int)readContentLength);
                            outstream.Write(data,0,(int)readContentLength);
                            outstream.Close();
                            //request.ContentType = contentType;
                        } 
                        catch (IOException e) 
                        {
                            throw new Exception(e.Message);
                        }
                    } 
                    else if (bodyObj is Stream) 
                    {
                        Stream stream = (Stream)bodyObj;
                        //request.MediaType = contentType;
                        Stream outstream = request.GetRequestStream();  
                        data= new byte[stream.Length];
                        stream.Read(data,0,data.Length);
                        stream.Close();
                        outstream.Write(data,0,data.Length);
                        outstream.Close();
                    }
                    //request.Method = method;
                    //request = (HttpWebRequest)HttpWebRequest.Create(signedUrl);
            //connection.getOutputStream().write(bodyContent.getBytes()); 
                    else 
                    {
                        string jsonStr = QSStringUtil.objectToJson(key, bodyObj);
                        //request.ContentType = contentType;
                        //request.MediaType = contentType;
                        data = new byte[jsonStr.Length];
                        data = encoding.GetBytes(jsonStr);
                        //request.ContentType = contentType;
                        Stream outstream = request.GetRequestStream();  
                        outstream.Write(data,0,data.Length);
                        outstream.Close();
                    }
                    
                }
            //connection.getOutputStream().write(bodyContent.getBytes());
                
            }
            //request = 
            return request;
        }

        /*private static class MulitFileuploadBody extends RequestBody {

        private String contentType;

        private int contentLength;

        private RandomAccessFile file;

        public MulitFileuploadBody(String contentType, RandomAccessFile rFile, int contentLength) {
            this.contentLength = contentLength;
            this.contentType = contentType;
            this.file = rFile;
        }

        @Override
        public long contentLength() throws IOException {
            return this.contentLength;
        }

        @Override
        public MediaType contentType() {
            return MediaType.parse(this.contentType);
        }

        @Override
        public void writeTo(BufferedSink sink) throws IOException {

            int readSize = 1024;
            int bytes = 0;
            byte[] bufferOut = new byte[readSize];
            int count = contentLength / readSize;
            int leftCount = contentLength % readSize;
            while (count > 0 && (bytes = file.read(bufferOut)) != -1) {
                sink.write(bufferOut, 0, bytes);
                count--;
            }
            if (count >= 0 && leftCount > 0) {
                bufferOut = new byte[leftCount];
                if ((bytes = file.read(bufferOut)) != -1) {
                    sink.write(bufferOut, 0, bytes);
                }
            }

            Util.closeQuietly(file);
        }
    }

    private static class InputStreamUploadBody extends RequestBody {

        private String contentType;

        private int contentLength;

        private InputStream file;

        public InputStreamUploadBody(String contentType, InputStream rFile, int contentLength) {
            this.contentLength = contentLength;
            this.contentType = contentType;
            this.file = rFile;
        }

        @Override
        public long contentLength() throws IOException {
            return this.contentLength;
        }

        @Override
        public MediaType contentType() {
            return MediaType.parse(this.contentType);
        }

        @Override
        public void writeTo(BufferedSink sink) throws IOException {

            int readSize = 1024;
            int bytes = 0;
            byte[] bufferOut = new byte[readSize];
            int count = contentLength / readSize;
            int leftCount = contentLength % readSize;
            while (count > 0 && (bytes = file.read(bufferOut)) != -1) {
                sink.write(bufferOut, 0, bytes);
                count--;
            }
            if (count == 0 && leftCount > 0) {
                bufferOut = new byte[leftCount];
                if ((bytes = file.read(bufferOut)) != -1) {
                    sink.write(bufferOut, 0, bytes);
                }
            }

            Util.closeQuietly(file);
        }
    }*/

    
    }
}
