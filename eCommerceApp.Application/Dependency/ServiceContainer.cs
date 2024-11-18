﻿using eCommerceApp.Application.Mapping;
using eCommerceApp.Application.Services.Implementations;
using eCommerceApp.Application.Services.Interfaces;
using eCommerceApp.Application.Validations;
using eCommerceApp.Application.Validations.Authentication;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceApp.Application.Dependency
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddScoped<IValidationService, ValidationService>();
            return services;
        }
    }
}
