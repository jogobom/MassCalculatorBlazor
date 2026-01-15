using System.Linq;
using System.Threading.Tasks;

namespace MassCalculator.Data
{
    public class MassConverterService
    {
        public static Task<double> CalculateNeutralMass(double massOverCharge, int charge)
        {
            return Task.FromResult(MassConverter.CalculateNeutralMass(massOverCharge, charge, 0));
        }

        public Task<Compound> GenerateCompoundDetails(double neutralMinimumIsotopeMass)
        {
            return GenerateCompoundDetails(new Mass { MinimumIsotopeMass = neutralMinimumIsotopeMass });
        }
        public Task<Compound> GenerateCompoundDetails(Mass mass)
        {
            var chargeStatesToBuild = Enumerable.Range(1, 20).ToList();

            return Task.FromResult(new Compound
            {
                NeutralMass = mass,
                ChargeStates = chargeStatesToBuild
                    .Select(z => BuildTheoreticalChargeState(mass, z))
                    .ToList(),
                NegativeChargeStates = chargeStatesToBuild
                    .Select(z => BuildTheoreticalChargeState(mass, -z))
                    .ToList()
            });
        }

        private ChargeState BuildTheoreticalChargeState(Mass mass, int z)
        {
            var isotopesToBuild = Enumerable.Range(0, 10);
            return new ChargeState
            {
                Charge = z,
                MassOverChargeRatio = MassConverter.CalculateMassOverCharge(mass, z),
                Isotopes = isotopesToBuild.Select(a => BuildTheoreticalIsotope(mass, z, a)).ToList()
            };
        }

        private static PredictedIsotopeAtCharge BuildTheoreticalIsotope(Mass mass, int z, int a)
        {
            return new PredictedIsotopeAtCharge
            {
                MassOverCharge = MassConverter.CalculateMassOverCharge(mass.MinimumIsotopeMass, z, a),
            };
        }
    }
}
