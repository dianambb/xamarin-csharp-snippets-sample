//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Graph;
using System.Linq;

// NOTE: All plan snippets work only with admin work accounts.


namespace Graph_Xamarin_CS_Snippets
{
    class PlanSnippets
    {   
        // Returns the checklist in a task.
        public static async Task<List<Bucket>> GetPlanBucketsAsync(string planId)
        {
            List<Bucket> planBuckets = null;
            var graphClient = AuthenticationHelper.GetAuthenticatedClient();
            try
            {
                var planBucketresult = await graphClient.Plans[planId].Buckets.Request().GetAsync();
                
                planBuckets = planBucketresult.ToList();

                foreach (Bucket bucket in planBuckets)
                {
                    Debug.WriteLine("Bucket: " + bucket.Name);
                }
            }


            catch (ServiceException e)
            {
                Debug.WriteLine("We could not get the specified task checklist: " + e.Error.Message);
                return null;

            }

            return planBuckets;
        }        
    }
}

