using I2.Loc;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS
{
    internal class GameEventDataModded
    {
        public string name;
        public string format;
        public int unlockPlayCountRequired;
        public int hostEventCost;
        public float baseFee;
        public float marketPriceMinPercent;
        public float marketPriceMaxPercent;
        public string positivePriceChangeType;
        public string negativePriceChangeType;

        public string GetName()
        {
            return LocalizationManager.GetTranslation(name);
        }
    }
}
