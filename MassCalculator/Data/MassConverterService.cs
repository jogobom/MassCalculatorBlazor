using System;
using System.Linq;
using System.Threading.Tasks;

namespace MassCalculator.Data
{
    public class MassConverterService
    {
        private const double ProtonMassAmu = 1.007276467;
        private const double C13MinusC12MassAmu = 1.0033548378;

        public double CalculateMassOverCharge(double neutralMass, int charge, double isotope)
        {
            var isotopeNeutralMass = (neutralMass + C13MinusC12MassAmu * isotope);
            if (charge < 0)
            {
                return isotopeNeutralMass / Math.Abs(charge) - ProtonMassAmu;
            }

            if (charge > 0)
            {
                return isotopeNeutralMass / charge + ProtonMassAmu;
            }

            return isotopeNeutralMass;
        }

        public Task<Compound> GenerateCompoundDetails(double neutralMonoisotopicMass)
        {
            var chargeStatesToBuild = Enumerable.Range(1, 10).ToList();

            return Task.FromResult(new Compound
            {
                NeutralMonoisotopicMass = neutralMonoisotopicMass,
                ChargeStates = chargeStatesToBuild
                    .Select(z => BuildChargeState(neutralMonoisotopicMass, z))
                    .ToList(),
                NegativeChargeStates = chargeStatesToBuild
                    .Select(z => BuildChargeState(neutralMonoisotopicMass, -z))
                    .ToList()
            });
        }

        private ChargeState BuildChargeState(double neutralMonoisotopicMass, int z)
        {
            var isotopesToBuild = Enumerable.Range(0, 10);
            return new ChargeState
            {
                Charge = z,
                Isotopes = isotopesToBuild.Select(a => BuildIsotope(neutralMonoisotopicMass, z, a)).ToList()
            };
        }

        private Isotope BuildIsotope(double neutralMonoisotopicMass, int z, int a)
        {
            return new Isotope
            {
                MassOverCharge = CalculateMassOverCharge(neutralMonoisotopicMass, z, a)
            };
        }
    }
}
