using UnityEngine;

namespace CodeCatGames.HMModelViewController.Runtime
{
    /// <summary>
    /// Represents a controller interface responsible for executing actions with the model, view, and mediator.
    /// </summary>
    /// <typeparam name="TModel">The type of the model. Must implement the IModel interface.</typeparam>
    /// <typeparam name="TSettings">The type of settings associated with the model. Must be a ScriptableObject.</typeparam>
    /// <typeparam name="TView">The type of the view. Must implement the IView interface.</typeparam>
    /// <typeparam name="TMediator">The type of the mediator. Must implement the IMediator interface.</typeparam>
    public interface IController<out TModel, TSettings, out TView, out TMediator>
        where TModel : IModel<TSettings>
        where TSettings : ScriptableObject
        where TView : IView
        where TMediator : IMediator<TModel, TSettings, TView>
    {
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
        
        /// <summary>
        /// Executes the controller's actions.
        /// </summary>
        public void Execute();
    }
}