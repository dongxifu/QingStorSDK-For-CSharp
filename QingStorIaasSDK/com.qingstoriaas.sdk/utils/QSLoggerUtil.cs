using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using log4net;
using QingStorIaasSDK.com.qingstor.sdk.constants;

namespace QingStorIaasSDK.com.qingstor.sdk.utils
{
    class QSLoggerUtil
    {
        
         public static  ILog setLoggerHanlder(string loggerName)
         {
            ILog logger = LogManager.GetLogger(loggerName);
            if (QSConstant.LOGGER_LEVEL.Equals(QSConstant.LOGGER_ERROR)) 
            {
                logger.Error("Error");   
            } 
            else if (QSConstant.LOGGER_LEVEL.Equals(QSConstant.LOGGER_WARNNING)) 
            {
                logger.Warn("Warning");
            } 
            else if (QSConstant.LOGGER_LEVEL.Equals(QSConstant.LOGGER_INFO)) 
            {
                logger.Info("Info");
            }
            else if (QSConstant.LOGGER_LEVEL.Equals(QSConstant.LOGGER_DEBUG)) 
            {
                logger.Debug("Debug");
            }
            else if (QSConstant.LOGGER_LEVEL.Equals(QSConstant.LOGGER_FATAL)) 
            {
                logger.Fatal("Fatal");
            } 
            else 
            {
                logger.Warn("Warning");
            }
            return logger;
        }
    }
}
