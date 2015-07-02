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

using JetBrains.ReSharper.FeaturesTestFramework.Completion;
using NUnit.Framework;

namespace Example.Tests.Completion
{
    internal class ContextAnalysisTest : BaseCodeCompletionTest
    {
        protected override CodeCompletionTestType TestType
        {
            get { return CodeCompletionTestType.List; }
        }

        [Test]
        public void TestSomething()
        {
            DoAutoCompletion(@"
            namespace N
            {
                interface I
                {
                    void M(int i);
                }

                abstract class C1 : I
                {
                    public virtual void M(int i) { }
                }

                class C2 : C1
                {
                    public override void M(int i)
                    {
                        {caret}
                    }
                }
            }");

            Assert.AreEqual(64, LookupItems.Count);
            Assert.IsTrue(LookupItemExists("i"));
            Assert.IsFalse(LookupItemExists("C"));
        }

        [Test]
        public void TestSomethingElse()
        {
            DoAutoCompletion(@"
            using System;
            using System.Collections.Generic;
            using System.IO;
                
            namespace N 
            {
                public class C 
                { 
                    public void M(int param)
                    {
                        par{caret}
                    }
                }
            }");

            Assert.IsTrue(LookupItemExists("param"));
            Assert.IsFalse(LookupItemExists("C1"));
        }
    }
}