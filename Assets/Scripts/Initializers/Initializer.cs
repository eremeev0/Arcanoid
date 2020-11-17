using Assets.Scripts.Initializers.UI;
using Assets.Scripts.Models.UI;

namespace Assets.Scripts.Initializers
{
    public class Initializer
    {
        /// <summary>
        /// All sub ui initializers calling here, using only when game start
        /// <example>
        /// <code>
        ///
        ///     // calling new initializer
        ///     new ExampleUIInitializer(new UIModel());
        /// 
        /// </code>
        /// </example>
        /// </summary>
        public void UIObjectsInitialization()
        {
            new FailedInitializer(new Failed());
            new MenuInitializer(new Menu());
            new ScoreInitializer(new Score());
            new SettingsInitializer(new Settings());
        }

        public void GameObjectsInitialization()
        {

        }

        public void LevelInitialization()
        {

        }
    }
}