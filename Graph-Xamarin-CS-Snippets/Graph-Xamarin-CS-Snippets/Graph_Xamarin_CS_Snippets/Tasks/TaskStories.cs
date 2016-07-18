//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// NOTE: All task snippets work only with admin work accounts.


namespace Graph_Xamarin_CS_Snippets
{
    class TaskStories
    {

        private static readonly string STORY_DATA_IDENTIFIER = Guid.NewGuid().ToString();

        public static async Task<bool> TryGetTaskChecklistAsync()
        {
            var taskChecklist = await TaskSnippets.GetTaskChecklistAsync("H-yUKvNckEGazVXI5LnPHmQAN_d8");
            return taskChecklist != null;
        }
        
    }
}

