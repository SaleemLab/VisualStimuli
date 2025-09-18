import json
from pathlib import Path
from typing import Annotated, Literal, Union, List
from pydantic import BaseModel, Field, RootModel
import os

class VisualBase(BaseModel):
    visual_type: str

class Gratings(VisualBase):
    visual_type: Literal["gratings"]
    temporal_frequency: float = Field(default=1.0)

class CheckerBoard(VisualBase):
    visual_type: Literal["checkerboard"]
    n_rows: float = Field(default=1.0)
    n_columns: float = Field(default=1.0)

class VisualStimulus(BaseModel):
    alias: str # The Bonsai name for this stimulus
    stimulus: Annotated[Union[Gratings, CheckerBoard], Field(discriminator="visual_type")]

class LogicBase(BaseModel):
    logic_type: str

class Timer(LogicBase):
    logic_type: Literal["timer"]
    due_time: float = Field(default=1.0)

class KeyPress(LogicBase):
    logic_type: Literal["keypress"]
    key_code: int = Field(default=13)

class WaitForTrigger(LogicBase):
    logic_type: Literal["waitfortrigger"]
    trigger_name: str

class LogicTransition(BaseModel):
    alias: str # The Bonsai name for this transition
    transition: Annotated[Union[Timer, KeyPress, WaitForTrigger], Field(discriminator="logic_type")]

class State(BaseModel):
    alias: str
    visual: VisualStimulus
    logic: LogicTransition
    transitions_to: str

class StateMachine(BaseModel):
    state_definitions: List[State]

if __name__ == "__main__":
    schema = StateMachine.model_json_schema()
    Path("Schemas\state-machine.json").write_text(json.dumps(schema, indent=2))
    os.system("dotnet bonsai.sgen ""Schemas\state-machine.json"" -o Workflows\Extensions --serializer yaml")