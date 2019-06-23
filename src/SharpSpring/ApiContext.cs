using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SharpSpring
{
    public class ApiContext : IGet
    {
        private ApiContextGet apiContextGet;
        private string accountId = "";
        private string secretKey = "";
        private string baseUrl = "http://api.sharpspring.com/pubapi/v1.2/?";

        public ApiContext(string connStrName = "SharpSpring")
        {
            ParseConnectionString(connStrName);
            if (string.IsNullOrEmpty(accountId) || string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(baseUrl)) throw new Exception("Invalid SharpSpring connection string");

            apiContextGet = new ApiContextGet(this);
        }

        private void ParseConnectionString(string connStrName)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connStrName].ConnectionString;
            string[] split1 = connStr.Split(';');
            foreach(string s in split1)
            {
                string[] split2 = s.Split('=');
                switch (split2[0].ToLower())
                {
                    case "baseurl":
                        baseUrl = split2[1];
                        break;
                    case "accountid":
                        accountId = split2[1];
                        break;
                    case "secretkey":
                        secretKey = split2[1];
                        break;
                }
            }
        }

        public IGetEntity Get()
        {
            return apiContextGet;
        }

        private string BaseApiUrl
        {
            get
            {
                return $"{baseUrl}?accountID={accountId}&secretKey={secretKey}";
            }
        }

        internal string ExecuteGetCommand(string command, int limit, int offset, params string[] parameters)
        {
            string requestId = "";// Guid.NewGuid().ToString();
            dynamic p = new
            {
                where = parameters,
                limit = 500,
                offset = offset
            };
            dynamic data = new
            {
                method = command,
                @params = p,
                id = requestId
            };

            WebRequest wr = WebRequest.Create(BaseApiUrl);
            wr.Method = "POST";
            wr.ContentType = "application/json";
            string json = JsonConvert.SerializeObject(data);
            using (Stream str = wr.GetRequestStream())
            {
                using (StreamWriter sw = new StreamWriter(str))
                {
                    sw.Write(json);
                }
            }
            using (WebResponse wr2 = wr.GetResponse())
            {
                using (Stream str2 = wr2.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(str2))
                    {
                        string ret = sr.ReadToEnd();
                        return ret;
                    }
                }
            }
        }
    }

    internal class ApiContextGet: IGetEntity
    {
        ApiContext context;

        internal ApiContextGet(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<IAccount> Accounts(int id = 0, int ownerId = 0, int limit = int.MaxValue, int offset = 0)
        {
            return Get<Account>("getAccounts", "account", limit, offset);
        }

        public IEnumerable<ILead> Leads(int id = 0, int ownerId = 0, int limit = int.MaxValue, int offset = 0)
        {
            return Get<Lead>("getLeads", "lead", limit, offset);
        }

        private IEnumerable<T> Get<T>(string command, string node, int limit, int offset)
        {
            string response = context.ExecuteGetCommand(command, limit, offset);
            JObject o = JObject.Parse(response);
            string error = o.SelectToken("error").ToString();
            if (!string.IsNullOrEmpty(error)) throw new Exception(error);
            JToken data = o.SelectToken("result").SelectToken(node);
            IEnumerable<T> ret = data.ToObject<IEnumerable<T>>();
            return ret;
        }
    }
}
