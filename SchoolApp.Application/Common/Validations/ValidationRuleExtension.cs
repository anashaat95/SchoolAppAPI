﻿namespace SchoolApp.Application.Common.Validations;

public static class ValidationruleExtension
{
    public static IRuleBuilderOptions<T, TProperty> ApplyNotEmptyRule<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().WithMessage("Required! {PropertyName} cannot be empty");
    }

    public static IRuleBuilderOptions<T, TProperty> ApplyNotNullableRule<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.NotNull().WithMessage("Required! {PropertyName} cannot be null");
    }

    public static IRuleBuilderOptions<T, string> ApplyMinLengthRule<T>(this IRuleBuilder<T, string> ruleBuilder, int MinLength)
    {
        return ruleBuilder.MinimumLength(MinLength).WithMessage("{PropertyName}" + $" must be at least {MinLength} characters");
    }

    public static IRuleBuilderOptions<T, string> ApplyMaxLengthRule<T>(this IRuleBuilder<T, string> ruleBuilder, int MaxLength)
    {
        return ruleBuilder.MaximumLength(MaxLength).WithMessage("{PropertyName}" + $" must be less than or equal {MaxLength} characters");
    }

    public static IRuleBuilderOptions<T, string> ApplyCommonStringRules<T>(this IRuleBuilder<T, string> ruleBuilder, int MinLength, int MaxLength)
    {
        return ruleBuilder.ApplyNotEmptyRule().ApplyNotNullableRule().ApplyMinLengthRule(MinLength).ApplyMaxLengthRule(MaxLength);
    }
}
