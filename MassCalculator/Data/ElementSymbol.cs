using System;
using System.Collections.Generic;

namespace MassCalculator.Data
{
    public class ElementSymbol : IEquatable<ElementSymbol>, IComparable<ElementSymbol>, IComparable
    {
        public ElementSymbol(string label)
        {
            Label = label;
        }

        public string Label { get; }

        public int CompareTo(ElementSymbol? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return string.Compare(Label, other.Label, StringComparison.Ordinal);
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is ElementSymbol other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(ElementSymbol)}");
        }

        public static bool operator <(ElementSymbol left, ElementSymbol right)
        {
            return Comparer<ElementSymbol>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(ElementSymbol left, ElementSymbol right)
        {
            return Comparer<ElementSymbol>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(ElementSymbol left, ElementSymbol right)
        {
            return Comparer<ElementSymbol>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(ElementSymbol left, ElementSymbol right)
        {
            return Comparer<ElementSymbol>.Default.Compare(left, right) >= 0;
        }

        public bool Equals(ElementSymbol? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Label == other.Label;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ElementSymbol)obj);
        }

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }

        public static bool operator ==(ElementSymbol left, ElementSymbol right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ElementSymbol left, ElementSymbol right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return Label;
        }
    }
}