using Core.Configs;
using Utils;

namespace Gameplay
{
    public class PlayerModel
    {
        public Observable<int> Coins { get; } = new(0);


        public PlayerModel(LevelSelectModuleConfig levelSelectModuleConfig)
        {
            Coins.Value = levelSelectModuleConfig.StartCoins;
        }


        public void ModifyCoins(int amount)
        {
            Coins.Value += amount;
        }
    }
}
