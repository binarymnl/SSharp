﻿namespace Scripting.SSharp.Execution.Compilers
{
  using Dom;
  using VM;
  using VM.Operations;

  [CompilerType(typeof(CodeProgram))]
  internal class CodeProgramCompiler : IVMCompiler
  {
    #region IVMCompiler Members

    public ExecutableMachine Compile(CodeObject code, ExecutableMachine machine)
    {
      var program = (CodeProgram)code;

      foreach (var statement in program.Statements)
        CodeDomCompiler.Compile(statement, machine);
      
      machine.CreateOperation<RetOperation>();

      //TODO: Functions
      //foreach (CodeObject function in program.Functions)
      //  Compile(function, machine);

      return machine;
    }

    #endregion
  }
}