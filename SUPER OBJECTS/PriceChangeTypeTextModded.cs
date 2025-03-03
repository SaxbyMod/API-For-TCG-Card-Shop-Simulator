using I2.Loc;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS
{
    internal class PriceChangeTypeTextModded
    {
        public string name;
        public string priceChangeType;
        public string GetName(bool isIncrease)
        {
            string translation = LocalizationManager.GetTranslation("decrease");

            if (isIncrease)
            {
                translation = LocalizationManager.GetTranslation("increase");
            }

            return LocalizationManager.GetTranslation(name).Replace("XXX", translation);
        }
    }
}
