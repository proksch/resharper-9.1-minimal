using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Application.Settings;
using JetBrains.ReSharper.Feature.Services.CodeCompletion;
using JetBrains.ReSharper.Feature.Services.CodeCompletion.Infrastructure.LookupItems;
using JetBrains.ReSharper.Feature.Services.Lookup;
using JetBrains.ReSharper.FeaturesTestFramework.Completion;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TextControl;

namespace Example.Tests
{
    [TestNetFramework4]
    internal abstract class BaseCodeCompletionTest : CodeCompletionTestBase
    {
        protected List<ILookupItem> LookupItems;

        protected override string RelativeTestDataPath
        {
            get { return ""; }
        }

        protected void DoAutoCompletion(string content)
        {
            var testFile = Path.Combine(BaseTestDataPath.FullPath, "adhoc_snippet.cs");

            File.WriteAllText(testFile, content);

            DoOneTest("adhoc_snippet");
        }

        protected override void ExecuteCodeCompletion(Suffix suffix,
            ITextControl textControl,
            IntellisenseManager intellisenseManager,
            bool automatic,
            string documentText,
            IContextBoundSettingsStore settingsStore)
        {
            var single = CodeCompletionParameters.CreateSingle(CodeCompletionType.BasicCompletion, false);
            single.EvaluationMode = EvaluationMode.LightAndFull;

            var result = intellisenseManager.GetCompletionResult(single, textControl);

            //var sorting = settingsStore.GetValue((Expression<Func<CodeCompletionSettingsKey, LookupListSorting>>) (key => key.LookupListSorting));
            //FilteredLookupItems filteredItems;
            //var result2 = GetCompletionResult(textControl, intellisenseManager, single, sorting, out filteredItems);

            LookupItems = new List<ILookupItem>(result.LookupItems);

            // ..here
            //var allTexts = LookupItems.Select(li => li.DisplayName.Text);
        }

        protected bool LookupItemExists(string name)
        {
            // access to DisplayName is missing a guard here, but not... (see above)

            // workaround for now:
            var expected = string.Format("{0};", name);
            return LookupItems.Any(x => x.ToString().StartsWith(expected));
        }
    }
}