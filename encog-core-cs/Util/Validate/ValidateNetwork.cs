//
// Encog(tm) Core v3.0 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2011 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
using Encog.ML;
using Encog.ML.Data;

namespace Encog.Util.Validate
{
    /// <summary>
    /// Perform validations on a network.
    /// </summary>
    public class ValidateNetwork
    {
        /// <summary>
        /// Validate that the specified data can be used with the method.
        /// </summary>
        /// <param name="method">The method to validate.</param>
        /// <param name="training">The training data.</param>
        public static void ValidateMethodToData(MLMethod method, MLDataSet training)
        {
            if (!(method is MLInput) || !(method is MLOutput))
            {
                throw new EncogError(
                    "This machine learning method is not compatible with the provided data.");
            }

            int trainingInputCount = training.InputSize;
            int trainingOutputCount = training.IdealSize;
            int methodInputCount = 0;
            int methodOutputCount = 0;

            if (method is MLInput)
            {
                methodInputCount = ((MLInput) method).InputCount;
            }

            if (method is MLOutput)
            {
                methodOutputCount = ((MLOutput) method).OutputCount;
            }

            if (methodInputCount != trainingInputCount)
            {
                throw new EncogError(
                    "The machine learning method has an input length of "
                    + methodInputCount + ", but the training data has "
                    + trainingInputCount + ". They must be the same.");
            }

            if (trainingOutputCount > 0 && methodOutputCount != trainingOutputCount)
            {
                throw new EncogError(
                    "The machine learning method has an output length of "
                    + methodOutputCount
                    + ", but the training data has "
                    + trainingOutputCount + ". They must be the same.");
            }
        }
    }
}