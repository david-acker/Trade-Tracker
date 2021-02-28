using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TradeTracker.Api.Helpers
{
    public class ArrayModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext context)
        {
            if (!context.ModelMetadata.IsEnumerableType)
            {
                context.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

            var input = context.ValueProvider.GetValue(context.ModelName).ToString();

            if (String.IsNullOrWhiteSpace(input))
            {
                context.Result = ModelBindingResult.Success(null);
                return Task.CompletedTask;
            }

            var elementType = context.ModelType.GetTypeInfo().GenericTypeArguments[0];
            var converter = TypeDescriptor.GetConverter(elementType);

            var values = input
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => converter.ConvertFromString(i.Trim()))
                .ToArray();

            var typedValues = Array.CreateInstance(elementType, values.Length);
            values.CopyTo(typedValues, 0);
            context.Model = typedValues;

            context.Result = ModelBindingResult.Success(context.Model);
            return Task.CompletedTask;


        }
    }
}