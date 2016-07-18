//Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
//See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Windows.Storage;


// NOTE: All groups snippets work only with admin work accounts.


namespace Graph_Xamarin_CS_Snippets
{
    class PlanStories
    {
        public static async Task<bool> TryGetPlanBucketsAsyncAsync()
        {
            var planBuckets = await PlanSnippets.GetPlanBucketsAsync("7LfmI3ic1kCFTLNjZX246GQABAV1");
            return planBuckets != null;
        }

       
    }
}

