# HMModelViewController
HMModelViewController provides a Model-View-Controller (MVC) architecture for Unity and applies the Mediator pattern to ensure that View classes only handle visual functions. It offers a modular structure through generic interfaces, enhancing code maintainability and flexibility.

## Features
HMModelViewController includes the following key features:
* MVC Architecture: Provides a clear separation of concerns with Model, View, and Controller layers.
* Mediator Pattern: Ensures that View classes focus on visual functionality only by delegating communication to a Mediator.
* Modular Design: Uses generic interfaces for easy extendability and reusability.

## Getting Started
Install via UPM with git URL

`https://github.com/Emre-Emiroglu/HMModelViewController.git`

Clone the repository
```bash
git clone https://github.com/Emre-Emiroglu/HMModelViewController.git
```
This project is developed using Unity version 6000.0.42f1.

## Usage
* Model: Create a model class that holds data.
    ```csharp
    public class MySettings { }
    
    public class MyModel : Model<MySettings>
    {
        public MyModel(MySettings settings) : base(settings) { }
        
        public override void LoadData() { }
        public override void SaveData() { }
    }
    ```

* View: Implement a view that will display the data.
    ```csharp
    public class MyView : View
    {
        public override void Show()
        {
             base.Show();
        }
        
        public override void Hide()
        {
             base.Hide();
        }
    }
    ```

* Mediator: The mediator ensures that the view and model do not directly communicate.
    ```csharp
    public class MyMediator : Mediator<MyModel, MySettings, MyView>
    {
        public MyMediator(MyModel model, MyView view) : base(model, view) { }
        
        public override void SetSubscriptions(bool isSubscribed) { }
    }
    ```

* Controller: Implement a controller to manage the flow between the model and view and execute an algorithm.
    ```csharp
    private class MyControllerOne : Controller<MyModel, MySettings, MyView, MyMediator>
    {
        public MyControllerOne(MyModel model, MyView view, MyMediator mediator) : base(model, view, mediator) { }
        
        public override void Execute() { }
    }
    
    private class MyControllerTwo : Controller<MyModel, MySettings, MyView, MyMediator>
    {
        public MyControllerTwo(MyModel model, MyView view, MyMediator mediator) : base(model, view, mediator) { }
        
        public override void Execute() { }
    }
    ```

* Generic interfaces: Model, view, mediator, and controller classes inherit generic interfaces written for them.
    ```csharp
    public interface IModel<out TSettings> where TSettings : class
    {
        public TSettings Settings { get; }
        
        public void LoadData();
        
        public void SaveData();
    }
    
    public interface IView
    {
        public void Show();
        
        public void Hide();
    }
    
    public interface IMediator<TModel, TSettings, TView>
        where TModel : IModel<TSettings>
        where TSettings : class
        where TView : IView
    {
        public List<IController<TModel, TSettings, TView, IMediator<TModel, TSettings, TView>>> Controllers { get; }
        
        public TModel Model { get; }
         
        public TView View { get; }
         
        public void Initialize();
        
        public void Dispose();
        
        public void SetSubscriptions(bool isSubscribed);
        
        public void RegisterController(IController<TModel, TSettings, TView, IMediator<TModel, TSettings, TView>> controller);
    }
    
    public interface IController<out TModel, TSettings, out TView, out TMediator>
        where TModel : IModel<TSettings>
        where TSettings : class
        where TView : IView
        where TMediator : IMediator<TModel, TSettings, TView>
    {
        public TModel Model { get; }
        
        public TView View { get; }
        
        public TMediator Mediator { get; }
        
        public void Execute();
    }
    ```

## Acknowledgments
Special thanks to the Unity community for their invaluable resources and tools.

For more information, visit the GitHub repository.
