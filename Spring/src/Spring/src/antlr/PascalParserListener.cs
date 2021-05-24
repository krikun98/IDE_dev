//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from PascalParser.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="PascalParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IPascalParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] PascalParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] PascalParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCompoundStatement([NotNull] PascalParser.CompoundStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.compoundStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCompoundStatement([NotNull] PascalParser.CompoundStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] PascalParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] PascalParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBody([NotNull] PascalParser.BodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBody([NotNull] PascalParser.BodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.simpleStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleStatement([NotNull] PascalParser.SimpleStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.simpleStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleStatement([NotNull] PascalParser.SimpleStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.assigmnentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssigmnentStatement([NotNull] PascalParser.AssigmnentStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.assigmnentStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssigmnentStatement([NotNull] PascalParser.AssigmnentStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] PascalParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] PascalParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.procedureStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProcedureStatement([NotNull] PascalParser.ProcedureStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.procedureStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProcedureStatement([NotNull] PascalParser.ProcedureStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.gotoStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGotoStatement([NotNull] PascalParser.GotoStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.gotoStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGotoStatement([NotNull] PascalParser.GotoStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabel([NotNull] PascalParser.LabelContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.label"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabel([NotNull] PascalParser.LabelContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.structuredStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStructuredStatement([NotNull] PascalParser.StructuredStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.structuredStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStructuredStatement([NotNull] PascalParser.StructuredStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.conditionalStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConditionalStatement([NotNull] PascalParser.ConditionalStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.conditionalStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConditionalStatement([NotNull] PascalParser.ConditionalStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.repetitiveStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepetitiveStatement([NotNull] PascalParser.RepetitiveStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.repetitiveStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepetitiveStatement([NotNull] PascalParser.RepetitiveStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.caseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCaseStatement([NotNull] PascalParser.CaseStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.caseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCaseStatement([NotNull] PascalParser.CaseStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.case"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCase([NotNull] PascalParser.CaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.case"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCase([NotNull] PascalParser.CaseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.caseRange"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCaseRange([NotNull] PascalParser.CaseRangeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.caseRange"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCaseRange([NotNull] PascalParser.CaseRangeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConstant([NotNull] PascalParser.ConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConstant([NotNull] PascalParser.ConstantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.elsePart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElsePart([NotNull] PascalParser.ElsePartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.elsePart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElsePart([NotNull] PascalParser.ElsePartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] PascalParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] PascalParser.IfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForStatement([NotNull] PascalParser.ForStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForStatement([NotNull] PascalParser.ForStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.repeatStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeatStatement([NotNull] PascalParser.RepeatStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.repeatStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeatStatement([NotNull] PascalParser.RepeatStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileStatement([NotNull] PascalParser.WhileStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileStatement([NotNull] PascalParser.WhileStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.withStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWithStatement([NotNull] PascalParser.WithStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.withStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWithStatement([NotNull] PascalParser.WithStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] PascalParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] PascalParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.simpleExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleExpression([NotNull] PascalParser.SimpleExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.simpleExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleExpression([NotNull] PascalParser.SimpleExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerm([NotNull] PascalParser.TermContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerm([NotNull] PascalParser.TermContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFactor([NotNull] PascalParser.FactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFactor([NotNull] PascalParser.FactorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCall([NotNull] PascalParser.FunctionCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCall([NotNull] PascalParser.FunctionCallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.actualParameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterActualParameterList([NotNull] PascalParser.ActualParameterListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.actualParameterList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitActualParameterList([NotNull] PascalParser.ActualParameterListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.unsignedConstant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnsignedConstant([NotNull] PascalParser.UnsignedConstantContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.unsignedConstant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnsignedConstant([NotNull] PascalParser.UnsignedConstantContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.setConstructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSetConstructor([NotNull] PascalParser.SetConstructorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.setConstructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSetConstructor([NotNull] PascalParser.SetConstructorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.setGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSetGroup([NotNull] PascalParser.SetGroupContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.setGroup"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSetGroup([NotNull] PascalParser.SetGroupContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.valueTypecast"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValueTypecast([NotNull] PascalParser.ValueTypecastContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.valueTypecast"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValueTypecast([NotNull] PascalParser.ValueTypecastContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="PascalParser.addressFactor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAddressFactor([NotNull] PascalParser.AddressFactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="PascalParser.addressFactor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAddressFactor([NotNull] PascalParser.AddressFactorContext context);
}
