## [1.0.1] - 2025-04-18

### Added
- Support for parameterized controller execution via `params object[] parameters` in `IController` and `Controller` base class.
- Detailed XML summary comments for the new parameterized `Execute` method.

### Changed
- Controller classes no longer depend on the `Mediator`. They are now completely decoupled from other architectural components (including View and Settings), improving modularity and reusability.
- The `IController` and `Controller` interfaces and classes have been simplified to remove unnecessary constructor dependencies.
- `README.md` updated with simplified examples reflecting the new decoupled structure.

### Removed
- The `Controllers` list and `RegisterController` method have been removed from the `IMediator` interface and its implementations.
    - Mediators are no longer responsible for holding or managing controller references.
    - Signal-to-controller binding is now left to the developer or to an external system (e.g., SignalBus or event managers).
- Mediator-Controller coupling logic eliminated to reinforce separation of concerns.

### Fixed
- N/A