//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Graph;
using System.Reflection;
using System.Linq;

// NOTE: All task snippets work only with admin work accounts.


namespace Graph_Xamarin_CS_Snippets
{
    class TaskSnippets
    {
        private static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        // Returns the checklist in a task.
        public static async Task<ChecklistItemCollection> GetTaskChecklistAsync(string taskId)
        {
            ChecklistItemCollection taskChecklist = null;
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();
            try
            {
                var taskDetails = await graphClient.Tasks[taskId].Details.Request().GetAsync();
                taskChecklist = taskDetails.Checklist;

                foreach(var ch in taskChecklist.AdditionalData)
                {
                    var checklist = ch.Value as Newtonsoft.Json.Linq.JObject;
                    ChecklistItem checklistItem = new ChecklistItem();
                    checklistItem.IsChecked =(bool) (checklist["isChecked"] as Newtonsoft.Json.Linq.JValue).Value;
                    checklistItem.Title = (checklist["title"] as Newtonsoft.Json.Linq.JValue).Value.ToString();
                    checklistItem.OrderHint = (checklist["orderHint"] as Newtonsoft.Json.Linq.JValue).Value.ToString();
                    checklistItem.LastModifiedBy = (checklist["lastModifiedBy"] as Newtonsoft.Json.Linq.JValue).Value.ToString();
                    DateTime dt;

                    // TODO: Fix the parser
                    if(DateTime.TryParse((checklist["lastModifiedBy"] as Newtonsoft.Json.Linq.JValue).Value.ToString(), out dt))
                    {
                        checklistItem.LastModifiedDateTime = dt;
                    }
                                      
                    Debug.WriteLine("key: " + ch.Key + "\t value:" + checklistItem.Title);
                }
            }


            catch (ServiceException e)
            {
                Debug.WriteLine("We could not get the specified task checklist: " + e.Error.Message);
                return null;

            }

            return taskChecklist;
        }        
    }
}

