namespace MassCalculator.Store.ChargedToNeutral
{
    public class SetChargeAction
    {
        public int? Charge { get; }

        public SetChargeAction(int? charge) => Charge = charge;
    }
}