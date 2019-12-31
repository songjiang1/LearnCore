//=====================================================================================
// All Rights Reserved , Copyright © sys 2013
//=====================================================================================

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Learn.Util
{
    /// <summary>
    /// MD5加密帮助类
    /// 版本：2.0
    /// <author>
    ///		<name>shecixiong</name>
    ///		<date>2013.09.27</date>
    /// </author>
    /// </summary>
    public class Md5Helper
    {
        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string MD5(string str, int code=32)
        { 
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                sb.Append(i.ToString("x2"));
            }
            if (code == 16)
            {
                return sb.ToString().Substring(8, 16).ToLower();
            }
            else
            {
                return sb.ToString().ToLower();
            } 
        }
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
        }
        public static bool IsSafeSqlParam(string value)
        {
            return !Regex.IsMatch(value, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }
        #endregion
    }
}
