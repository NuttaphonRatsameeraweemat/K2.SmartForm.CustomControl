using LP.CustomControl.Helper.Models;
using SourceCode.Hosting.Client.BaseAPI;
using SourceCode.SmartObjects.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LP.CustomControl.Helper
{
    public class SmartObjectControl
    {

        #region [Fields]

        /// <summary>
        /// The K2 url server.
        /// </summary>
        public const string K2_SERVER = "localhost";
        /// <summary>
        /// The K2 management and smart object port.
        /// </summary>
        public const int K2_PORT = 5555;

        #endregion

        #region [Methods]

        /// <summary>
        /// Get Data From Smart Object.
        /// </summary>
        /// <param name="smartObjectName">The Smart Object Name.</param>
        /// <param name="executeMethodName">The Execute Method Name.</param>
        /// <returns></returns>
        public Dictionary<string, string> GetSmartObject(string smartObjectName, string executeMethodName)
        {
            var result = new Dictionary<string, string>();
            var soServer = GetServer();
            using (soServer.Connection)
            {
                var workflowSmartObject = WorkflowSmartObject(soServer, smartObjectName, executeMethodName);

                var smartObject = soServer.ExecuteList(workflowSmartObject);
                result = this.ConvertToDictionary(smartObject.SmartObjectsList);
            }
            return result;
        }

        /// <summary>
        /// Convert SmartObjectCollection to Dictionary Class.
        /// </summary>
        /// <param name="smItem">The SmartObjectCollection List.</param>
        /// <returns></returns>
        private Dictionary<string,string> ConvertToDictionary(SmartObjectCollection smItem)
        {
            var result = new Dictionary<string, string>();
            foreach (SmartObject item in smItem)
            {
                foreach (SmartProperty property in item.Properties)
                {

                }
            }
            return result;
        }

        /// <summary>
        /// Declare SmartObject and ExecuteMethod Name.
        /// </summary>
        /// <param name="soServer">The SmartObjectClientServer.</param>
        /// <param name="smartObjectName">The Smart Object Name.</param>
        /// <param name="executeMethodName">The Execute Method Name.</param>
        /// <returns></returns>
        private SmartObject WorkflowSmartObject(SmartObjectClientServer soServer, string smartObjectName, string executeMethodName)
        {
            var result = soServer.GetSmartObject(smartObjectName);
            result.MethodToExecute = executeMethodName;
            return result;
        }

        /// <summary>
        /// Get Connection String Connect to K2.
        /// </summary>
        /// <returns>The connection string.</returns>
        private string GetConnectionString()
        {
            var hostServerConnectionString = new SCConnectionStringBuilder
            {
                Host = K2_SERVER,
                Port = K2_PORT,
                IsPrimaryLogin = true,
                Integrated = true
            };
            return hostServerConnectionString.ToString();
        }

        /// <summary>
        /// Create Connection to K2 Server.
        /// </summary>
        /// <returns></returns>
        private SmartObjectClientServer GetServer()
        {
            var soServer = new SmartObjectClientServer();
            soServer.CreateConnection();
            soServer.Connection.Open(this.GetConnectionString());
            return soServer;
        }

        #endregion

    }
}
