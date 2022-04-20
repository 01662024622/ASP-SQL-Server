using System;

namespace abahaBravo.Util
{
    public class JsonUtil
    {
        public static string GetParam(String data, String param, bool type = true)
        {
            if (type)
            {
                int from = data.IndexOf("\"" + param + "\":", StringComparison.Ordinal) + 3 + param.Length;
                if (from - param.Length < 3)
                {
                    return "";
                }
                int to = data.IndexOf(",\"", from, StringComparison.Ordinal);
                return data.Substring(from, to - from);
            }
            else
            {
                int from = data.IndexOf("\"" + param + "\":\"", StringComparison.Ordinal) + 4 + param.Length;
                if (from - param.Length < 4)
                {
                    return "";
                }
                int to = data.IndexOf("\",\"", from, StringComparison.Ordinal);
                return data.Substring(from, to - from);
            }
        }
    }
}