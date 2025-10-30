Mini Simulation TP2 – Unity Learning Activity Template

This repository contains a minimal, reusable Unity template for an interactive learning activity with scenario flow, measurable interaction, scoring, and simple logging.

Structure

Assets/
  Scenes/
  Scripts/
    Core/
      ScenarioManager.cs
      ScoreManager.cs
      ActionLogger.cs
    UI/
      UIController.cs
    Activities/
      ElectricCircuit/
        Draggable.cs
        SnapPoint.cs
        CircuitValidator.cs

Quick Setup (Unity 2021.3+)
- Create a new Unity project. Copy `Assets/Scripts` into it. Create `Assets/Scenes/MinimalLearning.unity`.
- Add Canvas texts: `ConsignesText`, `FeedbackText`, `ScoreText`; buttons: `NextStepButton`, `ValidateButton`; add `UIController` and assign.
- Add `ScenarioManager`, `ScoreManager`, `ActionLogger` to a `Managers` GameObject; wire references.
- For the electric circuit example, add `Draggable` to wire ends; add `SnapPoint` to battery plus and bulb terminals; add `CircuitValidator` and assign fields; set as `externalValidator` on `ScenarioManager`.
- Play: use `Validate` per step. Logs are written to `Application.persistentDataPath`.



"# Conception-d-une-sc-ne-Unity-interactive-vis-e-didactique" 
"# Conception-d-une-sc-ne-Unity-interactive-vis-e-didactique" 
