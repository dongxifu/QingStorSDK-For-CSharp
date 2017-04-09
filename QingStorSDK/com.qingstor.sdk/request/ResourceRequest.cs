using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QingStorSDK.com.qingstor.sdk.exception;
using QingStorSDK.com.qingstor.sdk.model;

namespace QingStorSDK.com.qingstor.sdk.request
{
    interface ResourceRequest
    {
         void sendApiRequestAsync(Dictionary<object,object> context, RequestInputModel paramBean, ResponseCallBack callback);

    /**
     * @param context
     * @param paramBean
     * @param outputClass
     * @throws QSException
     */
        OutputModel sendApiRequest(Dictionary<object,object> context, RequestInputModel paramBean, Type outputClass);

    /**
     * @param requestUrl
     * @param context
     * @param callback
     * @throws QSException
     */
        void sendApiRequestAsync(String requestUrl, Dictionary<object,object> context, ResponseCallBack callback);

    /**
     * @param requestUrl
     * @param context
     * @param outputClass
     * @return
     * @throws QSException
     */
        OutputModel sendApiRequest(string requestUrl,Dictionary<object,object> context,Type outputClass);
    }
}
