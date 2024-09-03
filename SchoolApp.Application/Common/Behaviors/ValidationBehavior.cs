using SchoolApp.Application.Common.Resoruces;

namespace SchoolApp.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
   where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IStringLocalizer<SharedResoruces> _localizer;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IStringLocalizer<SharedResoruces> localizer)
    {
        _validators = validators;
        _localizer = localizer;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failrues = validationResults
                            .SelectMany(r => r.Errors)
                            .Where(f => f != null).ToList();

        if (failrues.Count != 0)
        {
            var message = failrues
                             .Select(x => $"{_localizer[x.ErrorMessage]} : {_localizer[SharedResorucesKeys.NotEmpty]}")
                             .FirstOrDefault();
            throw new FluentValidation.ValidationException(message);
        }

        return await next();
    }
}
