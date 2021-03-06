﻿using log4net;
using System;
using System.Web;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Game.Web.Helper
{
    public class Log4Net
    {
        /// <summary>
        /// 日志操作对象
        /// </summary>
        private static ILog Log => LogManager.GetLogger("LogInfo");

        /// <summary>
        /// 写入信息日志
        /// </summary>
        /// <param name="message">信息内容</param>
        public static void WriteInfoLog(string message)
        {
            HttpRequest req = HttpContext.Current.Request;
            message = $"[{req.UserHostAddress}] [{req.Url.AbsoluteUri}] \t\r\n[消息]：{message}";
            Log.Info(message);
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="ex">错误异常</param>
        public static void WriteErrorLog(Exception ex)
        {
            HttpRequest req = HttpContext.Current.Request;
            string message = $"[{req.UserHostAddress}] [{req.Url.AbsoluteUri}] \t\r\n[当前堆栈]：{ex.StackTrace}\r\n[错误]：{ex.Message}";
            Log.Error(message);
        }
    }
}