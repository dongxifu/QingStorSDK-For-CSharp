using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingStorSDK.com.qingstor.sdk.exception
{
    class QSException : Exception
    {
        private static   long serialVersionUID = -5562309362764717920L;

        private string serviceName;

        private int errorCode;

        private string errorMessage;

        public QSException(int errorcode,string message)
        {
            this.errorCode=errorcode;
            this.errorMessage = message;
        }

        public QSException(string message) 
        {
            this.errorMessage = message;
        }

        public string getServiceName() 
        {
            return serviceName;
        }

        public void setServiceName(string serviceName) 
        {
            this.serviceName = serviceName;
        }

        public int getErrorCode() 
        {
            return errorCode;
        }

        public void setErrorCode(int errorCode) 
        {
            this.errorCode = errorCode;
        }

        public string getErrorMessage() 
        {
            return errorMessage;
        }

        public void setErrorMessage(string errorMessage) 
        {
            this.errorMessage = errorMessage;
        }
	    public string getMessage() 
        {
            return "Error Code:"+this.errorCode+"; Error Message:"+this.errorMessage;
	    }
    }
}
