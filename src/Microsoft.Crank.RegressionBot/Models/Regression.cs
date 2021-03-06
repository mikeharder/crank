﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Crank.RegressionBot.Models
{
    public class Regression
    {
        // The result before the one that is considered a regression
        public BenchmarksResult PreviousResult { get; set; }
        
        // The first result that is considered a regression
        public BenchmarksResult CurrentResult { get; set; }

        public double Change { get; set; }
        
        public double StandardDeviation { get; set; }
        
        public double Average { get; set; }

        // Whether the regression is now fixed
        [MessagePack.IgnoreMember]
        public bool HasRecovered => RecoveredResult != null;

        // The result when the benchmark recovered
        public BenchmarksResult RecoveredResult { get; set; }

        /// <summary>
        /// Gets a string representing this regression.
        /// Used to determine if two regressions are similar.
        /// </summary>
        public string Identifier => $"Id:{CurrentResult.Scenario}{CurrentResult.Description}{CurrentResult.DateTimeUtc}";

        public HashSet<string> Labels { get; set; } = new HashSet<string>();
        public HashSet<string> Owners { get; set; } = new HashSet<string>();
    }
}
