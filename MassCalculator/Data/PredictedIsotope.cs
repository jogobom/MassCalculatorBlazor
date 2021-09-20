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
            return Mass.Equals(other.Mass);
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
    }
}