﻿//  
//  Copyright 2017 Gustavo J Knuppe (https://github.com/knuppe)
//  
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//  
//       http://www.apache.org/licenses/LICENSE-2.0
//  
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//  
//   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//   - May you do good and not evil.                                         -
//   - May you find forgiveness for yourself and forgive others.             -
//   - May you share freely, never taking more than you give.                -
//   - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
//   

using NUnit.Framework;

namespace SharpNL.Tests.LangDetect {
    using SharpNL.LangDetect;
    using SharpNL.Utility;

    [TestFixture]
    public class LanguageDetectorCrossValidatorTest {
        [Test]
        public void EvaluateTest() {

            var parameters = new TrainingParameters();
            parameters.Set(Parameters.Iterations, "100");
            parameters.Set(Parameters.Cutoff, "5");
            
            var cv = new LanguageDetectorCrossValidator(parameters, new LanguageDetectorFactory());
            var sampleStream = LanguageDetectorMETest.CreateSampleStream();

            cv.Evaluate(sampleStream, 2);

            Assert.AreEqual(99, cv.DocumentCount);
            Assert.AreEqual(0.98989898989899, cv.DocumentAccuracy, 0.01);

        }
    }
}
