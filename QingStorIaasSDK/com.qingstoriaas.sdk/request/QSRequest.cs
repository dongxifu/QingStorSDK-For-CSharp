using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using log4net;
using System.Security.Cryptography;
using System.IO;
using System.Web;

using QingStorIaasSDK.com.qingstor.sdk.config;
using QingStorIaasSDK.com.qingstor.sdk.constants;
using QingStorIaasSDK.com.qingstor.sdk.exception;
using QingStorIaasSDK.com.qingstor.sdk.model;
using QingStorIaasSDK.com.qingstor.sdk.utils;
using QingStorIaasSDK.com.qingstor.sdk.request;

namespace QingStorIaasSDK.com.qingstor.sdk.request
{
    class QSRequest:ResourceRequest
    {
        private static ILog logger = QSLoggerUtil.setLoggerHanlder(typeof(QSRequest).Name);

        private static string REQUEST_PREFIX = "/";

        public void sendApiRequestAsync(
            Dictionary<object,object> context, RequestInputModel paramBean, ResponseCallBack callback)
        {
            string validate = paramBean != null ? paramBean.validateParam() : "";
            EvnContext evnContext = (EvnContext) context[QSConstant.EVN_CONTEXT_KEY];
            string evnValidate = evnContext.validateParam();
            if (!QSStringUtil.isEmpty(validate) || !QSStringUtil.isEmpty(evnValidate)) 
            {
                if (QSStringUtil.isEmpty(validate)) 
                {
                    validate = evnValidate;
                }
                OutputModel Out = QSParamInvokeUtil.getOutputModel(callback);
                QSHttpRequestClient.fillResponseCallbackModel(QSConstant.REQUEST_ERROR_CODE, validate, Out);
                callback.onAPIResponse(Out);
            } 
            else 
            {
                HttpWebRequest request = buildRequest(context, paramBean);
            QSHttpRequestClient.getInstance()
                    .requestActionAsync(request, evnContext.isSafeOkHttp(), callback);
            }
        }
        private byte[] GetBodyFile(String FilePath)
        {
            try
            {
                //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(signedUrl);
                FileStream fs = File.OpenRead(FilePath);
                //String Name=FilePath.Substring(FilePath.LastIndexOf("\\")+1,FilePath.Length-FilePath.LastIndexOf("\\")-1); //D:\1\2.EXE
                //request.Headers.Add(";filename=\"" + Name + "\"\r\n");
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, data.Length);
                fs.Close();

                //Stream outstream = request.GetRequestStream();
                //outstream.Write(data, 0, data.Length);
                //outstream.Close();
                return data;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return null;
        }
        private HttpWebRequest buildRequest(Dictionary<object,object> context, RequestInputModel Params)
        {
            EvnContext evnContext = (EvnContext) context[QSConstant.EVN_CONTEXT_KEY];
            string zone = (string) context[QSConstant.PARAM_KEY_REQUEST_ZONE];

            Dictionary<object,object> paramsQuery = QSParamInvokeUtil.getRequestParams(Params, QSConstant.PARAM_TYPE_QUERY);
            Dictionary<object, object> paramsBody = QSParamInvokeUtil.getRequestParams(Params, QSConstant.PARAM_TYPE_BODY);
            Dictionary<object, object> paramsHeaders = QSParamInvokeUtil.getRequestParams(Params, QSConstant.PARAM_TYPE_HEADER);

            paramsHeaders.Add("action", context["action"]);
            paramsHeaders.Add("zone", zone);

            if (context.ContainsKey(QSConstant.PARAM_KEY_USER_AGENT))
            {
                paramsHeaders.Add(QSConstant.PARAM_KEY_USER_AGENT, context[QSConstant.PARAM_KEY_USER_AGENT]);
            }

            String requestApi = (String)context[QSConstant.PARAM_KEY_REQUEST_APINAME];
            //string FileBody = GetBodyFile(context[QSConstant.PARAM_KEY_OBJECT_NAME].ToString()).ToString();
            paramsHeaders = initHeadContentMd5(requestApi, paramsBody, paramsHeaders);

            string method = (string) context[QSConstant.PARAM_KEY_REQUEST_METHOD];
            string bucketName = "";
            string requestPath = evnContext.getHost() +evnContext.getUri();

            string objectName = "";
            if(context.ContainsKey(QSConstant.PARAM_KEY_OBJECT_NAME))
                objectName = context[QSConstant.PARAM_KEY_OBJECT_NAME].ToString();
            /*if (!paramsHeaders.ContainsKey(QSConstant.HEADER_PARAM_KEY_CONTENTTYPE))
                paramsHeaders.Add(QSConstant.HEADER_PARAM_KEY_CONTENTTYPE,MimeMapping.GetMimeMapping(objectName));*/

            if (context.ContainsKey(QSConstant.PARAM_KEY_OBJECT_NAME)) 
            {
                //requestPath = requestPath.Replace(QSConstant.BUCKET_NAME_REPLACE, bucketName);
                requestPath = requestPath.Replace(QSConstant.OBJECT_NAME_REPLACE, QSStringUtil.urlCharactersEncoding(objectName));
            }


            string singedUrl =
                QSSignatureUtil.getURL(
                        evnContext.getAccessKey(),
                        evnContext.getAccessSecret(),
                        method,
                        requestPath,
                        paramsQuery,
                        paramsHeaders);
            singedUrl = evnContext.getProtocol() + "://" + singedUrl;
            //string requestSuffixPath = getRequestSuffixPath((string) context[QSConstant.PARAM_KEY_REQUEST_PATH], bucketName, objectName);
            /*paramsHeaders.Add("Authorization", authSign);
            logger.Info(authSign);
            string singedUrl =
                getSignedUrl(
                        evnContext.getRequestUrl(),
                        zone,
                        bucketName,
                        paramsQuery,
                        (string)context[QSConstant.PARAM_KEY_REQUEST_PATH]);*/
           
            logger.Info(singedUrl);
            if (QSConstant.PARAM_KEY_REQUEST_API_MULTIPART.Equals(requestApi)) 
            {
                HttpWebRequest request =
                    QSHttpRequestClient.getInstance()
                            .buildStorMultiUpload(
                                    method, paramsBody, singedUrl, paramsHeaders, paramsQuery);
                return request;

            } 
            else 
            {
                //System.Console.WriteLine(singedUrl);
                HttpWebRequest request =
                    QSHttpRequestClient.getInstance()
                            .buildStorRequest(method, paramsBody, singedUrl, paramsHeaders);
                return request;
            }
        }
        private string getRequestSuffixPath(string requestPath, string bucketName, string objectName)
        {
            if (QSStringUtil.isEmpty(bucketName)) 
            {
                return REQUEST_PREFIX;
            }
            
            String suffixPath = requestPath.Replace(REQUEST_PREFIX + QSConstant.BUCKET_NAME_REPLACE, "").Replace(REQUEST_PREFIX + QSConstant.OBJECT_NAME_REPLACE, "");
            if (QSStringUtil.isEmpty(objectName))
            {
                objectName = "";
            }
            else
            {
                objectName = QSStringUtil.urlCharactersEncoding(objectName);
            }
            return (REQUEST_PREFIX + objectName + suffixPath);
        }
        private Dictionary<object, object> initHeadContentMd5(String requestApi, Dictionary<object, object> paramsBody, Dictionary<object, object> paramsHead) 
        {
            if (QSConstant.PARAM_KEY_REQUEST_API_DELETE_MULTIPART.Equals(requestApi))
            {
                if (paramsBody.Count > 0)
                {
                    Object bodyContent=null;
                    if(paramsBody.ContainsKey("BodyInputFileStream"))
                    {
                        FileStream fs = (FileStream)paramsBody["BodyInputFileStream"];
                        StreamReader sr = new StreamReader(fs);
                        bodyContent = sr.ReadToEnd();
                    }
                    else
                        bodyContent = QSHttpRequestClient.getInstance().getBodyContent(paramsBody);
                    try
                    {
                        MD5 md5 = new MD5CryptoServiceProvider();
                        byte[] output = md5.ComputeHash(Encoding.Default.GetBytes(bodyContent.ToString()));
                        string contentMD5 = System.Text.Encoding.Default.GetString(output);
                        paramsHead.Add(QSConstant.PARAM_KEY_CONTENT_MD5, contentMD5);
                      
                    }
                    catch (Exception e)
                    {
                        throw new QSException(e.Message);
                    }


                }
            }
            
            return paramsHead;
             
        }
         private static string getSignedUrl(
            string serviceUrl,
            string zone,
            string bucketName,
            Dictionary<object,object> paramsQuery,
            string requestSuffixPath)
        {
            if ("".Equals(bucketName) || bucketName == null) 
            {
                return QSSignatureUtil.generateQSURL(paramsQuery, serviceUrl + requestSuffixPath);
            } 
            else 
            {
                string storRequestUrl = serviceUrl.Replace("://", "://" + zone + ".");
                return QSSignatureUtil.generateQSURL(
                    paramsQuery, storRequestUrl.Replace("://","://"+bucketName+".") + requestSuffixPath);
            }
        }
        public void sendApiRequestAsync(String requestUrl, Dictionary<object,object> context, ResponseCallBack callback)
        {
            EvnContext evnContext = (EvnContext) context[QSConstant.EVN_CONTEXT_KEY];
            HttpWebRequest request = QSHttpRequestClient.getInstance().buildUrlRequest(requestUrl);
            QSHttpRequestClient.getInstance().requestActionAsync(request, evnContext.isSafeOkHttp(), callback);
        }

        public OutputModel sendApiRequest(
            string requestUrl, Dictionary<object,object> context, Type outputClass)
        {
            EvnContext evnContext = (EvnContext) context[QSConstant.EVN_CONTEXT_KEY];
            HttpWebRequest request = QSHttpRequestClient.getInstance().buildUrlRequest(requestUrl);
            return QSHttpRequestClient.getInstance()
                .requestAction(request, evnContext.isSafeOkHttp(), outputClass);
        }

  
        public OutputModel sendApiRequest(Dictionary<object,object> context, RequestInputModel paramBean, Type outputClass)
        {
            string validate = paramBean != null ? paramBean.validateParam() : "";
            EvnContext evnContext = (EvnContext) context[QSConstant.EVN_CONTEXT_KEY];
            string evnValidate = evnContext.validateParam();
            if (!QSStringUtil.isEmpty(validate) || !QSStringUtil.isEmpty(evnValidate)) 
            {
                if (QSStringUtil.isEmpty(validate)) 
                {
                    validate = evnValidate;
                }
                try 
                {
                    OutputModel model = (OutputModel)Activator.CreateInstance(outputClass);
                    QSHttpRequestClient.fillResponseCallbackModel(QSConstant.REQUEST_ERROR_CODE, validate, model);
                    return model;
                } 
                catch (Exception e) 
                {
                    logger.Fatal(e.Message);
                    throw new QSException(e.Message);
                }
            } 
            else 
            {
                HttpWebRequest request = buildRequest(context, paramBean);
                return QSHttpRequestClient.getInstance().requestAction(request, evnContext.isSafeOkHttp(), outputClass);
            }
        }

    }
}
