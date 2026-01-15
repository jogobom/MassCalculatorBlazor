using System;

namespace MassCalculator.Data
{
    public static class MassConverter
    {
        private const double ProtonMassAmu = 1.007276467;
        private const double C13MinusC12MassAmu = 1.0033548378;

        public static double CalculateMassOverCharge(double minimumIsotopeNeutralMass, int charge, double isotope)
        {
            var isotopeNeutralMass = minimumIsotopeNeutralMass + C13MinusC12MassAmu * isotope;
            return charge switch
            {
                < 0 => isotopeNeutralMass / Math.Abs(charge) - ProtonMassAmu,
                > 0 => isotopeNeutralMass / charge + ProtonMassAmu,
                _ => isotopeNeutralMass
            };
        }
        
        public static Mass CalculateMassOverCharge(Mass neutralMass, int charge)
        {
            return charge switch
            {
                < 0 => new Mass
                {
                    Monoisotopic = neutralMass.Monoisotopic / Math.Abs(charge) - ProtonMassAmu,
                    MinimumIsotopeMass = neutralMass.MinimumIsotopeMass / Math.Abs(charge) - ProtonMassAmu,
                    Average = neutralMass.Average / Math.Abs(charge) - ProtonMassAmu
                },
                > 0 => new Mass
                {
                    Monoisotopic = neutralMass.Monoisotopic / charge + ProtonMassAmu,
                    MinimumIsotopeMass = neutralMass.MinimumIsotopeMass / charge + ProtonMassAmu,
                    Average = neutralMass.Average / charge + ProtonMassAmu
                },
                _ => neutralMass
            };
        }

        public static double CalculateNeutralMass(double massOverCharge, int charge, double isotope)
        {
            return charge switch
            {
                < 0 => (massOverCharge + ProtonMassAmu) * Math.Abs(charge),
                > 0 => (massOverCharge - ProtonMassAmu) * charge,
                _ => 0.0
            } + C13MinusC12MassAmu * isotope;
        }
    }
}