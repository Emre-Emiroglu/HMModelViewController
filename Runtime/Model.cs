using UnityEngine;

namespace CodeCatGames.HMModelViewController.Runtime
{
    /// <summary>
    /// Abstract base class for a model, implementing the IModel interface.
    /// </summary>
    /// <typeparam name="TSettings">The type of settings associated with the model. Must be a ScriptableObject.</typeparam>
    public abstract class Model<TSettings> : IModel<TSettings> where TSettings : ScriptableObject
    {
        #region Getters
        /// <summary>
        /// Gets the settings associated with the model.
        /// </summary>
        public TSettings Settings { get; }
        #endregion
        
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the model with a specified resource path for settings.
        /// </summary>
        /// <param name="resourcePath">The path to the resource that contains the model's settings.</param>
        public Model(string resourcePath)
        {
            if (resourcePath == string.Empty)
            {
                Debug.Log("Resource path can not be null for getting model settings!");
                return;
            }

            Settings = Resources.Load<TSettings>(resourcePath);
        }
        #endregion
        
        #region Executes
        /// <summary>
        /// Loads the model's data. This method must be implemented in derived classes.
        /// </summary>
        public abstract void LoadData();
        
        /// <summary>
        /// Saves the model's data. This method must be implemented in derived classes.
        /// </summary>
        public abstract void SaveData();
        #endregion
    }
}