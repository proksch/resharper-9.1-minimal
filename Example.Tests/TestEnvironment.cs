﻿/*
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

using System;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[ZoneDefinition]
// ReSharper disable once CheckNamespace
public interface IExampleTestZone : ITestsZone, IRequire<PsiFeatureTestZone>
{
}

[SetUpFixture]
public class TestEnvironmentAssembly : ExtensionTestEnvironmentAssembly<IExampleTestZone>
{
    public override void TearDown()
    {
        try
        {
            base.TearDown();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}