using UnityEngine;

namespace TestTask
{
    public class MainController : BaseController
    {
        
        private readonly ProfilePlayer profile;
        private readonly RectangleFactory factory;
        private readonly Transform canvas;
        private readonly Descriptions descriptions;
        private readonly PrefabsManager prefabsManager;
        private readonly UpdateController updateController;

        private MainMenuController _mainMenuController;
        private GameController _gameController;

        // private LoadingController _loadingController;
        
        public MainController(Descriptions descriptions, Transform canvas, UpdateController updateController)
        {
            this.descriptions = descriptions;
            this.canvas = canvas;
            this.updateController = updateController;

            prefabsManager = new PrefabsManager(descriptions);
            
            profile = new ProfilePlayer();
            profile.CurrentState.SubscribeOnChange(OnChangeGameState);
            profile.CurrentState.Value = GameState.Menu;
        }
        
        protected override void OnDispose()
        {
            
            base.OnDispose();
        }

        public void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Menu:
                    _mainMenuController = new MainMenuController(canvas, profile);
                    break;
                case GameState.Game:
                    _gameController = new GameController(descriptions, profile, prefabsManager, updateController);
                    _mainMenuController?.Dispose();
                    break;
                default:
                    break;
            }
        }
    }

    
    
    //todo вынести в отдельный файл
    public enum GameState
    {
        None,
        Menu,
        Game,
    }
}