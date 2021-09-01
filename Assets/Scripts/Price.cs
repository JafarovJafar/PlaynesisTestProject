namespace Game.Shop
{
    public struct Price
    {
        private Currency _currency;
        private float _amount;

        public Currency Currency => _currency;
        public float Amount => _amount;

        public Price(Currency currency, float amount)
        {
            _currency = currency;
            _amount = amount;
        }
    }
}