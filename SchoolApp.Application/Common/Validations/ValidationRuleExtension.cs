namespace SchoolApp.Application.Common.Validations;

public static class ValidationruleExtension
{
    public static IRuleBuilderOptions<T, TProperty> ApplyNotEmptyrule<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.NotEmpty().WithMessage("Required! {PropertyName} cannot be empty");
    }

    public static IRuleBuilderOptions<T, TProperty> ApplyNotNullablerule<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.NotNull().WithMessage("Required! {PropertyName} cannot be null");
    }

    public static IRuleBuilderOptions<T, string> ApplyMinLengthrule<T>(this IRuleBuilder<T, string> ruleBuilder, int MinLength)
    {
        return ruleBuilder.MinimumLength(MinLength).WithMessage("{PropertyName}" + $" must be at least {MinLength} characters");
    }

    public static IRuleBuilderOptions<T, string> ApplyMaxLengthrule<T>(this IRuleBuilder<T, string> ruleBuilder, int MaxLength)
    {
        return ruleBuilder.MaximumLength(MaxLength).WithMessage("{PropertyName}" + $" must be less than or equal {MaxLength} characters");
    }

    public static IRuleBuilderOptions<T, string> ApplyCommonStringrules<T>(this IRuleBuilder<T, string> ruleBuilder, int MinLength, int MaxLength)
    {
        return ruleBuilder.ApplyNotEmptyrule().ApplyNotNullablerule().ApplyMinLengthrule(MinLength).ApplyMaxLengthrule(MaxLength);
    }
}
