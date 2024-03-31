﻿using NSwag.Generation.Processors.Security;

namespace Todo.API.Infrastructures;

public static class NSwag
{
    public static void NSwagConfigSetting(this IServiceCollection services, IHostEnvironment env)
    {
        services.AddOpenApiDocument(
        (settings, provider) =>
        {

            settings.Title = $"Todo API ({env.EnvironmentName})";
            settings.Version = "v1";

            // 這個 OpenApiSecurityScheme 物件請勿加上 Name 與 In 屬性，否則產生出來的 OpenAPI Spec 格式會有錯誤！
            var apiScheme = new OpenApiSecurityScheme()
            {
                Type = OpenApiSecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT", // for documentation purposes (OpenAPI only)
                Description = "Copy JWT Token into the value field: {token}"
            };

            // 這裡會同時註冊 SecurityDefinition (.components.securitySchemes) 與 SecurityRequirement (.security)
            settings.AddSecurity("Bearer", Enumerable.Empty<string>(), apiScheme);

            // 這段是為了將 "Bearer" 加入到 OpenAPI Spec 裡 Operator 的 security (Security requirements) 中
            settings.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor());
        });


    }
}
