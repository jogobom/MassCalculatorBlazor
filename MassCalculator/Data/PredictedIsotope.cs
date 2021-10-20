using System;
using System.Collections.Generic;

namespace MassCalculator.Data
{
    public class PredictedIsotope : IEquatable<PredictedIsotope>, IComparable<PredictedIsotope>, IComparable
    {
        public int CompareTo(PredictedIsotope? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Mass.CompareTo(other.Mass);
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is PredictedIsotope other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(PredictedIsotope)}");
        }

        public static bool operator <(PredictedIsotope? left, PredictedIsotope? right)
        {
            return Comparer<PredictedIsotope>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(PredictedIsotope? left, PredictedIsotope? right)
        {
            return Comparer<PredictedIsotope>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(PredictedIsotope? left, PredictedIsotope? right)
        {
            return Comparer<PredictedIsotope>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(PredictedIsotope? left, PredictedIsotope? right)
        {
            return Comparer<PredictedIsotope>.Default.Compare(left, right) >= 0;
        }

        public bool Equals(PredictedIsotope? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return AlmostEqualUlps(Mass, other.Mass, 2);
        }

        private static bool AlmostEqualUlps(double a, double b, int maxUlpsDiff)
        {
            // Different signs means they do not match.
            if (a < 0 != b < 0)
            {
                // Check for equality to make sure +0==-0
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                return a == b;
            }

            // Find the difference in ULPs.
            var ulpsDiff = Math.Abs(BitConverter.DoubleToInt64Bits(a) - BitConverter.DoubleToInt64Bits(b));
            return ulpsDiff <= maxUlpsDiff;
        }
        
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PredictedIsotope)obj);
        }

        public override int GetHashCode()
        {
            return Mass.GetHashCode();
        }

        public static bool operator ==(PredictedIsotope? left, PredictedIsotope? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PredictedIsotope? left, PredictedIsotope? right)
        {
            return !Equals(left, right);
        }

        public double Mass { get; init; }
        public double Intensity { get; init; }
    }
}