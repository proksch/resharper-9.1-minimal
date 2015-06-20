/*
 * Copyright 2015 Sebastian Proksch
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Example.Completion;
using Example.Helper;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems;
using JetBrains.ReSharper.Feature.Services.CSharp.CodeCompletion.Infrastructure;
using JetBrains.ReSharper.Features.Intellisense.CodeCompletion.CSharp.Rules;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;

namespace Example.Tests.TestUtils
{
    /// <summary>
    ///     Should only be loaded in test mode
    /// </summary>
    [Language(typeof (CSharpLanguage))]
    internal class TestCompletion : CSharpItemsProviderBasic
    {
        private readonly ContextAnalysis _contextAnalysis;

        public TestCompletion(IHelper helper, SharedComponent sc)
        {
            _contextAnalysis = new ContextAnalysis(helper, sc);
        }

        protected override bool IsAvailable(CSharpCodeCompletionContext context)
        {
            return true;
        }

        protected override bool AddLookupItems(CSharpCodeCompletionContext context, GroupedItemsCollector collector)
        {
            _contextAnalysis.Analyze(context);
            return base.AddLookupItems(context, collector);
        }
    }
}