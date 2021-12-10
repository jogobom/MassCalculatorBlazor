using System.Linq;
using System.Threading.Tasks;

namespace MassCalculator.Data
{
    public class MassConverterService
    {
        public Task<double> CalculateNeutralMass(double massOverCharge, int charge)
        {
            return Task.FromResult(MassConverter.CalculateNeutralMass(massOverCharge, charge, 0));
        }

        public Task<Compound> GenerateCompoundDetails(double neutralMonoisotopicMass)
        {
            var chargeStatesToBuild = Enumerable.Range(1, 10).ToList();

            return Task.FromResult(new Compound
            {
                NeutralMonoisotopicMass = neutralMonoisotopicMass,
                ChargeStates = chargeStatesToBuild
                    .Select(z => BuildTheoreticalChargeState(neutralMonoisotopicMass, z))
                    .ToList(),
                NegativeChargeStates = chargeStatesToBuild
                    .Select(z => BuildTheoreticalChargeState(neutralMonoisotopicMass, -z))
                    .ToList()
            });
        }

        private ChargeState BuildTheoreticalChargeState(double neutralMonoisotopicMass, int z)
        {
            var isotopesToBuild = Enumerable.Range(0, 10);
            return new ChargeState
            {
                Charge = z,
                Isotopes = isotopesToBuild.Select(a => BuildTheoreticalIsotope(neutralMonoisotopicMass, z, a)).ToList()
            };
        }

        private PredictedIsotopeAtCharge BuildTheoreticalIsotope(double neutralMonoisotopicMass, int z, int a)
        {
            return new PredictedIsotopeAtCharge
            {
                MassOverCharge = MassConverter.CalculateMassOverCharge(neutralMonoisotopicMass, z, a),
            };
        }
    }
}
