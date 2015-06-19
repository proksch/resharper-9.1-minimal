using System;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.FeaturesTestFramework.Completion;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework.Projects;
using NUnit.Framework;

namespace Example.Completion
{
    [TestNetFramework4]
    internal class SomeTest : CodeCompletionTestBase
    {
        protected override CodeCompletionTestType TestType
        {
            get { return CodeCompletionTestType.List; }
        }

        [Test]
        public void DoSomeTest()
        {
            DoOneTest("blubb");
        }
    }
}