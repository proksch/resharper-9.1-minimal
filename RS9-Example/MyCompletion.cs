using System.IO;
using JetBrains.Application;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems.Impl;
using JetBrains.ReSharper.Feature.Services.CSharp.CodeCompletion.Infrastructure;
using JetBrains.ReSharper.Features.Intellisense.CodeCompletion.CSharp.Rules;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;

namespace RS9_Example
{
    [Language(typeof (CSharpLanguage))]
    internal class MyCompletion : CSharpItemsProviderBasic
    {
        protected override bool IsAvailable(CSharpCodeCompletionContext context)
        {
            return true;
        }

        protected override bool AddLookupItems(CSharpCodeCompletionContext context, GroupedItemsCollector collector)
        {
            var item = new TextLookupItem("hello");
            collector.Add(item);
            return base.AddLookupItems(context, collector);
        }
    }

    [ShellComponent]
    internal class MyComponent
    {
        public MyComponent()
        {
            // trying to figure out, when/if this is loaded
            File.WriteAllText(@"C:\Users\seb\MyComponent_ctor.txt", "it works");
        }
    }
}