using System;
namespace TechnicalInterview
{
    public struct CardDetails
    {
        public int numericalValue { get; set; }
        public CardFaces faceValue { get; set; }

        public CardDetails(int numericalValue, CardFaces faceValue)
        {
            this.numericalValue = numericalValue;
            this.faceValue = faceValue;
        }
    }
}

