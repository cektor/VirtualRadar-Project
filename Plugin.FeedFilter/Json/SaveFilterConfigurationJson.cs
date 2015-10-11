﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualRadar.Plugin.FeedFilter.Json
{
    /// <summary>
    /// The JSON that is returned after a filter configuration has been saved.
    /// </summary>
    class SaveFilterConfigurationJson : FilterConfigurationJson
    {
        /// <summary>
        /// Gets or sets a value indicating that the data could not be saved because it is stale.
        /// </summary>
        public bool WasStaleData { get; set; }

        /// <summary>
        /// Gets a list of prohibited ICAOs that were invalid and therefore not saved.
        /// </summary>
        public List<string> InvalidProhibitedIcaos { get; private set; }

        /// <summary>
        /// Gets a list of prohibited ICAOs that were duplicated. Duplicates are removed before saving.
        /// </summary>
        public List<string> DuplicateProhibitedIcaos { get; private set; }

        /// <summary>
        /// Creates a new object.
        /// </summary>
        public SaveFilterConfigurationJson()
        {
            InvalidProhibitedIcaos = new List<string>();
            DuplicateProhibitedIcaos = new List<string>();
        }
    }
}
