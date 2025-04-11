using UnityEngine;

namespace CodeCatGames.HMModelViewController.Runtime
{
    /// <summary>
    /// Abstract base class for a controller, implementing the IController interface.
    /// </summary>
    /// <typeparam name="TModel">The type of the model. Must implement the IModel interface.</typeparam>
    /// <typeparam name="TSettings">The type of settings associated with the model. Must be a ScriptableObject.</typeparam>
    /// <typeparam name="TView">The type of the view. Must implement the IView interface.</typeparam>
    /// <typeparam name="TMediator">The type of the mediator. Must implement the IMediator interface.</typeparam>
    public abstract class
        Controller<TModel, TSettings, TView, TMediator> : IController<TModel, TSettings, TView, TMediator>
        where TModel : IModel<TSettings>
        where TSettings : ScriptableObject
        where TView : IView
        where TMediator : IMediator<TModel, TSettings, TView>
    {
        #region Getters
        /// <summary>
        /// Gets the model associated with the controller.
        /// </summary>
        public TModel Model { get; }
        
        /// <summary>
        /// Gets the view associated with the controller.
        /// </summary>
        public TView View { get; }
        
        /// <summary>
        /// Gets the mediator associated with the controller.
        /// </summary>
        public TMediator Mediator { get; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the controller with the specified model, view, and mediator.
        /// </summary>
        /// <param name="model">The model associated with the controller.</param>
        /// <param name="view">The view associated with the controller.</param>
        /// <param name="mediator">The mediator associated with the controller.</param>
        public Controller(TModel model, TView view, TMediator mediator)
        {
            Model = model;
            View = view;
            Mediator = mediator;

            mediator.RegisterController(
                this as IController<TModel, TSettings, TView, IMediator<TModel, TSettings, TView>>);
        }
        #endregion

        #region Executes
        /// <summary>
        /// Executes the controller's actions. This method must be implemented in derived classes.
        /// </summary>
        public abstract void Execute();
        #endregion
    }
}