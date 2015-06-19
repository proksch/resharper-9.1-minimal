using Example.Completion;
using Example.Helper;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems.Impl;
using JetBrains.ReSharper.Feature.Services.CSharp.CodeCompletion.Infrastructure;
using JetBrains.ReSharper.Features.Intellisense.CodeCompletion.CSharp.Rules;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;

namespace Example.Tests.Completion
{
    [Language(typeof (CSharpLanguage))]
    internal class TestCompletion : CSharpItemsProviderBasic
    {
        private readonly IHelper _helper;

        public TestCompletion(IHelper helper)
        {
            _helper = helper;
        }

        protected override bool IsAvailable(CSharpCodeCompletionContext context)
        {
            new ContextAnalysis(_helper).Analyze(context);
            return true;
        }

        protected override bool AddLookupItems(CSharpCodeCompletionContext context, GroupedItemsCollector collector)
        {
            var item = new TextLookupItem("hello");
            collector.Add(item);
            return base.AddLookupItems(context, collector);
        }
    }
}